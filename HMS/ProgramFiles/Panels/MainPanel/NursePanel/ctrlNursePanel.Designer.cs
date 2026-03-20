namespace HMS.ProgramFiles.Panels.MainPanel.NursePanel
{
    partial class ctrlNursePanel
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
            this.ctrlPatientLogsButton1 = new HMS.Buttons.Records.PatientLogs.ctrlPatientLogsButton();
            this.ctrlDiagnosisButton1 = new HMS.Buttons.Procedures.ctrlDiagnosisButton();
            this.ctrlMyOperationMemberButton1 = new HMS.Buttons.Procedures.ctrlMyOperationMemberButton();
            this.ctrlNurseReservationButton1 = new HMS.Buttons.Records.EmployeeRecords.ctrlNurseReservationButton();
            this.ctrlPatientButtons1 = new HMS.Buttons.ctrlPatientButtons();
            this.ctrlAllDoctorReservationButton1 = new HMS.Buttons.Records.EmployeeRecords.ctrlAllDoctorReservationButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlMyLogsListButton1
            // 
            this.ctrlMyLogsListButton1.Location = new System.Drawing.Point(3, 428);
            this.ctrlMyLogsListButton1.Size = new System.Drawing.Size(217, 50);
            // 
            // ctrlMyPersonalInfoButton1
            // 
            this.ctrlMyPersonalInfoButton1.Location = new System.Drawing.Point(3, 479);
            this.ctrlMyPersonalInfoButton1.Size = new System.Drawing.Size(217, 50);
            // 
            // ctrlSystSettButton1
            // 
            this.ctrlSystSettButton1.Location = new System.Drawing.Point(3, 530);
            this.ctrlSystSettButton1.Size = new System.Drawing.Size(217, 50);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlAllDoctorReservationButton1);
            this.panel1.Controls.Add(this.ctrlPatientButtons1);
            this.panel1.Controls.Add(this.ctrlNurseReservationButton1);
            this.panel1.Controls.Add(this.ctrlMyOperationMemberButton1);
            this.panel1.Controls.Add(this.ctrlDiagnosisButton1);
            this.panel1.Controls.Add(this.ctrlPatientLogsButton1);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.Controls.SetChildIndex(this.ctrlPatientLogsButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlDiagnosisButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyOperationMemberButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlNurseReservationButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlPatientButtons1, 0);
            this.panel1.Controls.SetChildIndex(this.btnShrink, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlSystSettButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyPersonalInfoButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyLogsListButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlAllDoctorReservationButton1, 0);
            // 
            // ctrlPatientLogsButton1
            // 
            this.ctrlPatientLogsButton1.Location = new System.Drawing.Point(0, 226);
            this.ctrlPatientLogsButton1.Name = "ctrlPatientLogsButton1";
            this.ctrlPatientLogsButton1.Size = new System.Drawing.Size(217, 50);
            this.ctrlPatientLogsButton1.TabIndex = 3;
            // 
            // ctrlDiagnosisButton1
            // 
            this.ctrlDiagnosisButton1.Location = new System.Drawing.Point(0, 175);
            this.ctrlDiagnosisButton1.Name = "ctrlDiagnosisButton1";
            this.ctrlDiagnosisButton1.Size = new System.Drawing.Size(217, 50);
            this.ctrlDiagnosisButton1.TabIndex = 4;
            // 
            // ctrlMyOperationMemberButton1
            // 
            this.ctrlMyOperationMemberButton1.Location = new System.Drawing.Point(0, 124);
            this.ctrlMyOperationMemberButton1.Name = "ctrlMyOperationMemberButton1";
            this.ctrlMyOperationMemberButton1.Size = new System.Drawing.Size(217, 50);
            this.ctrlMyOperationMemberButton1.TabIndex = 5;
            // 
            // ctrlNurseReservationButton1
            // 
            this.ctrlNurseReservationButton1.Location = new System.Drawing.Point(0, 73);
            this.ctrlNurseReservationButton1.Name = "ctrlNurseReservationButton1";
            this.ctrlNurseReservationButton1.Size = new System.Drawing.Size(217, 50);
            this.ctrlNurseReservationButton1.TabIndex = 6;
            // 
            // ctrlPatientButtons1
            // 
            this.ctrlPatientButtons1.Location = new System.Drawing.Point(0, 282);
            this.ctrlPatientButtons1.Name = "ctrlPatientButtons1";
            this.ctrlPatientButtons1.Size = new System.Drawing.Size(217, 50);
            this.ctrlPatientButtons1.TabIndex = 7;
            // 
            // ctrlAllDoctorReservationButton1
            // 
            this.ctrlAllDoctorReservationButton1.Location = new System.Drawing.Point(3, 338);
            this.ctrlAllDoctorReservationButton1.Name = "ctrlAllDoctorReservationButton1";
            this.ctrlAllDoctorReservationButton1.Size = new System.Drawing.Size(217, 50);
            this.ctrlAllDoctorReservationButton1.TabIndex = 8;
            // 
            // ctrlNursePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrlNursePanel";
            this.Load += new System.EventHandler(this.ctrlNursePanel_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HMS.Buttons.Records.PatientLogs.ctrlPatientLogsButton ctrlPatientLogsButton1;
        private HMS.Buttons.Procedures.ctrlDiagnosisButton ctrlDiagnosisButton1;
        private HMS.Buttons.Procedures.ctrlMyOperationMemberButton ctrlMyOperationMemberButton1;
        public HMS.Buttons.Records.EmployeeRecords.ctrlNurseReservationButton ctrlNurseReservationButton1;
        private HMS.Buttons.ctrlPatientButtons ctrlPatientButtons1;
        private HMS.Buttons.Records.EmployeeRecords.ctrlAllDoctorReservationButton ctrlAllDoctorReservationButton1;
    }
}
