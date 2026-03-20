namespace HMS
{
    partial class frmLogsList
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
            this.ctrlLogsListForAdmin1 = new HMS.Lists.Admins.ctrlLogsListForAdmin();
            this.SuspendLayout();
            // 
            // ctrlLogsListForAdmin1
            // 
            this.ctrlLogsListForAdmin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLogsListForAdmin1.Location = new System.Drawing.Point(0, 0);
            this.ctrlLogsListForAdmin1.Name = "ctrlLogsListForAdmin1";
            this.ctrlLogsListForAdmin1.Size = new System.Drawing.Size(1374, 546);
            this.ctrlLogsListForAdmin1.TabIndex = 0;
            this.ctrlLogsListForAdmin1.Load += new System.EventHandler(this.ctrlLogsListForAdmin1_Load);
            // 
            // frmLogsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 546);
            this.Controls.Add(this.ctrlLogsListForAdmin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogsList";
            this.Text = "frmLogsList";
            this.Load += new System.EventHandler(this.frmLogsList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlLogsListForAdmin ctrlLogsListForAdmin1;
    }
}