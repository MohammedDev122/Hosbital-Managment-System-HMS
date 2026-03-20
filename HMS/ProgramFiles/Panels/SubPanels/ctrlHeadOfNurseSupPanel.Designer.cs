namespace HMS.ProgramFiles.Panels.SubPanels
{
    partial class ctrlHeadOfNurseSupPanel
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
            this.ctrlNurseButton1 = new HMS.Buttons.Persons.Employee.ctrlNurseButton();
            this.ctrlAllNursesReservationsButton1 = new HMS.Buttons.Records.EmployeeRecords.ctrlAllNursesReservationsButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlAllNursesReservationsButton1);
            this.panel1.Controls.Add(this.ctrlNurseButton1);
            this.panel1.MaximumSize = new System.Drawing.Size(250, 401);
            this.panel1.Size = new System.Drawing.Size(250, 401);
            // 
            // ctrlNurseButton1
            // 
            this.ctrlNurseButton1.Location = new System.Drawing.Point(-3, 32);
            this.ctrlNurseButton1.Name = "ctrlNurseButton1";
            this.ctrlNurseButton1.Size = new System.Drawing.Size(250, 50);
            this.ctrlNurseButton1.TabIndex = 0;
            // 
            // ctrlAllNursesReservationsButton1
            // 
            this.ctrlAllNursesReservationsButton1.Location = new System.Drawing.Point(3, 88);
            this.ctrlAllNursesReservationsButton1.Name = "ctrlAllNursesReservationsButton1";
            this.ctrlAllNursesReservationsButton1.Size = new System.Drawing.Size(247, 50);
            this.ctrlAllNursesReservationsButton1.TabIndex = 1;
            // 
            // ctrlHeadOfNurseSupPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MaximumSize = new System.Drawing.Size(250, 401);
            this.Name = "ctrlHeadOfNurseSupPanel";
            this.Size = new System.Drawing.Size(250, 401);
            this.Load += new System.EventHandler(this.ctrlHeadOfNurseSupPanel_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private HMS.Buttons.Persons.Employee.ctrlNurseButton ctrlNurseButton1;
        private HMS.Buttons.Records.EmployeeRecords.ctrlAllNursesReservationsButton ctrlAllNursesReservationsButton1;
    }
}
