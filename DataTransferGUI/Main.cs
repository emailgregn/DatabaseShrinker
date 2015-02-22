using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Threading;

namespace DataTransferGUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void cmdRefreshServer1_Click(object sender, EventArgs e)
        {
            RefreshServerList(cboServer1);
        }

        private void cmdRefreshServer2_Click(object sender, EventArgs e)
        {
            RefreshServerList(cboServer2);
        }

        private void rbWindowsAuthentication1_Click(object sender, EventArgs e)
        {
            txtUser1.Enabled = false;
            lblUserName1.Enabled = false;
            txtPassword1.Enabled = false;
            lblPassword1.Enabled = false;
        }

        private void rbSQLServerAuthentication1_CheckedChanged(object sender, EventArgs e)
        {
            txtUser1.Enabled = true;
            lblUserName1.Enabled = true;
            txtPassword1.Enabled = true;
            lblPassword1.Enabled = true;
        }

        private void rbWindowsAuthentication2_CheckedChanged(object sender, EventArgs e)
        {
            txtUser2.Enabled = false;
            lblUserName2.Enabled = false;
            txtPassword2.Enabled = false;
            lblPassword2.Enabled = false;
        }

        private void rbSQLServerAuthentication2_CheckedChanged(object sender, EventArgs e)
        {
            txtUser2.Enabled = true;
            lblUserName2.Enabled = true;
            txtPassword2.Enabled = true;
            lblPassword2.Enabled = true;
        }

        private void cboDatabase1_Click(object sender, EventArgs e)
        {
            if (cboDatabase1.Items.Count == 0)
            {
                if (rbWindowsAuthentication1.Checked)
                {
                    RefreshDatabaseList(cboDatabase1, cboServer1.Text);
                }
                else
                {
                    RefreshDatabaseList(cboDatabase1, cboServer1.Text, txtUser1.Text, txtPassword1.Text);
                }
            }
        }

        private void RefreshServerList(ComboBox cbo)
        {
            cbo.Items.Clear();
            DataTable dt = SmoApplication.EnumAvailableSqlServers(false);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cbo.Items.Add(dr["Name"].ToString());
                }
            }
        }

        private void RefreshDatabaseList(ComboBox cbo, string server)
        {
            try
            {
                cbo.Items.Clear();
                ServerConnection conn = new ServerConnection();
                conn.ServerInstance = server;
                Server srv = new Server(conn);

                foreach (Database db in srv.Databases)
                {
                    cbo.Items.Add(db.Name);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDatabaseList(ComboBox cbo, string server, string login, string password)
        {
            try
            {
                cbo.Items.Clear();
                ServerConnection conn = new ServerConnection();
                conn.ServerInstance = server;
                conn.LoginSecure = false;
                conn.Login = login;
                conn.Password = password;
                Server srv = new Server(conn);

                foreach (Database db in srv.Databases)
                {
                    cbo.Items.Add(db.Name);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboDatabase2_Click(object sender, EventArgs e)
        {
            if (cboDatabase2.Items.Count == 0)
            {
                if (rbWindowsAuthentication2.Checked)
                {
                    RefreshDatabaseList(cboDatabase2, cboServer2.Text);
                }
                else
                {
                    RefreshDatabaseList(cboDatabase2, cboServer2.Text, txtUser2.Text, txtPassword2.Text);
                }
            }
        }

        private void cboServer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDatabase1.Items.Clear();
        }

        private void cboServer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDatabase2.Items.Clear();
        }

        private void cmdCompare_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(TransferDBSchema));
            t.Start();
        }

        protected void DiscoveryProgress_Handler
        (object sender, ProgressReportEventArgs e
            )
        {
            Console.WriteLine(e.Total + "/" + e.TotalCount + " " + e.Current.Value);

            this.Invoke(new MethodInvoker(delegate
                                              {
                                                  this.lblStatus.Text = e.Total + "/" + e.TotalCount + " " +
                                                                        e.Current.Value;
                                              }));
        }

        protected void DataTransferEvent_Handler(
            object sender, DataTransferEventArgs e)
        {

            //Console.WriteLine("[" + e.DataTransferEventType + "] " + e.Message);

            this.Invoke(new MethodInvoker(delegate
                                              {
                                                  lblStatus.Text = "[" + e.DataTransferEventType + "] " + e.Message;
                                              }));
        }

        protected void TransferDbData()
        {
            Server sourceServer = null;
            Server targetServer = null;

            string sourceDatabaseName = string.Empty;
            string targetDatabaseName = string.Empty;

            this.Invoke(new MethodInvoker(delegate
            {
                cmdCompare.Enabled = false;

                sourceDatabaseName = cboDatabase1.Text;
                targetDatabaseName = cboDatabase2.Text;

                if (rbSQLServerAuthentication1.Checked == true)
                {
                    ServerConnection conn = new ServerConnection();
                    conn.ServerInstance = cboServer1.Text;
                    conn.LoginSecure = false;
                    conn.Login = txtUser1.Text;
                    conn.Password = txtPassword1.Text;
                    sourceServer = new Server(conn);
                }
                else
                {
                    ServerConnection conn = new ServerConnection();
                    conn.ServerInstance = cboServer1.Text;
                    sourceServer = new Server(conn);
                }


                if (rbSQLServerAuthentication2.Checked == true)
                {
                    ServerConnection conn = new ServerConnection();
                    conn.ServerInstance = cboServer2.Text;
                    conn.LoginSecure = false;
                    conn.Login = txtUser2.Text;
                    conn.Password = txtPassword2.Text;
                    targetServer = new Server(conn);
                }
                else
                {
                    ServerConnection conn = new ServerConnection();
                    conn.ServerInstance = cboServer2.Text;
                    targetServer = new Server(conn);
                }
            }));


            try
            {
                string sourceServerVersion = sourceServer.Information.Version.ToString();
                string targetServerVersion = targetServer.Information.Version.ToString();
                Database sourceDatabase = sourceServer.Databases[sourceDatabaseName];
                // ToDo: Make sure all destination tables are empty.
                DGTDataTransfer sdt = new DGTDataTransfer(sourceServer, sourceDatabaseName, targetServer, targetDatabaseName);
                sdt.copyDataForAllTables(new CopyPortionPercentage(50));

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Invoke(new MethodInvoker(delegate
                {

                    cmdCompare.Enabled = true;
                }));
            }
        }

        protected void TransferDBSchema()
        {
            Server sourceServer = null;
            Server targetServer = null;
            
            string sourceDatabaseName=string.Empty;
            string targetDatabaseName=string.Empty;

            this.Invoke(new MethodInvoker(delegate
                                              {
                                                  cmdCompare.Enabled = false;
                                                  
                                                  sourceDatabaseName = cboDatabase1.Text;
                                                  targetDatabaseName = cboDatabase2.Text;
                                                  
                                                  if (rbSQLServerAuthentication1.Checked == true)
                                                  {
                                                      ServerConnection conn = new ServerConnection();
                                                      conn.ServerInstance = cboServer1.Text;
                                                      conn.LoginSecure = false;
                                                      conn.Login = txtUser1.Text;
                                                      conn.Password = txtPassword1.Text;
                                                      sourceServer = new Server(conn);
                                                  }
                                                  else
                                                  {
                                                      ServerConnection conn = new ServerConnection();
                                                      conn.ServerInstance = cboServer1.Text;
                                                      sourceServer = new Server(conn);
                                                  }


                                                  if (rbSQLServerAuthentication2.Checked == true)
                                                  {
                                                      ServerConnection conn = new ServerConnection();
                                                      conn.ServerInstance = cboServer2.Text;
                                                      conn.LoginSecure = false;
                                                      conn.Login = txtUser2.Text;
                                                      conn.Password = txtPassword2.Text;
                                                      targetServer = new Server(conn);
                                                  }
                                                  else
                                                  {
                                                      ServerConnection conn = new ServerConnection();
                                                      conn.ServerInstance = cboServer2.Text;
                                                      targetServer = new Server(conn);
                                                  }
                                              }));

            try
            {
                string sourceServerVersion = sourceServer.Information.Version.ToString();
                string targetServerVersion = targetServer.Information.Version.ToString();

                Database sourceDatabase = sourceServer.Databases[sourceDatabaseName];
                


                //ToDo: GUI check if db exists and chkCreateTargetDatabase.Checked, confirm DROP db


                DTGSchemaTransfer sdbt = new DTGSchemaTransfer(sourceServer, sourceDatabaseName, targetServer, targetDatabaseName);

                configureTransferOptions(targetServer, sdbt);

                // SqlDbTransfer will not create the target database
                Database targetDatabase;
                if (chkCreateTargetDatabase.Checked)
                {
                    targetDatabase = sdbt.createTargetDatabase(sourceDatabase, targetServer, targetDatabaseName);
                }
                else
                {
                    targetDatabase = targetServer.Databases[targetDatabaseName];
                }



                //xfr.DestinationLoginSecure = true;
                sdbt.AddDataTransferEvent(DataTransferEvent_Handler);
                sdbt.AddProgressReportEvent(DiscoveryProgress_Handler);

                sdbt.TransferDatabaseSchema();

                this.Invoke(new MethodInvoker(() => txtScript.Clear()));

                foreach (var s in sdbt.TransferScripts())
                {
                    this.Invoke(new MethodInvoker(() => txtScript.AppendText(s + Environment.NewLine)));

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Invoke(new MethodInvoker(delegate
                {

                    cmdCompare.Enabled = true;
                }));
            }
        }

        private void configureTransferOptions(Server targetServer, DTGSchemaTransfer sdbt)
        {
            if (!rbWindowsAuthentication2.Checked)
            {
                sdbt.DestinationLogin = targetServer.ConnectionContext.Login;
                sdbt.DestinationPassword = targetServer.ConnectionContext.Password;
            }

            sdbt.CopyAllDatabaseTriggers = chkCopyAllDatabaseTriggers.Checked;
            sdbt.CopyAllDefaults = chkCopyAllDefaults.Checked;
            sdbt.CopyAllFullTextCatalogs = chkCopyAllFullTextCatalogs.Checked;
            sdbt.CopyAllFullTextStopLists = chkCopyAllFullTextStopLists.Checked;
            sdbt.CopyAllLogins = false; // chkCopyAllLogins.Checked; // Causes The server principal 'NT SERVICE\Winmgmt' already exists.
            sdbt.CopyAllObjects = chkCopyAllObjects.Checked;
            sdbt.CopyAllPartitionFunctions = chkCopyAllPartitionFunctions.Checked;
            sdbt.CopyAllPartitionSchemes = chkCopyAllPartitionSchemes.Checked;
            sdbt.CopyAllPlanGuides = chkCopyAllPlanGuides.Checked;
            sdbt.CopyAllRoles = chkCopyAllRoles.Checked;
            sdbt.CopyAllRules = chkCopyAllRules.Checked;
            sdbt.CopyAllSchemas = chkCopyAllSchemas.Checked;
            sdbt.CopyAllSqlAssemblies = chkCopyAllSqlAssemblies.Checked;
            sdbt.CopyAllStoredProcedures = chkCopyAllStoredProcedures.Checked;
            sdbt.CopyAllSynonyms = chkCopyAllSynonyms.Checked;
            sdbt.CopyAllTables = chkCopyAllTables.Checked;
            sdbt.CopyAllUserDefinedAggregates = chkCopyAllUserDefinedAggregates.Checked;
            sdbt.CopyAllUserDefinedDataTypes = chkCopyAllUserDefinedDataTypes.Checked;
            sdbt.CopyAllUserDefinedFunctions = chkCopyAllUserDefinedFunctions.Checked;
            sdbt.CopyAllUserDefinedTableTypes = chkCopyAllUserDefinedTableTypes.Checked;
            sdbt.CopyAllUserDefinedTypes = chkCopyAllUserDefinedTypes.Checked;
            sdbt.CopyAllUsers = false; // chkCopyAllUsers.Checked; // Causes The server principal 'NT SERVICE\Winmgmt' already exists.
            sdbt.CopyAllViews = chkCopyAllViews.Checked;
            sdbt.CopyAllXmlSchemaCollections = chkCopyAllXmlSchemaCollections.Checked;
            sdbt.CopySchema = chkCopySchema.Checked;
        }


        private void cboDatabase2_Click_1(object sender, EventArgs e)
        {
            if (cboDatabase2.Items.Count == 0)
            {
                if (rbWindowsAuthentication2.Checked)
                {
                    RefreshDatabaseList(cboDatabase2, cboServer2.Text);
                }
                else
                {
                    RefreshDatabaseList(cboDatabase2, cboServer2.Text, txtUser2.Text, txtPassword2.Text);
                }
            }
        }

        private void cmdTransferDbData_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(TransferDbData));
            t.Start();
        }


    }
}
