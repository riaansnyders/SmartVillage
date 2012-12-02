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

    public partial class Frm_Manage_Rules : Form
    {
        private static string _connectionString = string.Empty;
        private static string _pageTitle = string.Empty;
        private static int _ruleId = 0;

        #region Constructor
        public Frm_Manage_Rules(int Id_RuleSet)
        {
            _ruleId = Id_RuleSet;

            InitializeComponent();
        }
        #endregion

        #region Get Connection String
        private string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["ConnectionString"];
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

        #region Form Load Event Handler
        private void Frm_Manage_Rules_Load(object sender, EventArgs e)
        {
            _connectionString = GetConnectionString();

            BindZonesComboBox();

            BindComparisonComboBox();

            BindSwitchDeviceCombobox();

            BindRuleData();
        }
        #endregion

        #region Select Zone Event Handler
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboItem selectedItem = comboBox1.SelectedItem as ComboItem;
            int selectedZone = selectedItem.Id;

            List<lfa.pmgmt.data.DTO.Configuration.Unit> units = new List<data.DTO.Configuration.Unit>();
            lfa.pmgmt.data.DAO.Configuration.Unit unitDAO = new data.DAO.Configuration.Unit();
            unitDAO.ConnectionString = _connectionString;

            units = unitDAO.List(selectedZone);

            foreach (lfa.pmgmt.data.DTO.Configuration.Unit unit in units)
            {
                ComboItem item = new ComboItem();
                item.Id = unit.Id;
                item.Name = unit.Name;

                comboBox2.Items.Add(item);
            }
        }
        #endregion

        #region Select Unit Event Handler
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboItem selectedItem = comboBox1.SelectedItem as ComboItem;
            int selectedUnit = selectedItem.Id;

            List<lfa.pmgmt.data.DTO.Configuration.Device> devices = new List<data.DTO.Configuration.Device>();
            lfa.pmgmt.data.DAO.Configuration.Device deviceDAO = new data.DAO.Configuration.Device();
            deviceDAO.ConnectionString = _connectionString;

            devices = deviceDAO.List(selectedUnit);

            foreach (lfa.pmgmt.data.DTO.Configuration.Device device in devices)
            {
                ComboItem item = new ComboItem();
                item.Id = device.Id;
                item.Name = device.Name;

                comboBox3.Items.Add(item);
            }
        }
        #endregion

        #region Private Methods
        private void BindZonesComboBox()
        {
            List<lfa.pmgmt.data.DTO.Configuration.Zone> zones = new List<data.DTO.Configuration.Zone>();

            lfa.pmgmt.data.DAO.Configuration.Zone zoneDAO = new data.DAO.Configuration.Zone();
            zoneDAO.ConnectionString = _connectionString;

            zones = zoneDAO.List();

            foreach (lfa.pmgmt.data.DTO.Configuration.Zone zone in zones)
            {
                ComboItem item = new ComboItem();
                item.Id = zone.Id;
                item.Name = zone.Name;

                comboBox1.Items.Add(item);
            }
        }

        private void BindComparisonComboBox()
        {
            comboBox4.Items.Add("Smaller Than Equal");
            comboBox4.Items.Add("Bigger Then Equal");
            comboBox4.Items.Add("Smaller Then");
            comboBox4.Items.Add("Bigger Then");
            comboBox4.Items.Add("Equal");
        }

        private void BindSwitchDeviceCombobox()
        {

            comboBox5.Items.Add("Switch On");
            comboBox5.Items.Add("Switch Off");
        }

        private void BindRuleData()
        {
            dataGridView1.DataSource = null;

            lfa.pmgmt.data.DAO.BusinessRule.Rule ruleDAO = new data.DAO.BusinessRule.Rule();
            ruleDAO.ConnectionString = _connectionString;

            List<lfa.pmgmt.data.DTO.BusinessRule.Rule> rules = new List<data.DTO.BusinessRule.Rule>();
            rules = ruleDAO.List(_ruleId);

            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = null;

            dataGridView1.DataSource = rules;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string deviceOnOff = "Off";
                string rule = row.Cells[1].Value.ToString();
                string result = row.Cells[2].Value.ToString();

                string[] ruleArray = rule.Split(".".ToCharArray());
                int unitId = int.Parse(ruleArray[0].ToString());
                string comparer = ruleArray[2].ToString();
                string value = ruleArray[3].ToString();

                string[] resultArray = result.Split(".".ToCharArray());
                int deviceId = int.Parse(resultArray[1].ToString());
                int status = int.Parse(resultArray[2].ToString());

                if(status == 1)
                {
                    deviceOnOff = "On";
                }

                lfa.pmgmt.data.DAO.Configuration.Unit unitDAO = new data.DAO.Configuration.Unit();
                unitDAO.ConnectionString = _connectionString;

                lfa.pmgmt.data.DAO.Configuration.Device deviceDAO = new data.DAO.Configuration.Device();
                deviceDAO.ConnectionString = _connectionString;

                string unitName = unitDAO.GetName(unitId);
                string deviceName = deviceDAO.GetDeviceName(deviceId);

                row.Cells[1].Value = "If " + unitName + " load is " + comparer + " " + value + " Then";
                row.Cells[2].Value = "Switch " + deviceName + " " + deviceOnOff;
            }

            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].Width = 150;
        }
        #endregion

        #region Add Rule Event Handler
        private void btnOK_Click(object sender, EventArgs e)
        {
            int status = 2;

            ComboItem zone = comboBox1.SelectedItem as ComboItem;
            ComboItem unit = comboBox2.SelectedItem as ComboItem;
            ComboItem device = comboBox3.SelectedItem as ComboItem;

            string comparer = comboBox4.SelectedItem.ToString();
            string deviceOnOff = comboBox5.SelectedItem.ToString();

            switch (comparer)
            {
                case "Smaller Then Equal":
                    comparer = "<";
                    break;
                case "Bigger Then Equal":
                    comparer = ">=";
                    break;
                case "Smaller Then":
                    comparer = "<";
                    break;
                case "Bigger Then":
                    comparer = ">";
                    break;
                case "Equal":
                    comparer = "==";
                    break;
            }

            if(deviceOnOff == "Switch On")
            {
                status = 1;
            }
            
            string condition = unit.Id + "." + device.Id + "." + comparer + "." + textBox1.Text;

            string result = unit.Id + "." + device.Id + "." + status.ToString();

            lfa.pmgmt.data.DAO.BusinessRule.Rule ruleDAO = new data.DAO.BusinessRule.Rule();
            ruleDAO.ConnectionString = _connectionString;
            ruleDAO.Insert(_ruleId,condition,result);

            List<lfa.pmgmt.data.DTO.BusinessRule.Rule> rules = new List<data.DTO.BusinessRule.Rule>();
            rules = ruleDAO.List(_ruleId);

            dataGridView1.DataSource = null;

            dataGridView1.DataSource = rules;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string sdeviceOnOff = "Off";
                string rule = row.Cells[1].Value.ToString();
                string sresult = row.Cells[2].Value.ToString();

                string[] ruleArray = rule.Split(".".ToCharArray());
                int unitId = int.Parse(ruleArray[0].ToString());
                string scomparer = ruleArray[2].ToString();
                string value = ruleArray[3].ToString();

                string[] resultArray = result.Split(".".ToCharArray());
                int deviceId = int.Parse(resultArray[1].ToString());
                int sstatus = int.Parse(resultArray[2].ToString());

                if (sstatus == 1)
                {
                    sdeviceOnOff = "On";
                }

                lfa.pmgmt.data.DAO.Configuration.Unit unitDAO = new data.DAO.Configuration.Unit();
                unitDAO.ConnectionString = _connectionString;

                lfa.pmgmt.data.DAO.Configuration.Device deviceDAO = new data.DAO.Configuration.Device();
                deviceDAO.ConnectionString = _connectionString;

                string unitName = unitDAO.GetName(unitId);
                string deviceName = deviceDAO.GetDeviceName(deviceId);

                row.Cells[1].Value = "If " + unitName + " load is " + scomparer + " " + value + "Then";
                row.Cells[2].Value = "Switch " + deviceName + " " + sdeviceOnOff;
            }

            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].Width = 150;

        }
        #endregion

        #region Delete Button Event Handler
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int selectedItemId = int.Parse(selectedRow.Cells[0].Value.ToString());

                lfa.pmgmt.data.DAO.BusinessRule.Rule ruleDAO = new data.DAO.BusinessRule.Rule();
                ruleDAO.ConnectionString = _connectionString;
                ruleDAO.Delete(selectedItemId);

                HandleInformationMesssage("Rule successfully deleted!");

                BindRuleData();
            }
            else
            {
                Exception ex = new Exception("No rule selected to delete!");
                HandleException(ex);
            }
        }
        #endregion
    }
}
