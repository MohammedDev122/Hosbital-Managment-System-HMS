namespace HMS.ProgramFiles.Panels.MainPanel.PharmacistPanel
{
    partial class ctrlHeadPharmacist
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlPharmacistSupPanelButton1 = new HMS.ProgramFiles.Buttons.ctrlPharmacistSupPanelButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlPharmacistSupPanelButton1);
            this.panel1.Controls.SetChildIndex(this.ctrlSystSettButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyPersonalInfoButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyLogsListButton1, 0);
            this.panel1.Controls.SetChildIndex(this.btnShrink, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlPharmacistSupPanelButton1, 0);
            // 
            // ctrlPharmacistSupPanelButton1
            // 
            this.ctrlPharmacistSupPanelButton1.Location = new System.Drawing.Point(3, 148);
            this.ctrlPharmacistSupPanelButton1.Name = "ctrlPharmacistSupPanelButton1";
            this.ctrlPharmacistSupPanelButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlPharmacistSupPanelButton1.Size = new System.Drawing.Size(250, 39);
            this.ctrlPharmacistSupPanelButton1.TabIndex = 5;
            // 
            // ctrlHeadPharmacist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrlHeadPharmacist";
            this.Load += new System.EventHandler(this.ctrlHeadPharmacist_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Buttons.ctrlPharmacistSupPanelButton ctrlPharmacistSupPanelButton1;
    }
}
