namespace HMS
{
    partial class frmAddEditPharmacist
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
            this.ctrlAddEditPharmacist1 = new HMS.Add_Edit.AddEditPerson.AddEditEmployees.ctrlAddEditPharmacist();
            this.SuspendLayout();
            // 
            // ctrlAddEditPharmacist1
            // 
            this.ctrlAddEditPharmacist1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditPharmacist1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditPharmacist1.Name = "ctrlAddEditPharmacist1";
            this.ctrlAddEditPharmacist1.Size = new System.Drawing.Size(1451, 733);
            this.ctrlAddEditPharmacist1.TabIndex = 0;
            this.ctrlAddEditPharmacist1.Load += new System.EventHandler(this.ctrlAddEditPharmacist1_Load);
            // 
            // frmAddEditPharmacist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 733);
            this.Controls.Add(this.ctrlAddEditPharmacist1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditPharmacist";
            this.Text = "frmAddEditPharmacist";
            this.Load += new System.EventHandler(this.frmAddEditPharmacist_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.AddEditPerson.AddEditEmployees.ctrlAddEditPharmacist ctrlAddEditPharmacist1;
    }
}