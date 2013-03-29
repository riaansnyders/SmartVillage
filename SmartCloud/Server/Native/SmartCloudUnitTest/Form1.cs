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
        //UT_ZONE_EDIT
        private void button1_Click_3(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "zone/edit?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtZoneId.Text + "&name=" + txtZoneName.Text + "&serial=" + txtZoneDescription.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //UT_ZONE_CREATE
        private void b_Click(object sender, EventArgs e)
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

        //UT_ZONE_DELETE
        private void button2_Click_1(object sender, EventArgs e)
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

        //UT_ZONE_LIST
        private void button3_Click_1(object sender, EventArgs e)
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

        //UT_ZONE_STATE_ON
        private void button4_Click_1(object sender, EventArgs e)
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

        //UT_ZONE_STATE_OFF
        private void button5_Click_1(object sender, EventArgs e)
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
        //UT_DEVICE_CREATE
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "device/create?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&zoneid=" + txtDeviceZoneId.Text + "&name=" + txtDeviceName.Text + "&address=" + txtDeviceAddress.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //UT_DEVICE_EDIT
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "device/edit?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtDeviceId.Text + "&zoneid=" + txtDeviceZoneId.Text + "&name=" + txtDeviceName.Text + "&address=" + txtDeviceAddress.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //UT_DEVICE_DELETE
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "device/delete?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtDeviceId.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //UT_DEVICE_LIST
        private void button8_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDeviceZoneId.Text))
            {
                MessageBox.Show("Please provide a zone id",
                                 "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string baseURL = txtServiceBaseURL.Text;
                    string securityURL = "device/list?loadid=1&";

                    string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&zoneid=" + txtDeviceZoneId.Text;

                    PostToService(requestURL);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following exception has been raised: " + ex.Message,
                                    "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
                }
            }
        }

        //UT_DEVICE_STATE_ON
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "device/state?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtDeviceId.Text + "&state=on&serial=" + txtSmartCloudSerial.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //UT_DEVICE_STATE_OFF
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "device/state?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtDeviceId.Text + "&state=off&serial=" + txtSmartCloudSerial.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //UT_DEVICE_LINK
        private void button12_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDeviceScheduleId.Text))
            {
                MessageBox.Show("Please provide a schedule id!",
                                 "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string baseURL = txtServiceBaseURL.Text;
                    string securityURL = "device/link?loadid=1&";

                    string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtDeviceId.Text + "&scheduleId=" + txtDeviceScheduleId.Text;

                    PostToService(requestURL);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following exception has been raised: " + ex.Message,
                                    "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
                }
            }
        }

        //UT_DEVICE_UNLINK
        private void button13_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtDeviceScheduleId.Text))
            {
                MessageBox.Show("Please provide a schedule id!",
                                 "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string baseURL = txtServiceBaseURL.Text;
                    string securityURL = "device/link?loadid=1&";

                    string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtDeviceId.Text + "&scheduleId=" + txtDeviceScheduleId.Text;

                    PostToService(requestURL);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following exception has been raised: " + ex.Message,
                                    "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Switches
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

        


        
       

    

        
       

        

       

       

       

       
    }
}
