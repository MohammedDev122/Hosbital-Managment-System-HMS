namespace HMS.ProgramFiles.Panels.MainPanel.AccountantPanel
{
    partial class ctrlHeadAccountant
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
            this.ctrlAccountantSubPanelButton1 = new HMS.ProgramFiles.Buttons.ctrlAccountantSubPanelButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlAccountantSubPanelButton1);
            this.panel1.Controls.SetChildIndex(this.ctrlSystSettButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyPersonalInfoButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyLogsListButton1, 0);
            this.panel1.Controls.SetChildIndex(this.btnShrink, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlAccountantSubPanelButton1, 0);
            // 
            // ctrlAccountantSubPanelButton1
            // 
            this.ctrlAccountantSubPanelButton1.Location = new System.Drawing.Point(3, 169);
            this.ctrlAccountantSubPanelButton1.Name = "ctrlAccountantSubPanelButton1";
            this.ctrlAccountantSubPanelButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlAccountantSubPanelButton1.Size = new System.Drawing.Size(223, 39);
            this.ctrlAccountantSubPanelButton1.TabIndex = 5;
            // 
            // ctrlHeadAccountant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrlHeadAccountant";
            this.Load += new System.EventHandler(this.ctrlHeadAccountant_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Buttons.ctrlAccountantSubPanelButton ctrlAccountantSubPanelButton1;
    }
}
