namespace HMS
{
    partial class Accountant
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
            this.ctrlAccountantPanel1 = new HMS.ProgramFiles.Panels.MainPanel.AccountantPanel.ctrlAccountantPanel();
            this.SuspendLayout();
            // 
            // ctrlAccountantPanel1
            // 
            this.ctrlAccountantPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlAccountantPanel1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAccountantPanel1.MaximumSize = new System.Drawing.Size(230, 1000);
            this.ctrlAccountantPanel1.MinimumSize = new System.Drawing.Size(50, 1000);
            this.ctrlAccountantPanel1.Name = "ctrlAccountantPanel1";
            this.ctrlAccountantPanel1.Size = new System.Drawing.Size(230, 1000);
            this.ctrlAccountantPanel1.TabIndex = 1;
            // 
            // Accountant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1887, 915);
            this.Controls.Add(this.ctrlAccountantPanel1);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1905, 962);
            this.Name = "Accountant";
            this.Text = "Accountant";
            this.Load += new System.EventHandler(this.Accountant_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ProgramFiles.Panels.MainPanel.AccountantPanel.ctrlAccountantPanel ctrlAccountantPanel1;
    }
}