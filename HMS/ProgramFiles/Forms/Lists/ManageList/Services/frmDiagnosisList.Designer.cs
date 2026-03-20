namespace HMS
{
    partial class frmDiagnosisList
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
            this.ctrlDiagnosisListViewForAdmins1 = new HMS.Lists.Admins.ctrlDiagnosisListViewForAdmins();
            this.SuspendLayout();
            // 
            // ctrlDiagnosisListViewForAdmins1
            // 
            this.ctrlDiagnosisListViewForAdmins1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlDiagnosisListViewForAdmins1.Location = new System.Drawing.Point(0, 0);
            this.ctrlDiagnosisListViewForAdmins1.Name = "ctrlDiagnosisListViewForAdmins1";
            this.ctrlDiagnosisListViewForAdmins1.Size = new System.Drawing.Size(1460, 585);
            this.ctrlDiagnosisListViewForAdmins1.TabIndex = 0;
            this.ctrlDiagnosisListViewForAdmins1.Load += new System.EventHandler(this.ctrlDiagnosisListViewForAdmins1_Load);
            // 
            // frmDiagnosisList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 585);
            this.Controls.Add(this.ctrlDiagnosisListViewForAdmins1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDiagnosisList";
            this.Text = "frmDiagnosisList";
            this.Load += new System.EventHandler(this.frmDiagnosisList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlDiagnosisListViewForAdmins ctrlDiagnosisListViewForAdmins1;
    }
}