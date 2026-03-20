namespace HMS
{
    partial class frmMyLogsList
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
            this.ctrllogsListForEmployee1 = new HMS.Lists.Owners.ctrllogsListForEmployee();
            this.SuspendLayout();
            // 
            // ctrllogsListForEmployee1
            // 
            this.ctrllogsListForEmployee1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrllogsListForEmployee1.Location = new System.Drawing.Point(0, 0);
            this.ctrllogsListForEmployee1.Name = "ctrllogsListForEmployee1";
            this.ctrllogsListForEmployee1.Size = new System.Drawing.Size(1361, 534);
            this.ctrllogsListForEmployee1.TabIndex = 0;
            this.ctrllogsListForEmployee1.Load += new System.EventHandler(this.ctrllogsListForEmployee1_Load);
            // 
            // frmMyLogsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 534);
            this.Controls.Add(this.ctrllogsListForEmployee1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMyLogsList";
            this.Text = "frmMyLogsList";
            this.Load += new System.EventHandler(this.frmMyLogsList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Owners.ctrllogsListForEmployee ctrllogsListForEmployee1;
    }
}