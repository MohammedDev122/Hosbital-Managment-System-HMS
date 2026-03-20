namespace HMS
{
    partial class frmAddEditPrescription
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
            this.ctrlAddEditPrescriptions1 = new HMS.Add_Edit.Medications.ctrlAddEditPrescriptions();
            this.SuspendLayout();
            // 
            // ctrlAddEditPrescriptions1
            // 
            this.ctrlAddEditPrescriptions1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditPrescriptions1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditPrescriptions1.Name = "ctrlAddEditPrescriptions1";
            this.ctrlAddEditPrescriptions1.Size = new System.Drawing.Size(1413, 450);
            this.ctrlAddEditPrescriptions1.TabIndex = 0;
            this.ctrlAddEditPrescriptions1.Load += new System.EventHandler(this.ctrlAddEditPrescriptions1_Load);
            // 
            // frmAddEditPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 450);
            this.Controls.Add(this.ctrlAddEditPrescriptions1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditPrescription";
            this.Text = "frmAddEditPrescription";
            this.Load += new System.EventHandler(this.frmAddEditPrescription_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.Medications.ctrlAddEditPrescriptions ctrlAddEditPrescriptions1;
    }
}