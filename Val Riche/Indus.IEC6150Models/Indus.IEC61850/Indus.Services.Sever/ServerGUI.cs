using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Text;
using System.Windows.Forms;
using Indus.IEC61850.LogicalModel.ACSI ;
using Indus.ACSI.Core;
using System.Diagnostics;

//ASN
using Indus.ASN_1.Services.Builders;
using Indus.ASN_1.Services.BER;

namespace Indus.Services.Server
{
    public partial class ServerGUI : Form
    {
        private IECServer IEC61850Server;
        HostServer server;
        delegate void SetTextCallBack(string text);
        public ServerGUI()
        {
            InitializeComponent();
            CreateIECServer();
            server = new HostServer(IEC61850Server);
            server.ServerConnected += new Connected (this.GotConnected);
            server.ServerDataReceived  += new DataReceived (this.GotConnected);
            server.Start();
            FillTreewithIECModel();
            this.txtLogInfo.Text = server.CurrentLog;
        }

        private void FillTreewithIECModel()
        {

            TreeNode node = new TreeNode();
            node.Text = "IEC61850Server";
            tvwModel.Nodes.Add(node);
            foreach (LogicalDevice ld in IEC61850Server.LogicalDevices)
            {
                TreeNode ldNode = new TreeNode(ld.LDName);
                node.Nodes.Add(ldNode );
                foreach (LogicalNode lnode in ld.LogicalNodes)
                {
                    TreeNode lnNode = new TreeNode(lnode.LNName);
                    ldNode.Nodes.Add(lnNode);
                    //foreach (DataObject dO in lnode.Data)
                    //{
                    //    TreeNode doNode = new TreeNode();
                    //    lnNode.Nodes.Add(doNode);
                    //}
                }

            }


        }
        private void SetText(string text)
        {
            if (this.txtLogInfo.InvokeRequired)
            {
                SetTextCallBack d = new SetTextCallBack(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {

                this.txtLogInfo.Text = text;
            }
        }
        private void GotConnected()
        {
            //this.txtLogInfo.Text = server.CurrentLog;
            SetText(server.CurrentLog);
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateIECServer();
            MessageBox.Show(IEC61850Server.GetServerDirectory(ObjectClassEnum.LogicalDevice )[0]);
        }

        public void CreateIECServer()
        {
            IEC61850Server = new IECServer();
            IECLogicalDevice device = new IECLogicalDevice("E1.QA5", "E1.QA5");

            IEC61850Server.AddLogicalDevice(device);
            IECLogicalNode node = new IECLogicalNode("/XCBR", "E1.QA5/XCBR8");
            device.AddLogicalNode(node);
            IECData data = new IECData(".Pos", "E1.QA5/XCBR8.Pos");
            node.AddData(data);
            IECDataAttribute attrib = new IECDataAttribute(".ctlVal", "0");
            data.AddDataAttribues(attrib);
            attrib = new IECDataAttribute(".stVal", "0");
            data.AddDataAttribues(attrib);
            attrib = new IECDataAttribute(".q", "0");
            data.AddDataAttribues(attrib);
            attrib = new IECDataAttribute(".t", "0");
            data.AddDataAttribues(attrib);
            attrib = new IECDataAttribute(".ctlModel", "0");
            data.AddDataAttribues(attrib);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RequestBuilder builder = new RequestBuilder("LOGICAL-DEVICE");
            Encoder encode = new Encoder(builder.RequestString());
            Debug.Print( System.Text.Encoding.ASCII.GetString( encode.Encode()));


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.txtLogInfo.Text = server.CurrentLog;
        }
    }
}