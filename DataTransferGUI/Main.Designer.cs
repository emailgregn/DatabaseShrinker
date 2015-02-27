/*
 * Thanks : http://www.codeproject.com/Articles/317996/SMO-Tutorial-4-of-n-Transferring-Data-and-Tracing
 * License
 * This article, along with any associated source code and files, is licensed under The Code Project Open License (CPOL)
 * Author
 * Kanasz Robert
 */
namespace DataTransferGUI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.cmdTransferDbData = new System.Windows.Forms.Button();
            this.cmdCompare = new System.Windows.Forms.Button();
            this.pnlServer2 = new System.Windows.Forms.Panel();
            this.cmdRefreshServer2 = new System.Windows.Forms.Button();
            this.lblDatabase2 = new System.Windows.Forms.Label();
            this.cboDatabase2 = new System.Windows.Forms.ComboBox();
            this.lblPassword2 = new System.Windows.Forms.Label();
            this.lblUserName2 = new System.Windows.Forms.Label();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.txtUser2 = new System.Windows.Forms.TextBox();
            this.rbSQLServerAuthentication2 = new System.Windows.Forms.RadioButton();
            this.rbWindowsAuthentication2 = new System.Windows.Forms.RadioButton();
            this.cboServer2 = new System.Windows.Forms.ComboBox();
            this.lblServer2 = new System.Windows.Forms.Label();
            this.pnlServer1 = new System.Windows.Forms.Panel();
            this.cmdRefreshServer1 = new System.Windows.Forms.Button();
            this.lblDatabase1 = new System.Windows.Forms.Label();
            this.cboDatabase1 = new System.Windows.Forms.ComboBox();
            this.lblPassword1 = new System.Windows.Forms.Label();
            this.lblUserName1 = new System.Windows.Forms.Label();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.txtUser1 = new System.Windows.Forms.TextBox();
            this.rbSQLServerAuthentication1 = new System.Windows.Forms.RadioButton();
            this.rbWindowsAuthentication1 = new System.Windows.Forms.RadioButton();
            this.cboServer1 = new System.Windows.Forms.ComboBox();
            this.lblServer1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkCopyAllDatabaseTriggers = new System.Windows.Forms.CheckBox();
            this.chkCopyAllDefaults = new System.Windows.Forms.CheckBox();
            this.chkCopyAllFullTextCatalogs = new System.Windows.Forms.CheckBox();
            this.chkCopyAllFullTextStopLists = new System.Windows.Forms.CheckBox();
            this.chkCopyAllLogins = new System.Windows.Forms.CheckBox();
            this.chkCopyAllObjects = new System.Windows.Forms.CheckBox();
            this.chkCopyAllPartitionFunctions = new System.Windows.Forms.CheckBox();
            this.chkCopyAllPartitionSchemes = new System.Windows.Forms.CheckBox();
            this.chkCopyAllPlanGuides = new System.Windows.Forms.CheckBox();
            this.chkCopyAllRoles = new System.Windows.Forms.CheckBox();
            this.chkCopyAllRules = new System.Windows.Forms.CheckBox();
            this.chkCopyAllSchemas = new System.Windows.Forms.CheckBox();
            this.chkCopyAllSqlAssemblies = new System.Windows.Forms.CheckBox();
            this.chkCopyAllStoredProcedures = new System.Windows.Forms.CheckBox();
            this.chkCopyAllSynonyms = new System.Windows.Forms.CheckBox();
            this.chkCopyAllTables = new System.Windows.Forms.CheckBox();
            this.chkCopyAllUserDefinedAggregates = new System.Windows.Forms.CheckBox();
            this.chkCopyAllUserDefinedDataTypes = new System.Windows.Forms.CheckBox();
            this.chkCopyAllUserDefinedFunctions = new System.Windows.Forms.CheckBox();
            this.chkCopyAllUserDefinedTableTypes = new System.Windows.Forms.CheckBox();
            this.chkCopyAllUserDefinedTypes = new System.Windows.Forms.CheckBox();
            this.chkCopyAllUsers = new System.Windows.Forms.CheckBox();
            this.chkCopyAllViews = new System.Windows.Forms.CheckBox();
            this.chkCopyAllXmlSchemaCollections = new System.Windows.Forms.CheckBox();
            this.chkCopySchema = new System.Windows.Forms.CheckBox();
            this.chkCreateTargetDatabase = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtScript = new System.Windows.Forms.TextBox();
            this.chkCopyData = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.pnlServer2.SuspendLayout();
            this.pnlServer1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(685, 439);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.pnlSettings);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(677, 413);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Location = new System.Drawing.Point(18, 228);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 179);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(6, 25);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(628, 151);
            this.lblStatus.TabIndex = 0;
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.cmdTransferDbData);
            this.pnlSettings.Controls.Add(this.cmdCompare);
            this.pnlSettings.Controls.Add(this.pnlServer2);
            this.pnlSettings.Controls.Add(this.pnlServer1);
            this.pnlSettings.Location = new System.Drawing.Point(3, 6);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(671, 216);
            this.pnlSettings.TabIndex = 0;
            // 
            // cmdTransferDbData
            // 
            this.cmdTransferDbData.Location = new System.Drawing.Point(578, 190);
            this.cmdTransferDbData.Name = "cmdTransferDbData";
            this.cmdTransferDbData.Size = new System.Drawing.Size(75, 23);
            this.cmdTransferDbData.TabIndex = 4;
            this.cmdTransferDbData.Text = "Data";
            this.cmdTransferDbData.UseVisualStyleBackColor = true;
            this.cmdTransferDbData.Click += new System.EventHandler(this.cmdTransferDbData_Click);
            // 
            // cmdCompare
            // 
            this.cmdCompare.Location = new System.Drawing.Point(496, 190);
            this.cmdCompare.Name = "cmdCompare";
            this.cmdCompare.Size = new System.Drawing.Size(75, 23);
            this.cmdCompare.TabIndex = 3;
            this.cmdCompare.Text = "Schema";
            this.cmdCompare.UseVisualStyleBackColor = true;
            this.cmdCompare.Click += new System.EventHandler(this.cmdCompare_Click);
            // 
            // pnlServer2
            // 
            this.pnlServer2.Controls.Add(this.cmdRefreshServer2);
            this.pnlServer2.Controls.Add(this.lblDatabase2);
            this.pnlServer2.Controls.Add(this.cboDatabase2);
            this.pnlServer2.Controls.Add(this.lblPassword2);
            this.pnlServer2.Controls.Add(this.lblUserName2);
            this.pnlServer2.Controls.Add(this.txtPassword2);
            this.pnlServer2.Controls.Add(this.txtUser2);
            this.pnlServer2.Controls.Add(this.rbSQLServerAuthentication2);
            this.pnlServer2.Controls.Add(this.rbWindowsAuthentication2);
            this.pnlServer2.Controls.Add(this.cboServer2);
            this.pnlServer2.Controls.Add(this.lblServer2);
            this.pnlServer2.Location = new System.Drawing.Point(338, 17);
            this.pnlServer2.Name = "pnlServer2";
            this.pnlServer2.Size = new System.Drawing.Size(317, 171);
            this.pnlServer2.TabIndex = 2;
            // 
            // cmdRefreshServer2
            // 
            this.cmdRefreshServer2.Location = new System.Drawing.Point(285, 3);
            this.cmdRefreshServer2.Name = "cmdRefreshServer2";
            this.cmdRefreshServer2.Size = new System.Drawing.Size(21, 23);
            this.cmdRefreshServer2.TabIndex = 11;
            this.cmdRefreshServer2.UseVisualStyleBackColor = true;
            this.cmdRefreshServer2.Click += new System.EventHandler(this.cmdRefreshServer2_Click);
            // 
            // lblDatabase2
            // 
            this.lblDatabase2.AutoSize = true;
            this.lblDatabase2.Location = new System.Drawing.Point(5, 133);
            this.lblDatabase2.Name = "lblDatabase2";
            this.lblDatabase2.Size = new System.Drawing.Size(56, 13);
            this.lblDatabase2.TabIndex = 9;
            this.lblDatabase2.Text = "Database:";
            // 
            // cboDatabase2
            // 
            this.cboDatabase2.FormattingEnabled = true;
            this.cboDatabase2.Location = new System.Drawing.Point(63, 130);
            this.cboDatabase2.Name = "cboDatabase2";
            this.cboDatabase2.Size = new System.Drawing.Size(243, 21);
            this.cboDatabase2.TabIndex = 8;
            this.cboDatabase2.Click += new System.EventHandler(this.cboDatabase2_Click_1);
            // 
            // lblPassword2
            // 
            this.lblPassword2.AutoSize = true;
            this.lblPassword2.Enabled = false;
            this.lblPassword2.Location = new System.Drawing.Point(96, 107);
            this.lblPassword2.Name = "lblPassword2";
            this.lblPassword2.Size = new System.Drawing.Size(56, 13);
            this.lblPassword2.TabIndex = 7;
            this.lblPassword2.Text = "Password:";
            // 
            // lblUserName2
            // 
            this.lblUserName2.AutoSize = true;
            this.lblUserName2.Enabled = false;
            this.lblUserName2.Location = new System.Drawing.Point(89, 81);
            this.lblUserName2.Name = "lblUserName2";
            this.lblUserName2.Size = new System.Drawing.Size(63, 13);
            this.lblUserName2.TabIndex = 6;
            this.lblUserName2.Text = "User Name:";
            // 
            // txtPassword2
            // 
            this.txtPassword2.Enabled = false;
            this.txtPassword2.Location = new System.Drawing.Point(158, 104);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.PasswordChar = '*';
            this.txtPassword2.Size = new System.Drawing.Size(148, 20);
            this.txtPassword2.TabIndex = 5;
            // 
            // txtUser2
            // 
            this.txtUser2.Enabled = false;
            this.txtUser2.Location = new System.Drawing.Point(158, 78);
            this.txtUser2.Name = "txtUser2";
            this.txtUser2.Size = new System.Drawing.Size(148, 20);
            this.txtUser2.TabIndex = 4;
            // 
            // rbSQLServerAuthentication2
            // 
            this.rbSQLServerAuthentication2.AutoSize = true;
            this.rbSQLServerAuthentication2.Location = new System.Drawing.Point(63, 55);
            this.rbSQLServerAuthentication2.Name = "rbSQLServerAuthentication2";
            this.rbSQLServerAuthentication2.Size = new System.Drawing.Size(150, 17);
            this.rbSQLServerAuthentication2.TabIndex = 3;
            this.rbSQLServerAuthentication2.Text = "SQL Server authentication";
            this.rbSQLServerAuthentication2.UseVisualStyleBackColor = true;
            this.rbSQLServerAuthentication2.CheckedChanged += new System.EventHandler(this.rbSQLServerAuthentication2_CheckedChanged);
            // 
            // rbWindowsAuthentication2
            // 
            this.rbWindowsAuthentication2.AutoSize = true;
            this.rbWindowsAuthentication2.Checked = true;
            this.rbWindowsAuthentication2.Location = new System.Drawing.Point(63, 32);
            this.rbWindowsAuthentication2.Name = "rbWindowsAuthentication2";
            this.rbWindowsAuthentication2.Size = new System.Drawing.Size(139, 17);
            this.rbWindowsAuthentication2.TabIndex = 2;
            this.rbWindowsAuthentication2.TabStop = true;
            this.rbWindowsAuthentication2.Text = "Windows authentication";
            this.rbWindowsAuthentication2.UseVisualStyleBackColor = true;
            this.rbWindowsAuthentication2.CheckedChanged += new System.EventHandler(this.rbWindowsAuthentication2_CheckedChanged);
            // 
            // cboServer2
            // 
            this.cboServer2.FormattingEnabled = true;
            this.cboServer2.Location = new System.Drawing.Point(63, 4);
            this.cboServer2.Name = "cboServer2";
            this.cboServer2.Size = new System.Drawing.Size(216, 21);
            this.cboServer2.TabIndex = 1;
            this.cboServer2.SelectedIndexChanged += new System.EventHandler(this.cboServer2_SelectedIndexChanged);
            // 
            // lblServer2
            // 
            this.lblServer2.AutoSize = true;
            this.lblServer2.Location = new System.Drawing.Point(20, 7);
            this.lblServer2.Name = "lblServer2";
            this.lblServer2.Size = new System.Drawing.Size(41, 13);
            this.lblServer2.TabIndex = 0;
            this.lblServer2.Text = "Server:";
            // 
            // pnlServer1
            // 
            this.pnlServer1.Controls.Add(this.cmdRefreshServer1);
            this.pnlServer1.Controls.Add(this.lblDatabase1);
            this.pnlServer1.Controls.Add(this.cboDatabase1);
            this.pnlServer1.Controls.Add(this.lblPassword1);
            this.pnlServer1.Controls.Add(this.lblUserName1);
            this.pnlServer1.Controls.Add(this.txtPassword1);
            this.pnlServer1.Controls.Add(this.txtUser1);
            this.pnlServer1.Controls.Add(this.rbSQLServerAuthentication1);
            this.pnlServer1.Controls.Add(this.rbWindowsAuthentication1);
            this.pnlServer1.Controls.Add(this.cboServer1);
            this.pnlServer1.Controls.Add(this.lblServer1);
            this.pnlServer1.Location = new System.Drawing.Point(15, 17);
            this.pnlServer1.Name = "pnlServer1";
            this.pnlServer1.Size = new System.Drawing.Size(317, 171);
            this.pnlServer1.TabIndex = 1;
            // 
            // cmdRefreshServer1
            // 
            this.cmdRefreshServer1.Location = new System.Drawing.Point(285, 4);
            this.cmdRefreshServer1.Name = "cmdRefreshServer1";
            this.cmdRefreshServer1.Size = new System.Drawing.Size(21, 23);
            this.cmdRefreshServer1.TabIndex = 10;
            this.cmdRefreshServer1.UseVisualStyleBackColor = true;
            this.cmdRefreshServer1.Click += new System.EventHandler(this.cmdRefreshServer1_Click);
            // 
            // lblDatabase1
            // 
            this.lblDatabase1.AutoSize = true;
            this.lblDatabase1.Location = new System.Drawing.Point(5, 133);
            this.lblDatabase1.Name = "lblDatabase1";
            this.lblDatabase1.Size = new System.Drawing.Size(56, 13);
            this.lblDatabase1.TabIndex = 9;
            this.lblDatabase1.Text = "Database:";
            // 
            // cboDatabase1
            // 
            this.cboDatabase1.FormattingEnabled = true;
            this.cboDatabase1.Location = new System.Drawing.Point(63, 130);
            this.cboDatabase1.Name = "cboDatabase1";
            this.cboDatabase1.Size = new System.Drawing.Size(243, 21);
            this.cboDatabase1.TabIndex = 8;
            this.cboDatabase1.Click += new System.EventHandler(this.cboDatabase1_Click);
            // 
            // lblPassword1
            // 
            this.lblPassword1.AutoSize = true;
            this.lblPassword1.Enabled = false;
            this.lblPassword1.Location = new System.Drawing.Point(96, 107);
            this.lblPassword1.Name = "lblPassword1";
            this.lblPassword1.Size = new System.Drawing.Size(56, 13);
            this.lblPassword1.TabIndex = 7;
            this.lblPassword1.Text = "Password:";
            // 
            // lblUserName1
            // 
            this.lblUserName1.AutoSize = true;
            this.lblUserName1.Enabled = false;
            this.lblUserName1.Location = new System.Drawing.Point(89, 81);
            this.lblUserName1.Name = "lblUserName1";
            this.lblUserName1.Size = new System.Drawing.Size(63, 13);
            this.lblUserName1.TabIndex = 6;
            this.lblUserName1.Text = "User Name:";
            // 
            // txtPassword1
            // 
            this.txtPassword1.Enabled = false;
            this.txtPassword1.Location = new System.Drawing.Point(158, 104);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.PasswordChar = '*';
            this.txtPassword1.Size = new System.Drawing.Size(148, 20);
            this.txtPassword1.TabIndex = 5;
            // 
            // txtUser1
            // 
            this.txtUser1.Enabled = false;
            this.txtUser1.Location = new System.Drawing.Point(158, 78);
            this.txtUser1.Name = "txtUser1";
            this.txtUser1.Size = new System.Drawing.Size(148, 20);
            this.txtUser1.TabIndex = 4;
            // 
            // rbSQLServerAuthentication1
            // 
            this.rbSQLServerAuthentication1.AutoSize = true;
            this.rbSQLServerAuthentication1.Location = new System.Drawing.Point(63, 55);
            this.rbSQLServerAuthentication1.Name = "rbSQLServerAuthentication1";
            this.rbSQLServerAuthentication1.Size = new System.Drawing.Size(150, 17);
            this.rbSQLServerAuthentication1.TabIndex = 3;
            this.rbSQLServerAuthentication1.Text = "SQL Server authentication";
            this.rbSQLServerAuthentication1.UseVisualStyleBackColor = true;
            this.rbSQLServerAuthentication1.CheckedChanged += new System.EventHandler(this.rbSQLServerAuthentication1_CheckedChanged);
            // 
            // rbWindowsAuthentication1
            // 
            this.rbWindowsAuthentication1.AutoSize = true;
            this.rbWindowsAuthentication1.Checked = true;
            this.rbWindowsAuthentication1.Location = new System.Drawing.Point(63, 32);
            this.rbWindowsAuthentication1.Name = "rbWindowsAuthentication1";
            this.rbWindowsAuthentication1.Size = new System.Drawing.Size(139, 17);
            this.rbWindowsAuthentication1.TabIndex = 2;
            this.rbWindowsAuthentication1.TabStop = true;
            this.rbWindowsAuthentication1.Text = "Windows authentication";
            this.rbWindowsAuthentication1.UseVisualStyleBackColor = true;
            this.rbWindowsAuthentication1.Click += new System.EventHandler(this.rbWindowsAuthentication1_Click);
            // 
            // cboServer1
            // 
            this.cboServer1.FormattingEnabled = true;
            this.cboServer1.Location = new System.Drawing.Point(63, 4);
            this.cboServer1.Name = "cboServer1";
            this.cboServer1.Size = new System.Drawing.Size(216, 21);
            this.cboServer1.TabIndex = 1;
            this.cboServer1.SelectedIndexChanged += new System.EventHandler(this.cboServer1_SelectedIndexChanged);
            // 
            // lblServer1
            // 
            this.lblServer1.AutoSize = true;
            this.lblServer1.Location = new System.Drawing.Point(20, 7);
            this.lblServer1.Name = "lblServer1";
            this.lblServer1.Size = new System.Drawing.Size(41, 13);
            this.lblServer1.TabIndex = 0;
            this.lblServer1.Text = "Server:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(677, 413);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Transfer Options";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllDatabaseTriggers, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllDefaults, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllFullTextCatalogs, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllFullTextStopLists, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllLogins, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllObjects, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllPartitionFunctions, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllPartitionSchemes, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllPlanGuides, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllRoles, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllRules, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllSchemas, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllSqlAssemblies, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllStoredProcedures, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllSynonyms, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllTables, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllUserDefinedAggregates, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllUserDefinedDataTypes, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllUserDefinedFunctions, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllUserDefinedTableTypes, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllUserDefinedTypes, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllUsers, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllViews, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyAllXmlSchemaCollections, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkCopyData, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.chkCopySchema, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.chkCreateTargetDatabase, 2, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(638, 167);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chkCopyAllDatabaseTriggers
            // 
            this.chkCopyAllDatabaseTriggers.AutoSize = true;
            this.chkCopyAllDatabaseTriggers.Checked = true;
            this.chkCopyAllDatabaseTriggers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllDatabaseTriggers.Location = new System.Drawing.Point(3, 3);
            this.chkCopyAllDatabaseTriggers.Name = "chkCopyAllDatabaseTriggers";
            this.chkCopyAllDatabaseTriggers.Size = new System.Drawing.Size(122, 17);
            this.chkCopyAllDatabaseTriggers.TabIndex = 0;
            this.chkCopyAllDatabaseTriggers.Text = "Copy All Db Triggers";
            this.chkCopyAllDatabaseTriggers.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllDefaults
            // 
            this.chkCopyAllDefaults.AutoSize = true;
            this.chkCopyAllDefaults.Checked = true;
            this.chkCopyAllDefaults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllDefaults.Location = new System.Drawing.Point(3, 26);
            this.chkCopyAllDefaults.Name = "chkCopyAllDefaults";
            this.chkCopyAllDefaults.Size = new System.Drawing.Size(106, 17);
            this.chkCopyAllDefaults.TabIndex = 1;
            this.chkCopyAllDefaults.Text = "Copy All Defaults";
            this.chkCopyAllDefaults.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllFullTextCatalogs
            // 
            this.chkCopyAllFullTextCatalogs.AutoSize = true;
            this.chkCopyAllFullTextCatalogs.Checked = true;
            this.chkCopyAllFullTextCatalogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllFullTextCatalogs.Location = new System.Drawing.Point(3, 49);
            this.chkCopyAllFullTextCatalogs.Name = "chkCopyAllFullTextCatalogs";
            this.chkCopyAllFullTextCatalogs.Size = new System.Drawing.Size(151, 17);
            this.chkCopyAllFullTextCatalogs.TabIndex = 2;
            this.chkCopyAllFullTextCatalogs.Text = "Copy All Full Text Catalogs";
            this.chkCopyAllFullTextCatalogs.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllFullTextStopLists
            // 
            this.chkCopyAllFullTextStopLists.AutoSize = true;
            this.chkCopyAllFullTextStopLists.Checked = true;
            this.chkCopyAllFullTextStopLists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllFullTextStopLists.Location = new System.Drawing.Point(3, 72);
            this.chkCopyAllFullTextStopLists.Name = "chkCopyAllFullTextStopLists";
            this.chkCopyAllFullTextStopLists.Size = new System.Drawing.Size(153, 17);
            this.chkCopyAllFullTextStopLists.TabIndex = 3;
            this.chkCopyAllFullTextStopLists.Text = "Copy All Full Text Stop Lists";
            this.chkCopyAllFullTextStopLists.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllLogins
            // 
            this.chkCopyAllLogins.AutoSize = true;
            this.chkCopyAllLogins.Checked = true;
            this.chkCopyAllLogins.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllLogins.Location = new System.Drawing.Point(3, 95);
            this.chkCopyAllLogins.Name = "chkCopyAllLogins";
            this.chkCopyAllLogins.Size = new System.Drawing.Size(98, 17);
            this.chkCopyAllLogins.TabIndex = 4;
            this.chkCopyAllLogins.Text = "Copy All Logins";
            this.chkCopyAllLogins.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllObjects
            // 
            this.chkCopyAllObjects.AutoSize = true;
            this.chkCopyAllObjects.Checked = true;
            this.chkCopyAllObjects.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllObjects.Location = new System.Drawing.Point(3, 118);
            this.chkCopyAllObjects.Name = "chkCopyAllObjects";
            this.chkCopyAllObjects.Size = new System.Drawing.Size(103, 17);
            this.chkCopyAllObjects.TabIndex = 5;
            this.chkCopyAllObjects.Text = "Copy All Objects";
            this.chkCopyAllObjects.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllPartitionFunctions
            // 
            this.chkCopyAllPartitionFunctions.AutoSize = true;
            this.chkCopyAllPartitionFunctions.Checked = true;
            this.chkCopyAllPartitionFunctions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllPartitionFunctions.Location = new System.Drawing.Point(162, 3);
            this.chkCopyAllPartitionFunctions.Name = "chkCopyAllPartitionFunctions";
            this.chkCopyAllPartitionFunctions.Size = new System.Drawing.Size(153, 17);
            this.chkCopyAllPartitionFunctions.TabIndex = 6;
            this.chkCopyAllPartitionFunctions.Text = "Copy All Partition Functions";
            this.chkCopyAllPartitionFunctions.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllPartitionSchemes
            // 
            this.chkCopyAllPartitionSchemes.AutoSize = true;
            this.chkCopyAllPartitionSchemes.Checked = true;
            this.chkCopyAllPartitionSchemes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllPartitionSchemes.Location = new System.Drawing.Point(162, 26);
            this.chkCopyAllPartitionSchemes.Name = "chkCopyAllPartitionSchemes";
            this.chkCopyAllPartitionSchemes.Size = new System.Drawing.Size(152, 17);
            this.chkCopyAllPartitionSchemes.TabIndex = 7;
            this.chkCopyAllPartitionSchemes.Text = "Copy All Partition Schemes";
            this.chkCopyAllPartitionSchemes.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllPlanGuides
            // 
            this.chkCopyAllPlanGuides.AutoSize = true;
            this.chkCopyAllPlanGuides.Checked = true;
            this.chkCopyAllPlanGuides.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllPlanGuides.Location = new System.Drawing.Point(162, 49);
            this.chkCopyAllPlanGuides.Name = "chkCopyAllPlanGuides";
            this.chkCopyAllPlanGuides.Size = new System.Drawing.Size(124, 17);
            this.chkCopyAllPlanGuides.TabIndex = 8;
            this.chkCopyAllPlanGuides.Text = "Copy All Plan Guides";
            this.chkCopyAllPlanGuides.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllRoles
            // 
            this.chkCopyAllRoles.AutoSize = true;
            this.chkCopyAllRoles.Checked = true;
            this.chkCopyAllRoles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllRoles.Location = new System.Drawing.Point(162, 72);
            this.chkCopyAllRoles.Name = "chkCopyAllRoles";
            this.chkCopyAllRoles.Size = new System.Drawing.Size(94, 17);
            this.chkCopyAllRoles.TabIndex = 9;
            this.chkCopyAllRoles.Text = "Copy All Roles";
            this.chkCopyAllRoles.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllRules
            // 
            this.chkCopyAllRules.AutoSize = true;
            this.chkCopyAllRules.Checked = true;
            this.chkCopyAllRules.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllRules.Location = new System.Drawing.Point(162, 95);
            this.chkCopyAllRules.Name = "chkCopyAllRules";
            this.chkCopyAllRules.Size = new System.Drawing.Size(94, 17);
            this.chkCopyAllRules.TabIndex = 10;
            this.chkCopyAllRules.Text = "Copy All Rules";
            this.chkCopyAllRules.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllSchemas
            // 
            this.chkCopyAllSchemas.AutoSize = true;
            this.chkCopyAllSchemas.Checked = true;
            this.chkCopyAllSchemas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllSchemas.Location = new System.Drawing.Point(162, 118);
            this.chkCopyAllSchemas.Name = "chkCopyAllSchemas";
            this.chkCopyAllSchemas.Size = new System.Drawing.Size(111, 17);
            this.chkCopyAllSchemas.TabIndex = 11;
            this.chkCopyAllSchemas.Text = "Copy All Schemas";
            this.chkCopyAllSchemas.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllSqlAssemblies
            // 
            this.chkCopyAllSqlAssemblies.AutoSize = true;
            this.chkCopyAllSqlAssemblies.Checked = true;
            this.chkCopyAllSqlAssemblies.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllSqlAssemblies.Location = new System.Drawing.Point(321, 3);
            this.chkCopyAllSqlAssemblies.Name = "chkCopyAllSqlAssemblies";
            this.chkCopyAllSqlAssemblies.Size = new System.Drawing.Size(140, 17);
            this.chkCopyAllSqlAssemblies.TabIndex = 12;
            this.chkCopyAllSqlAssemblies.Text = "Copy All  Sql Assemblies";
            this.chkCopyAllSqlAssemblies.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllStoredProcedures
            // 
            this.chkCopyAllStoredProcedures.AutoSize = true;
            this.chkCopyAllStoredProcedures.Checked = true;
            this.chkCopyAllStoredProcedures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllStoredProcedures.Location = new System.Drawing.Point(321, 26);
            this.chkCopyAllStoredProcedures.Name = "chkCopyAllStoredProcedures";
            this.chkCopyAllStoredProcedures.Size = new System.Drawing.Size(86, 17);
            this.chkCopyAllStoredProcedures.TabIndex = 13;
            this.chkCopyAllStoredProcedures.Text = "Copy All SPs";
            this.chkCopyAllStoredProcedures.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllSynonyms
            // 
            this.chkCopyAllSynonyms.AutoSize = true;
            this.chkCopyAllSynonyms.Checked = true;
            this.chkCopyAllSynonyms.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllSynonyms.Location = new System.Drawing.Point(321, 49);
            this.chkCopyAllSynonyms.Name = "chkCopyAllSynonyms";
            this.chkCopyAllSynonyms.Size = new System.Drawing.Size(115, 17);
            this.chkCopyAllSynonyms.TabIndex = 14;
            this.chkCopyAllSynonyms.Text = "Copy All Synonyms";
            this.chkCopyAllSynonyms.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllTables
            // 
            this.chkCopyAllTables.AutoSize = true;
            this.chkCopyAllTables.Checked = true;
            this.chkCopyAllTables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllTables.Location = new System.Drawing.Point(321, 72);
            this.chkCopyAllTables.Name = "chkCopyAllTables";
            this.chkCopyAllTables.Size = new System.Drawing.Size(99, 17);
            this.chkCopyAllTables.TabIndex = 15;
            this.chkCopyAllTables.Text = "Copy All Tables";
            this.chkCopyAllTables.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllUserDefinedAggregates
            // 
            this.chkCopyAllUserDefinedAggregates.AutoSize = true;
            this.chkCopyAllUserDefinedAggregates.Checked = true;
            this.chkCopyAllUserDefinedAggregates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllUserDefinedAggregates.Location = new System.Drawing.Point(321, 95);
            this.chkCopyAllUserDefinedAggregates.Name = "chkCopyAllUserDefinedAggregates";
            this.chkCopyAllUserDefinedAggregates.Size = new System.Drawing.Size(121, 17);
            this.chkCopyAllUserDefinedAggregates.TabIndex = 16;
            this.chkCopyAllUserDefinedAggregates.Text = "Copy All Aggregates";
            this.chkCopyAllUserDefinedAggregates.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllUserDefinedDataTypes
            // 
            this.chkCopyAllUserDefinedDataTypes.AutoSize = true;
            this.chkCopyAllUserDefinedDataTypes.Checked = true;
            this.chkCopyAllUserDefinedDataTypes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllUserDefinedDataTypes.Location = new System.Drawing.Point(321, 118);
            this.chkCopyAllUserDefinedDataTypes.Name = "chkCopyAllUserDefinedDataTypes";
            this.chkCopyAllUserDefinedDataTypes.Size = new System.Drawing.Size(103, 17);
            this.chkCopyAllUserDefinedDataTypes.TabIndex = 17;
            this.chkCopyAllUserDefinedDataTypes.Text = "Copy All UDDTs";
            this.chkCopyAllUserDefinedDataTypes.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllUserDefinedFunctions
            // 
            this.chkCopyAllUserDefinedFunctions.AutoSize = true;
            this.chkCopyAllUserDefinedFunctions.Checked = true;
            this.chkCopyAllUserDefinedFunctions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllUserDefinedFunctions.Location = new System.Drawing.Point(480, 3);
            this.chkCopyAllUserDefinedFunctions.Name = "chkCopyAllUserDefinedFunctions";
            this.chkCopyAllUserDefinedFunctions.Size = new System.Drawing.Size(94, 17);
            this.chkCopyAllUserDefinedFunctions.TabIndex = 18;
            this.chkCopyAllUserDefinedFunctions.Text = "Copy All UDFs";
            this.chkCopyAllUserDefinedFunctions.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllUserDefinedTableTypes
            // 
            this.chkCopyAllUserDefinedTableTypes.AutoSize = true;
            this.chkCopyAllUserDefinedTableTypes.Checked = true;
            this.chkCopyAllUserDefinedTableTypes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllUserDefinedTableTypes.Location = new System.Drawing.Point(480, 26);
            this.chkCopyAllUserDefinedTableTypes.Name = "chkCopyAllUserDefinedTableTypes";
            this.chkCopyAllUserDefinedTableTypes.Size = new System.Drawing.Size(102, 17);
            this.chkCopyAllUserDefinedTableTypes.TabIndex = 19;
            this.chkCopyAllUserDefinedTableTypes.Text = "Copy All UDTTs";
            this.chkCopyAllUserDefinedTableTypes.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllUserDefinedTypes
            // 
            this.chkCopyAllUserDefinedTypes.AutoSize = true;
            this.chkCopyAllUserDefinedTypes.Checked = true;
            this.chkCopyAllUserDefinedTypes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllUserDefinedTypes.Location = new System.Drawing.Point(480, 49);
            this.chkCopyAllUserDefinedTypes.Name = "chkCopyAllUserDefinedTypes";
            this.chkCopyAllUserDefinedTypes.Size = new System.Drawing.Size(95, 17);
            this.chkCopyAllUserDefinedTypes.TabIndex = 20;
            this.chkCopyAllUserDefinedTypes.Text = "Copy All UDTs";
            this.chkCopyAllUserDefinedTypes.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllUsers
            // 
            this.chkCopyAllUsers.AutoSize = true;
            this.chkCopyAllUsers.Checked = true;
            this.chkCopyAllUsers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllUsers.Location = new System.Drawing.Point(480, 72);
            this.chkCopyAllUsers.Name = "chkCopyAllUsers";
            this.chkCopyAllUsers.Size = new System.Drawing.Size(94, 17);
            this.chkCopyAllUsers.TabIndex = 21;
            this.chkCopyAllUsers.Text = "Copy All Users";
            this.chkCopyAllUsers.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllViews
            // 
            this.chkCopyAllViews.AutoSize = true;
            this.chkCopyAllViews.Checked = true;
            this.chkCopyAllViews.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllViews.Location = new System.Drawing.Point(480, 95);
            this.chkCopyAllViews.Name = "chkCopyAllViews";
            this.chkCopyAllViews.Size = new System.Drawing.Size(95, 17);
            this.chkCopyAllViews.TabIndex = 22;
            this.chkCopyAllViews.Text = "Copy All Views";
            this.chkCopyAllViews.UseVisualStyleBackColor = true;
            // 
            // chkCopyAllXmlSchemaCollections
            // 
            this.chkCopyAllXmlSchemaCollections.AutoSize = true;
            this.chkCopyAllXmlSchemaCollections.Checked = true;
            this.chkCopyAllXmlSchemaCollections.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyAllXmlSchemaCollections.Location = new System.Drawing.Point(480, 118);
            this.chkCopyAllXmlSchemaCollections.Name = "chkCopyAllXmlSchemaCollections";
            this.chkCopyAllXmlSchemaCollections.Size = new System.Drawing.Size(151, 17);
            this.chkCopyAllXmlSchemaCollections.TabIndex = 23;
            this.chkCopyAllXmlSchemaCollections.Text = "Copy All Xml Schema Colls";
            this.chkCopyAllXmlSchemaCollections.UseVisualStyleBackColor = true;
            // 
            // chkCopySchema
            // 
            this.chkCopySchema.AutoSize = true;
            this.chkCopySchema.Checked = true;
            this.chkCopySchema.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopySchema.Location = new System.Drawing.Point(162, 141);
            this.chkCopySchema.Name = "chkCopySchema";
            this.chkCopySchema.Size = new System.Drawing.Size(92, 17);
            this.chkCopySchema.TabIndex = 25;
            this.chkCopySchema.Text = "Copy Schema";
            this.chkCopySchema.UseVisualStyleBackColor = true;
            // 
            // chkCreateTargetDatabase
            // 
            this.chkCreateTargetDatabase.AutoSize = true;
            this.chkCreateTargetDatabase.Checked = true;
            this.chkCreateTargetDatabase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreateTargetDatabase.Location = new System.Drawing.Point(321, 141);
            this.chkCreateTargetDatabase.Name = "chkCreateTargetDatabase";
            this.chkCreateTargetDatabase.Size = new System.Drawing.Size(140, 17);
            this.chkCreateTargetDatabase.TabIndex = 26;
            this.chkCreateTargetDatabase.Text = "Create Target Database";
            this.chkCreateTargetDatabase.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtScript);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(677, 413);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Script";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtScript
            // 
            this.txtScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScript.Location = new System.Drawing.Point(4, 4);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtScript.Size = new System.Drawing.Size(670, 406);
            this.txtScript.TabIndex = 0;
            // 
            // chkCopyData
            // 
            this.chkCopyData.AutoSize = true;
            this.chkCopyData.Enabled = false;
            this.chkCopyData.Location = new System.Drawing.Point(3, 141);
            this.chkCopyData.Name = "chkCopyData";
            this.chkCopyData.Size = new System.Drawing.Size(76, 17);
            this.chkCopyData.TabIndex = 24;
            this.chkCopyData.Text = "Copy Data";
            this.chkCopyData.UseVisualStyleBackColor = true;
            this.chkCopyData.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 456);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Text = "Data Transfer";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.pnlServer2.ResumeLayout(false);
            this.pnlServer2.PerformLayout();
            this.pnlServer1.ResumeLayout(false);
            this.pnlServer1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Button cmdCompare;
        private System.Windows.Forms.Panel pnlServer2;
        private System.Windows.Forms.Button cmdRefreshServer2;
        private System.Windows.Forms.Label lblDatabase2;
        private System.Windows.Forms.ComboBox cboDatabase2;
        private System.Windows.Forms.Label lblPassword2;
        private System.Windows.Forms.Label lblUserName2;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.TextBox txtUser2;
        private System.Windows.Forms.RadioButton rbSQLServerAuthentication2;
        private System.Windows.Forms.RadioButton rbWindowsAuthentication2;
        private System.Windows.Forms.ComboBox cboServer2;
        private System.Windows.Forms.Label lblServer2;
        private System.Windows.Forms.Panel pnlServer1;
        private System.Windows.Forms.Button cmdRefreshServer1;
        private System.Windows.Forms.Label lblDatabase1;
        private System.Windows.Forms.ComboBox cboDatabase1;
        private System.Windows.Forms.Label lblPassword1;
        private System.Windows.Forms.Label lblUserName1;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.TextBox txtUser1;
        private System.Windows.Forms.RadioButton rbSQLServerAuthentication1;
        private System.Windows.Forms.RadioButton rbWindowsAuthentication1;
        private System.Windows.Forms.ComboBox cboServer1;
        private System.Windows.Forms.Label lblServer1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chkCopyAllDatabaseTriggers;
        private System.Windows.Forms.CheckBox chkCopyAllDefaults;
        private System.Windows.Forms.CheckBox chkCopyAllFullTextCatalogs;
        private System.Windows.Forms.CheckBox chkCopyAllFullTextStopLists;
        private System.Windows.Forms.CheckBox chkCopyAllLogins;
        private System.Windows.Forms.CheckBox chkCopyAllObjects;
        private System.Windows.Forms.CheckBox chkCopyAllPartitionFunctions;
        private System.Windows.Forms.CheckBox chkCopyAllPartitionSchemes;
        private System.Windows.Forms.CheckBox chkCopyAllPlanGuides;
        private System.Windows.Forms.CheckBox chkCopyAllRoles;
        private System.Windows.Forms.CheckBox chkCopyAllRules;
        private System.Windows.Forms.CheckBox chkCopyAllSchemas;
        private System.Windows.Forms.CheckBox chkCopyAllSqlAssemblies;
        private System.Windows.Forms.CheckBox chkCopyAllStoredProcedures;
        private System.Windows.Forms.CheckBox chkCopyAllSynonyms;
        private System.Windows.Forms.CheckBox chkCopyAllTables;
        private System.Windows.Forms.CheckBox chkCopyAllUserDefinedAggregates;
        private System.Windows.Forms.CheckBox chkCopyAllUserDefinedDataTypes;
        private System.Windows.Forms.CheckBox chkCopyAllUserDefinedFunctions;
        private System.Windows.Forms.CheckBox chkCopyAllUserDefinedTableTypes;
        private System.Windows.Forms.CheckBox chkCopyAllUserDefinedTypes;
        private System.Windows.Forms.CheckBox chkCopyAllUsers;
        private System.Windows.Forms.CheckBox chkCopyAllViews;
        private System.Windows.Forms.CheckBox chkCopyAllXmlSchemaCollections;
        private System.Windows.Forms.CheckBox chkCopySchema;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtScript;
        private System.Windows.Forms.CheckBox chkCreateTargetDatabase;
        private System.Windows.Forms.Button cmdTransferDbData;
        private System.Windows.Forms.CheckBox chkCopyData;

    }
}

