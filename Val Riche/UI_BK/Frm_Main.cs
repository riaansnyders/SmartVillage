namespace lfa.pmgmt.ui
{
    #region Using Directives
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    using lfa.pmgmt.data.DAO.BusinessRule;
    using lfa.pmgmt.data.DAO.Configuration;
    using lfa.pmgmt.data.DAO.Schedule;

    using lfa.pmgmt.data.DTO.BusinessRule;
    using lfa.pmgmt.data.DTO.Configuration;
    using lfa.pmgmt.data.DTO.Schedule;

    using BravaSystem.Communication;
    #endregion

    public partial class Frm_Main : Form
    {
        private static string _pageTitle = string.Empty;
        private static string _connectionString = string.Empty;
        private static string _currentModule = string.Empty;

        private static bool _loadComplete = false;

        private static int _selectedItemDataId = 0;

        #region Constructor
        public Frm_Main()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Load Event Handler
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            try
            {
                ClearAllItems();

                lblHeader.Text = "Management :: Configuration";

                _currentModule = "Configuration";

                SetPageTitle();

               _connectionString = GetConnectionString();

               BindConfigurationData();

               _loadComplete = true;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        #endregion

        #region Set Page Title
        private void SetPageTitle()
        {
            _pageTitle = ConfigurationManager.AppSettings["ApplicationTitle"];

            this.Text = " " + _pageTitle;
        }
        #endregion

        #region Get SQL Connection String
        private static string GetConnectionString()
        {
           return ConfigurationManager.AppSettings["ConnectionString"];
        }
        #endregion

        #region Bind Configuration Data
        private void BindConfigurationData()
        {
            _loadComplete = false;

            lfa.pmgmt.data.DAO.Configuration.Zone zoneDAO = new data.DAO.Configuration.Zone();
            zoneDAO.ConnectionString = _connectionString;

            List<lfa.pmgmt.data.DTO.Configuration.Zone> zoneList = zoneDAO.List();

            btnGrdMainHeader.Text = "Zones";
            grdMain.DataSource = zoneList;

            btnGrdChildOneHeader.Text = "Units";

            btnGrdChildTwoHeader.Text = "Devices";

            _loadComplete = true;
        }
        #endregion

        #region Clear All Items
        private void ClearAllItems()
        {
            lblHeader.Text = string.Empty;
            button2.Visible = false;

            button6.Visible = false;
            button5.Visible = false;

            btnGrdMainHeader.Text = string.Empty;
            btnGrdChildOneHeader.Text = string.Empty;
            btnGrdChildTwoHeader.Text = string.Empty;

            grdMain.DataSource = null;
            grdChildOne.DataSource = null;
            grdChildTwo.DataSource = null;

            if (grdChildTwo.Columns.Count > 0)
            {
                grdChildTwo.Columns.Clear();
            }

            grdChildTwo.Rows.Clear();

            btnLoadShed.Visible = false;

            _selectedItemDataId = 0;
        }

        private void ClearAllItemsForRefresh()
        {
            button2.Visible = false;
            button5.Visible = false;
            button6.Visible = false;

            btnGrdMainHeader.Text = string.Empty;
            btnGrdChildOneHeader.Text = string.Empty;
            btnGrdChildTwoHeader.Text = string.Empty;

            grdMain.DataSource = null;
            grdChildOne.DataSource = null;
            grdChildTwo.DataSource = null;

            if (grdChildTwo.Columns.Count > 0)
            {
                grdChildTwo.Columns.Clear();
            }

            grdChildTwo.Rows.Clear();

            btnLoadShed.Visible = false;

            _selectedItemDataId = 0;
        }
        #endregion

        #region Save Event Handler
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_loadComplete)
            {
                switch (_currentModule)
                {
                    case "Configuration":

                        try
                        {
                            BulkUpdateConfiguration();
                        }
                        catch (Exception ex)
                        {
                            HandleException(ex);
                        }

                        break;
                    case "Schedule":
                        try
                        {
                            BulkUpdateSchedule();
                        }
                        catch (Exception ex)
                        {
                            HandleException(ex);
                        }

                        break;
                    case "LoadShed":
                        HandleInformationMesssage("Load shedding data can not be saved! Data is only for control purposes!");
                        break;
                    case "Rules":
                        HandleInformationMesssage("This action is disabled for power management rules!");
                        break;
                }
            }
        }
        #endregion

        #region Schedule Event Handler
        private void btnSchedule_Click(object sender, EventArgs e)
        {
            _loadComplete = false;

            _currentModule = "Schedule";

            ClearAllItems();

            BindScheduleData();

            button6.Visible = true;

            lblHeader.Text = "Management :: Scheduling";

            _loadComplete = true;
        }
        #endregion

        #region Bind Schedule Data
        private void BindScheduleData()
        {
            lfa.pmgmt.data.DAO.Schedule.Schedule scheduleDAO = new data.DAO.Schedule.Schedule();
            scheduleDAO.ConnectionString = _connectionString;

            List<lfa.pmgmt.data.DTO.Schedule.Schedule> list = scheduleDAO.List();

            btnGrdMainHeader.Text = "Schedules";
            grdMain.DataSource = list;

            btnGrdChildOneHeader.Text = "Units";

            btnGrdChildTwoHeader.Text = "Devices";
        }
        #endregion

        #region Business Rules Setup Button Event Handler
        private void btnSetupRules_Click(object sender, EventArgs e)
        {
            _currentModule = "Rules";

            _loadComplete = false;

            ClearAllItems();

            BindLoadShedRules();

            lblHeader.Text = "Load Management Rules :: Management";

            _loadComplete = true;
        }
        #endregion

        #region Usage Report Button Event Handler
        private void btnUsageReport_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "Reports :: View Usage";

            HandleInformationMesssage("Feauture currently not enabled!");
        }
        #endregion

        #region Information Handlers
        private void HandleException(Exception ex)
        {
            MessageBox.Show("The following exception has occured: " + ex.ToString(), _pageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void HandleInformationMesssage(string message)
        {
            MessageBox.Show(message, _pageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Manual Load Shedding Event Handler
        private void btnShedding_Click(object sender, EventArgs e)
        {
            _loadComplete = false;

            _currentModule = "LoadShed";

            ClearAllItems();

            lblHeader.Text = "Management :: Power Management";

            BindLoadShedData();
        }
        #endregion

        #region Refresh Button Event Handler
        private void button1_Click(object sender, EventArgs e)
        {
            _loadComplete = false;

            ClearAllItemsForRefresh();

            switch (_currentModule)
            {
                case "Configuration":
                    BindConfigurationData();
                    break;
                case "Schedule":
                    BindScheduleData();
                    break;
                case "Rules":
                    BindLoadShedRules();
                    break;
                default:
                    BindConfigurationData();
                    break;
            }

            HandleInformationMesssage("Data Refreshed! Please select an item from the main grid to view details!");
            _loadComplete = true;
        }
        #endregion

        #region Configuration Button Event Handler
        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            _loadComplete = false;

            _currentModule = "Configuration";

            ClearAllItems();

            lblHeader.Text = "Management :: Configuration";

            BindConfigurationData();
        }
        #endregion

        #region Main Grid Add New Button Event Handler
        private void btnGrdmain_AddNew_Click(object sender, EventArgs e)
        {
            switch (_currentModule)
            {
                case "Configuration":
                    Forms.Frm_AddNew_Zone frmAddNewZone = new Forms.Frm_AddNew_Zone();
                    frmAddNewZone.ShowDialog();

                    ClearAllItemsForRefresh();

                    BindConfigurationData();

                    break;
                case "Schedule":
                    Forms.Frm_AddNew_Schedule frmAddNewSchedule = new Forms.Frm_AddNew_Schedule();
                    frmAddNewSchedule.ShowDialog();
                    
                    ClearAllItemsForRefresh();

                    BindScheduleData();

                    break;
                case "LoadShed":
                    HandleInformationMesssage("Load shedding data can not be saved! Data is only for control purposes!");
                    break;
                case "Rules":
                    Forms.Frm_AddNew_RuleSet frmAddNewRuleSet = new Forms.Frm_AddNew_RuleSet();
                    frmAddNewRuleSet.ShowDialog();
                    break;
            }
        }
        #endregion

        #region Main Grid Row Select Event Handler
        private void grdMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = null;

            if (_loadComplete)
            {
                switch (_currentModule)
                {
                    case "Configuration":
                        selectedRow = grdMain.SelectedRows[0];
                        _selectedItemDataId = int.Parse(selectedRow.Cells[0].Value.ToString());

                        _loadComplete = false;
                         
                        lfa.pmgmt.data.DAO.Configuration.Unit unitDAO = new data.DAO.Configuration.Unit();
                        unitDAO.ConnectionString = _connectionString;
                        List<lfa.pmgmt.data.DTO.Configuration.Unit> unitList = unitDAO.List(_selectedItemDataId);

                        grdChildOne.DataSource = unitList;

                        grdChildOne.Columns[0].Visible = false;
                        grdChildOne.Columns[1].Visible = false;

                        grdChildTwo.Columns.Clear();
                        grdChildTwo.DataSource = null;

                        button5.Visible = true;

                        _loadComplete = true;
                        break;
                    case "Schedule":

                        if (grdMain.Rows.Count > 0)
                        {
                            try
                            {
                                selectedRow = grdMain.SelectedRows[0];
                            }
                            catch
                            {
                                selectedRow = grdMain.Rows[0];
                            }

                            _selectedItemDataId = int.Parse(selectedRow.Cells[0].Value.ToString());

                            _loadComplete = false;

                            lfa.pmgmt.data.DAO.Schedule.Unit scheduleDAO = new lfa.pmgmt.data.DAO.Schedule.Unit();
                            scheduleDAO.ConnectionString = _connectionString;
                            List<lfa.pmgmt.data.DTO.Schedule.Unit> s_unitList = scheduleDAO.List(_selectedItemDataId);

                            grdChildOne.DataSource = s_unitList;

                            grdChildOne.Columns[0].Visible = false;
                            grdChildOne.Columns[1].Visible = false;

                            grdChildTwo.Columns.Clear();
                            grdChildTwo.DataSource = null;
                        }

                        _loadComplete = true;
                        break;
                    case "LoadShed":
                        selectedRow = grdMain.SelectedRows[0];
                        _selectedItemDataId = int.Parse(selectedRow.Cells[0].Value.ToString());

                        _loadComplete = false;

                        lfa.pmgmt.data.DAO.Configuration.Unit s_unitDAO = new data.DAO.Configuration.Unit();
                        s_unitDAO.ConnectionString = _connectionString;
                        List<lfa.pmgmt.data.DTO.Configuration.Unit> ls_unitList = s_unitDAO.List(_selectedItemDataId);

                        grdChildOne.DataSource = ls_unitList;

                        grdChildOne.Columns[0].Visible = false;
                        grdChildOne.Columns[1].Visible = false;

                        grdChildTwo.Columns.Clear();
                        grdChildTwo.DataSource = null;

                        _loadComplete = true;
                        break;
                    case "Rules":
                         selectedRow = grdMain.SelectedRows[0];
                        _selectedItemDataId = int.Parse(selectedRow.Cells[0].Value.ToString());

                        _loadComplete = false;

                        btnDelete.Visible = true;
                        button2.Visible = true;

                        _loadComplete = true;
                        break;
                }
            }
        }

        #endregion

        #region Grid Child One Add New Button Event Handler
        private void btngrdChildOne_AddNew_Click(object sender, EventArgs e)
        {
            try
            {
                _selectedItemDataId = int.Parse(grdMain.SelectedRows[0].Cells[0].Value.ToString());

                switch (_currentModule)
                {
                    case "Configuration":
                        if (grdMain.SelectedRows.Count <= 0)
                        {
                            Exception ex = new Exception("Please select a zone from the panel on the left!");
                            HandleException(ex);
                        }
                        else
                        {
                            if (_selectedItemDataId > 0)
                            {
                                Forms.Frm_AddNew_Unit frmAddNewUnit = new Forms.Frm_AddNew_Unit(_selectedItemDataId);
                                frmAddNewUnit.ShowDialog();
                            }
                            else
                            {
                                Exception ex = new Exception("Please select a zone from the panel on the left!");
                                HandleException(ex);
                            }
                        }
                        break;
                    case "Schedule":
                        if (grdMain.SelectedRows.Count <= 0)
                        {
                            Exception ex = new Exception("Please select a schedule from the panel on the left!");
                            HandleException(ex);
                        }
                        else
                        {
                            if (_selectedItemDataId > 0)
                            {
                                Forms.Frm_AddNew_ScheduleUnit frmAddNewScheduleUnit = new Forms.Frm_AddNew_ScheduleUnit(_selectedItemDataId);
                                frmAddNewScheduleUnit.ShowDialog();
                            }
                            else
                            {
                                Exception ex = new Exception("Please select a schedule from the panel on the left!");
                                HandleException(ex);
                            }
                        }
                        break;
                    case "LoadShed":
                        HandleInformationMesssage("Load shedding data can not be saved! Data is only for control purposes!");
                        break;
                    case "Rules":
                        HandleInformationMesssage("This action is disabled for power management rules!");
                        break;
                }
            }
            catch
            {
                Exception ex = new Exception("There are either no item selected in the previous grid, or there are no data available to allow this action!");
                HandleException(ex);
            }
        }
        #endregion

        #region Grid Child One Row Select Event Handler
        private void grdChildOne_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_loadComplete)
            {
                switch (_currentModule)
                {
                    case "Configuration":
                        _loadComplete = false;

                         DataGridViewRow selectedRow = grdChildOne.SelectedRows[0];
                        _selectedItemDataId = int.Parse(selectedRow.Cells[0].Value.ToString());

                         lfa.pmgmt.data.DAO.Configuration.Device deviceDAO = new data.DAO.Configuration.Device();
                        deviceDAO.ConnectionString = _connectionString;
                        List<lfa.pmgmt.data.DTO.Configuration.Device> list = deviceDAO.List(_selectedItemDataId);

                        grdChildTwo.DataSource = list;

                        grdChildTwo.Columns[0].Visible = false;
                        grdChildTwo.Columns[1].Visible = false;

                        grdChildTwo.Columns[5].ReadOnly = true;

                        _loadComplete = true;
                        break;
                    case "Schedule":
                         _loadComplete = false;

                         DataGridViewRow s_selectedRow = grdChildOne.SelectedRows[0];
                        _selectedItemDataId = int.Parse(s_selectedRow.Cells[0].Value.ToString());

                        int selectedSchedule = int.Parse(grdMain.SelectedRows[0].Cells[0].Value.ToString());

                         lfa.pmgmt.data.DAO.Schedule.Device s_deviceDAO = new data.DAO.Schedule.Device();
                        s_deviceDAO.ConnectionString = _connectionString;
                        List<lfa.pmgmt.data.DTO.Schedule.Device> s_list = s_deviceDAO.ListById(_selectedItemDataId,selectedSchedule);

                        grdChildTwo.Columns.Clear();

                        grdChildTwo.DataSource = s_list;

                        grdChildTwo.Columns[0].Visible = false;
  
                        _loadComplete = true;
                        break;
                    case "LoadShed":
                        _loadComplete = false;

                        DataGridViewRow ls_selectedRow = grdChildOne.SelectedRows[0];
                        _selectedItemDataId = int.Parse(ls_selectedRow.Cells[0].Value.ToString());

                        lfa.pmgmt.data.DAO.Configuration.Device ls_deviceDAO = new data.DAO.Configuration.Device();
                        ls_deviceDAO.ConnectionString = _connectionString;
                        List<lfa.pmgmt.data.DTO.Configuration.LoadShedDevice> ls_list = ls_deviceDAO.ListLoadShed(_selectedItemDataId);

                        grdChildTwo.Columns.Clear();

                        grdChildTwo.DataSource = ls_list;

                        grdChildTwo.Columns[0].Visible = false;
                        grdChildTwo.Columns[2].Visible = false;
                        grdChildTwo.Columns[3].Visible = false;
                        grdChildTwo.Columns[4].Visible = false;

                        ComboBox cmbStatus = new ComboBox();
                        cmbStatus.Items.Add("On");
                        cmbStatus.Items.Add("Off");

                        DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                        comboBoxColumn.Items.Add("On");
                        comboBoxColumn.Items.Add("Off");
                        grdChildTwo.Columns.Add(comboBoxColumn);

                        foreach(DataGridViewRow dgvRow in grdChildTwo.Rows)
                        {
                            dgvRow.Cells[5].Value = dgvRow.Cells[4].Value;
                        }

                        btnLoadShed.Visible = true;

                        _loadComplete = true;
                        break;
                }
            }
        }
        #endregion

        #region Child Two Grid Add New Button
        private void btnGridChildTwo_AddNew_Click(object sender, EventArgs e)
        {
            try
            {
                _selectedItemDataId = int.Parse(grdChildOne.SelectedRows[0].Cells[0].Value.ToString());

                switch (_currentModule)
                {
                    case "Configuration":
                        if (grdChildOne.SelectedRows.Count <= 0)
                        {
                            Exception ex = new Exception("Please select a unit from the panel panel on the left!");
                            HandleException(ex);
                        }
                        else
                        {
                            if (_selectedItemDataId > 0)
                            {
                                Forms.Frm_AddNew_Device frmAddNewDevice = new Forms.Frm_AddNew_Device(_selectedItemDataId);
                                frmAddNewDevice.ShowDialog();
                            }
                            else
                            {
                                Exception ex = new Exception("Please select a unit from the panel panel on the left!");
                                HandleException(ex);
                            }
                        }
                        break;
                    case "Schedule":
                        if (grdChildOne.SelectedRows.Count <= 0)
                        {
                            Exception ex = new Exception("Please select a unit from the panel panel on the left!");
                            HandleException(ex);
                        }
                        else
                        {
                            if (_selectedItemDataId > 0)
                            {
                                int selectedSchedule = int.Parse(grdMain.SelectedRows[0].Cells[0].Value.ToString());
                                Forms.Frm_AddNew_ScheduleDevice frmAddNewScheduleDevice = new Forms.Frm_AddNew_ScheduleDevice(_selectedItemDataId, selectedSchedule);
                                frmAddNewScheduleDevice.ShowDialog();
                            }
                            else
                            {
                                Exception ex = new Exception("Please select a unit from the panel panel on the left!");
                                HandleException(ex);
                            }
                        }
                        break;
                    case "LoadShed":
                        HandleInformationMesssage("Load shedding data can not be saved! Data is only for control purposes!");
                        break;
                    case "Rules":
                        HandleInformationMesssage("This action is disabled for power management rules!");
                        break;
                }
            }
            catch
            {
                Exception ex = new Exception("There are either no item selected in the previous grid, or there are no data available to allow this action!");
                HandleException(ex);
            }
        }
        #endregion

        #region Configuration Bulk Update Methods
        private void BulkUpdateConfiguration()
        {
            BulkUpdateDevices();
            BulkUpdateUnits();
            BulkUpdateZones();

            HandleInformationMesssage("Data successfully saved! Please refresh the data!");
        }

        private void BulkUpdateZones()
        {
            if (grdMain.Rows.Count > 0)
            {
                foreach (DataGridViewRow grdMainRow in grdMain.Rows)
                {
                    lfa.pmgmt.data.DAO.Configuration.Zone zoneDOA = new data.DAO.Configuration.Zone();
                    zoneDOA.ConnectionString = _connectionString;
                    zoneDOA.Update(int.Parse(grdMainRow.Cells[0].Value.ToString()), grdMainRow.Cells[1].Value.ToString());
                    zoneDOA.EnableDisable(int.Parse(grdMainRow.Cells[0].Value.ToString()),
                                          Convert.ToBoolean(grdMainRow.Cells[3].Value.ToString()));
                }
            }
        }

        private void BulkUpdateUnits()
        {
            if (grdChildOne.Rows.Count > 0)
            {
                foreach (DataGridViewRow childOneRow in grdChildOne.Rows)
                {
                    lfa.pmgmt.data.DAO.Configuration.Unit unitDOA = new data.DAO.Configuration.Unit();
                    unitDOA.ConnectionString = _connectionString;
                    unitDOA.Update(int.Parse(childOneRow.Cells[0].Value.ToString()), int.Parse(childOneRow.Cells[1].Value.ToString()),
                                             childOneRow.Cells[2].Value.ToString(), childOneRow.Cells[4].Value.ToString());
                    unitDOA.EnableDisable(int.Parse(childOneRow.Cells[0].Value.ToString()),
                                          Convert.ToBoolean(childOneRow.Cells[5].Value.ToString()));
                }
            }
        }

        private void BulkUpdateDevices()
        {
            if (grdChildTwo.Rows.Count > 0)
            {
                foreach (DataGridViewRow childTwoRow in grdChildTwo.Rows)
                {
                    lfa.pmgmt.data.DAO.Configuration.Device deviceDOA = new data.DAO.Configuration.Device();
                    deviceDOA.ConnectionString = _connectionString;
                    deviceDOA.Update(int.Parse(childTwoRow.Cells[0].Value.ToString()), int.Parse(childTwoRow.Cells[1].Value.ToString()),
                                     childTwoRow.Cells[2].Value.ToString());
                    deviceDOA.EnableDisable(int.Parse(childTwoRow.Cells[0].Value.ToString()),
                                            Convert.ToBoolean(childTwoRow.Cells[4].Value.ToString()));
                }
            }
        }
        #endregion

        #region Schedule Bulk Update Methods
        private void BulkUpdateSchedule()
        {
            BuldUpdateScheduleDevice();
            BulkUpdateScheduleSchedule();

            HandleInformationMesssage("Data successfully saved! Please refresh the data!");
        }

        private void BulkUpdateScheduleSchedule()
        {

            foreach (DataGridViewRow scheduleRow in grdMain.Rows)
            {
                lfa.pmgmt.data.DAO.Schedule.Schedule scheduleDAO = new data.DAO.Schedule.Schedule();
                scheduleDAO.ConnectionString = _connectionString;
                scheduleDAO.Update(int.Parse(scheduleRow.Cells[0].Value.ToString()), scheduleRow.Cells[1].Value.ToString(),
                                    scheduleRow.Cells[2].Value.ToString(), scheduleRow.Cells[3].Value.ToString(),
                                    int.Parse(scheduleRow.Cells[4].Value.ToString()));

                scheduleDAO.EnableDisable(int.Parse(scheduleRow.Cells[0].Value.ToString()),
                                        Convert.ToBoolean(scheduleRow.Cells[6].Value.ToString()));
            }
        }

        private void BuldUpdateScheduleDevice()
        {
            foreach (DataGridViewRow deviceRow in grdChildTwo.Rows)
            {
                lfa.pmgmt.data.DAO.Schedule.Device deviceDAO = new data.DAO.Schedule.Device();
                deviceDAO.ConnectionString = _connectionString;
                deviceDAO.Update(int.Parse(deviceRow.Cells[0].Value.ToString()), 0, 0,
                                 Convert.ToBoolean(deviceRow.Cells[3].Value.ToString()));
            }
        }
        #endregion

        #region Bind LoadShed Data
        private void BindLoadShedData()
        {
            _loadComplete = false;

            lfa.pmgmt.data.DAO.Configuration.Zone zoneDAO = new data.DAO.Configuration.Zone();
            zoneDAO.ConnectionString = _connectionString;

            List<lfa.pmgmt.data.DTO.Configuration.Zone> zoneList = zoneDAO.List();

            btnGrdMainHeader.Text = "Zones";
            grdMain.DataSource = zoneList;

            btnGrdChildOneHeader.Text = "Units";

            btnGrdChildTwoHeader.Text = "Devices";

            _loadComplete = true;
        }
        #endregion

        #region Load Shedding Button Event Handler
        private void btnLoadShed_Click(object sender, EventArgs e)
        {
            string address = string.Empty;
            string unitName = grdChildOne.SelectedRows[0].Cells[2].Value.ToString();

            BravaCodes.SwitchState[] mySwitchStates = new BravaCodes.SwitchState[8];
            
            for (int x = 0; x <= 7; x++) mySwitchStates[x] = BravaCodes.SwitchState.SwitchOff;

            foreach (DataGridViewRow row in grdChildTwo.Rows)
            {
                int status = 0;
                int id = int.Parse(row.Cells[0].Value.ToString());
                string selectedvalue = row.Cells[5].Value.ToString();

                lfa.pmgmt.data.DAO.Configuration.Device deviceDAO = new data.DAO.Configuration.Device();
                deviceDAO.ConnectionString = _connectionString;

                address = deviceDAO.GetDeviceAddress(id);
                string deviceSwitch = deviceDAO.GetDeviceSwitch(id);
 
                if (selectedvalue == "On")
                    status = 1;
                else
                    status = 2;

                SetSwitchState(deviceSwitch, status, mySwitchStates);

                UpdateDeviceLoadShedStatus(status, id);
            }

            SendSwitchState(address, unitName, int.Parse(ConfigurationManager.AppSettings["DefaultPort"].ToString()), mySwitchStates);

            DisableAllSchedules();

            string loadShedMsg = "Devices successfully load shedded! ";
            loadShedMsg += "Please note that manual power management disables all schedules. To enable a schedule, please ";
            loadShedMsg += "go to the 'Schedule' management screen and re-enable the schedule.";

            HandleInformationMesssage(loadShedMsg);

            grdChildTwo.DataSource = null;
            grdChildTwo.Columns.Clear();
        }

        private static void UpdateDeviceLoadShedStatus(int status, int id)
        {
            lfa.pmgmt.data.DAO.Configuration.Device deviceDAO = new data.DAO.Configuration.Device();
            deviceDAO.ConnectionString = _connectionString;
            deviceDAO.UpdateLoadShedDeviceStatus(id, status);
        }

        private void DisableAllSchedules()
        {
            lfa.pmgmt.data.DAO.Schedule.Schedule scheduleDAO = new lfa.pmgmt.data.DAO.Schedule.Schedule();
            scheduleDAO.ConnectionString = _connectionString;
            scheduleDAO.DisableAll();
        }

        private void SendSwitchState(string ipAddress, string unitName, int port, BravaCodes.SwitchState[] mySwitchStates)
        {
            BravaConnection myConnection = new BravaConnection();

            myConnection.BravaIP = System.Net.IPAddress.Parse(ipAddress);

            myConnection.BravaPort = port;

            SwitchbankUpdate mySwitchbankUpdate = new SwitchbankUpdate(
                mySwitchStates[0],
                mySwitchStates[1],
                mySwitchStates[2],
                mySwitchStates[3],
                mySwitchStates[4],
                mySwitchStates[5],
                mySwitchStates[6],
                mySwitchStates[7]);

            BravaSocket mySocket = new BravaSocket(mySwitchbankUpdate, myConnection);

            try
            {
                mySocket.DoTransaction();

                if (mySwitchbankUpdate.State == BravaTransaction.TransactionState.Completed)
                {
                    mySwitchbankUpdate.State = BravaTransaction.TransactionState.Closed;

                    lfa.pmgmt.data.DAO.Logging.CurrentStatus currentStatusDAO = new data.DAO.Logging.CurrentStatus();
                    currentStatusDAO.ConnectionString = _connectionString;
                    currentStatusDAO.Insert(unitName, "OK");
                }

                if (mySwitchbankUpdate.State == BravaTransaction.TransactionState.Failed)
                {
                    lfa.pmgmt.data.DAO.Logging.Log logDAO = new data.DAO.Logging.Log();
                    logDAO.ConnectionString = _connectionString;
                    logDAO.Insert(1, "Unit: " + unitName, "TCP/IP Communications Error due to: BRAVA API or Connection error.", DateTime.Now);

                    lfa.pmgmt.data.DAO.Logging.CurrentStatus currentStatusDAO = new data.DAO.Logging.CurrentStatus();
                    currentStatusDAO.ConnectionString = _connectionString;
                    currentStatusDAO.Insert(unitName, "ERR");
                }
            }
            catch (System.Net.Sockets.SocketException ex)
            {

               lfa.pmgmt.data.DAO.Logging.Log logDAO = new data.DAO.Logging.Log();
               logDAO.ConnectionString = _connectionString;
               logDAO.Insert(1, "Unit: " + unitName, "TCP/IP Communications Error due to: " + ex.ToString(), DateTime.Now);

               lfa.pmgmt.data.DAO.Logging.CurrentStatus currentStatusDAO = new data.DAO.Logging.CurrentStatus();
               currentStatusDAO.ConnectionString = _connectionString;
               currentStatusDAO.Insert(unitName, "ERR");
            }
            catch (Exception nex)
            {
                HandleException(nex);
            }
            finally
            {
                mySocket.SocketClient.Close();
            }
        }

        private static void SetSwitchState(string swState, int status, BravaCodes.SwitchState[] mySwitchStates)
        {
            if (swState == "Switch 1")
            {
                if (status == 1)
                {
                    mySwitchStates[0] = BravaCodes.SwitchState.SwitchOn;
                }
                else
                {
                    mySwitchStates[0] = BravaCodes.SwitchState.SwitchOff;
                }
            }

            if (swState == "Switch 2")
            {
                if (status == 1)
                {
                    mySwitchStates[1] = BravaCodes.SwitchState.SwitchOn;
                }
                else
                {
                    mySwitchStates[1] = BravaCodes.SwitchState.SwitchOff;
                }
            }

            if (swState == "Switch 3")
            {// cbSingleSw3.Checked)
                if (status == 1)
                {
                    mySwitchStates[2] = BravaCodes.SwitchState.SwitchOn;
                }
                else
                {
                    mySwitchStates[2] = BravaCodes.SwitchState.SwitchOff;
                }
            }

            if (swState == "Switch 4") // cbSingleSw4.Checked)
            {
                if (status == 1)
                {
                    mySwitchStates[3] = BravaCodes.SwitchState.SwitchOn;
                }
                else
                {
                    mySwitchStates[3] = BravaCodes.SwitchState.SwitchOff;
                }
            }

            if (swState == "Switch 5") // cbSingleSw5.Checked)
            {
                if (status == 1)
                {
                    mySwitchStates[4] = BravaCodes.SwitchState.SwitchOn;
                }
                else
                {
                    mySwitchStates[4] = BravaCodes.SwitchState.SwitchOff;
                }
            }

            if (swState == "Switch 6") // cbSingleSw6.Checked)
            {
                if (status == 1)
                {
                    mySwitchStates[5] = BravaCodes.SwitchState.SwitchOn;
                }
                else
                {
                    mySwitchStates[5] = BravaCodes.SwitchState.SwitchOff;
                }
            }

            if (swState == "Switch 7") // cbSingleSw7.Checked)
            {
                if (status == 1)
                {
                    mySwitchStates[6] = BravaCodes.SwitchState.SwitchOn;
                }
                else
                {
                    mySwitchStates[6] = BravaCodes.SwitchState.SwitchOff;
                }
            }
            if (swState == "Switch 8") // cbSingleSw8.Checked)
            {
                if (status == 1)
                {
                    mySwitchStates[7] = BravaCodes.SwitchState.SwitchOn;
                }
                else
                {
                    mySwitchStates[7] = BravaCodes.SwitchState.SwitchOff;
                }
            }
        }
        #endregion

        #region Load Management Rules Binding
        private void BindLoadShedRules()
        {
            lfa.pmgmt.data.DAO.BusinessRule.RuleSet ruleSetDAO = new data.DAO.BusinessRule.RuleSet();
            ruleSetDAO.ConnectionString = _connectionString;

            List<lfa.pmgmt.data.DTO.BusinessRule.RuleSet> ruleSets = ruleSetDAO.List();

            grdMain.DataSource = ruleSets;

            btnGrdMainHeader.Text = "Rulesets";
            btnGrdChildOneHeader.Text = string.Empty;
            btnGrdChildTwoHeader.Text = string.Empty;
        }
        #endregion

        #region Delete Button Event Handler
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_loadComplete)
            {
                switch (_currentModule)
                {
                    case "Rules":

                        if (grdMain.SelectedRows.Count == 0)
                        {
                            Exception ex = new Exception("Please selected a ruleset to delete!");
                            HandleException(ex);
                        }
                        else
                        {
                            DeleteRuleset();
                        }
                        break;
                    case "LoadShed":
                        HandleInformationMesssage("Load shedding data can not be deleted! Data is only for control purposes!");
                       break;
                    case "Configuration":
                       try
                       {
                           int selectedZoneId = int.Parse(grdMain.SelectedRows[0].Cells[0].Value.ToString());

                           lfa.pmgmt.data.DAO.Configuration.Zone zoneDAO = new data.DAO.Configuration.Zone();
                           zoneDAO.ConnectionString = _connectionString;
                           zoneDAO.Delete(selectedZoneId);

                           HandleInformationMesssage("Data successfully deleted! Please refresh the data!");
                       }
                       catch (Exception ex)
                       {
                           HandleException(ex);
                       }
                        break;
                    case "Schedule":
                        try
                        {
                            int selectedScheduleId = int.Parse(grdMain.SelectedRows[0].Cells[0].Value.ToString());

                            lfa.pmgmt.data.DAO.Schedule.Schedule scheduleDAO = new data.DAO.Schedule.Schedule();
                            scheduleDAO.ConnectionString = _connectionString;
                            scheduleDAO.Delete(selectedScheduleId);

                            HandleInformationMesssage("Data successfully deleted! Please refresh the data!");
                        }
                        catch (Exception ex)
                        {
                            HandleException(ex);
                        }
                        break;
                }
            }
        }
        #endregion

        #region Delete Methods
        private void DeleteRuleset()
        {
            int selectedId = 0;

            foreach (DataGridViewRow dataRow in grdMain.Rows)
            {
                if (dataRow.Selected)
                {
                    selectedId = int.Parse(dataRow.Cells[0].Value.ToString());

                    lfa.pmgmt.data.DAO.BusinessRule.RuleSet ruleSetDAO = new data.DAO.BusinessRule.RuleSet();
                    ruleSetDAO.ConnectionString = _connectionString;

                    ruleSetDAO.Delete(selectedId);

                    HandleInformationMesssage("Data successfully deleted! Please refresh the data!");
                }
            }
        }
        #endregion

        #region Manage Business Rules Event Handler
        private void button2_Click(object sender, EventArgs e)
        {

            int selectedItemId = 0;

            foreach (DataGridViewRow row in grdMain.Rows)
            {
                if (row.Selected)
                {
                    selectedItemId = int.Parse(row.Cells[0].Value.ToString());
                }
            }

            Forms.Frm_Manage_Rules frmManageRules = new Forms.Frm_Manage_Rules(selectedItemId);
            frmManageRules.ShowDialog();
        }
        #endregion

        #region Load Management Event Handler
        private void btnLoadManagement_Click(object sender, EventArgs e)
        {
            button6.Visible = false;

            Forms.Frm_Manage_Load frmManageLoad = new Forms.Frm_Manage_Load();
            frmManageLoad.ShowDialog();
        }
        #endregion

        #region Delete Button Event Handler
        private void button4_Click(object sender, EventArgs e)
        {
            switch (_currentModule)
            {
                case "LoadShed":
                    HandleInformationMesssage("Load shedding data can not deleted! Data is only for control purposes!");
                    break;
                case "Configuration":
                    try
                    {
                        int selectedDeviceId = int.Parse(grdChildTwo.SelectedRows[0].Cells[0].Value.ToString());

                        lfa.pmgmt.data.DAO.Configuration.Device deviceDAO = new data.DAO.Configuration.Device();
                        deviceDAO.ConnectionString = _connectionString;
                        deviceDAO.Delete(selectedDeviceId);

                        HandleInformationMesssage("Data successfully deleted! Please refresh the data!");
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                    break;
                case "Schedule":
                    try
                    {
                        int s_selectedDeviceId = int.Parse(grdChildTwo.SelectedRows[0].Cells[0].Value.ToString());

                        lfa.pmgmt.data.DAO.Schedule.Device scheduleDAO = new data.DAO.Schedule.Device();
                        scheduleDAO.ConnectionString = _connectionString;
                        scheduleDAO.Delete(s_selectedDeviceId);

                        HandleInformationMesssage("Data successfully deleted! Please refresh the data!");
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                    break;
            }
        }
        #endregion

        #region Delete Event Handler
        private void button3_Click(object sender, EventArgs e)
        {
            switch (_currentModule)
            {
                case "LoadShed":
                    HandleInformationMesssage("Load shedding data can not be deleted! Data is only for control purposes!");
                    break;
                case "Configuration":
                    try
                    {
                        int selectedUnitId = int.Parse(grdChildOne.SelectedRows[0].Cells[0].Value.ToString());

                        lfa.pmgmt.data.DAO.Configuration.Unit unitDAO = new data.DAO.Configuration.Unit();
                        unitDAO.ConnectionString = _connectionString;
                        unitDAO.Delete(selectedUnitId);

                        HandleInformationMesssage("Data successfully deleted! Please refresh the data!");
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                    break;
                case "Schedule":
                    try
                    {
                        int selectedSchedule = int.Parse(grdMain.SelectedRows[0].Cells[0].Value.ToString());
                        int s_selectedUnitId = int.Parse(grdChildOne.SelectedRows[0].Cells[0].Value.ToString());

                        lfa.pmgmt.data.DAO.Schedule.Unit s_unitDAO = new data.DAO.Schedule.Unit();
                        s_unitDAO.ConnectionString = _connectionString;
                        s_unitDAO.Delete(s_selectedUnitId, selectedSchedule);

                        HandleInformationMesssage("Data successfully deleted! Please refresh the data!");
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                    break;
            }
        }
        #endregion

        #region Link To Zone
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedSchedule = int.Parse(grdMain.SelectedRows[0].Cells[0].Value.ToString());

                Forms.Frm_Link_Zone frmLinkZone = new Forms.Frm_Link_Zone(selectedSchedule);
                frmLinkZone.ShowDialog();
            }
            catch
            {
                Exception ex = new Exception("Please select a schedule to link form the grid below!");
                HandleException(ex);
            }
        }
        #endregion

        #region Copy Unit Configuration
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedUnit = int.Parse(grdChildOne.SelectedRows[0].Cells[0].Value.ToString());

                Forms.Frm_Copy_Unit frmCopyUnit = new Forms.Frm_Copy_Unit(_selectedItemDataId, selectedUnit);
                frmCopyUnit.ShowDialog();
            }
            catch
            {
                Exception ex = new Exception("There are either no item selected in the grid, or there are no data available to allow this action!");
                HandleException(ex);
            }
        }
        #endregion

        #region Priority Event Handler
        private void button7_Click(object sender, EventArgs e)
        {
            Forms.Frm_Manage_Priority frmManagePriority = new Forms.Frm_Manage_Priority();
            frmManagePriority.ShowDialog();
        }
        #endregion

        #region Communication Fault Viewer Log
        private void button9_Click(object sender, EventArgs e)
        {
            Forms.Frm_Manage_Log logViewer = new Forms.Frm_Manage_Log();
            logViewer.ShowDialog();
        }
        #endregion

        #region Signal Board Viewer
        private void button10_Click(object sender, EventArgs e)
        {
            Forms.Frm_Manage_SignalBoard signalBoard = new Forms.Frm_Manage_SignalBoard();
            signalBoard.ShowDialog();
        }
        #endregion
    }
}
