namespace HMS
{
    partial class Pharmacist
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
            this.ctrlPharmacistPanel1 = new HMS.ProgramFiles.Panels.MainPanel.PharmacistPanel.ctrlPharmacistPanel();
            this.SuspendLayout();
            // 
            // ctrlPharmacistPanel1
            // 
            this.ctrlPharmacistPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlPharmacistPanel1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPharmacistPanel1.MaximumSize = new System.Drawing.Size(260, 1000);
            this.ctrlPharmacistPanel1.MinimumSize = new System.Drawing.Size(50, 1000);
            this.ctrlPharmacistPanel1.Name = "ctrlPharmacistPanel1";
            this.ctrlPharmacistPanel1.Size = new System.Drawing.Size(260, 1000);
            this.ctrlPharmacistPanel1.TabIndex = 1;
            // 
            // Pharmacist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1887, 971);
            this.Controls.Add(this.ctrlPharmacistPanel1);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1905, 1018);
            this.Name = "Pharmacist";
            this.Text = "Pharmacist";
            this.Load += new System.EventHandler(this.Pharmacist_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ProgramFiles.Panels.MainPanel.PharmacistPanel.ctrlPharmacistPanel ctrlPharmacistPanel1;
    }
}