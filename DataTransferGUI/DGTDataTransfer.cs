using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;

namespace DataTransferGUI
{
    public class DGTDataTransfer
    {

        private Server sourceServer;
        private String sourceDatabaseName;
        private Database sourceDatabase;

        private Server targetServer;
        private String targetDatabaseName;
        private Database targetDatabase;

        private List<ForeignKey> disabledForeignKeys;

        public DGTDataTransfer(Server sourceServer, String sourceDatabaseName, Server targetServer, String targetDatabaseName)
        {
            this.sourceServer = sourceServer;
            this.targetServer = targetServer;

            this.sourceDatabaseName = sourceDatabaseName;
            this.targetDatabaseName = targetDatabaseName;

            this.sourceDatabase = sourceServer.Databases[sourceDatabaseName];
            this.targetDatabase = targetServer.Databases[targetDatabaseName];

            this.disabledForeignKeys = new List<ForeignKey>();
        }

        public String GetSqlSampleCopy(Table sourceTable, uint percent)
        {
            // Comma seperated columns (except computed) for the FK table
            String referencedColumns = sourceTable.Columns.Cast<Column>()
                .Where(c1 => c1.Computed == false)
                .Select(c0 => String.Format("[{0}].[{1}].[{2}]", sourceTable.Schema, sourceTable.Name, c0.Name))
                .Aggregate((current, next) => current + ", " + next);

            String referencedColumnsJoined = String.Join("\n\t, ", referencedColumns);
            return String.Format(@"
SELECT {0} 
FROM [{1}].[{2}] TABLESAMPLE({3} PERCENT)
;", referencedColumnsJoined, sourceTable.Schema, sourceTable.Name, percent);
        }

        public String GetSqlTopNCopy(Table sourceTable, uint percent)
        {
            // Comma seperated columns (except computed) for the FK table
            String referencedColumns = sourceTable.Columns.Cast<Column>()
                .Where(c1 => c1.Computed == false)
                .Select(c0 => String.Format("[{0}].[{1}].[{2}]", sourceTable.Schema, sourceTable.Name, c0.Name))
                .Aggregate((current, next) => current + ", " + next);

            String referencedColumnsJoined = String.Join("\n\t, ", referencedColumns);

            if (percent < 100)
            {
                return String.Format("SELECT TOP {2} PERCENT {3} FROM [{0}].[{1}] ORDER BY NEWID();", sourceTable.Schema, sourceTable.Name, percent, referencedColumnsJoined);
            }
            else
            {
                // No need to ORDER BY if 100%
                return String.Format("SELECT TOP {2} PERCENT {3} FROM [{0}].[{1}];", sourceTable.Schema, sourceTable.Name, percent, referencedColumnsJoined);
            }
        }

        /// <summary>
        /// Copy just the rows needed to support the FK that aren't already there.
        /// ONLY works for targetServer = ( sourceServer OR Linked Server)
        /// </summary>
        /// <param name="fk"></param>
        /// <returns></returns>
        public string GetSqlCopyDataMissingKeys(ForeignKey fk)
        {
            /*

            SELECT src.[AddressID], src.[AddressLine1], src.[AddressLine2], src.[City], src.[StateProvinceID], src.[PostalCode], src.[SpatialLocation], src.[rowguid], src.[ModifiedDate] 
            FROM [.\SQL2012].[AdventureWorks2012].[Person].[Address] AS src
            WHERE EXISTS (
                SELECT 1 
                FROM  [.\SQL2012].[AdventureWorks2012_Copy].[Sales].[SalesOrderHeader] AS fktgt
                WHERE fktgt.[ShipToAddressID] = src.[AddressID]
            )
            AND NOT EXISTS (
	            SELECT 1 
	            FROM [.\SQL2012].[AdventureWorks2012_Copy].[Person].[Address] AS tgt
	            WHERE src.[AddressID] = tgt.[AddressID]
            )
            ;

            */

            // Comma seperated columns (except computed) for the FK referenced table
            Table referencedTable = fk.Parent.Parent.Tables[fk.ReferencedTable, fk.ReferencedTableSchema];
            String cteReferencedColumns = referencedTable.Columns.Cast<Column>()
                .Where(c1 => c1.Computed == false)
                .Select(c0 => String.Format("{0}.[{1}]", "src", c0.Name))
                .Aggregate((current, next) => current + ", " + next);

            String selectColumns = String.Join("\n\t, ", cteReferencedColumns);

            String[] existsJoinsArray = fk.Columns.Cast<ForeignKeyColumn>()
                .Select(c => String.Format("fktgt.[{0}] = src.[{1}]",
                    c.Name,
                    c.ReferencedColumn))
                .ToArray<String>();

            String existsJoins = String.Join(" AND ", existsJoinsArray);

            String[] notExistsJoinsArray = fk.Columns.Cast<ForeignKeyColumn>()
                            .Select(c => String.Format("src.[{0}] = tgt.[{0}]",
                                c.ReferencedColumn))
                            .ToArray<String>();

            String notExistsJoins = String.Join(" AND ", notExistsJoinsArray);

            return String.Format(@"
SELECT {0} 
FROM [{9}].[{1}].[{2}].[{3}] AS src
WHERE EXISTS (
    SELECT 1 
    FROM  [{10}].[{4}].[{5}].[{6}] AS fktgt
    WHERE {7}
)
AND NOT EXISTS (
	SELECT 1 
	FROM [{10}].[{4}].[{2}].[{3}] AS tgt
	WHERE {8}
)
;", selectColumns, 
  this.sourceDatabaseName, 
  fk.ReferencedTableSchema, 
  fk.ReferencedTable, 
  this.targetDatabaseName, 
  fk.Parent.Schema, 
  fk.Parent.Name, 
  existsJoins, 
  notExistsJoins
  ,this.sourceServer.Name
  ,this.targetServer.Name);
        }

        public void copyDataForAllTables(CopyPortion portion)
        {
            List<Table> processedTables = new List<Table>();

            // Get largest ( by rowcount) unprocessed table
            Table nextLargestTable = sourceDatabase.Tables.Cast<Table>()
                .Where(t => t.IsSystemObject == false)
                .Except(processedTables)
                .OrderBy(t => t.RowCount)
                .Reverse()
                .FirstOrDefault();

            while (nextLargestTable != null)
            {
                recurseCopyData(nextLargestTable, targetDatabase, portion, processedTables, null);
                nextLargestTable = sourceDatabase.Tables.Cast<Table>()
                    .Where(t => t.IsSystemObject == false)
                    .Except(processedTables)
                    .OrderBy(t => t.RowCount)
                    .Reverse()
                    .FirstOrDefault();
            }

        }
        private void recurseCopyData(Table sourceTable, Database targetDatabase, CopyPortion portion, List<Table> processedTables, ForeignKey recursionFK)
        {
            // Copy n% of the fact table and then traverse each foreign key needed to restore RI
            Table targetTable = targetDatabase.Tables[sourceTable.Name, sourceTable.Schema];
            this.disabledForeignKeys.AddRange(disableTableForeignKeys(targetTable));
            if (isLargeTable(sourceTable))
            {
                if (recursionFK == null)
                {
                    CopyTableSample(sourceTable, targetTable, portion);
                    processedTables.Add(sourceTable);
                }
                else
                {
                    CopyTableMissingKeys(sourceTable, recursionFK, targetDatabase, portion);
                    processedTables.Add(sourceTable);
                }
            }
            else
            {
                // It's small so just copy 100%
                CopyTableTopN(sourceTable, targetTable, new CopyPortionPercentage(100));
                processedTables.Add(sourceTable);
            }

            //ToDo: Break out of circular / self referencing FKs 
            foreach (ForeignKey sourceForeignKey in sourceTable.ForeignKeys)
            {
                if (sourceForeignKey.IsEnabled)
                {
                    Table referencedTable = sourceDatabase.Tables[sourceForeignKey.ReferencedTable, sourceForeignKey.ReferencedTableSchema];
                    if (!processedTables.Contains(referencedTable))
                    {
                        recurseCopyData(referencedTable, targetDatabase, portion, processedTables, sourceForeignKey);
                    }
                    else
                    {
                        this.disabledForeignKeys.AddRange(disableTableForeignKeys(targetTable));
                        CopyTableMissingKeys(referencedTable, sourceForeignKey, targetDatabase, portion);
                        processedTables.Add(referencedTable);
                    }
                }
            }

            enableTableForeignKeys(this.disabledForeignKeys);

        }

        private void enableTableForeignKeys(List<ForeignKey> foreignKeys)
        {
            // Enable all of the foreign keys again
            foreach (ForeignKey fk in foreignKeys)
            {
                fk.IsEnabled = true;
                fk.Alter();
            }
        }

        private static List<ForeignKey> disableTableForeignKeys(Table targetTable)
        {
            List<ForeignKey> disabledForeignKeys = new List<ForeignKey>();
            //Temporarily disable all of the foreign keys
            foreach (ForeignKey fk in targetTable.ForeignKeys)
            {
                if (fk.IsEnabled)
                {
                    disabledForeignKeys.Add(fk);
                    fk.IsEnabled = false;
                    fk.Alter();
                }
            }
            return disabledForeignKeys;
        }



        /// <summary>
        /// 1Mb or more is a large table.
        /// </summary>
        /// <param name="sourceTable"></param>
        /// <returns></returns>
        public Boolean isLargeTable(Table sourceTable)
        {
            return this.isLargeTable(sourceTable, 1024);
        }
        public Boolean isLargeTable(Table sourceTable, uint thresholdKilobytes)
        {
            return (sourceTable.DataSpaceUsed >= thresholdKilobytes);
        }

        /// <summary>
        /// Copy a simple percentage of the table.
        /// Uses TABLESAMPLE for large tables(fast), TOP n PERCENT for small tables(diverse).
        /// </summary>

        private long CopyTableSample(Table sourceTable, Table targetTable, CopyPortion portion)
        {
            long ret = 0;
            uint percent = portion.AsPercentage();

            String sql = GetSqlSampleCopy(sourceTable, percent);
            using (SqlConnection sourceConnection = sourceServer.ConnectionContext.SqlConnectionObject)
            {
                sourceConnection.Open();
                sourceConnection.ChangeDatabase(sourceTable.Parent.Name);
                using (SqlCommand sqlCommand = new SqlCommand(sql, sourceConnection))
                {
                    ret = this.BulkCopyData(sourceTable, sqlCommand, targetTable);
                }
                sourceConnection.Close();
            }
            return ret;
        }

        private long CopyTableTopN(Table sourceTable, Table targetTable, CopyPortion portion)
        {
            uint percent = portion.AsPercentage();
            long ret = 0;

            String sql = GetSqlTopNCopy(sourceTable, percent);
            using (SqlConnection sourceConnection = sourceServer.ConnectionContext.SqlConnectionObject)
            {
                sourceConnection.Open();
                sourceConnection.ChangeDatabase(sourceTable.Parent.Name);
                using (SqlCommand sqlCommand = new SqlCommand(sql, sourceConnection))
                {
                    ret = this.BulkCopyData(sourceTable, sqlCommand, targetTable);
                }
                sourceConnection.Close();
            }
            return ret;
        }


        private long CopyTableMissingKeys(Table sourceTable, ForeignKey sourceForeignKey, Database targetDatabase, CopyPortion portion)
        {
            long ret;
            String sql;
            Table targetTable = targetDatabase.Tables[sourceForeignKey.ReferencedTable, sourceForeignKey.ReferencedTableSchema];
            if (sourceTable.RowCount > 0)
            {
                sql = GetSqlCopyDataMissingKeys(sourceForeignKey);
            }
            else {
                uint percent = portion.AsPercentage();            
                sql = GetSqlSampleCopy(sourceTable, percent);
            }
            using (SqlConnection sourceConnection = sourceServer.ConnectionContext.SqlConnectionObject)
            {
                sourceConnection.Open();
                sourceConnection.ChangeDatabase(targetDatabase.Name);
                using (SqlCommand sqlMissingKeysCommand = new SqlCommand(sql, sourceConnection))
                {
                    ret = this.BulkCopyData(sourceTable, sqlMissingKeysCommand, targetTable);
                }
                sourceConnection.Close();
                return ret;
            }
        }

        /// <summary>
        /// Thanks: http://www.michaelbowersox.com/2011/12/01/streaming-data-between-databases-using-sqlbulkcopy-and-sqldatareader/
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="targetConnectionString"></param>
        /// <param name="targetTable"></param>
        /// <returns></returns>
        private long BulkCopyData(Table sourceTable, SqlCommand sqlCommand, Table targetTable)
        {
            Database targetDatabase = targetTable.Parent;
            String targetTableName = "[" + targetTable.Schema + "].[" + targetTable.Name + "]";

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                using (SqlConnection targetConnection = targetServer.ConnectionContext.SqlConnectionObject)
                {
                    targetConnection.Open();
                    targetConnection.ChangeDatabase(targetTable.Parent.Name);
                    using (SqlTransaction txn = targetConnection.BeginTransaction())
                    {
                        using (SqlBulkCopy bulk = new SqlBulkCopy(targetConnection, SqlBulkCopyOptions.KeepIdentity, txn))
                        {
                            //ToDo:
                            //bulk.SqlRowsCopied += new SqlRowsCopiedEventHandler(s_SqlRowsCopied);

                            bulk.DestinationTableName = targetTableName;

                            // Don't try copy computed columns
                            Column[] sourceColumns = sourceTable.Columns.Cast<Column>()
                                .Where(c0 => !c0.Computed).ToArray<Column>();


                            foreach (Column col in sourceColumns)
                            {
                                bulk.ColumnMappings.Add(col.Name, col.Name);
                            }
                            try
                            {
                                bulk.WriteToServer(reader);
                                txn.Commit();

                                // targetTable says it's been dropped ???. Out of context maybe?
                                //Table retTable = targetDatabase.Tables[targetTableName]; //Database.Tables[Table]
                                //retTable.Refresh();

                                return 0;// retTable.RowCount;
                            }
                            catch (Exception ex)
                            {
                                throw;
                            }
                            finally
                            {
                                bulk.Close();
                                reader.Close();
                                targetConnection.Close();
                            }
                        }
                    }
                }
            }
        }

    }
}
