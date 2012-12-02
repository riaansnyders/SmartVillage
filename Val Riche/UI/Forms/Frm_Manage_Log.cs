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

    public partial class Frm_Manage_Log : Form
    {
        private static string _connectionString = string.Empty;
        private static string _pageTitle = string.Empty;

        #region Constructor
        public Frm_Manage_Log()
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
        private void Frm_Manage_Log_Load_1(object sender, EventArgs e)
        {
            _connectionString = GetConnectionString();

            BindLogData();
        }
        #endregion

        #region Delete Button Event Handler
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int selectedItemId = int.Parse(selectedRow.Cells[0].Value.ToString());

                lfa.pmgmt.data.DAO.Logging.Log logDAO = new data.DAO.Logging.Log();
                logDAO.ConnectionString = _connectionString;
                logDAO.Delete(selectedItemId);

                HandleInformationMesssage("Log item successfully deleted!");

                BindLogData();
            }
            else
            {
                Exception ex = new Exception("No log item selected to delete!");
                HandleException(ex);
            }
        }
        #endregion

        #region Bind Log Data
        private void BindLogData()
        {
            lfa.pmgmt.data.DAO.Logging.Log logDAO = new data.DAO.Logging.Log();
            logDAO.ConnectionString = _connectionString;

            List<lfa.pmgmt.data.DTO.Logging.Log> logList = logDAO.List();

            dataGridView1.DataSource = logList;

            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].Width = 650;
        }
        #endregion

        #region Refresh Event Handler
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            BindLogData();
        }
        #endregion

        #region Truncate Table Event Handler
        private void button2_Click(object sender, EventArgs e)
        {
            lfa.pmgmt.data.DAO.Logging.Log logDAO = new data.DAO.Logging.Log();
            logDAO.ConnectionString = _connectionString;
            logDAO.Truncate();

            dataGridView1.DataSource = null;

            BindLogData();
        }
        #endregion

    }
}
