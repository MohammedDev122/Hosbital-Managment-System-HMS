namespace HMS
{
    partial class frmAddEditDiagnosis
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
            this.ctrlAddEditDiagnosis1 = new HMS.Add_Edit.AddEditServices.ctrlAddEditDiagnosis();
            this.SuspendLayout();
            // 
            // ctrlAddEditDiagnosis1
            // 
            this.ctrlAddEditDiagnosis1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditDiagnosis1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditDiagnosis1.Name = "ctrlAddEditDiagnosis1";
            this.ctrlAddEditDiagnosis1.Size = new System.Drawing.Size(1455, 599);
            this.ctrlAddEditDiagnosis1.TabIndex = 0;
            this.ctrlAddEditDiagnosis1.Load += new System.EventHandler(this.ctrlAddEditDiagnosis1_Load);
            // 
            // frmAddEditDiagnosis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1455, 599);
            this.Controls.Add(this.ctrlAddEditDiagnosis1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditDiagnosis";
            this.Text = "frmAddEditDiagnosis";
            this.Load += new System.EventHandler(this.frmAddEditDiagnosis_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.AddEditServices.ctrlAddEditDiagnosis ctrlAddEditDiagnosis1;
    }
}