namespace Indus.Services.Client
{
    partial class ClientGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLogInfo = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSendIECRequest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(41, 14);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(209, 35);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect>";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(41, 28);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(209, 35);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send >>";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Visible = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(5, 69);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(243, 20);
            this.txtSend.TabIndex = 2;
            this.txtSend.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(11, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "Client Log";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLogInfo
            // 
            this.txtLogInfo.BackColor = System.Drawing.SystemColors.Info;
            this.txtLogInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogInfo.Location = new System.Drawing.Point(12, 147);
            this.txtLogInfo.Multiline = true;
            this.txtLogInfo.Name = "txtLogInfo";
            this.txtLogInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogInfo.Size = new System.Drawing.Size(279, 199);
            this.txtLogInfo.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 114);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(74, 29);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = ">>>";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSendIECRequest
            // 
            this.btnSendIECRequest.Location = new System.Drawing.Point(12, 74);
            this.btnSendIECRequest.Name = "btnSendIECRequest";
            this.btnSendIECRequest.Size = new System.Drawing.Size(279, 34);
            this.btnSendIECRequest.TabIndex = 7;
            this.btnSendIECRequest.Text = "GetServerDirectory_Req";
            this.btnSendIECRequest.UseVisualStyleBackColor = true;
            this.btnSendIECRequest.Click += new System.EventHandler(this.btnSendIECRequest_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 57);
            this.label2.TabIndex = 8;
            this.label2.Text = "IEC 61850 Client Demonstrator - Connects to Server if exists and on clicking butt" +
                "on sends Request and logs the response - Connected on Start";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Info;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(11, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 47);
            this.label5.TabIndex = 11;
            this.label5.Text = "MMS PDU GetServiceDirectpry_REq{...";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Info;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(204, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 47);
            this.label3.TabIndex = 12;
            this.label3.Text = "Request";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(130, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 47);
            this.label4.TabIndex = 13;
            this.label4.Text = "ASN.1 BER Encoding";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClientGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 362);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSendIECRequest);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLogInfo);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnConnect);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(319, 389);
            this.Name = "ClientGUI";
            this.Text = "IEC 61850 Client Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLogInfo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSendIECRequest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

