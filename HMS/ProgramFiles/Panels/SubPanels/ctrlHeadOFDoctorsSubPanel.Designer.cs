namespace HMS.ProgramFiles.Panels.SubPanels
{
    partial class ctrlHeadOFDoctorsSubPanel
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
            this.ctrlServicesTypesButton1 = new HMS.Buttons.Derived.ctrlServicesTypesButton();
            this.ctrlSpecilizationsButton1 = new HMS.Buttons.Derived.ctrlSpecilizationsButton();
            this.ctrlOperaionsButton1 = new HMS.Buttons.Procedures.ctrlOperaionsButton();
            this.ctrlDoctorButton1 = new HMS.Buttons.ctrlDoctorButton();
            this.ctrlAllDoctorReservationButton1 = new HMS.Buttons.Records.EmployeeRecords.ctrlAllDoctorReservationButton();
            this.ctrlDiagnosisButton1 = new HMS.Buttons.Procedures.ctrlDiagnosisButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlDiagnosisButton1);
            this.panel1.Controls.Add(this.ctrlAllDoctorReservationButton1);
            this.panel1.Controls.Add(this.ctrlDoctorButton1);
            this.panel1.Controls.Add(this.ctrlOperaionsButton1);
            this.panel1.Controls.Add(this.ctrlSpecilizationsButton1);
            this.panel1.Controls.Add(this.ctrlServicesTypesButton1);
            this.panel1.MaximumSize = new System.Drawing.Size(240, 401);
            this.panel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.panel1.Size = new System.Drawing.Size(240, 401);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ctrlServicesTypesButton1
            // 
            this.ctrlServicesTypesButton1.Location = new System.Drawing.Point(3, 305);
            this.ctrlServicesTypesButton1.Name = "ctrlServicesTypesButton1";
            this.ctrlServicesTypesButton1.Panel = null;
            this.ctrlServicesTypesButton1.Size = new System.Drawing.Size(177, 50);
            this.ctrlServicesTypesButton1.TabIndex = 0;
            // 
            // ctrlSpecilizationsButton1
            // 
            this.ctrlSpecilizationsButton1.Location = new System.Drawing.Point(3, 253);
            this.ctrlSpecilizationsButton1.Name = "ctrlSpecilizationsButton1";
            this.ctrlSpecilizationsButton1.Panel = null;
            this.ctrlSpecilizationsButton1.Size = new System.Drawing.Size(174, 50);
            this.ctrlSpecilizationsButton1.TabIndex = 1;
            // 
            // ctrlOperaionsButton1
            // 
            this.ctrlOperaionsButton1.Location = new System.Drawing.Point(3, 197);
            this.ctrlOperaionsButton1.Name = "ctrlOperaionsButton1";
            this.ctrlOperaionsButton1.Panel = null;
            this.ctrlOperaionsButton1.Size = new System.Drawing.Size(174, 50);
            this.ctrlOperaionsButton1.TabIndex = 2;
            // 
            // ctrlDoctorButton1
            // 
            this.ctrlDoctorButton1.Location = new System.Drawing.Point(3, 147);
            this.ctrlDoctorButton1.Name = "ctrlDoctorButton1";
            this.ctrlDoctorButton1.Panel = null;
            this.ctrlDoctorButton1.Size = new System.Drawing.Size(174, 50);
            this.ctrlDoctorButton1.TabIndex = 3;
            // 
            // ctrlAllDoctorReservationButton1
            // 
            this.ctrlAllDoctorReservationButton1.Location = new System.Drawing.Point(3, 91);
            this.ctrlAllDoctorReservationButton1.Name = "ctrlAllDoctorReservationButton1";
            this.ctrlAllDoctorReservationButton1.Panel = null;
            this.ctrlAllDoctorReservationButton1.Size = new System.Drawing.Size(220, 50);
            this.ctrlAllDoctorReservationButton1.TabIndex = 4;
            // 
            // ctrlDiagnosisButton1
            // 
            this.ctrlDiagnosisButton1.Location = new System.Drawing.Point(3, 35);
            this.ctrlDiagnosisButton1.Name = "ctrlDiagnosisButton1";
            this.ctrlDiagnosisButton1.Panel = null;
            this.ctrlDiagnosisButton1.Size = new System.Drawing.Size(174, 50);
            this.ctrlDiagnosisButton1.TabIndex = 5;
            // 
            // ctrlHeadOFDoctorsSubPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MaximumSize = new System.Drawing.Size(240, 401);
            this.Name = "ctrlHeadOFDoctorsSubPanel";
            this.Size = new System.Drawing.Size(240, 401);
            this.Load += new System.EventHandler(this.ctrlHeadOFDoctorsSubPanel_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HMS.Buttons.Derived.ctrlServicesTypesButton ctrlServicesTypesButton1;
        private HMS.Buttons.Derived.ctrlSpecilizationsButton ctrlSpecilizationsButton1;
        private HMS.Buttons.Procedures.ctrlOperaionsButton ctrlOperaionsButton1;
        private HMS.Buttons.Records.EmployeeRecords.ctrlAllDoctorReservationButton ctrlAllDoctorReservationButton1;
        private HMS.Buttons.ctrlDoctorButton ctrlDoctorButton1;
        private HMS.Buttons.Procedures.ctrlDiagnosisButton ctrlDiagnosisButton1;
    }
}
