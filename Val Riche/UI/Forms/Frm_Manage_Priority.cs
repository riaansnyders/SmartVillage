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

    public partial class Frm_Manage_Priority : Form
    {
        private static string _connectionString = string.Empty;
        private static string _pageTitle = string.Empty;
        private static int _ruleId = 0;

        #region Constructor
        public Frm_Manage_Priority()
        {
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

            BindSchedules();

            BindPriorites();

            BindRuleData();
        }

        
        #endregion

        #region Private Methods
        private void BindSchedules()
        {
            lfa.pmgmt.data.DAO.Schedule.Schedule scheduleDAO = new data.DAO.Schedule.Schedule();
            scheduleDAO.ConnectionString = _connectionString;

            List<lfa.pmgmt.data.DTO.Schedule.Schedule> schedules = scheduleDAO.List();

            foreach (lfa.pmgmt.data.DTO.Schedule.Schedule schedule in schedules)
            {
                ComboItem item = new ComboItem();
                item.Id = schedule.Id;
                item.Name = schedule.Name;

                comboBox1.Items.Add(item);
            }
        }

        private void BindPriorites()
        {
            comboBox4.Items.Add("Low");
            comboBox4.Items.Add("Medium");
            comboBox4.Items.Add("High");
        }

        private void BindRuleData()
        {
            lfa.pmgmt.data.DAO.Schedule.Schedule schedulDAO = new data.DAO.Schedule.Schedule();
            schedulDAO.ConnectionString = _connectionString;
            List<lfa.pmgmt.data.DTO.Schedule.Priority> priorityList = schedulDAO.ListPriority();

            dataGridView1.DataSource = priorityList;
        }
        #endregion

        #region Add Rule Event Handler
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ComboItem schedule = comboBox1.SelectedItem as ComboItem;
                string priority = comboBox4.SelectedItem.ToString();

                lfa.pmgmt.data.DAO.Schedule.Schedule dao = new data.DAO.Schedule.Schedule();
                dao.ConnectionString = _connectionString;
                dao.InsertPriority(schedule.Id, priority);

                BindRuleData();
            }
            catch (Exception ex)
            {
                HandleException(ex);
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

                lfa.pmgmt.data.DAO.Schedule.Schedule ruleDAO = new data.DAO.Schedule.Schedule();
                ruleDAO.ConnectionString = _connectionString;
                ruleDAO.DeletePriority(selectedItemId);

                HandleInformationMesssage("Priority successfully deleted!");

                BindRuleData();
            }
            else
            {
                Exception ex = new Exception("No priority selected to delete!");
                HandleException(ex);
            }
        }
        #endregion
    }
}
