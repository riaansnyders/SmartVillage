namespace EngineersTools
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.tabsMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.numAllUnitsAutoPollMinutes = new System.Windows.Forms.NumericUpDown();
            this.cbAllUnitPollAutoTimer = new System.Windows.Forms.CheckBox();
            this.btnAllUnitPoll = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitsIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcpipaddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.switchstate1DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.switchstate2DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.switchstate3DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.switchstate4DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.switchstate5DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.switchstate6DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.switchstate7DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.switchstate8DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dsLiveSiteData = new EngineersTools.dsLiveSiteData();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbListOfIPAddress = new System.Windows.Forms.ComboBox();
            this.txtSingleIPPort = new System.Windows.Forms.TextBox();
            this.txtSingleIPAddr = new System.Windows.Forms.TextBox();
            this.btnSingleConnect = new System.Windows.Forms.Button();
            this.gbLS8Control = new System.Windows.Forms.GroupBox();
            this.btnGetSingleSwitchState = new System.Windows.Forms.Button();
            this.cbSingleSw5 = new System.Windows.Forms.CheckBox();
            this.cbSingleSw6 = new System.Windows.Forms.CheckBox();
            this.cbSingleSw7 = new System.Windows.Forms.CheckBox();
            this.cbSingleSw8 = new System.Windows.Forms.CheckBox();
            this.cbSingleSw4 = new System.Windows.Forms.CheckBox();
            this.cbSingleSw3 = new System.Windows.Forms.CheckBox();
            this.cbSingleSw2 = new System.Windows.Forms.CheckBox();
            this.cbSingleSw1 = new System.Windows.Forms.CheckBox();
            this.btnSendSingleSwitchState = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grpSettingsSiteConfig = new System.Windows.Forms.GroupBox();
            this.btnReadConfigFile = new System.Windows.Forms.Button();
            this.btnImportCSVConfigFile = new System.Windows.Forms.Button();
            this.btnSiteConfigFileOpen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfigXMLFileName = new System.Windows.Forms.TextBox();
            this.grpSettingsProtocol = new System.Windows.Forms.GroupBox();
            this.btnDeviceProtocolSettingReset = new System.Windows.Forms.Button();
            this.numDeviceProtocolPortNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDeviceProtocolEncoding = new System.Windows.Forms.ComboBox();
            this.dtSiteDataStatusViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dlgOpenXMLFile = new System.Windows.Forms.OpenFileDialog();
            this.dlgOpenCSVTXTFile = new System.Windows.Forms.OpenFileDialog();
            this.tmrPollAllUnit = new System.Windows.Forms.Timer(this.components);
            this.tabsMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAllUnitsAutoPollMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLiveSiteData)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.gbLS8Control.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.grpSettingsSiteConfig.SuspendLayout();
            this.grpSettingsProtocol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDeviceProtocolPortNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSiteDataStatusViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabsMain
            // 
            this.tabsMain.Controls.Add(this.tabPage1);
            this.tabsMain.Controls.Add(this.tabPage2);
            this.tabsMain.Controls.Add(this.tabPage3);
            this.tabsMain.Location = new System.Drawing.Point(6, 9);
            this.tabsMain.Name = "tabsMain";
            this.tabsMain.SelectedIndex = 0;
            this.tabsMain.Size = new System.Drawing.Size(1000, 640);
            this.tabsMain.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.numAllUnitsAutoPollMinutes);
            this.tabPage1.Controls.Add(this.cbAllUnitPollAutoTimer);
            this.tabPage1.Controls.Add(this.btnAllUnitPoll);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(992, 614);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "All Units";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(359, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "minutes";
            // 
            // numAllUnitsAutoPollMinutes
            // 
            this.numAllUnitsAutoPollMinutes.Location = new System.Drawing.Point(233, 16);
            this.numAllUnitsAutoPollMinutes.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numAllUnitsAutoPollMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAllUnitsAutoPollMinutes.Name = "numAllUnitsAutoPollMinutes";
            this.numAllUnitsAutoPollMinutes.Size = new System.Drawing.Size(120, 20);
            this.numAllUnitsAutoPollMinutes.TabIndex = 22;
            this.numAllUnitsAutoPollMinutes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbAllUnitPollAutoTimer
            // 
            this.cbAllUnitPollAutoTimer.AutoSize = true;
            this.cbAllUnitPollAutoTimer.Location = new System.Drawing.Point(91, 19);
            this.cbAllUnitPollAutoTimer.Name = "cbAllUnitPollAutoTimer";
            this.cbAllUnitPollAutoTimer.Size = new System.Drawing.Size(136, 17);
            this.cbAllUnitPollAutoTimer.TabIndex = 21;
            this.cbAllUnitPollAutoTimer.Text = "Automatic Polling every";
            this.cbAllUnitPollAutoTimer.UseVisualStyleBackColor = true;
            this.cbAllUnitPollAutoTimer.CheckedChanged += new System.EventHandler(this.cbAllUnitPollAutoTimer_CheckedChanged);
            // 
            // btnAllUnitPoll
            // 
            this.btnAllUnitPoll.Location = new System.Drawing.Point(9, 14);
            this.btnAllUnitPoll.Name = "btnAllUnitPoll";
            this.btnAllUnitPoll.Size = new System.Drawing.Size(75, 23);
            this.btnAllUnitPoll.TabIndex = 20;
            this.btnAllUnitPoll.Text = "Poll All Units";
            this.btnAllUnitPoll.UseVisualStyleBackColor = true;
            this.btnAllUnitPoll.Click += new System.EventHandler(this.btnAllUnitPoll_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.unitsIDDataGridViewTextBoxColumn,
            this.tcpipaddressDataGridViewTextBoxColumn,
            this.unitnameDataGridViewTextBoxColumn,
            this.switchstate1DataGridViewCheckBoxColumn,
            this.switchstate2DataGridViewCheckBoxColumn,
            this.switchstate3DataGridViewCheckBoxColumn,
            this.switchstate4DataGridViewCheckBoxColumn,
            this.switchstate5DataGridViewCheckBoxColumn,
            this.switchstate6DataGridViewCheckBoxColumn,
            this.switchstate7DataGridViewCheckBoxColumn,
            this.switchstate8DataGridViewCheckBoxColumn});
            this.dataGridView1.DataMember = "dtSiteDataStatusView";
            this.dataGridView1.DataSource = this.dsLiveSiteData;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dataGridView1.Location = new System.Drawing.Point(9, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(977, 490);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // unitsIDDataGridViewTextBoxColumn
            // 
            this.unitsIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.unitsIDDataGridViewTextBoxColumn.DataPropertyName = "UnitsID";
            this.unitsIDDataGridViewTextBoxColumn.HeaderText = "Unit ID";
            this.unitsIDDataGridViewTextBoxColumn.Name = "unitsIDDataGridViewTextBoxColumn";
            this.unitsIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitsIDDataGridViewTextBoxColumn.Width = 65;
            // 
            // tcpipaddressDataGridViewTextBoxColumn
            // 
            this.tcpipaddressDataGridViewTextBoxColumn.DataPropertyName = "tcpipaddress";
            this.tcpipaddressDataGridViewTextBoxColumn.HeaderText = "IP Address";
            this.tcpipaddressDataGridViewTextBoxColumn.Name = "tcpipaddressDataGridViewTextBoxColumn";
            this.tcpipaddressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitnameDataGridViewTextBoxColumn
            // 
            this.unitnameDataGridViewTextBoxColumn.DataPropertyName = "unitname";
            this.unitnameDataGridViewTextBoxColumn.HeaderText = "Unit Name";
            this.unitnameDataGridViewTextBoxColumn.Name = "unitnameDataGridViewTextBoxColumn";
            this.unitnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitnameDataGridViewTextBoxColumn.Width = 180;
            // 
            // switchstate1DataGridViewCheckBoxColumn
            // 
            this.switchstate1DataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.switchstate1DataGridViewCheckBoxColumn.DataPropertyName = "switchstate1";
            this.switchstate1DataGridViewCheckBoxColumn.HeaderText = "switchstate1";
            this.switchstate1DataGridViewCheckBoxColumn.Name = "switchstate1DataGridViewCheckBoxColumn";
            this.switchstate1DataGridViewCheckBoxColumn.Width = 72;
            // 
            // switchstate2DataGridViewCheckBoxColumn
            // 
            this.switchstate2DataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.switchstate2DataGridViewCheckBoxColumn.DataPropertyName = "switchstate2";
            this.switchstate2DataGridViewCheckBoxColumn.HeaderText = "switchstate2";
            this.switchstate2DataGridViewCheckBoxColumn.Name = "switchstate2DataGridViewCheckBoxColumn";
            this.switchstate2DataGridViewCheckBoxColumn.Width = 72;
            // 
            // switchstate3DataGridViewCheckBoxColumn
            // 
            this.switchstate3DataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.switchstate3DataGridViewCheckBoxColumn.DataPropertyName = "switchstate3";
            this.switchstate3DataGridViewCheckBoxColumn.HeaderText = "switchstate3";
            this.switchstate3DataGridViewCheckBoxColumn.Name = "switchstate3DataGridViewCheckBoxColumn";
            this.switchstate3DataGridViewCheckBoxColumn.Width = 72;
            // 
            // switchstate4DataGridViewCheckBoxColumn
            // 
            this.switchstate4DataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.switchstate4DataGridViewCheckBoxColumn.DataPropertyName = "switchstate4";
            this.switchstate4DataGridViewCheckBoxColumn.HeaderText = "switchstate4";
            this.switchstate4DataGridViewCheckBoxColumn.Name = "switchstate4DataGridViewCheckBoxColumn";
            this.switchstate4DataGridViewCheckBoxColumn.Width = 72;
            // 
            // switchstate5DataGridViewCheckBoxColumn
            // 
            this.switchstate5DataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.switchstate5DataGridViewCheckBoxColumn.DataPropertyName = "switchstate5";
            this.switchstate5DataGridViewCheckBoxColumn.HeaderText = "switchstate5";
            this.switchstate5DataGridViewCheckBoxColumn.Name = "switchstate5DataGridViewCheckBoxColumn";
            this.switchstate5DataGridViewCheckBoxColumn.Width = 72;
            // 
            // switchstate6DataGridViewCheckBoxColumn
            // 
            this.switchstate6DataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.switchstate6DataGridViewCheckBoxColumn.DataPropertyName = "switchstate6";
            this.switchstate6DataGridViewCheckBoxColumn.HeaderText = "switchstate6";
            this.switchstate6DataGridViewCheckBoxColumn.Name = "switchstate6DataGridViewCheckBoxColumn";
            this.switchstate6DataGridViewCheckBoxColumn.Width = 72;
            // 
            // switchstate7DataGridViewCheckBoxColumn
            // 
            this.switchstate7DataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.switchstate7DataGridViewCheckBoxColumn.DataPropertyName = "switchstate7";
            this.switchstate7DataGridViewCheckBoxColumn.HeaderText = "switchstate7";
            this.switchstate7DataGridViewCheckBoxColumn.Name = "switchstate7DataGridViewCheckBoxColumn";
            this.switchstate7DataGridViewCheckBoxColumn.Width = 72;
            // 
            // switchstate8DataGridViewCheckBoxColumn
            // 
            this.switchstate8DataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.switchstate8DataGridViewCheckBoxColumn.DataPropertyName = "switchstate8";
            this.switchstate8DataGridViewCheckBoxColumn.HeaderText = "switchstate8";
            this.switchstate8DataGridViewCheckBoxColumn.Name = "switchstate8DataGridViewCheckBoxColumn";
            this.switchstate8DataGridViewCheckBoxColumn.Width = 72;
            // 
            // dsLiveSiteData
            // 
            this.dsLiveSiteData.DataSetName = "dsLiveSiteData";
            this.dsLiveSiteData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.cmbListOfIPAddress);
            this.tabPage2.Controls.Add(this.txtSingleIPPort);
            this.tabPage2.Controls.Add(this.txtSingleIPAddr);
            this.tabPage2.Controls.Add(this.btnSingleConnect);
            this.tabPage2.Controls.Add(this.gbLS8Control);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(992, 614);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Single Unit";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "IP Address";
            // 
            // cmbListOfIPAddress
            // 
            this.cmbListOfIPAddress.FormattingEnabled = true;
            this.cmbListOfIPAddress.Location = new System.Drawing.Point(10, 27);
            this.cmbListOfIPAddress.Name = "cmbListOfIPAddress";
            this.cmbListOfIPAddress.Size = new System.Drawing.Size(179, 21);
            this.cmbListOfIPAddress.TabIndex = 21;
            // 
            // txtSingleIPPort
            // 
            this.txtSingleIPPort.Enabled = false;
            this.txtSingleIPPort.Location = new System.Drawing.Point(368, 28);
            this.txtSingleIPPort.Name = "txtSingleIPPort";
            this.txtSingleIPPort.Size = new System.Drawing.Size(108, 20);
            this.txtSingleIPPort.TabIndex = 20;
            this.txtSingleIPPort.Text = "9000";
            this.txtSingleIPPort.Visible = false;
            // 
            // txtSingleIPAddr
            // 
            this.txtSingleIPAddr.Enabled = false;
            this.txtSingleIPAddr.Location = new System.Drawing.Point(208, 28);
            this.txtSingleIPAddr.Name = "txtSingleIPAddr";
            this.txtSingleIPAddr.Size = new System.Drawing.Size(164, 20);
            this.txtSingleIPAddr.TabIndex = 19;
            this.txtSingleIPAddr.Text = "IPaddress";
            this.txtSingleIPAddr.Visible = false;
            // 
            // btnSingleConnect
            // 
            this.btnSingleConnect.Location = new System.Drawing.Point(10, 63);
            this.btnSingleConnect.Name = "btnSingleConnect";
            this.btnSingleConnect.Size = new System.Drawing.Size(127, 46);
            this.btnSingleConnect.TabIndex = 18;
            this.btnSingleConnect.Text = "Connect";
            this.btnSingleConnect.UseVisualStyleBackColor = true;
            this.btnSingleConnect.Click += new System.EventHandler(this.btnSingleConnect_Click);
            // 
            // gbLS8Control
            // 
            this.gbLS8Control.Controls.Add(this.btnGetSingleSwitchState);
            this.gbLS8Control.Controls.Add(this.cbSingleSw5);
            this.gbLS8Control.Controls.Add(this.cbSingleSw6);
            this.gbLS8Control.Controls.Add(this.cbSingleSw7);
            this.gbLS8Control.Controls.Add(this.cbSingleSw8);
            this.gbLS8Control.Controls.Add(this.cbSingleSw4);
            this.gbLS8Control.Controls.Add(this.cbSingleSw3);
            this.gbLS8Control.Controls.Add(this.cbSingleSw2);
            this.gbLS8Control.Controls.Add(this.cbSingleSw1);
            this.gbLS8Control.Controls.Add(this.btnSendSingleSwitchState);
            this.gbLS8Control.Location = new System.Drawing.Point(6, 131);
            this.gbLS8Control.Name = "gbLS8Control";
            this.gbLS8Control.Size = new System.Drawing.Size(495, 148);
            this.gbLS8Control.TabIndex = 17;
            this.gbLS8Control.TabStop = false;
            this.gbLS8Control.Text = "Resident Brava LS-8 ";
            // 
            // btnGetSingleSwitchState
            // 
            this.btnGetSingleSwitchState.Location = new System.Drawing.Point(27, 97);
            this.btnGetSingleSwitchState.Name = "btnGetSingleSwitchState";
            this.btnGetSingleSwitchState.Size = new System.Drawing.Size(138, 34);
            this.btnGetSingleSwitchState.TabIndex = 9;
            this.btnGetSingleSwitchState.Text = "Read Switch State";
            this.btnGetSingleSwitchState.UseVisualStyleBackColor = true;
            this.btnGetSingleSwitchState.Click += new System.EventHandler(this.btnGetSingleSwitchState_Click);
            // 
            // cbSingleSw5
            // 
            this.cbSingleSw5.AutoSize = true;
            this.cbSingleSw5.Location = new System.Drawing.Point(18, 58);
            this.cbSingleSw5.Name = "cbSingleSw5";
            this.cbSingleSw5.Size = new System.Drawing.Size(64, 17);
            this.cbSingleSw5.TabIndex = 8;
            this.cbSingleSw5.Text = "Switch5";
            this.cbSingleSw5.UseVisualStyleBackColor = true;
            // 
            // cbSingleSw6
            // 
            this.cbSingleSw6.AutoSize = true;
            this.cbSingleSw6.Location = new System.Drawing.Point(128, 58);
            this.cbSingleSw6.Name = "cbSingleSw6";
            this.cbSingleSw6.Size = new System.Drawing.Size(64, 17);
            this.cbSingleSw6.TabIndex = 7;
            this.cbSingleSw6.Text = "Switch6";
            this.cbSingleSw6.UseVisualStyleBackColor = true;
            // 
            // cbSingleSw7
            // 
            this.cbSingleSw7.AutoSize = true;
            this.cbSingleSw7.Location = new System.Drawing.Point(249, 58);
            this.cbSingleSw7.Name = "cbSingleSw7";
            this.cbSingleSw7.Size = new System.Drawing.Size(64, 17);
            this.cbSingleSw7.TabIndex = 6;
            this.cbSingleSw7.Text = "Switch7";
            this.cbSingleSw7.UseVisualStyleBackColor = true;
            // 
            // cbSingleSw8
            // 
            this.cbSingleSw8.AutoSize = true;
            this.cbSingleSw8.Location = new System.Drawing.Point(380, 58);
            this.cbSingleSw8.Name = "cbSingleSw8";
            this.cbSingleSw8.Size = new System.Drawing.Size(64, 17);
            this.cbSingleSw8.TabIndex = 5;
            this.cbSingleSw8.Text = "Switch8";
            this.cbSingleSw8.UseVisualStyleBackColor = true;
            // 
            // cbSingleSw4
            // 
            this.cbSingleSw4.AutoSize = true;
            this.cbSingleSw4.Location = new System.Drawing.Point(380, 28);
            this.cbSingleSw4.Name = "cbSingleSw4";
            this.cbSingleSw4.Size = new System.Drawing.Size(64, 17);
            this.cbSingleSw4.TabIndex = 4;
            this.cbSingleSw4.Text = "Switch4";
            this.cbSingleSw4.UseVisualStyleBackColor = true;
            // 
            // cbSingleSw3
            // 
            this.cbSingleSw3.AutoSize = true;
            this.cbSingleSw3.Location = new System.Drawing.Point(249, 28);
            this.cbSingleSw3.Name = "cbSingleSw3";
            this.cbSingleSw3.Size = new System.Drawing.Size(64, 17);
            this.cbSingleSw3.TabIndex = 3;
            this.cbSingleSw3.Text = "Switch3";
            this.cbSingleSw3.UseVisualStyleBackColor = true;
            // 
            // cbSingleSw2
            // 
            this.cbSingleSw2.AutoSize = true;
            this.cbSingleSw2.Location = new System.Drawing.Point(128, 28);
            this.cbSingleSw2.Name = "cbSingleSw2";
            this.cbSingleSw2.Size = new System.Drawing.Size(64, 17);
            this.cbSingleSw2.TabIndex = 2;
            this.cbSingleSw2.Text = "Switch2";
            this.cbSingleSw2.UseVisualStyleBackColor = true;
            // 
            // cbSingleSw1
            // 
            this.cbSingleSw1.AutoSize = true;
            this.cbSingleSw1.Location = new System.Drawing.Point(18, 28);
            this.cbSingleSw1.Name = "cbSingleSw1";
            this.cbSingleSw1.Size = new System.Drawing.Size(64, 17);
            this.cbSingleSw1.TabIndex = 1;
            this.cbSingleSw1.Text = "Switch1";
            this.cbSingleSw1.UseVisualStyleBackColor = true;
            // 
            // btnSendSingleSwitchState
            // 
            this.btnSendSingleSwitchState.Location = new System.Drawing.Point(211, 97);
            this.btnSendSingleSwitchState.Name = "btnSendSingleSwitchState";
            this.btnSendSingleSwitchState.Size = new System.Drawing.Size(138, 34);
            this.btnSendSingleSwitchState.TabIndex = 0;
            this.btnSendSingleSwitchState.Text = "Send Switch State";
            this.btnSendSingleSwitchState.UseVisualStyleBackColor = true;
            this.btnSendSingleSwitchState.Click += new System.EventHandler(this.btnSendSingleSwitchState_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grpSettingsSiteConfig);
            this.tabPage3.Controls.Add(this.grpSettingsProtocol);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(992, 614);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grpSettingsSiteConfig
            // 
            this.grpSettingsSiteConfig.Controls.Add(this.btnReadConfigFile);
            this.grpSettingsSiteConfig.Controls.Add(this.btnImportCSVConfigFile);
            this.grpSettingsSiteConfig.Controls.Add(this.btnSiteConfigFileOpen);
            this.grpSettingsSiteConfig.Controls.Add(this.label3);
            this.grpSettingsSiteConfig.Controls.Add(this.txtConfigXMLFileName);
            this.grpSettingsSiteConfig.Location = new System.Drawing.Point(15, 160);
            this.grpSettingsSiteConfig.Name = "grpSettingsSiteConfig";
            this.grpSettingsSiteConfig.Size = new System.Drawing.Size(432, 163);
            this.grpSettingsSiteConfig.TabIndex = 3;
            this.grpSettingsSiteConfig.TabStop = false;
            this.grpSettingsSiteConfig.Text = "Site Configuration File";
            // 
            // btnReadConfigFile
            // 
            this.btnReadConfigFile.Location = new System.Drawing.Point(148, 134);
            this.btnReadConfigFile.Name = "btnReadConfigFile";
            this.btnReadConfigFile.Size = new System.Drawing.Size(83, 23);
            this.btnReadConfigFile.TabIndex = 4;
            this.btnReadConfigFile.Text = "Read Config";
            this.btnReadConfigFile.UseVisualStyleBackColor = true;
            this.btnReadConfigFile.Click += new System.EventHandler(this.btnApplyConfigFile_Click);
            // 
            // btnImportCSVConfigFile
            // 
            this.btnImportCSVConfigFile.Location = new System.Drawing.Point(7, 69);
            this.btnImportCSVConfigFile.Name = "btnImportCSVConfigFile";
            this.btnImportCSVConfigFile.Size = new System.Drawing.Size(106, 23);
            this.btnImportCSVConfigFile.TabIndex = 3;
            this.btnImportCSVConfigFile.Text = "Import CSV File";
            this.btnImportCSVConfigFile.UseVisualStyleBackColor = true;
            // 
            // btnSiteConfigFileOpen
            // 
            this.btnSiteConfigFileOpen.Location = new System.Drawing.Point(359, 41);
            this.btnSiteConfigFileOpen.Name = "btnSiteConfigFileOpen";
            this.btnSiteConfigFileOpen.Size = new System.Drawing.Size(66, 23);
            this.btnSiteConfigFileOpen.TabIndex = 2;
            this.btnSiteConfigFileOpen.Text = "Browse...";
            this.btnSiteConfigFileOpen.UseVisualStyleBackColor = true;
            this.btnSiteConfigFileOpen.Click += new System.EventHandler(this.btnSiteConfigFileOpen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Site XML Configuration File";
            // 
            // txtConfigXMLFileName
            // 
            this.txtConfigXMLFileName.Location = new System.Drawing.Point(7, 43);
            this.txtConfigXMLFileName.Name = "txtConfigXMLFileName";
            this.txtConfigXMLFileName.ReadOnly = true;
            this.txtConfigXMLFileName.Size = new System.Drawing.Size(352, 20);
            this.txtConfigXMLFileName.TabIndex = 0;
            // 
            // grpSettingsProtocol
            // 
            this.grpSettingsProtocol.Controls.Add(this.btnDeviceProtocolSettingReset);
            this.grpSettingsProtocol.Controls.Add(this.numDeviceProtocolPortNum);
            this.grpSettingsProtocol.Controls.Add(this.label2);
            this.grpSettingsProtocol.Controls.Add(this.label1);
            this.grpSettingsProtocol.Controls.Add(this.cmbDeviceProtocolEncoding);
            this.grpSettingsProtocol.Location = new System.Drawing.Point(15, 14);
            this.grpSettingsProtocol.Name = "grpSettingsProtocol";
            this.grpSettingsProtocol.Size = new System.Drawing.Size(304, 139);
            this.grpSettingsProtocol.TabIndex = 2;
            this.grpSettingsProtocol.TabStop = false;
            this.grpSettingsProtocol.Text = "Device Protocol";
            // 
            // btnDeviceProtocolSettingReset
            // 
            this.btnDeviceProtocolSettingReset.Location = new System.Drawing.Point(136, 105);
            this.btnDeviceProtocolSettingReset.Name = "btnDeviceProtocolSettingReset";
            this.btnDeviceProtocolSettingReset.Size = new System.Drawing.Size(124, 23);
            this.btnDeviceProtocolSettingReset.TabIndex = 4;
            this.btnDeviceProtocolSettingReset.Text = "Default Values";
            this.btnDeviceProtocolSettingReset.UseVisualStyleBackColor = true;
            // 
            // numDeviceProtocolPortNum
            // 
            this.numDeviceProtocolPortNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numDeviceProtocolPortNum.Location = new System.Drawing.Point(7, 33);
            this.numDeviceProtocolPortNum.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numDeviceProtocolPortNum.Name = "numDeviceProtocolPortNum";
            this.numDeviceProtocolPortNum.Size = new System.Drawing.Size(113, 20);
            this.numDeviceProtocolPortNum.TabIndex = 1;
            this.numDeviceProtocolPortNum.Value = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "TCP Port Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Protocol Encoding";
            // 
            // cmbDeviceProtocolEncoding
            // 
            this.cmbDeviceProtocolEncoding.Enabled = false;
            this.cmbDeviceProtocolEncoding.FormattingEnabled = true;
            this.cmbDeviceProtocolEncoding.Items.AddRange(new object[] {
            "Binary",
            "XML (TODO)"});
            this.cmbDeviceProtocolEncoding.Location = new System.Drawing.Point(7, 78);
            this.cmbDeviceProtocolEncoding.Name = "cmbDeviceProtocolEncoding";
            this.cmbDeviceProtocolEncoding.Size = new System.Drawing.Size(200, 21);
            this.cmbDeviceProtocolEncoding.TabIndex = 2;
            this.cmbDeviceProtocolEncoding.Text = "Binary";
            // 
            // dtSiteDataStatusViewBindingSource
            // 
            this.dtSiteDataStatusViewBindingSource.DataMember = "dtSiteDataStatusView";
            this.dtSiteDataStatusViewBindingSource.DataSource = this.dsLiveSiteData;
            // 
            // dlgOpenXMLFile
            // 
            this.dlgOpenXMLFile.Filter = "\"xml files|*.xml\"";
            this.dlgOpenXMLFile.Title = "Select XML File";
            // 
            // dlgOpenCSVTXTFile
            // 
            this.dlgOpenCSVTXTFile.Filter = "\"csv files|*.csv|txt files|*.txt|All files|*.*";
            this.dlgOpenCSVTXTFile.Title = "Open CSV or TXT file";
            // 
            // tmrPollAllUnit
            // 
            this.tmrPollAllUnit.Interval = 10000;
            this.tmrPollAllUnit.Tick += new System.EventHandler(this.btnAllUnitPoll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 609);
            this.Controls.Add(this.tabsMain);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabsMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAllUnitsAutoPollMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLiveSiteData)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.gbLS8Control.ResumeLayout(false);
            this.gbLS8Control.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.grpSettingsSiteConfig.ResumeLayout(false);
            this.grpSettingsSiteConfig.PerformLayout();
            this.grpSettingsProtocol.ResumeLayout(false);
            this.grpSettingsProtocol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDeviceProtocolPortNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSiteDataStatusViewBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtSingleIPPort;
        private System.Windows.Forms.TextBox txtSingleIPAddr;
        private System.Windows.Forms.Button btnSingleConnect;
        private System.Windows.Forms.GroupBox gbLS8Control;
        private System.Windows.Forms.CheckBox cbSingleSw5;
        private System.Windows.Forms.CheckBox cbSingleSw6;
        private System.Windows.Forms.CheckBox cbSingleSw7;
        private System.Windows.Forms.CheckBox cbSingleSw8;
        private System.Windows.Forms.CheckBox cbSingleSw4;
        private System.Windows.Forms.CheckBox cbSingleSw3;
        private System.Windows.Forms.CheckBox cbSingleSw2;
        private System.Windows.Forms.CheckBox cbSingleSw1;
        private System.Windows.Forms.Button btnSendSingleSwitchState;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox grpSettingsProtocol;
        private System.Windows.Forms.Button btnDeviceProtocolSettingReset;
        private System.Windows.Forms.NumericUpDown numDeviceProtocolPortNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDeviceProtocolEncoding;
        private System.Windows.Forms.GroupBox grpSettingsSiteConfig;
        private System.Windows.Forms.Button btnImportCSVConfigFile;
        private System.Windows.Forms.Button btnSiteConfigFileOpen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConfigXMLFileName;
        private System.Windows.Forms.OpenFileDialog dlgOpenXMLFile;
        private System.Windows.Forms.OpenFileDialog dlgOpenCSVTXTFile;
        private System.Windows.Forms.ComboBox cmbListOfIPAddress;
        private System.Windows.Forms.Button btnReadConfigFile;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource dtSiteDataStatusViewBindingSource;
        private dsLiveSiteData dsLiveSiteData;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitsIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcpipaddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn switchstate1DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn switchstate2DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn switchstate3DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn switchstate4DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn switchstate5DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn switchstate6DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn switchstate7DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn switchstate8DataGridViewCheckBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetSingleSwitchState;
        private System.Windows.Forms.CheckBox cbAllUnitPollAutoTimer;
        private System.Windows.Forms.Button btnAllUnitPoll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numAllUnitsAutoPollMinutes;
        private System.Windows.Forms.Timer tmrPollAllUnit;
    }
}

