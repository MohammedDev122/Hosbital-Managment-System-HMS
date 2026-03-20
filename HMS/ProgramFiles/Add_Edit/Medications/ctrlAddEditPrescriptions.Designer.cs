namespace HMS.Add_Edit.Medications
{
    partial class ctrlAddEditPrescriptions
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPatientID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGetMedicalRecord = new System.Windows.Forms.Button();
            this.txtMedicalRecordID = new System.Windows.Forms.TextBox();
            this.cmbPrescriptionState = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrescripedMed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddEdit
            // 
            this.lblAddEdit.Size = new System.Drawing.Size(75, 38);
            this.lblAddEdit.Text = "Add";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label1.Location = new System.Drawing.Point(65, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Medical Record ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label3.Location = new System.Drawing.Point(986, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "PrescriptionState:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label4.Location = new System.Drawing.Point(542, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Patient ID:";
            // 
            // lblPatientID
            // 
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblPatientID.Location = new System.Drawing.Point(695, 141);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(55, 29);
            this.lblPatientID.TabIndex = 7;
            this.lblPatientID.Text = "......";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label6.Location = new System.Drawing.Point(530, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 29);
            this.label6.TabIndex = 8;
            this.label6.Text = "Patient Name:";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblPatientName.Location = new System.Drawing.Point(729, 211);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(83, 29);
            this.lblPatientName.TabIndex = 9;
            this.lblPatientName.Text = "..........";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1265, 402);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 39);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGetMedicalRecord
            // 
            this.btnGetMedicalRecord.Location = new System.Drawing.Point(417, 204);
            this.btnGetMedicalRecord.Name = "btnGetMedicalRecord";
            this.btnGetMedicalRecord.Size = new System.Drawing.Size(75, 23);
            this.btnGetMedicalRecord.TabIndex = 11;
            this.btnGetMedicalRecord.Text = "........";
            this.btnGetMedicalRecord.UseVisualStyleBackColor = true;
            this.btnGetMedicalRecord.Click += new System.EventHandler(this.btnGetMedicalRecord_Click);
            // 
            // txtMedicalRecordID
            // 
            this.txtMedicalRecordID.Location = new System.Drawing.Point(298, 204);
            this.txtMedicalRecordID.Name = "txtMedicalRecordID";
            this.txtMedicalRecordID.Size = new System.Drawing.Size(100, 22);
            this.txtMedicalRecordID.TabIndex = 12;
            this.txtMedicalRecordID.TextChanged += new System.EventHandler(this.txtMedicalRecordID_TextChanged);
            // 
            // cmbPrescriptionState
            // 
            this.cmbPrescriptionState.FormattingEnabled = true;
            this.cmbPrescriptionState.Location = new System.Drawing.Point(1244, 159);
            this.cmbPrescriptionState.Name = "cmbPrescriptionState";
            this.cmbPrescriptionState.Size = new System.Drawing.Size(121, 24);
            this.cmbPrescriptionState.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label2.Location = new System.Drawing.Point(65, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "Prescriped Medication:";
            // 
            // btnPrescripedMed
            // 
            this.btnPrescripedMed.BackgroundImage = global::HMS.Properties.Resources._9306428;
            this.btnPrescripedMed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrescripedMed.Location = new System.Drawing.Point(71, 348);
            this.btnPrescripedMed.Name = "btnPrescripedMed";
            this.btnPrescripedMed.Size = new System.Drawing.Size(149, 110);
            this.btnPrescripedMed.TabIndex = 15;
            this.btnPrescripedMed.UseVisualStyleBackColor = true;
            this.btnPrescripedMed.Click += new System.EventHandler(this.btnPrescripedMed_Click);
            // 
            // ctrlAddEditPrescriptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPrescripedMed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPrescriptionState);
            this.Controls.Add(this.txtMedicalRecordID);
            this.Controls.Add(this.btnGetMedicalRecord);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblPatientID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "ctrlAddEditPrescriptions";
            this.Load += new System.EventHandler(this.AddEditPrescriptions_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblPatientID, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.lblPatientName, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnGetMedicalRecord, 0);
            this.Controls.SetChildIndex(this.txtMedicalRecordID, 0);
            this.Controls.SetChildIndex(this.cmbPrescriptionState, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnPrescripedMed, 0);
            this.Controls.SetChildIndex(this.lblAddEdit, 0);
            this.Controls.SetChildIndex(this.label, 0);
            this.Controls.SetChildIndex(this.lblID, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPatientID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGetMedicalRecord;
        private System.Windows.Forms.TextBox txtMedicalRecordID;
        private System.Windows.Forms.ComboBox cmbPrescriptionState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrescripedMed;
    }
}
