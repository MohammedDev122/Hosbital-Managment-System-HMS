namespace HMS
{
    partial class frmPatientLogsList
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
            this.ctrlPatientLogsListForAdmin1 = new HMS.Lists.Admins.ctrlPatientLogsListForAdmin();
            this.SuspendLayout();
            // 
            // ctrlPatientLogsListForAdmin1
            // 
            this.ctrlPatientLogsListForAdmin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPatientLogsListForAdmin1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPatientLogsListForAdmin1.Name = "ctrlPatientLogsListForAdmin1";
            this.ctrlPatientLogsListForAdmin1.Size = new System.Drawing.Size(1353, 579);
            this.ctrlPatientLogsListForAdmin1.TabIndex = 0;
            this.ctrlPatientLogsListForAdmin1.Load += new System.EventHandler(this.ctrlPatientLogsListForAdmin1_Load);
            // 
            // frmPatientLogsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 579);
            this.Controls.Add(this.ctrlPatientLogsListForAdmin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPatientLogsList";
            this.Text = "frmPatientLogsButton";
            this.Load += new System.EventHandler(this.frmPatientLogsButton_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlPatientLogsListForAdmin ctrlPatientLogsListForAdmin1;
    }
}