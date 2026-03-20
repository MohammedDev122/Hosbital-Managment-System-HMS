namespace HMS.ProgramFiles.Panels.SubPanels
{
    partial class ctrlHeadOfPharmacistSupPanel
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
            this.ctrlPharmacistButton1 = new HMS.Buttons.Persons.Employee.ctrlPharmacistButton();
            this.ctrlMedicationButton1 = new HMS.Buttons.Medications.ctrlMedicationButton();
            this.ctrlCatorgiesButton1 = new HMS.Buttons.Derived.ctrlCatorgiesButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlCatorgiesButton1);
            this.panel1.Controls.Add(this.ctrlMedicationButton1);
            this.panel1.Controls.Add(this.ctrlPharmacistButton1);
            // 
            // ctrlPharmacistButton1
            // 
            this.ctrlPharmacistButton1.Location = new System.Drawing.Point(3, 58);
            this.ctrlPharmacistButton1.Name = "ctrlPharmacistButton1";
            this.ctrlPharmacistButton1.Panel = null;
            this.ctrlPharmacistButton1.Size = new System.Drawing.Size(174, 50);
            this.ctrlPharmacistButton1.TabIndex = 0;
            // 
            // ctrlMedicationButton1
            // 
            this.ctrlMedicationButton1.Location = new System.Drawing.Point(0, 105);
            this.ctrlMedicationButton1.Name = "ctrlMedicationButton1";
            this.ctrlMedicationButton1.Panel = null;
            this.ctrlMedicationButton1.Size = new System.Drawing.Size(180, 63);
            this.ctrlMedicationButton1.TabIndex = 1;
            // 
            // ctrlCatorgiesButton1
            // 
            this.ctrlCatorgiesButton1.Location = new System.Drawing.Point(-61, 174);
            this.ctrlCatorgiesButton1.Name = "ctrlCatorgiesButton1";
            this.ctrlCatorgiesButton1.Panel = null;
            this.ctrlCatorgiesButton1.Size = new System.Drawing.Size(238, 50);
            this.ctrlCatorgiesButton1.TabIndex = 2;
            // 
            // ctrlHeadOfPharmacistSupPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrlHeadOfPharmacistSupPanel";
            this.Load += new System.EventHandler(this.ctrlHeadOfPharmacistSupPanel_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HMS.Buttons.Derived.ctrlCatorgiesButton ctrlCatorgiesButton1;
        private HMS.Buttons.Medications.ctrlMedicationButton ctrlMedicationButton1;
        private HMS.Buttons.Persons.Employee.ctrlPharmacistButton ctrlPharmacistButton1;
    }
}
