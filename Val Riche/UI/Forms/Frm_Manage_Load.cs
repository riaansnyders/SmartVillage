using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace lfa.pmgmt.ui.Forms
{
   
    public partial class Frm_Manage_Load : Form
    {
        private static string _connectionString = string.Empty;
        private static string _pageTitle = string.Empty;
        private static int zoneId = 0;

        #region Constructor
        public Frm_Manage_Load()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Load Event Handler
        private void Frm_AddNew_Unit_Load_1(object sender, EventArgs e)
        {
            _connectionString = GetConnectionString();

            lfa.pmgmt.data.DAO.BusinessRule.Load loadDAO = new lfa.pmgmt.data.DAO.BusinessRule.Load();
            loadDAO.ConnectionString = _connectionString;

            List<lfa.pmgmt.data.DTO.BusinessRule.Load> loadList = loadDAO.List();

            if (loadList.Count > 0)
            {
                if (loadList[0].ManualLoad > 0)
                {
                    txtZoneName.Text = loadList[0].ManualLoad.ToString();

                    radioButton2.Checked = false;
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;

                    txtZoneName.Text = loadList[0].CurrentLoad.ToString();
                }

                textBox1.Text = loadList[0].MaximumLoad.ToString();
            }
            else
            {
                radioButton1.Checked = true;
                txtZoneName.Text = "0";
                textBox1.Text = "0";
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
            if (string.IsNullOrEmpty(txtZoneName.Text))
            {
                Exception ex = new Exception("Validation Exception : Please provide the current electricity load!");
                HandleException(ex);
            }
            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                Exception ex = new Exception("Validation Exception : Please provide the maximum electricity load!");
                HandleException(ex);
            }
            else
            {
                try
                {
                    if (radioButton1.Checked)
                    {
                        string loadValue = textBox1.Text;

                        lfa.pmgmt.data.DAO.BusinessRule.Load loadDAO = new data.DAO.BusinessRule.Load();
                        loadDAO.ConnectionString = _connectionString;
                        loadDAO.InsertManual(int.Parse(txtZoneName.Text), int.Parse(textBox1.Text));
                    }
                    else
                    {
                        lfa.pmgmt.data.DAO.BusinessRule.Load loadDAO = new data.DAO.BusinessRule.Load();
                        loadDAO.ConnectionString = _connectionString;
                        loadDAO.Insert(int.Parse(txtZoneName.Text), int.Parse(textBox1.Text));
                    }

                    HandleInformationMesssage("Data successfully saved! Please refresh the form data!");

                    this.Close();
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
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

        #region Radio Button Switch Event Handler
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                _connectionString = GetConnectionString();

                lfa.pmgmt.data.DAO.BusinessRule.Load loadDAO = new lfa.pmgmt.data.DAO.BusinessRule.Load();
                loadDAO.ConnectionString = _connectionString;

                List<lfa.pmgmt.data.DTO.BusinessRule.Load> loadList = loadDAO.List();

                if (loadList.Count > 0)
                {
                    txtZoneName.Text = loadList[0].ManualLoad.ToString();
                    textBox1.Text = loadList[0].MaximumLoad.ToString();
                }
               

                radioButton2.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                _connectionString = GetConnectionString();

                lfa.pmgmt.data.DAO.BusinessRule.Load loadDAO = new lfa.pmgmt.data.DAO.BusinessRule.Load();
                loadDAO.ConnectionString = _connectionString;

                List<lfa.pmgmt.data.DTO.BusinessRule.Load> loadList = loadDAO.List();

                if (loadList.Count > 0)
                {
                    txtZoneName.Text = loadList[0].CurrentLoad.ToString();
                    textBox1.Text = loadList[0].MaximumLoad.ToString();
                }
                else
                {
                    txtZoneName.Text = "0";
                    textBox1.Text = "0";
                }

                radioButton1.Checked = false;
            }
        }
        #endregion
    }
}
