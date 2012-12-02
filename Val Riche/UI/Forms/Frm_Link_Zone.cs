using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lfa.pmgmt.ui.Forms
{
   
    public partial class Frm_Link_Zone : Form
    {
        private static string _connectionString = string.Empty;
        private static string _pageTitle = string.Empty;
        private static int _scheduleId = 0;

        #region Constructor
        public Frm_Link_Zone(int scheduleId)
        {
            InitializeComponent();

            _scheduleId = scheduleId;
        }
        #endregion

        #region Form Load Event Handler
        private void Frm_AddNew_Unit_Load_1(object sender, EventArgs e)
        {
            _connectionString = GetConnectionString();

            lfa.pmgmt.data.DAO.Configuration.Zone DAO = new lfa.pmgmt.data.DAO.Configuration.Zone();
            DAO.ConnectionString = _connectionString;

            List<lfa.pmgmt.data.DTO.Configuration.Zone> List = DAO.List();

            ComboItem blank = new ComboItem();
            blank.Id = -1;
            blank.Name = string.Empty;

            comboBox1.Items.Add(blank);

            foreach (lfa.pmgmt.data.DTO.Configuration.Zone zone in List)
            {
                ComboItem item = new ComboItem();
                item.Id = zone.Id;
                item.Name = zone.Name;

                comboBox1.Items.Add(item);
            }
        }
        #endregion

        #region Get Connection String
        private string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["ConnectionString"];
        }
        #endregion

        #region OK Button Event Handler
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ComboItem selectedItem = comboBox1.SelectedItem as ComboItem;
                int zoneId = selectedItem.Id;

                bool status = false;

                lfa.pmgmt.data.DAO.Configuration.Unit unitDAO = new data.DAO.Configuration.Unit();
                unitDAO.ConnectionString = _connectionString;

                List<lfa.pmgmt.data.DTO.Configuration.Unit> units = unitDAO.List(zoneId);

                foreach (lfa.pmgmt.data.DTO.Configuration.Unit unit in units)
                {
                    lfa.pmgmt.data.DAO.Schedule.Unit sunitDAO = new data.DAO.Schedule.Unit();
                    sunitDAO.ConnectionString = _connectionString;
                    sunitDAO.Insert(unit.Id, _scheduleId);

                    lfa.pmgmt.data.DAO.Configuration.Device deviceDAO = new data.DAO.Configuration.Device();
                    deviceDAO.ConnectionString = _connectionString;

                    List<lfa.pmgmt.data.DTO.Configuration.Device> devices = deviceDAO.List(unit.Id);

                    foreach (lfa.pmgmt.data.DTO.Configuration.Device device in devices)
                    {
                        lfa.pmgmt.data.DAO.Schedule.Device sdeviceDAO = new data.DAO.Schedule.Device();
                        sdeviceDAO.ConnectionString = _connectionString;
                        sdeviceDAO.Insert(device.Id, unit.Id, status, _scheduleId);
                    }

                    lfa.pmgmt.data.DAO.Schedule.Schedule dao = new data.DAO.Schedule.Schedule();
                    dao.ConnectionString = _connectionString;
                    dao.LinkZone(_scheduleId, zoneId);
                }

                bool switch1On = checkBox1.Checked;
                bool switch2On = checkBox2.Checked;
                bool switch3On = checkBox3.Checked;
                bool switch4On = checkBox4.Checked;
                bool switch5On = checkBox5.Checked;
                bool switch6On = checkBox6.Checked;
                bool switch7On = checkBox7.Checked;
                bool switch8On = checkBox8.Checked;

                lfa.pmgmt.data.DAO.Schedule.Unit unitDAO2 = new data.DAO.Schedule.Unit();
                unitDAO2.ConnectionString = _connectionString;
                List<lfa.pmgmt.data.DTO.Schedule.Unit> unitList = unitDAO2.ListWithZone(_scheduleId);

                foreach (lfa.pmgmt.data.DTO.Schedule.Unit unit in unitList)
                {
                    if (unit.Id_Zone == zoneId)
                    {
                        lfa.pmgmt.data.DAO.Schedule.Device deviceDAO = new data.DAO.Schedule.Device();
                        deviceDAO.ConnectionString = _connectionString;

                        List<lfa.pmgmt.data.DTO.Schedule.Device> deviceList = deviceDAO.ListWithDeviceId(unit.Id, _scheduleId);

                        foreach (lfa.pmgmt.data.DTO.Schedule.Device device in deviceList)
                        {
                            lfa.pmgmt.data.DAO.Configuration.Device configDeviceDAO = new data.DAO.Configuration.Device();
                            configDeviceDAO.ConnectionString = _connectionString;
                            lfa.pmgmt.data.DTO.Configuration.Device configDevice = configDeviceDAO.Get(device.DeviceId);

                            switch (configDevice.Switch)
                            {
                                case "Switch 1":
                                    deviceDAO.Update(device.Id, 0, 0, switch1On);
                                    break;
                                case "Switch 2":
                                    deviceDAO.Update(device.Id, 0, 0, switch2On);
                                    break;
                                case "Switch 3":
                                    deviceDAO.Update(device.Id, 0, 0, switch3On);
                                    break;
                                case "Switch 4":
                                    deviceDAO.Update(device.Id, 0, 0, switch4On);
                                    break;
                                case "Switch 5":
                                    deviceDAO.Update(device.Id, 0, 0, switch5On);
                                    break;
                                case "Switch 6":
                                    deviceDAO.Update(device.Id, 0, 0, switch6On);
                                    break;
                                case "Switch 7":
                                    deviceDAO.Update(device.Id, 0, 0, switch7On);
                                    break;
                                case "Switch 8":
                                    deviceDAO.Update(device.Id, 0, 0, switch8On);
                                    break;
                            }
                        }
                    }
                }

                HandleInformationMesssage("Data successfully saved! Please refresh the form data!");

                this.Close();
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

        #region Cancel Button Event Handler
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Zone Selection Event Handler
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboItem selectedItem = comboBox1.SelectedItem as ComboItem;
            int zoneId = selectedItem.Id;

            lfa.pmgmt.data.DAO.Schedule.Unit unitDAO = new data.DAO.Schedule.Unit();
            unitDAO.ConnectionString = _connectionString;
            List<lfa.pmgmt.data.DTO.Schedule.Unit> unitList = unitDAO.ListWithZone(_scheduleId);

            lfa.pmgmt.data.DAO.Schedule.Device deviceDAO = new data.DAO.Schedule.Device();
            deviceDAO.ConnectionString = _connectionString;

            foreach (lfa.pmgmt.data.DTO.Schedule.Unit unit in unitList)
            {
                if (unit.Id_Zone == zoneId)
                {
                    List<lfa.pmgmt.data.DTO.Schedule.Device> deviceList = deviceDAO.ListWithDeviceId(unit.Id, _scheduleId);

                    foreach (lfa.pmgmt.data.DTO.Schedule.Device device in deviceList)
                    {
                        lfa.pmgmt.data.DAO.Configuration.Device configDeviceDAO = new data.DAO.Configuration.Device();
                        configDeviceDAO.ConnectionString = _connectionString;

                        lfa.pmgmt.data.DTO.Configuration.Device configDevice = configDeviceDAO.Get(device.DeviceId);

                        switch (configDevice.Switch)
                        {
                            case "Switch 1":
                                checkBox1.Checked = device.DeviceOn;
                                break;
                            case "Switch 2":
                                checkBox2.Checked = device.DeviceOn;
                                break;
                            case "Switch 3":
                                checkBox3.Checked = device.DeviceOn;
                                break;
                            case "Switch 4":
                                checkBox4.Checked = device.DeviceOn;
                                break;
                            case "Switch 5":
                                checkBox5.Checked = device.DeviceOn;
                                break;
                            case "Switch 6":
                                checkBox6.Checked = device.DeviceOn;
                                break;
                            case "Switch 7":
                                checkBox7.Checked = device.DeviceOn;
                                break;
                            case "Switch 8":
                                checkBox8.Checked = device.DeviceOn;
                                break;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
