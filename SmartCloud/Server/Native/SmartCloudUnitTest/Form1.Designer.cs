namespace SmartCloudUnitTest
{
    partial class Form1
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
            this.txtServiceBaseURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUTLogins = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSmartCloudSerial = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSecurityToken = new System.Windows.Forms.TextBox();
            this.txtLoadId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtQueryResult = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.b = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtZoneId = new System.Windows.Forms.TextBox();
            this.txtZoneName = new System.Windows.Forms.TextBox();
            this.txtZoneDescription = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtZoneState = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtServiceBaseURL
            // 
            this.txtServiceBaseURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServiceBaseURL.Location = new System.Drawing.Point(138, 23);
            this.txtServiceBaseURL.Name = "txtServiceBaseURL";
            this.txtServiceBaseURL.Size = new System.Drawing.Size(577, 20);
            this.txtServiceBaseURL.TabIndex = 0;
            this.txtServiceBaseURL.Text = "http://localhost:9010/smartpower/smartcloud/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Service Base URL: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUTLogins);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSmartCloudSerial);
            this.groupBox1.Location = new System.Drawing.Point(31, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 125);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Security";
            // 
            // btnUTLogins
            // 
            this.btnUTLogins.Location = new System.Drawing.Point(609, 69);
            this.btnUTLogins.Name = "btnUTLogins";
            this.btnUTLogins.Size = new System.Drawing.Size(75, 23);
            this.btnUTLogins.TabIndex = 2;
            this.btnUTLogins.Text = "Login";
            this.btnUTLogins.UseVisualStyleBackColor = true;
            this.btnUTLogins.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "SmartCloudSerial :";
            // 
            // txtSmartCloudSerial
            // 
            this.txtSmartCloudSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSmartCloudSerial.Location = new System.Drawing.Point(107, 28);
            this.txtSmartCloudSerial.Name = "txtSmartCloudSerial";
            this.txtSmartCloudSerial.Size = new System.Drawing.Size(572, 20);
            this.txtSmartCloudSerial.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSecurityToken);
            this.groupBox2.Controls.Add(this.txtLoadId);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(31, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General";
            // 
            // txtSecurityToken
            // 
            this.txtSecurityToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecurityToken.Location = new System.Drawing.Point(107, 61);
            this.txtSecurityToken.Name = "txtSecurityToken";
            this.txtSecurityToken.Size = new System.Drawing.Size(577, 20);
            this.txtSecurityToken.TabIndex = 3;
            // 
            // txtLoadId
            // 
            this.txtLoadId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoadId.Location = new System.Drawing.Point(107, 25);
            this.txtLoadId.Name = "txtLoadId";
            this.txtLoadId.Size = new System.Drawing.Size(577, 20);
            this.txtLoadId.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "LoadId :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Security Token :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtQueryResult);
            this.groupBox3.Location = new System.Drawing.Point(774, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(415, 461);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Query Results";
            // 
            // txtQueryResult
            // 
            this.txtQueryResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQueryResult.Location = new System.Drawing.Point(14, 35);
            this.txtQueryResult.Multiline = true;
            this.txtQueryResult.Name = "txtQueryResult";
            this.txtQueryResult.Size = new System.Drawing.Size(384, 420);
            this.txtQueryResult.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtZoneState);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.txtZoneDescription);
            this.groupBox4.Controls.Add(this.txtZoneName);
            this.groupBox4.Controls.Add(this.txtZoneId);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.b);
            this.groupBox4.Location = new System.Drawing.Point(31, 306);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(702, 222);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Zone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Id: ";
            // 
            // b
            // 
            this.b.Location = new System.Drawing.Point(107, 183);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(75, 23);
            this.b.TabIndex = 0;
            this.b.Text = "Create";
            this.b.UseVisualStyleBackColor = true;
            this.b.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Name: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Serial :";
            // 
            // txtZoneId
            // 
            this.txtZoneId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZoneId.Location = new System.Drawing.Point(107, 18);
            this.txtZoneId.Name = "txtZoneId";
            this.txtZoneId.Size = new System.Drawing.Size(572, 20);
            this.txtZoneId.TabIndex = 4;
            // 
            // txtZoneName
            // 
            this.txtZoneName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZoneName.Location = new System.Drawing.Point(107, 65);
            this.txtZoneName.Name = "txtZoneName";
            this.txtZoneName.Size = new System.Drawing.Size(572, 20);
            this.txtZoneName.TabIndex = 5;
            // 
            // txtZoneDescription
            // 
            this.txtZoneDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZoneDescription.Location = new System.Drawing.Point(107, 108);
            this.txtZoneDescription.Name = "txtZoneDescription";
            this.txtZoneDescription.Size = new System.Drawing.Size(572, 20);
            this.txtZoneDescription.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(188, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(269, 183);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(350, 183);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Enable";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(431, 183);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Disable";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(512, 182);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "SetState";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "State:";
            // 
            // txtZoneState
            // 
            this.txtZoneState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZoneState.Location = new System.Drawing.Point(107, 148);
            this.txtZoneState.Name = "txtZoneState";
            this.txtZoneState.Size = new System.Drawing.Size(572, 20);
            this.txtZoneState.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 596);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServiceBaseURL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartPower SmartCloud UnitTester";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServiceBaseURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLoadId;
        private System.Windows.Forms.TextBox txtSecurityToken;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSmartCloudSerial;
        private System.Windows.Forms.Button btnUTLogins;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtQueryResult;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button b;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtZoneDescription;
        private System.Windows.Forms.TextBox txtZoneName;
        private System.Windows.Forms.TextBox txtZoneId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtZoneState;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
    }
}

