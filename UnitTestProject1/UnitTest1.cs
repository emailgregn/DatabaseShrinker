/**
* Copyright (c) 2015 Greg Nicol
* This file is part of DataTransferGUI.
* 
* DataTransferGUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
* 
* DataTransferGUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
* 
* You should have received a copy of the GNU General Public License along with DataTransferGUI.  If not, see <http://www.gnu.org/licenses/>.
*
*/
namespace UnitTestProject1
{
    using System;
    using NUnit.Framework;
    using System.Data.SqlClient;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Sdk.Sfc;
    using DataTransferGUI;

    [TestFixture]
    public class GetSqlUnitTests
    {

        static String testDatabaseName = "AdventureWorks2012";
        static String testConnectionString = String.Format("Server=.\\SQL2012;Database={0};Trusted_Connection=True;Application Name={1}", testDatabaseName, "Unit Test App");

        SqlConnection testConnection;
        Server testServer;
        Database testDatabase;
        Table testTable;

        static String targetDatabaseName = "AdventureWorks2012_Copy";
        static String targetConnectionString = String.Format("Server=.\\SQL2012;Database={0};Trusted_Connection=True;Application Name={1}", targetDatabaseName, "Unit Test App");

        SqlConnection targetConnection;
        Server targetServer;
        Database targetDatabase;
        Table targetTable;




        DGTDataTransfer sdt;

        [SetUp]
        public void Init()
        {
            this.testConnection = new SqlConnection(testConnectionString);
            this.testServer = new Server(new ServerConnection(testConnection));
            this.testDatabase = testServer.Databases[testDatabaseName];
            this.testTable = testDatabase.Tables["Product", "Production"];

            this.targetConnection = new SqlConnection(targetConnectionString);
            this.targetServer = new Server(new ServerConnection(targetConnection));
            this.targetDatabase = targetServer.Databases[targetDatabaseName];
            this.targetTable = targetDatabase.Tables["Product", "Production"];            



        }

        [TearDown]
        public void TearDown()
        {
            this.testConnection.Close();
            this.testConnection.Dispose();
        }

        [Test]
        public void Test_GetSqlSampleCopy_1()
        {
            sdt = new DGTDataTransfer(testServer, testDatabaseName, targetServer, targetDatabaseName);

            String expected = "SELECT * FROM [Production].[Product] TABLESAMPLE(100 PERCENT);";
            String actual = sdt.GetSqlSampleCopy(testTable, 100);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_GetSqlTopNCopy_1()
        {
            sdt = new DGTDataTransfer(testServer, testDatabaseName, targetServer, targetDatabaseName);

            String expected = "SELECT TOP 100 PERCENT * FROM [Production].[Product] ORDER BY NEWID();";
            String actual = sdt.GetSqlTopNCopy(testTable, 100);
            Assert.AreEqual(expected, actual);
        }
        //[Test]
        //public void Test_GetSqlCopyDataByKeys_1()
        //{
        //    sdt = new SqlDataTransfer(testServer, testDatabaseName, targetServer, targetDatabaseName);

        //    String expected = "";
        //    String actual = sdt.GetSqlCopyDataByKeys(testTable, 100, "");
        //    Assert.AreEqual(expected, actual);
        //}
//        [Test]
//        public void Test_GetSqlTableOrdinality_1()
//        {
//            sdt = new SqlDataTransfer(testServer, testDatabaseName, targetServer, targetDatabaseName);

//            String expected = @";WITH CTE
//AS (
//    SELECT COUNT (DISTINCT [Product].[ProductModelID] ) AS [KOUNT_Product_ProductModelID],
//	COUNT (DISTINCT [Product].[ProductSubcategoryID] ) AS [KOUNT_Product_ProductSubcategoryID],
//	COUNT (DISTINCT [Product].[SizeUnitMeasureCode] ) AS [KOUNT_Product_SizeUnitMeasureCode],
//	COUNT (DISTINCT [Product].[WeightUnitMeasureCode] ) AS [KOUNT_Product_WeightUnitMeasureCode]
//    FROM [Production].[Product]
//    ) SELECT TOP 1 Ordinality
//            ,Uniques
//FROM CTE
//UNPIVOT ( Uniques FOR Ordinality IN ([KOUNT_Product_ProductModelID],
//	[KOUNT_Product_ProductSubcategoryID],
//	[KOUNT_Product_SizeUnitMeasureCode],
//	[KOUNT_Product_WeightUnitMeasureCode])) AS Unpvt
//ORDER BY Uniques DESC";

//            String actual = sdt.GetSqlTopOrdinality(testTable);
//            Assert.AreEqual(expected, actual);
//        }
        [Test]
        public void Test_GetSqlCopyDataMissingKeys_1()
        {
            sdt = new DGTDataTransfer(testServer, testDatabaseName, targetServer, targetDatabaseName);

            String expected = "";
            String actual = sdt.GetSqlCopyDataMissingKeys(testTable.ForeignKeys[0]);
            Assert.AreEqual(expected, actual);
        }

    }
}
