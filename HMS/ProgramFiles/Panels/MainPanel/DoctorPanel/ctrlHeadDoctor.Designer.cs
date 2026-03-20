namespace HMS.ProgramFiles.Panels.MainPanel
{
    partial class ctrlHeadDoctor
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
            this.ctrlDoctorSubPanelButton1 = new HMS.ProgramFiles.Buttons.ctrlDoctorSubPanelButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlMyLogsListButton1
            // 
            this.ctrlMyLogsListButton1.Location = new System.Drawing.Point(3, 705);
            // 
            // ctrlMyPersonalInfoButton1
            // 
            this.ctrlMyPersonalInfoButton1.Location = new System.Drawing.Point(3, 655);
            // 
            // ctrlSystSettButton1
            // 
            this.ctrlSystSettButton1.Location = new System.Drawing.Point(3, 605);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlDoctorSubPanelButton1);
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
            this.panel1.Controls.SetChildIndex(this.ctrlDoctorSubPanelButton1, 0);
            // 
            // ctrlDoctorSubPanelButton1
            // 
            this.ctrlDoctorSubPanelButton1.Location = new System.Drawing.Point(3, 302);
            this.ctrlDoctorSubPanelButton1.Name = "ctrlDoctorSubPanelButton1";
            this.ctrlDoctorSubPanelButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlDoctorSubPanelButton1.Size = new System.Drawing.Size(224, 39);
            this.ctrlDoctorSubPanelButton1.TabIndex = 8;
            // 
            // ctrlHeadDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrlHeadDoctor";
            this.Load += new System.EventHandler(this.ctrlHeadDoctor_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Buttons.ctrlDoctorSubPanelButton ctrlDoctorSubPanelButton1;
    }
}
