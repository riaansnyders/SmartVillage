namespace lfa.pmgmt.ui.Forms
{
    partial class Frm_Manage_Priority
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Manage_Priority));
            this.lblUnitName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnGrdMainHeader = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUnitName
            // 
            this.lblUnitName.AutoSize = true;
            this.lblUnitName.Location = new System.Drawing.Point(23, 25);
            this.lblUnitName.Name = "lblUnitName";
            this.lblUnitName.Size = new System.Drawing.Size(58, 13);
            this.lblUnitName.TabIndex = 0;
            this.lblUnitName.Text = "Schedule :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Priority  :";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(135, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(409, 21);
            this.comboBox1.TabIndex = 1;
            
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(135, 77);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(409, 21);
            this.comboBox4.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 254);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(605, 203);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(428, 128);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(116, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "Add Priority >>";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnGrdMainHeader
            // 
            this.btnGrdMainHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnGrdMainHeader.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGrdMainHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrdMainHeader.ForeColor = System.Drawing.Color.White;
            this.btnGrdMainHeader.Location = new System.Drawing.Point(26, 186);
            this.btnGrdMainHeader.Name = "btnGrdMainHeader";
            this.btnGrdMainHeader.Size = new System.Drawing.Size(605, 23);
            this.btnGrdMainHeader.TabIndex = 15;
            this.btnGrdMainHeader.TabStop = false;
            this.btnGrdMainHeader.Text = "Rules";
            this.btnGrdMainHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrdMainHeader.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = global::lfa.pmgmt.ui.Properties.Resources.Actions_button_cancel_icon;
            this.btnDelete.Location = new System.Drawing.Point(26, 215);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 33);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Frm_Manage_Priority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 470);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnGrdMainHeader);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUnitName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Manage_Priority";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Manage priority";
            this.Load += new System.EventHandler(this.Frm_Manage_Rules_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUnitName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnGrdMainHeader;
        private System.Windows.Forms.Button btnDelete;
    }
}