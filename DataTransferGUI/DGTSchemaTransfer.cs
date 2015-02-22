using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace DataTransferGUI
{
    class DTGSchemaTransfer
    {
        private Server sourceServer;
        private String sourceDatabaseName;
        private Database sourceDatabase;

        private Server targetServer;
        private String targetDatabaseName;
        private Database targetDatabase;

        private Transfer _transfer;

        public DTGSchemaTransfer(Server sourceServer, String sourceDatabaseName, Server targetServer, String targetDatabaseName)
        {
            this.sourceServer = sourceServer;
            this.targetServer = targetServer;

            this.sourceDatabaseName = sourceDatabaseName;
            this.targetDatabaseName = targetDatabaseName;

            this.sourceDatabase = sourceServer.Databases[sourceDatabaseName];
            this.targetDatabase = targetServer.Databases[targetDatabaseName];

            _transfer = new Transfer(sourceDatabase);
            this.resetImmutableTranferProperties();
        }

        public Transfer transfer
        {
            get
            {
                return _transfer;
            }
        }

        public String DestinationLogin { get { return _transfer.DestinationLogin; } set { _transfer.DestinationLogin = value; } }
        public String DestinationPassword { get { return _transfer.DestinationPassword; } set { _transfer.DestinationPassword = value; } }
        public Boolean CopyAllDatabaseTriggers { get { return _transfer.CopyAllDatabaseTriggers; } set { _transfer.CopyAllDatabaseTriggers = value; } }
        public Boolean CopyAllDefaults { get { return _transfer.CopyAllDefaults; } set { _transfer.CopyAllDefaults = value; } }
        public Boolean CopyAllFullTextCatalogs { get { return _transfer.CopyAllFullTextCatalogs; } set { _transfer.CopyAllFullTextCatalogs = value; } }
        public Boolean CopyAllFullTextStopLists { get { return _transfer.CopyAllFullTextStopLists; } set { _transfer.CopyAllFullTextStopLists = value; } }
        public Boolean CopyAllLogins { get { return _transfer.CopyAllLogins; } set { _transfer.CopyAllLogins = value; } }
        public Boolean CopyAllObjects { get { return _transfer.CopyAllObjects; } set { _transfer.CopyAllObjects = value; } }
        public Boolean CopyAllPartitionFunctions { get { return _transfer.CopyAllPartitionFunctions; } set { _transfer.CopyAllPartitionFunctions = value; } }
        public Boolean CopyAllPartitionSchemes { get { return _transfer.CopyAllPartitionSchemes; } set { _transfer.CopyAllPartitionSchemes = value; } }
        public Boolean CopyAllPlanGuides { get { return _transfer.CopyAllPlanGuides; } set { _transfer.CopyAllPlanGuides = value; } }
        public Boolean CopyAllRoles { get { return _transfer.CopyAllRoles; } set { _transfer.CopyAllRoles = value; } }
        public Boolean CopyAllRules { get { return _transfer.CopyAllRules; } set { _transfer.CopyAllRules = value; } }
        public Boolean CopyAllSchemas { get { return _transfer.CopyAllSchemas; } set { _transfer.CopyAllSchemas = value; } }
        public Boolean CopyAllSqlAssemblies { get { return _transfer.CopyAllSqlAssemblies; } set { _transfer.CopyAllSqlAssemblies = value; } }
        public Boolean CopyAllStoredProcedures { get { return _transfer.CopyAllStoredProcedures; } set { _transfer.CopyAllStoredProcedures = value; } }
        public Boolean CopyAllSynonyms { get { return _transfer.CopyAllSynonyms; } set { _transfer.CopyAllSynonyms = value; } }
        public Boolean CopyAllTables { get { return _transfer.CopyAllTables; } set { _transfer.CopyAllTables = value; } }
        public Boolean CopyAllUserDefinedAggregates { get { return _transfer.CopyAllUserDefinedAggregates; } set { _transfer.CopyAllUserDefinedAggregates = value; } }
        public Boolean CopyAllUserDefinedDataTypes { get { return _transfer.CopyAllUserDefinedDataTypes; } set { _transfer.CopyAllUserDefinedDataTypes = value; } }
        public Boolean CopyAllUserDefinedFunctions { get { return _transfer.CopyAllUserDefinedFunctions; } set { _transfer.CopyAllUserDefinedFunctions = value; } }
        public Boolean CopyAllUserDefinedTableTypes { get { return _transfer.CopyAllUserDefinedTableTypes; } set { _transfer.CopyAllUserDefinedTableTypes = value; } }
        public Boolean CopyAllUserDefinedTypes { get { return _transfer.CopyAllUserDefinedTypes; } set { _transfer.CopyAllUserDefinedTypes = value; } }
        public Boolean CopyAllUsers { get { return _transfer.CopyAllUsers; } set { _transfer.CopyAllUsers = value; } }
        public Boolean CopyAllViews { get { return _transfer.CopyAllViews; } set { _transfer.CopyAllViews = value; } }
        public Boolean CopyAllXmlSchemaCollections { get { return _transfer.CopyAllXmlSchemaCollections; } set { _transfer.CopyAllXmlSchemaCollections = value; } }
        public Boolean CopySchema { get { return _transfer.CopySchema; } set { _transfer.CopySchema = value; } }

        public void AddDataTransferEvent(DataTransferEventHandler evt)
        {
            _transfer.DataTransferEvent += evt;
        }
        public void AddProgressReportEvent(ProgressReportEventHandler evt)
        {
            _transfer.DiscoveryProgress += evt;
        }

        public void TransferDatabaseSchema()
        {
            this.resetImmutableTranferProperties();
            _transfer.TransferData();
        }

        public StringCollection TransferScripts()
        {
            return _transfer.ScriptTransfer();
        }

        private void resetImmutableTranferProperties()
        {
            _transfer.DestinationDatabase = this.targetDatabaseName;
            _transfer.DestinationServer = this.targetServer.Name;

            _transfer.CreateTargetDatabase = false; //Don't let SMO Create the DB
            _transfer.CopyData = false; // Don't let SMO do the data transfer

        }


        public Database createTargetDatabase(Database sourceDatabase, Server targetServer, String targetDatabaseName)
        {
            Database targetDatabase;
            String sourceDatabaseName = sourceDatabase.Name;

            // Create the destination database ourselves so can set files.
            targetDatabase = new Database(targetServer, targetDatabaseName);
            foreach (FileGroup fg in targetDatabase.FileGroups)
            {
                targetDatabase.FileGroups.Remove(fg);
            }
            foreach (LogFile lf in targetDatabase.LogFiles)
            {
                targetDatabase.LogFiles.Remove(lf);
            }
            createTargetFilegroups(sourceDatabaseName, sourceDatabase, targetDatabase);
            createTargetLogfiles(sourceDatabaseName, sourceDatabase, targetDatabase);
            targetDatabase.Create();
            return targetDatabase;
        }

        private void createTargetLogfiles(string sourceDatabaseName, Database sourceDatabase, Database targetDatabase)
        {
            foreach (LogFile sourceLogFile in sourceDatabase.LogFiles)
            {
                String targetLogName;
                if (sourceLogFile.Name.Contains(sourceDatabaseName))
                {
                    targetLogName = sourceLogFile.Name.Replace(sourceDatabase.Name, targetDatabase.Name);
                }
                else
                {
                    // Shit! now what ???
                    // ToDo: Implement a naming convention?
                    throw new NotImplementedException("Don't know how to deal with filenames that don't contain the database name");
                }
                String targetLogFileName;
                if (sourceLogFile.FileName.Contains(sourceDatabaseName))
                {
                    targetLogFileName = sourceLogFile.FileName.Replace(sourceDatabase.Name, targetDatabase.Name);
                }
                else
                {
                    // Shit! now what ???
                    // ToDo: Implement a naming convention?
                    throw new NotImplementedException("Don't know how to deal with filenames that don't contain the database name");
                }
                LogFile newLogFile = new LogFile(targetDatabase, targetLogName, targetLogFileName);
                newLogFile.GrowthType = FileGrowthType.Percent;
                newLogFile.Growth = 10; // 10%
                targetDatabase.LogFiles.Add(newLogFile);
            }
        }

        private void createTargetFilegroups(string sourceDatabaseName, Database sourceDatabase, Database targetDatabase)
        {
            foreach (FileGroup sourceFileGroup in sourceDatabase.FileGroups)
            {
                FileGroup newFileGroup = new FileGroup(targetDatabase, sourceFileGroup.Name, sourceFileGroup.IsFileStream);
                //newFileGroup.IsDefault = sourceFileGroup.IsDefault;
                foreach (DataFile f in sourceFileGroup.Files)
                {
                    String targetName;
                    if (f.Name.Contains(sourceDatabaseName))
                    {
                        targetName = f.Name.Replace(sourceDatabase.Name, targetDatabase.Name);
                    }
                    else
                    {
                        // Shit! now what ???
                        // ToDo: Implement a naming convention?
                        throw new NotImplementedException("Don't know how to deal with filenames that don't contain the database name");
                    }
                    String targetFileName;
                    if (f.FileName.Contains(sourceDatabaseName))
                    {
                        targetFileName = f.FileName.Replace(sourceDatabase.Name, targetDatabase.Name);
                    }
                    else
                    {
                        // Shit! now what ???
                        // ToDo: Implement a naming convention?
                        throw new NotImplementedException("Don't know how to deal with filenames that don't contain the database name");
                    }
                    DataFile newDataFile = new DataFile(newFileGroup, targetName, targetFileName);
                    newDataFile.Size = 1024 * 10; //KB
                    newDataFile.GrowthType = FileGrowthType.Percent;
                    newDataFile.Growth = 33; // 33%
                    newFileGroup.Files.Add(newDataFile);
                }
                targetDatabase.FileGroups.Add(newFileGroup);

            }
        }


    }

}
