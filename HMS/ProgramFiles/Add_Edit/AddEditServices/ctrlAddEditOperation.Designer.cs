namespace HMS.Add_Edit.AddEditServices
{
    partial class ctrlAddEditOperation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbSpecilization = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOperationRoomList = new System.Windows.Forms.Button();
            this.txtOperationRoomID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbOperationResult = new System.Windows.Forms.ComboBox();
            this.txtMedicalRecordID = new System.Windows.Forms.TextBox();
            this.btnGetMedicalRecord = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnOperationStaff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbServiceState
            // 
            this.cmbServiceState.SelectedIndexChanged += new System.EventHandler(this.cmbServiceState_SelectedIndexChanged);
            // 
            // btnSelectPatient
            // 
            this.btnSelectPatient.Visible = false;
            // 
            // txtPatientID
            // 
            this.txtPatientID.ReadOnly = true;
            // 
            // lblAddEdit
            // 
            this.lblAddEdit.Size = new System.Drawing.Size(269, 38);
            this.lblAddEdit.Text = "Add New Service";
            // 
            // cmbSpecilization
            // 
            this.cmbSpecilization.FormattingEnabled = true;
            this.cmbSpecilization.Location = new System.Drawing.Point(698, 353);
            this.cmbSpecilization.Name = "cmbSpecilization";
            this.cmbSpecilization.Size = new System.Drawing.Size(121, 24);
            this.cmbSpecilization.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label7.Location = new System.Drawing.Point(471, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 29);
            this.label7.TabIndex = 26;
            this.label7.Text = "Specilization";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label111.Location = new System.Drawing.Point(436, 405);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(220, 29);
            this.label111.TabIndex = 27;
            this.label111.Text = "Medical Record ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label8.Location = new System.Drawing.Point(945, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(236, 29);
            this.label8.TabIndex = 29;
            this.label8.Text = "Operation Room ID:";
            // 
            // btnOperationRoomList
            // 
            this.btnOperationRoomList.Location = new System.Drawing.Point(1293, 276);
            this.btnOperationRoomList.Name = "btnOperationRoomList";
            this.btnOperationRoomList.Size = new System.Drawing.Size(75, 23);
            this.btnOperationRoomList.TabIndex = 31;
            this.btnOperationRoomList.Text = "..........";
            this.btnOperationRoomList.UseVisualStyleBackColor = true;
            this.btnOperationRoomList.Click += new System.EventHandler(this.btnOperationRoomList_Click);
            // 
            // txtOperationRoomID
            // 
            this.txtOperationRoomID.Location = new System.Drawing.Point(1177, 273);
            this.txtOperationRoomID.Name = "txtOperationRoomID";
            this.txtOperationRoomID.Size = new System.Drawing.Size(100, 22);
            this.txtOperationRoomID.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label11.Location = new System.Drawing.Point(945, 316);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(202, 29);
            this.label11.TabIndex = 34;
            this.label11.Text = "Operation Result";
            // 
            // cmbOperationResult
            // 
            this.cmbOperationResult.Enabled = false;
            this.cmbOperationResult.FormattingEnabled = true;
            this.cmbOperationResult.Location = new System.Drawing.Point(1187, 321);
            this.cmbOperationResult.Name = "cmbOperationResult";
            this.cmbOperationResult.Size = new System.Drawing.Size(121, 24);
            this.cmbOperationResult.TabIndex = 33;
            // 
            // txtMedicalRecordID
            // 
            this.txtMedicalRecordID.Location = new System.Drawing.Point(684, 412);
            this.txtMedicalRecordID.Name = "txtMedicalRecordID";
            this.txtMedicalRecordID.Size = new System.Drawing.Size(100, 22);
            this.txtMedicalRecordID.TabIndex = 35;
            this.txtMedicalRecordID.TextChanged += new System.EventHandler(this.txtMedicalRecordID_TextChanged);
            // 
            // btnGetMedicalRecord
            // 
            this.btnGetMedicalRecord.Location = new System.Drawing.Point(816, 411);
            this.btnGetMedicalRecord.Name = "btnGetMedicalRecord";
            this.btnGetMedicalRecord.Size = new System.Drawing.Size(75, 23);
            this.btnGetMedicalRecord.TabIndex = 36;
            this.btnGetMedicalRecord.Text = "..........";
            this.btnGetMedicalRecord.UseVisualStyleBackColor = true;
            this.btnGetMedicalRecord.Click += new System.EventHandler(this.btnGetMedicalRecord_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label13.Location = new System.Drawing.Point(23, 491);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(182, 29);
            this.label13.TabIndex = 38;
            this.label13.Text = "Operation Staff";
            // 
            // btnOperationStaff
            // 
            this.btnOperationStaff.BackgroundImage = global::HMS.Properties.Resources.white_user_member_guest_icon_png_image_701751695037005zdurfaim0y;
            this.btnOperationStaff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOperationStaff.Enabled = false;
            this.btnOperationStaff.Location = new System.Drawing.Point(13, 523);
            this.btnOperationStaff.Name = "btnOperationStaff";
            this.btnOperationStaff.Size = new System.Drawing.Size(177, 181);
            this.btnOperationStaff.TabIndex = 37;
            this.btnOperationStaff.UseVisualStyleBackColor = true;
            this.btnOperationStaff.Click += new System.EventHandler(this.btnOperationStaff_Click);
            // 
            // ctrlAddEditOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnOperationStaff);
            this.Controls.Add(this.btnGetMedicalRecord);
            this.Controls.Add(this.txtMedicalRecordID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbOperationResult);
            this.Controls.Add(this.txtOperationRoomID);
            this.Controls.Add(this.btnOperationRoomList);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label111);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbSpecilization);
            this.Name = "ctrlAddEditOperation";
            this.Size = new System.Drawing.Size(1420, 719);
            this.Load += new System.EventHandler(this.ctrlAddEditOperation_Load_1);
            this.Controls.SetChildIndex(this.cmbSpecilization, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label111, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.btnOperationRoomList, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblEndTime, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.lblPaymentID, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.cmbServiceState, 0);
            this.Controls.SetChildIndex(this.dtpDate, 0);
            this.Controls.SetChildIndex(this.dtpStartTime, 0);
            this.Controls.SetChildIndex(this.btnSelectPatient, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.lblPaymentState, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.txtPatientID, 0);
            this.Controls.SetChildIndex(this.lblAddEdit, 0);
            this.Controls.SetChildIndex(this.label, 0);
            this.Controls.SetChildIndex(this.lblID, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblPatientName, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.lblPatientPhone, 0);
            this.Controls.SetChildIndex(this.txtOperationRoomID, 0);
            this.Controls.SetChildIndex(this.cmbOperationResult, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtMedicalRecordID, 0);
            this.Controls.SetChildIndex(this.btnGetMedicalRecord, 0);
            this.Controls.SetChildIndex(this.btnOperationStaff, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSpecilization;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOperationRoomList;
        private System.Windows.Forms.TextBox txtOperationRoomID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbOperationResult;
        private System.Windows.Forms.TextBox txtMedicalRecordID;
        private System.Windows.Forms.Button btnGetMedicalRecord;
        private System.Windows.Forms.Button btnOperationStaff;
        private System.Windows.Forms.Label label13;
    }
}
