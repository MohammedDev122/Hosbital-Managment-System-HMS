namespace HMS
{
    partial class frmAddEditMedicalCatorgies
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
            this.ctrlAddEditMedCatorgy1 = new HMS.Add_Edit.Medications.ctrlAddEditMedCatorgy();
            this.SuspendLayout();
            // 
            // ctrlAddEditMedCatorgy1
            // 
            this.ctrlAddEditMedCatorgy1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditMedCatorgy1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditMedCatorgy1.Name = "ctrlAddEditMedCatorgy1";
            this.ctrlAddEditMedCatorgy1.Size = new System.Drawing.Size(1419, 450);
            this.ctrlAddEditMedCatorgy1.TabIndex = 0;
            this.ctrlAddEditMedCatorgy1.Load += new System.EventHandler(this.ctrlAddEditMedCatorgy1_Load);
            // 
            // frmAddEditMedicalCatorgies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 450);
            this.Controls.Add(this.ctrlAddEditMedCatorgy1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditMedicalCatorgies";
            this.Text = "frmAddEditMedicalCatorgies";
            this.Load += new System.EventHandler(this.frmAddEditMedicalCatorgies_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.Medications.ctrlAddEditMedCatorgy ctrlAddEditMedCatorgy1;
    }
}