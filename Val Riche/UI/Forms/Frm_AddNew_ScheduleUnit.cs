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
   
    public partial class Frm_AddNew_ScheduleUnit : Form
    {
        private static string _connectionString = string.Empty;
        private static string _pageTitle = string.Empty;
        private static int scheduleId = 0;

        #region Constructor
        public Frm_AddNew_ScheduleUnit(int Id_Schedule)
        {
            InitializeComponent();

            scheduleId = Id_Schedule;
        }
        #endregion

        #region Form Load Event Handler
        private void Frm_AddNew_Unit_Load_1(object sender, EventArgs e)
        {
            _connectionString = GetConnectionString();

            lfa.pmgmt.data.DAO.Schedule.Unit scheduleDAO = new data.DAO.Schedule.Unit();
            scheduleDAO.ConnectionString = _connectionString;
            List<lfa.pmgmt.data.DTO.Schedule.Unit> scheduleList = scheduleDAO.ListConfigurationUnits();

            foreach (lfa.pmgmt.data.DTO.Schedule.Unit scheduleItem in scheduleList)
            {
                ComboItem item = new ComboItem();
                item.Id = scheduleItem.Id;
                item.Name = scheduleItem.Name;

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
                ComboItem item = comboBox1.SelectedItem as ComboItem;
                int selectedItem = item.Id;
                lfa.pmgmt.data.DAO.Schedule.Unit DAO = new data.DAO.Schedule.Unit();
                DAO.ConnectionString = _connectionString;
                DAO.Insert(selectedItem,scheduleId);

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
    }
}
