namespace HMS
{
    partial class frmAddPrescripedMed
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
            this.ctrlPrescripedMedListForPatient1 = new HMS.Lists.Owners.Patient.ctrlPrescripedMedListForPatient();
            this.ctrlMedicationListForOthers1 = new HMS.Lists.Others.ctrlMedicationListForOthers();
            this.SuspendLayout();
            // 
            // ctrlPrescripedMedListForPatient1
            // 
            this.ctrlPrescripedMedListForPatient1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlPrescripedMedListForPatient1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPrescripedMedListForPatient1.Name = "ctrlPrescripedMedListForPatient1";
            this.ctrlPrescripedMedListForPatient1.Size = new System.Drawing.Size(1448, 398);
            this.ctrlPrescripedMedListForPatient1.TabIndex = 0;
            this.ctrlPrescripedMedListForPatient1.Load += new System.EventHandler(this.ctrlPrescripedMedListForPatient1_Load);
            // 
            // ctrlMedicationListForOthers1
            // 
            this.ctrlMedicationListForOthers1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlMedicationListForOthers1.Location = new System.Drawing.Point(0, 394);
            this.ctrlMedicationListForOthers1.Name = "ctrlMedicationListForOthers1";
            this.ctrlMedicationListForOthers1.Size = new System.Drawing.Size(1448, 331);
            this.ctrlMedicationListForOthers1.TabIndex = 1;
            this.ctrlMedicationListForOthers1.OnSelectedID += new System.EventHandler<int>(this.ctrlMedicationListForOthers1_OnSelectedID);
            // 
            // frmAddPrescripedMed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 725);
            this.Controls.Add(this.ctrlMedicationListForOthers1);
            this.Controls.Add(this.ctrlPrescripedMedListForPatient1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddPrescripedMed";
            this.Text = "frmAddPrescripedMed";
            this.Load += new System.EventHandler(this.frmAddPrescripedMed_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Owners.Patient.ctrlPrescripedMedListForPatient ctrlPrescripedMedListForPatient1;
        private Lists.Others.ctrlMedicationListForOthers ctrlMedicationListForOthers1;
    }
}