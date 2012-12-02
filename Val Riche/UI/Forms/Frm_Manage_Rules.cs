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

            BindPriorities();
        }
        #endregion

        #region Select Zone Event Handler
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Select Unit Event Handler
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
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
            comboBox4.Items.Add("Smaller Then Equal");
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

                lfa.pmgmt.data.DAO.Configuration.Zone zoneDAO = new data.DAO.Configuration.Zone();
                zoneDAO.ConnectionString = _connectionString;

                lfa.pmgmt.data.DTO.Configuration.Zone zoneItem = zoneDAO.Get(unitId);

                string zoneName = zoneItem.Name;

                row.Cells[1].Value = "If " + zoneName + " load is " + comparer + " " + value + " Then";
                row.Cells[2].Value = "Switch " + deviceOnOff;
                row.Cells[3].Value = row.Cells[3].Value;
            }

            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].Width = 150;
        }

        private void BindPriorities()
        {
            comboBox2.Items.Add("High");
            comboBox2.Items.Add("Medium");
            comboBox2.Items.Add("Low");
            comboBox2.Items.Add("None");
        }
        #endregion

        #region Add Rule Event Handler
        private void btnOK_Click(object sender, EventArgs e)
        {
            int status = 2;

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                Exception ex = new Exception("Validation Exception : Please provide a load value!");
                HandleException(ex);
            }
            else
            {
                ComboItem zone = comboBox1.SelectedItem as ComboItem;

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

                if (deviceOnOff == "Switch On")
                {
                    status = 1;
                }

                string condition = zone.Id + ".1." + comparer + "." + textBox1.Text;

                string result = zone.Id + ".1." + status.ToString();

                lfa.pmgmt.data.DAO.BusinessRule.Rule ruleDAO = new data.DAO.BusinessRule.Rule();
                ruleDAO.ConnectionString = _connectionString;
                ruleDAO.Insert(_ruleId, condition, result);

                int ruleId = ruleDAO.GetLastInsertedRuleId();

                //if (!comboBox2.SelectedItem.ToString().ToLower().Equals("none"))
                //{
                    lfa.pmgmt.data.DAO.BusinessRule.RuleSet rulesetDAO = new data.DAO.BusinessRule.RuleSet();
                    rulesetDAO.ConnectionString = _connectionString;
                    rulesetDAO.InsertPriority(_ruleId, ruleId, comboBox2.SelectedItem.ToString());
                //}

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

                    string[] resultArray = sresult.Split(".".ToCharArray());
                    int deviceId = int.Parse(resultArray[1].ToString());
                    int sstatus = int.Parse(resultArray[2].ToString());

                    if (sstatus == 1)
                    {
                        sdeviceOnOff = "On";
                    }

                    lfa.pmgmt.data.DAO.Configuration.Zone zoneDAO = new data.DAO.Configuration.Zone();
                    zoneDAO.ConnectionString = _connectionString;

                    lfa.pmgmt.data.DTO.Configuration.Zone zoneItem = zoneDAO.Get(unitId);

                    string zoneName = zoneItem.Name;

                    row.Cells[1].Value = "If " + zoneName + " load is " + scomparer + " " + value + " Then";
                    row.Cells[2].Value = "Switch " + sdeviceOnOff;
                }

                dataGridView1.Columns[1].Width = 180;
                dataGridView1.Columns[2].Width = 150;
            }
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
