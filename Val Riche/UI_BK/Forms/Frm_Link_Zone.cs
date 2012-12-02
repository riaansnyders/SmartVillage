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

            comboBox2.Items.Add("On");
            comboBox2.Items.Add("Off");
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
                #region OLD CODE
                //ComboItem selectedItem = comboBox1.SelectedItem as ComboItem;

                //int zoneId = selectedItem.Id;
                //bool status = false;

                //if (comboBox2.SelectedItem.ToString() == "On")
                //{
                //    status = true;
                //}

                //lfa.pmgmt.data.DAO.Configuration.Unit unitDAO = new data.DAO.Configuration.Unit();
                //unitDAO.ConnectionString = _connectionString;

                //List<lfa.pmgmt.data.DTO.Configuration.Unit> units = unitDAO.List(zoneId);

                //foreach (lfa.pmgmt.data.DTO.Configuration.Unit unit in units)
                //{
                //    lfa.pmgmt.data.DAO.Schedule.Unit sunitDAO = new data.DAO.Schedule.Unit();
                //    sunitDAO.ConnectionString = _connectionString;
                //    sunitDAO.Insert(unit.Id, _scheduleId);

                //    lfa.pmgmt.data.DAO.Configuration.Device deviceDAO = new data.DAO.Configuration.Device();
                //    deviceDAO.ConnectionString = _connectionString;

                //    List<lfa.pmgmt.data.DTO.Configuration.Device> devices = deviceDAO.List(unit.Id);

                //    foreach (lfa.pmgmt.data.DTO.Configuration.Device device in devices)
                //    {
                //        lfa.pmgmt.data.DAO.Schedule.Device sdeviceDAO = new data.DAO.Schedule.Device();
                //        sdeviceDAO.ConnectionString = _connectionString;
                //        sdeviceDAO.Insert(device.Id, unit.Id,status, _scheduleId);
                //    }

                //    lfa.pmgmt.data.DAO.Schedule.Schedule dao = new data.DAO.Schedule.Schedule();
                //    dao.ConnectionString = _connectionString;
                //    dao.LinkZone(_scheduleId, zoneId);
                //}
                #endregion

                foreach (DataGridViewRow dataRow in dataGridView1.Rows)
                {
                    lfa.pmgmt.data.DAO.Schedule.Device deviceDAO = new data.DAO.Schedule.Device();
                    deviceDAO.ConnectionString = _connectionString;

                    if (dataRow.Cells[4].Value.ToString() == "Off")
                    {
                        deviceDAO.Update(int.Parse(dataRow.Cells[0].Value.ToString()), 0, 0,
                                         false);
                    }
                    else
                    {
                        deviceDAO.Update(int.Parse(dataRow.Cells[0].Value.ToString()), 0, 0,
                                         true);
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

        #region Change Zone Event Handler
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Text = string.Empty;

            ComboItem selectedCBItem = comboBox1.SelectedItem as ComboItem;
            int selectedItem = selectedCBItem.Id;

            if (selectedItem > -1)
            {
                lfa.pmgmt.data.DAO.Configuration.Unit units = new data.DAO.Configuration.Unit();
                units.ConnectionString = _connectionString;
                List<lfa.pmgmt.data.DTO.Configuration.Unit> unitList = units.List(selectedItem);

                foreach (lfa.pmgmt.data.DTO.Configuration.Unit unitItem in unitList)
                {
                    ComboItem item = new ComboItem();
                    item.Id = unitItem.Id;
                    item.Name = unitItem.Name;



                    comboBox3.Items.Add(item);
                }
            }
        }
        #endregion

        #region Unit Selection Event Handler
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboItem selectedItem = comboBox3.SelectedItem as ComboItem;
            int unitId = selectedItem.Id;

            dataGridView1.DataSource = null;

            if (unitId > -1)
            {
                lfa.pmgmt.data.DAO.Schedule.Device scheduleDeviceDAO = new data.DAO.Schedule.Device();
                scheduleDeviceDAO.ConnectionString = _connectionString;

                List<lfa.pmgmt.data.DTO.Schedule.Device> scheduleDevices = scheduleDeviceDAO.ListById(unitId, _scheduleId);

                if (scheduleDevices.Count > 0)
                {
                    dataGridView1.DataSource = scheduleDevices;

                    ComboBox cmbStatus = new ComboBox();
                    cmbStatus.Items.Add("On");
                    cmbStatus.Items.Add("Off");

                    DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                    comboBoxColumn.Items.Add("On");
                    comboBoxColumn.Items.Add("Off");
                    dataGridView1.Columns.Add(comboBoxColumn);

                    foreach (DataGridViewRow scheduleRow in dataGridView1.Rows)
                    {
                       if (Convert.ToBoolean(scheduleRow.Cells[3].Value.ToString()))
                       {
                          scheduleRow.Cells[4].Value = "On";
                       }
                       else
                       {
                          scheduleRow.Cells[4].Value = "Off";
                       }
                    }

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].Visible = false;

                    dataGridView1.Columns[1].Width = 273;
                    dataGridView1.Columns[4].Width = 100;
                }
            }
        }
        #endregion
    }
}
