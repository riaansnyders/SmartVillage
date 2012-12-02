namespace Indus.Services.Server
{
    partial class ServerGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerGUI));
            this.btnCreate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtLogInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tvwModel = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(258, 29);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create Sample Server and Devices";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Visible = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "CreateRequest";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLogInfo
            // 
            this.txtLogInfo.BackColor = System.Drawing.SystemColors.Info;
            this.txtLogInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogInfo.Location = new System.Drawing.Point(147, 120);
            this.txtLogInfo.Multiline = true;
            this.txtLogInfo.Name = "txtLogInfo";
            this.txtLogInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogInfo.Size = new System.Drawing.Size(302, 149);
            this.txtLogInfo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(147, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server Log";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(365, 52);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 29);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh Log";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tvwModel
            // 
            this.tvwModel.Location = new System.Drawing.Point(12, 84);
            this.tvwModel.Name = "tvwModel";
            this.tvwModel.Size = new System.Drawing.Size(129, 185);
            this.tvwModel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(12, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(432, 47);
            this.label2.TabIndex = 6;
            this.label2.Text = "Demonstrator of IEC61850 Server - Incorporates ACSI Model, Built in Server and Co" +
                "mmunication Support to Decode MMS Request";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-3, 323);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(461, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Info;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(-2, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 47);
            this.label3.TabIndex = 8;
            this.label3.Text = "MMS PDU - Encoded using ASN.1";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(121, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 47);
            this.label4.TabIndex = 9;
            this.label4.Text = "ASN.1 Decode";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Info;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(236, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 47);
            this.label5.TabIndex = 10;
            this.label5.Text = "Command Processor";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Info;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(351, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 47);
            this.label6.TabIndex = 11;
            this.label6.Text = "Response - MMS PDU+ ASN.1";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 357);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tvwModel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLogInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCreate);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(472, 384);
            this.Name = "ServerGUI";
            this.Text = "IEC 61850 Server Demo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtLogInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TreeView tvwModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

