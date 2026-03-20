namespace HMS
{
    partial class frmDiagnosisForDoctor
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
            this.ctrlDiagnosisListViewForDoctor1 = new HMS.Lists.Owners.Employee.ctrlDiagnosisListViewForDoctor();
            this.SuspendLayout();
            // 
            // ctrlDiagnosisListViewForDoctor1
            // 
            this.ctrlDiagnosisListViewForDoctor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlDiagnosisListViewForDoctor1.Location = new System.Drawing.Point(0, 0);
            this.ctrlDiagnosisListViewForDoctor1.Name = "ctrlDiagnosisListViewForDoctor1";
            this.ctrlDiagnosisListViewForDoctor1.Size = new System.Drawing.Size(1413, 669);
            this.ctrlDiagnosisListViewForDoctor1.TabIndex = 0;
            this.ctrlDiagnosisListViewForDoctor1.Load += new System.EventHandler(this.ctrlDiagnosisListViewForDoctor1_Load);
            // 
            // frmDiagnosisForDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 669);
            this.Controls.Add(this.ctrlDiagnosisListViewForDoctor1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDiagnosisForDoctor";
            this.Text = "frmDiagnosisForDoctor";
            this.Load += new System.EventHandler(this.frmDiagnosisForDoctor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Owners.Employee.ctrlDiagnosisListViewForDoctor ctrlDiagnosisListViewForDoctor1;
    }
}