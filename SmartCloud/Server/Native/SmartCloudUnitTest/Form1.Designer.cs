﻿namespace SmartCloudUnitTest
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtZoneDescription = new System.Windows.Forms.TextBox();
            this.txtZoneName = new System.Windows.Forms.TextBox();
            this.txtZoneId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.b = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.txtDeviceId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDeviceZoneId = new System.Windows.Forms.TextBox();
            this.txtDeviceScheduleId = new System.Windows.Forms.TextBox();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.txtDeviceAddress = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.txtSmartCloudSerial.Text = "12345";
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
            this.txtSecurityToken.Text = "12345";
            // 
            // txtLoadId
            // 
            this.txtLoadId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoadId.Location = new System.Drawing.Point(107, 25);
            this.txtLoadId.Name = "txtLoadId";
            this.txtLoadId.Size = new System.Drawing.Size(577, 20);
            this.txtLoadId.TabIndex = 2;
            this.txtLoadId.Text = "1";
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
            this.groupBox3.Size = new System.Drawing.Size(415, 573);
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
            this.txtQueryResult.Size = new System.Drawing.Size(384, 519);
            this.txtQueryResult.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(31, 296);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(702, 304);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.txtZoneDescription);
            this.tabPage1.Controls.Add(this.txtZoneName);
            this.tabPage1.Controls.Add(this.txtZoneId);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.b);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(694, 278);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Zones";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(513, 172);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 23);
            this.button5.TabIndex = 23;
            this.button5.Text = "SetState OFF";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(432, 172);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 22;
            this.button4.Text = "SetState ON";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(351, 172);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 21;
            this.button3.Text = "List";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(270, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // txtZoneDescription
            // 
            this.txtZoneDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZoneDescription.Location = new System.Drawing.Point(108, 115);
            this.txtZoneDescription.Name = "txtZoneDescription";
            this.txtZoneDescription.Size = new System.Drawing.Size(572, 20);
            this.txtZoneDescription.TabIndex = 18;
            // 
            // txtZoneName
            // 
            this.txtZoneName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZoneName.Location = new System.Drawing.Point(108, 72);
            this.txtZoneName.Name = "txtZoneName";
            this.txtZoneName.Size = new System.Drawing.Size(572, 20);
            this.txtZoneName.TabIndex = 17;
            // 
            // txtZoneId
            // 
            this.txtZoneId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZoneId.Location = new System.Drawing.Point(108, 25);
            this.txtZoneId.Name = "txtZoneId";
            this.txtZoneId.Size = new System.Drawing.Size(572, 20);
            this.txtZoneId.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Serial :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Name: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Id: ";
            // 
            // b
            // 
            this.b.Location = new System.Drawing.Point(108, 172);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(75, 23);
            this.b.TabIndex = 12;
            this.b.Text = "Create";
            this.b.UseVisualStyleBackColor = true;
            this.b.Click += new System.EventHandler(this.b_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button13);
            this.tabPage2.Controls.Add(this.button12);
            this.tabPage2.Controls.Add(this.txtDeviceAddress);
            this.tabPage2.Controls.Add(this.txtDeviceName);
            this.tabPage2.Controls.Add(this.txtDeviceScheduleId);
            this.tabPage2.Controls.Add(this.txtDeviceZoneId);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.button9);
            this.tabPage2.Controls.Add(this.button10);
            this.tabPage2.Controls.Add(this.txtDeviceId);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.button11);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(694, 278);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Devices (Units)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(694, 278);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Switches";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(694, 278);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Priority";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(694, 278);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Schedule";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(427, 227);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(92, 23);
            this.button6.TabIndex = 31;
            this.button6.Text = "SetState OFF";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(346, 227);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 30;
            this.button7.Text = "SetState ON";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(265, 227);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 29;
            this.button8.Text = "List";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(184, 227);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 28;
            this.button9.Text = "Delete";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(103, 227);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 27;
            this.button10.Text = "Edit";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // txtDeviceId
            // 
            this.txtDeviceId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeviceId.Location = new System.Drawing.Point(103, 20);
            this.txtDeviceId.Name = "txtDeviceId";
            this.txtDeviceId.Size = new System.Drawing.Size(572, 20);
            this.txtDeviceId.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Id: ";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(21, 227);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 24;
            this.button11.Text = "Create";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Zone Id:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Schedule Id: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "IP Address:";
            // 
            // txtDeviceZoneId
            // 
            this.txtDeviceZoneId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeviceZoneId.Location = new System.Drawing.Point(103, 60);
            this.txtDeviceZoneId.Name = "txtDeviceZoneId";
            this.txtDeviceZoneId.Size = new System.Drawing.Size(572, 20);
            this.txtDeviceZoneId.TabIndex = 36;
            // 
            // txtDeviceScheduleId
            // 
            this.txtDeviceScheduleId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeviceScheduleId.Location = new System.Drawing.Point(103, 101);
            this.txtDeviceScheduleId.Name = "txtDeviceScheduleId";
            this.txtDeviceScheduleId.Size = new System.Drawing.Size(572, 20);
            this.txtDeviceScheduleId.TabIndex = 37;
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeviceName.Location = new System.Drawing.Point(103, 137);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(572, 20);
            this.txtDeviceName.TabIndex = 38;
            // 
            // txtDeviceAddress
            // 
            this.txtDeviceAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeviceAddress.Location = new System.Drawing.Point(103, 174);
            this.txtDeviceAddress.Name = "txtDeviceAddress";
            this.txtDeviceAddress.Size = new System.Drawing.Size(572, 20);
            this.txtDeviceAddress.TabIndex = 39;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(525, 227);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(70, 23);
            this.button12.TabIndex = 40;
            this.button12.Text = "Link";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(601, 227);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(87, 23);
            this.button13.TabIndex = 41;
            this.button13.Text = "Unlink";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 619);
            this.Controls.Add(this.tabControl1);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtZoneDescription;
        private System.Windows.Forms.TextBox txtZoneName;
        private System.Windows.Forms.TextBox txtZoneId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button b;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox txtDeviceId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDeviceZoneId;
        private System.Windows.Forms.TextBox txtDeviceAddress;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.TextBox txtDeviceScheduleId;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
    }
}
