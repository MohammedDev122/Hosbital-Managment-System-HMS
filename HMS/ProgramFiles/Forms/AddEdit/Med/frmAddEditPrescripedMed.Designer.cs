namespace HMS
{
    partial class frmAddEditPrescripedMed
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
            this.ctrlAddEditPrescripedMed1 = new HMS.Add_Edit.Medications.ctrlAddEditPrescripedMed();
            this.SuspendLayout();
            // 
            // ctrlAddEditPrescripedMed1
            // 
            this.ctrlAddEditPrescripedMed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditPrescripedMed1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditPrescripedMed1.Name = "ctrlAddEditPrescripedMed1";
            this.ctrlAddEditPrescripedMed1.Size = new System.Drawing.Size(1502, 590);
            this.ctrlAddEditPrescripedMed1.TabIndex = 0;
            this.ctrlAddEditPrescripedMed1.Load += new System.EventHandler(this.ctrlAddEditPrescripedMed1_Load);
            // 
            // frmAddEditPrescripedMed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 590);
            this.Controls.Add(this.ctrlAddEditPrescripedMed1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditPrescripedMed";
            this.Text = "frmAddEditPrescripedMed";
            this.Load += new System.EventHandler(this.frmAddEditPrescripedMed_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.Medications.ctrlAddEditPrescripedMed ctrlAddEditPrescripedMed1;
    }
}