namespace HMS.Add_Edit.AddEditServices
{
    partial class ctrlAddEditDiagnosis
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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDoctorName = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblDoctorPhone = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblMedicalRecordID = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbSpecilization = new System.Windows.Forms.ComboBox();
            this.txtDiagnosticNotes = new System.Windows.Forms.TextBox();
            this.txtDoctorID = new System.Windows.Forms.TextBox();
            this.btnSelectDoctor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(63, 408);
            // 
            // lblPaymentID
            // 
            this.lblPaymentID.Location = new System.Drawing.Point(221, 408);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(63, 353);
            // 
            // cmbServiceState
            // 
            this.cmbServiceState.Location = new System.Drawing.Point(256, 358);
            this.cmbServiceState.SelectedIndexChanged += new System.EventHandler(this.cmbServiceState_SelectedIndexChanged);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH/mm/SS";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            // 
            // btnSelectPatient
            // 
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(63, 454);
            // 
            // lblPaymentState
            // 
            this.lblPaymentState.Location = new System.Drawing.Point(274, 454);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1289, 492);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(482, 207);
            // 
            // lblPatientName
            // 
            this.lblPatientName.Location = new System.Drawing.Point(679, 207);
            // 
            // lblPatientPhone
            // 
            this.lblPatientPhone.Location = new System.Drawing.Point(679, 250);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(482, 250);
            // 
            // lblAddEdit
            // 
            this.lblAddEdit.Size = new System.Drawing.Size(269, 38);
            this.lblAddEdit.Text = "Add New Service";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label7.Location = new System.Drawing.Point(1009, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 29);
            this.label7.TabIndex = 25;
            this.label7.Text = "Doctor ID:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label8.Location = new System.Drawing.Point(1009, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 29);
            this.label8.TabIndex = 26;
            this.label8.Text = "Doctor Name:";
            // 
            // lblDoctorName
            // 
            this.lblDoctorName.AutoSize = true;
            this.lblDoctorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblDoctorName.Location = new System.Drawing.Point(1206, 195);
            this.lblDoctorName.Name = "lblDoctorName";
            this.lblDoctorName.Size = new System.Drawing.Size(69, 29);
            this.lblDoctorName.TabIndex = 27;
            this.lblDoctorName.Text = "........";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label13.Location = new System.Drawing.Point(1009, 245);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(174, 29);
            this.label13.TabIndex = 28;
            this.label13.Text = "Doctor Phone:";
            // 
            // lblDoctorPhone
            // 
            this.lblDoctorPhone.AutoSize = true;
            this.lblDoctorPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblDoctorPhone.Location = new System.Drawing.Point(1206, 245);
            this.lblDoctorPhone.Name = "lblDoctorPhone";
            this.lblDoctorPhone.Size = new System.Drawing.Size(83, 29);
            this.lblDoctorPhone.TabIndex = 29;
            this.lblDoctorPhone.Text = "..........";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label15.Location = new System.Drawing.Point(482, 292);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(227, 29);
            this.label15.TabIndex = 30;
            this.label15.Text = "Medical Record ID:";
            // 
            // lblMedicalRecordID
            // 
            this.lblMedicalRecordID.AutoSize = true;
            this.lblMedicalRecordID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblMedicalRecordID.Location = new System.Drawing.Point(741, 292);
            this.lblMedicalRecordID.Name = "lblMedicalRecordID";
            this.lblMedicalRecordID.Size = new System.Drawing.Size(55, 29);
            this.lblMedicalRecordID.TabIndex = 31;
            this.lblMedicalRecordID.Text = "......";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label17.Location = new System.Drawing.Point(477, 335);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(212, 29);
            this.label17.TabIndex = 32;
            this.label17.Text = "Diagnostic Notes:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label19.Location = new System.Drawing.Point(1009, 284);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(157, 29);
            this.label19.TabIndex = 34;
            this.label19.Text = "Specilization";
            // 
            // cmbSpecilization
            // 
            this.cmbSpecilization.FormattingEnabled = true;
            this.cmbSpecilization.Location = new System.Drawing.Point(1182, 284);
            this.cmbSpecilization.Name = "cmbSpecilization";
            this.cmbSpecilization.Size = new System.Drawing.Size(121, 24);
            this.cmbSpecilization.TabIndex = 35;
            // 
            // txtDiagnosticNotes
            // 
            this.txtDiagnosticNotes.Location = new System.Drawing.Point(704, 342);
            this.txtDiagnosticNotes.Multiline = true;
            this.txtDiagnosticNotes.Name = "txtDiagnosticNotes";
            this.txtDiagnosticNotes.Size = new System.Drawing.Size(330, 188);
            this.txtDiagnosticNotes.TabIndex = 36;
            // 
            // txtDoctorID
            // 
            this.txtDoctorID.Location = new System.Drawing.Point(1140, 152);
            this.txtDoctorID.Name = "txtDoctorID";
            this.txtDoctorID.Size = new System.Drawing.Size(100, 22);
            this.txtDoctorID.TabIndex = 37;
            this.txtDoctorID.TextChanged += new System.EventHandler(this.txtDoctorIDTextChanged);
            // 
            // btnSelectDoctor
            // 
            this.btnSelectDoctor.Location = new System.Drawing.Point(1289, 152);
            this.btnSelectDoctor.Name = "btnSelectDoctor";
            this.btnSelectDoctor.Size = new System.Drawing.Size(52, 23);
            this.btnSelectDoctor.TabIndex = 38;
            this.btnSelectDoctor.Text = ".....";
            this.btnSelectDoctor.UseVisualStyleBackColor = true;
            this.btnSelectDoctor.Click += new System.EventHandler(this.btnSelectDoctor_Click);
            // 
            // ctrlAddEditDiagnosis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelectDoctor);
            this.Controls.Add(this.txtDoctorID);
            this.Controls.Add(this.txtDiagnosticNotes);
            this.Controls.Add(this.cmbSpecilization);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblMedicalRecordID);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblDoctorPhone);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblDoctorName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Name = "ctrlAddEditDiagnosis";
            this.Size = new System.Drawing.Size(1420, 547);
            this.Load += new System.EventHandler(this.ctrlAddEditDiagnosis_Load);
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
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblPatientName, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.lblPatientPhone, 0);
            this.Controls.SetChildIndex(this.lblAddEdit, 0);
            this.Controls.SetChildIndex(this.label, 0);
            this.Controls.SetChildIndex(this.lblID, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.lblDoctorName, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.lblDoctorPhone, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.lblMedicalRecordID, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.cmbSpecilization, 0);
            this.Controls.SetChildIndex(this.txtDiagnosticNotes, 0);
            this.Controls.SetChildIndex(this.txtDoctorID, 0);
            this.Controls.SetChildIndex(this.btnSelectDoctor, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDoctorName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblDoctorPhone;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblMedicalRecordID;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbSpecilization;
        private System.Windows.Forms.TextBox txtDiagnosticNotes;
        private System.Windows.Forms.TextBox txtDoctorID;
        private System.Windows.Forms.Button btnSelectDoctor;
    }
}
