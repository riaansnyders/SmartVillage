using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Text;
using System.Windows.Forms;
using Indus.ASN_1.Services.Builders;
using Indus.ASN_1.Services.BER;
namespace Indus.Services.Client
{
    public partial class ClientGUI : Form
    {
        private ConnectionClient  _client;
        delegate void SetTextCallBack(string text);
        public ClientGUI()
        {
            InitializeComponent();
            _client = new ConnectionClient();
            _client.ClientConnected += new Connected(this.GotConnected);
            _client.ClientDataReceived += new DataReceived(this.GotConnected);
            Connect();
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
            //this.txtLogInfo.Text = _client.CurrentLog;
            SetText(_client.CurrentLog);
        }

        private void Connect()
        {
            _client.Connect("10.140.76.105", 102);
            this.txtLogInfo.Text = _client.CurrentLog;
        
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //_client.Connect("127.0.0.1", 102);
            //10.140.76.105
            _client.Connect("10.140.76.105", 102);
            this.txtLogInfo.Text = _client.CurrentLog;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            _client.SendData(txtSend.Text);
            this.txtLogInfo.Text = _client.CurrentLog;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.txtLogInfo.Text = _client.CurrentLog;
        }

        private void btnSendIECRequest_Click(object sender, EventArgs e)
        {
            RequestBuilder builder = new RequestBuilder("LOGICAL-DEVICE");
            Encoder encode = new Encoder(builder.RequestString());
            _client.SendData(encode.Encode());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}