namespace HMS
{
    partial class frmAddEditMedication
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
            this.ctrlAddEditMedication1 = new HMS.Add_Edit.Medications.ctrlAddEditMedication();
            this.SuspendLayout();
            // 
            // ctrlAddEditMedication1
            // 
            this.ctrlAddEditMedication1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditMedication1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditMedication1.Name = "ctrlAddEditMedication1";
            this.ctrlAddEditMedication1.Size = new System.Drawing.Size(1415, 531);
            this.ctrlAddEditMedication1.TabIndex = 0;
            this.ctrlAddEditMedication1.Load += new System.EventHandler(this.ctrlAddEditMedication1_Load);
            // 
            // frmAddEditMedication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 531);
            this.Controls.Add(this.ctrlAddEditMedication1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditMedication";
            this.Text = "frmAddEditMedication";
            this.Load += new System.EventHandler(this.frmAddEditMedication_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.Medications.ctrlAddEditMedication ctrlAddEditMedication1;
    }
}