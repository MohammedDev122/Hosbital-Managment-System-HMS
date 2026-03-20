namespace HMS.ProgramFiles.Panels.MainPanel
{
    partial class ctrlDoctorPanel
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
            this.ctrlMyDiagnosisDoctorButton1 = new HMS.Buttons.Procedures.ctrlMyDiagnosisDoctorButton();
            this.ctrlMyOperationMemberButton1 = new HMS.Buttons.Procedures.ctrlMyOperationMemberButton();
            this.ctrlDoctorReservationButton1 = new HMS.Buttons.Records.EmployeeRecords.ctrlDoctorReservationButton();
            this.ctrlMedicalRecordsButton1 = new HMS.Buttons.Records.PatientLogs.ctrlMedicalRecordsButton();
            this.ctrlMyPrescriptionForDocButton1 = new HMS.Buttons.Medications.ctrlMyPrescriptionForDocButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlMyLogsListButton1
            // 
            this.ctrlMyLogsListButton1.Location = new System.Drawing.Point(3, 405);
            this.ctrlMyLogsListButton1.Size = new System.Drawing.Size(224, 50);
            // 
            // ctrlMyPersonalInfoButton1
            // 
            this.ctrlMyPersonalInfoButton1.Location = new System.Drawing.Point(3, 355);
            this.ctrlMyPersonalInfoButton1.Size = new System.Drawing.Size(253, 50);
            // 
            // ctrlSystSettButton1
            // 
            this.ctrlSystSettButton1.Location = new System.Drawing.Point(3, 305);
            this.ctrlSystSettButton1.Size = new System.Drawing.Size(224, 50);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlMyPrescriptionForDocButton1);
            this.panel1.Controls.Add(this.ctrlMedicalRecordsButton1);
            this.panel1.Controls.Add(this.ctrlDoctorReservationButton1);
            this.panel1.Controls.Add(this.ctrlMyOperationMemberButton1);
            this.panel1.Controls.Add(this.ctrlMyDiagnosisDoctorButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.Controls.SetChildIndex(this.btnShrink, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlSystSettButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyPersonalInfoButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyLogsListButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyDiagnosisDoctorButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyOperationMemberButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlDoctorReservationButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMedicalRecordsButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyPrescriptionForDocButton1, 0);
            // 
            // ctrlMyDiagnosisDoctorButton1
            // 
            this.ctrlMyDiagnosisDoctorButton1.Location = new System.Drawing.Point(3, 55);
            this.ctrlMyDiagnosisDoctorButton1.Name = "ctrlMyDiagnosisDoctorButton1";
            this.ctrlMyDiagnosisDoctorButton1.Size = new System.Drawing.Size(224, 50);
            this.ctrlMyDiagnosisDoctorButton1.TabIndex = 3;
            // 
            // ctrlMyOperationMemberButton1
            // 
            this.ctrlMyOperationMemberButton1.Location = new System.Drawing.Point(3, 155);
            this.ctrlMyOperationMemberButton1.Name = "ctrlMyOperationMemberButton1";
            this.ctrlMyOperationMemberButton1.Size = new System.Drawing.Size(224, 50);
            this.ctrlMyOperationMemberButton1.TabIndex = 4;
            // 
            // ctrlDoctorReservationButton1
            // 
            this.ctrlDoctorReservationButton1.Location = new System.Drawing.Point(3, 105);
            this.ctrlDoctorReservationButton1.Name = "ctrlDoctorReservationButton1";
            this.ctrlDoctorReservationButton1.Size = new System.Drawing.Size(224, 50);
            this.ctrlDoctorReservationButton1.TabIndex = 5;
            // 
            // ctrlMedicalRecordsButton1
            // 
            this.ctrlMedicalRecordsButton1.Location = new System.Drawing.Point(3, 205);
            this.ctrlMedicalRecordsButton1.Name = "ctrlMedicalRecordsButton1";
            this.ctrlMedicalRecordsButton1.Size = new System.Drawing.Size(224, 50);
            this.ctrlMedicalRecordsButton1.TabIndex = 6;
            // 
            // ctrlMyPrescriptionForDocButton1
            // 
            this.ctrlMyPrescriptionForDocButton1.Location = new System.Drawing.Point(3, 255);
            this.ctrlMyPrescriptionForDocButton1.Name = "ctrlMyPrescriptionForDocButton1";
            this.ctrlMyPrescriptionForDocButton1.Size = new System.Drawing.Size(224, 50);
            this.ctrlMyPrescriptionForDocButton1.TabIndex = 7;
            // 
            // ctrlDoctorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrlDoctorPanel";
            this.Load += new System.EventHandler(this.ctrlDoctorPanel_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public HMS.Buttons.Records.EmployeeRecords.ctrlDoctorReservationButton ctrlDoctorReservationButton1;
        protected HMS.Buttons.Procedures.ctrlMyOperationMemberButton ctrlMyOperationMemberButton1;
        protected HMS.Buttons.Procedures.ctrlMyDiagnosisDoctorButton ctrlMyDiagnosisDoctorButton1;
        protected HMS.Buttons.Records.PatientLogs.ctrlMedicalRecordsButton ctrlMedicalRecordsButton1;
        protected HMS.Buttons.Medications.ctrlMyPrescriptionForDocButton ctrlMyPrescriptionForDocButton1;
    }
}
