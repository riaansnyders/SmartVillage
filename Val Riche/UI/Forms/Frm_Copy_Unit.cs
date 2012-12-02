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
   
    public partial class Frm_Copy_Unit : Form
    {
        private static string _connectionString = string.Empty;
        private static string _pageTitle = string.Empty;
        private static int zoneId = 0;
        private static int _unitId = 0;

        #region Constructor
        public Frm_Copy_Unit(int Id_Zone, int unitid)
        {
            InitializeComponent();

            zoneId = Id_Zone;
            _unitId = unitid;
        }
        #endregion

        #region Form Load Event Handler
        private void Frm_AddNew_Unit_Load_1(object sender, EventArgs e)
        {
            _connectionString = GetConnectionString();
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
                Exception ex = new Exception("Validation Exception : Please provide a new unit name!");
                HandleException(ex);
            }
            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                Exception ex = new Exception("Validation Exception : Please provide a IP Address for the unit!");
                HandleException(ex);
            }
            else
            {
                try
                {
                    lfa.pmgmt.data.DAO.Configuration.Unit DAO = new data.DAO.Configuration.Unit();
                    DAO.ConnectionString = _connectionString;
                    DAO.Insert(zoneId, txtZoneName.Text, DateTime.Now,textBox1.Text);

                    int insertedId = DAO.GetLastInsertedUnit(zoneId);

                    lfa.pmgmt.data.DAO.Configuration.Device deviceDAO = new data.DAO.Configuration.Device();
                    deviceDAO.ConnectionString = _connectionString;

                    List<lfa.pmgmt.data.DTO.Configuration.Device> devices = deviceDAO.List(_unitId);

                    foreach (lfa.pmgmt.data.DTO.Configuration.Device device in devices)
                    {
                        deviceDAO.Insert(insertedId, device.Name, DateTime.Now, device.Switch);
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
    }
}
