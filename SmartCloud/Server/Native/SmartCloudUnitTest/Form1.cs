using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SmartCloudUnitTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Login
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "security/login?";
                string smartcloudSerial = txtSmartCloudSerial.Text;

                string requestURL = baseURL + securityURL + "token=" + smartcloudSerial;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message, 
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK, 
                                 MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Zones
        //[UT_Create]
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "zone/create?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&name=" + txtZoneName.Text + "&serial=" + txtZoneDescription.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //[UT_Edit]
        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "zone/edit?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtZoneId.Text + "&name=" + txtZoneName.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //[UT_Delete]
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "zone/delete?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtZoneId.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //[UT_LIST]
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "zone/list?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //[UT_SetStateOn]
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "zone/state?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtZoneId.Text + "&state=on&serial=" + txtZoneDescription.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //[UT_SetStateOff]
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "zone/state?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtZoneId.Text + "&state=off&serial=" + txtZoneDescription.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Device (Units as per Val Riche)

        #endregion

        #region Private Methods
        private void PostToService(string requestURL)
        {
            string Method = "POST";

            HttpWebRequest req = WebRequest.Create(requestURL) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = Method;
            req.Timeout = 15000;
            req.ContentType = "text/xml";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

            Encoding enc = System.Text.Encoding.GetEncoding(1252);
            StreamReader loResponseStream =
            new StreamReader(resp.GetResponseStream(), enc);

            string Response = loResponseStream.ReadToEnd();

            loResponseStream.Close();
            resp.Close();

            txtQueryResult.Text = Response;
        }
        #endregion

        private void button1_Click_3(object sender, EventArgs e)
        {

        }

        private void b_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

       

       

       
    }
}
