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

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtZoneId.Text + 
                                    "&name=" + txtZoneName.Text + "&serial=" + txtZoneDescription.Text;

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

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&name=" + txtZoneName.Text + 
                                    "&serial=" + txtZoneDescription.Text;

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

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtZoneId.Text + 
                                    "&state=on&serial=" + txtZoneDescription.Text;

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

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtZoneId.Text + 
                                    "&state=off&serial=" + txtZoneDescription.Text;

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

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtDeviceId.Text + 
                                    "&zoneid=" + txtDeviceZoneId.Text + "&name=" + txtDeviceName.Text + "&address=" + txtDeviceAddress.Text;

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

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtDeviceId.Text + 
                                    "&state=on&serial=" + txtSmartCloudSerial.Text;

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

                    string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtDeviceId.Text + 
                                        "&scheduleId=" + txtDeviceScheduleId.Text;

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

                    string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtDeviceId.Text + 
                                        "&scheduleId=" + txtDeviceScheduleId.Text;

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
        //UT_CREATE_SWITCH
        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "switch/create?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&deviceid=" + txtSwitchDeviceId.Text + "&name=" + txtSwitchName.Text + "&deviceswitch=" + txtSwitch.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //UT_EDIT_SWITCH
        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "switch/edit?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtSwitchId.Text + 
                                    "&deviceid=" + txtSwitchDeviceId.Text + "&name=" + txtSwitchName.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //UT_DELETE_SWITCH
        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "switch/delete?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtSwitchId.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //UT_LIST_SWITCH
        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "switch/list?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&deviceid=" + txtSwitchDeviceId.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //UT_SWITCH_STATEON
        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "switch/state?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtSwitchId.Text + 
                                    "&state=on&serial=" + txtSmartCloudSerial.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //UT_SWITCH_STATEOFF
        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "switch/state?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtSwitchId.Text + 
                                    "&state=off&serial=" + txtSmartCloudSerial.Text;

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

        #region Priority
        //UT_PRIORITY_CREATE
        private void button22_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtPriorityScheduleId.Text))
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
                    string securityURL = "priority/create?loadid=1&";

                    string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&scheduleid=" + txtPriorityScheduleId.Text +
                                        "&name=" + txtPriorityName.Text;

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

        //UT_PRIORITY_DELETE
        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "priority/delete?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtPriorityId.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //UT_PRIORITY_LIST
        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "priority/list?loadid=1&";

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
        #endregion

        #region Schedule
        //UT_Schedule_Create
        private void button28_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "schedule/create?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&name=" + txtScheduleName.Text +
                                                            "&startdatetime=" + txtStartDate.Text + "&enddatetime=" + txtEndDate.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //UT_Schedule_Edit
        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "schedule/edit?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtScheduleId.Text +
                                                            "&name=" + txtScheduleName.Text + "&startdatetime=" + txtStartDate.Text +
                                                            "&enddatetime=" + txtEndDate.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //UT_Schedule_Delete
        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "schedule/delete?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtScheduleId.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //UT_Schedule_List
        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "schedule/list?loadid=1&";

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

        //UT_Schedule_Enable
        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "schedule/enable?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtScheduleId.Text;

                PostToService(requestURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception has been raised: " + ex.Message,
                                "SmartPower SmartCloud UnitTester", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        //UT_Schedule_Disable
        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                string baseURL = txtServiceBaseURL.Text;
                string securityURL = "schedule/disable?loadid=1&";

                string requestURL = baseURL + securityURL + "token=" + txtSecurityToken.Text + "&id=" + txtScheduleId.Text;

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
