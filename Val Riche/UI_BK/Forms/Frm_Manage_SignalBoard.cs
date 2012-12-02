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

    public partial class Frm_Manage_SignalBoard : Form
    {
        private static string _connectionString = string.Empty;
        private static string _pageTitle = string.Empty;
        private static int _selectedZone = 0;

        #region Constructor
        public Frm_Manage_SignalBoard()
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

            lfa.pmgmt.data.DAO.Configuration.Zone zoneDOA = new data.DAO.Configuration.Zone();
            zoneDOA.ConnectionString = _connectionString;
            List<lfa.pmgmt.data.DTO.Configuration.Zone> zoneList = zoneDOA.List();

            foreach (lfa.pmgmt.data.DTO.Configuration.Zone zone in zoneList)
            {
                ComboItem item = new ComboItem();
                item.Id = zone.Id;
                item.Name = zone.Name;

                comboBox1.Items.Add(item);
            }
        }
        #endregion

        #region Refresh Event Handler
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Columns.Clear();

                ComboItem item = comboBox1.SelectedItem as ComboItem;

                _selectedZone = item.Id;
                lfa.pmgmt.data.DAO.Logging.CurrentStatus currentStats = new data.DAO.Logging.CurrentStatus();
                currentStats.ConnectionString = _connectionString;

                List<lfa.pmgmt.data.DTO.Logging.CurrentStatus> statusList = currentStats.List(_selectedZone);

                dataGridView1.DataSource = statusList;

                DataGridViewImageColumn iColumn = new DataGridViewImageColumn();
                
                dataGridView1.Columns.Add(iColumn);

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[2].Value.ToString().Equals("OK"))
                    {
                        DataGridViewImageCell column = row.Cells[3] as DataGridViewImageCell;
                        column.Value = Image.FromFile("OK.png");
                    }
                    else
                    {
                        DataGridViewImageCell column = row.Cells[3] as DataGridViewImageCell;
                        column.Value = Image.FromFile("NotOK.png");
                    }
                    row.Height = 40;
                }

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Width = 400;
                dataGridView1.Columns[2].Visible = false;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        #endregion

        #region Selected Zone Index Changed
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Columns.Clear();

                ComboItem item = comboBox1.SelectedItem as ComboItem;

                lfa.pmgmt.data.DAO.Logging.CurrentStatus currentStats = new data.DAO.Logging.CurrentStatus();
                currentStats.ConnectionString = _connectionString;

                _selectedZone = item.Id;
                List<lfa.pmgmt.data.DTO.Logging.CurrentStatus> statusList = currentStats.List(_selectedZone);

                dataGridView1.DataSource = statusList;

                DataGridViewImageColumn iColumn = new DataGridViewImageColumn();
                dataGridView1.Columns.Add(iColumn);

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[2].Value.ToString().Equals("OK"))
                    {
                        DataGridViewImageCell column = row.Cells[3] as DataGridViewImageCell;
                        
                        column.Value = Image.FromFile("OK.png");
                    }
                    else
                    {
                        DataGridViewImageCell column = row.Cells[3] as DataGridViewImageCell;
                        column.Value = Image.FromFile("NotOK.png");
                    }

                    row.Height = 40;
                }

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Width = 400;
                dataGridView1.Columns[2].Visible = false;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
                
        }
        #endregion

    }
}
