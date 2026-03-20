namespace HMS
{
    partial class Doctor
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
            this.ctrlDoctorPanel1 = new HMS.ProgramFiles.Panels.MainPanel.ctrlDoctorPanel();
            this.SuspendLayout();
            // 
            // ctrlDoctorPanel1
            // 
            this.ctrlDoctorPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlDoctorPanel1.Location = new System.Drawing.Point(0, 0);
            this.ctrlDoctorPanel1.MaximumSize = new System.Drawing.Size(230, 1000);
            this.ctrlDoctorPanel1.MinimumSize = new System.Drawing.Size(50, 1000);
            this.ctrlDoctorPanel1.Name = "ctrlDoctorPanel1";
            this.ctrlDoctorPanel1.Size = new System.Drawing.Size(230, 1000);
            this.ctrlDoctorPanel1.TabIndex = 1;
            // 
            // Doctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1887, 915);
            this.Controls.Add(this.ctrlDoctorPanel1);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1905, 962);
            this.Name = "Doctor";
            this.Text = "Doctor";
            this.Load += new System.EventHandler(this.Doctor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ProgramFiles.Panels.MainPanel.ctrlDoctorPanel ctrlDoctorPanel1;
    }
}