namespace HMS.ProgramFiles.Panels.MainPanel.NursePanel
{
    partial class ctrlHeadNurse
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
            this.ctrlNurseSubPanelButton1 = new HMS.ProgramFiles.Buttons.ctrlNurseSubPanelButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlMyLogsListButton1
            // 
            this.ctrlMyLogsListButton1.Location = new System.Drawing.Point(0, 421);
            // 
            // ctrlMyPersonalInfoButton1
            // 
            this.ctrlMyPersonalInfoButton1.Location = new System.Drawing.Point(0, 472);
            // 
            // ctrlSystSettButton1
            // 
            this.ctrlSystSettButton1.Location = new System.Drawing.Point(0, 528);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlNurseSubPanelButton1);
            this.panel1.Controls.SetChildIndex(this.btnShrink, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlSystSettButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyPersonalInfoButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyLogsListButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlNurseSubPanelButton1, 0);
            // 
            // ctrlNurseSubPanelButton1
            // 
            this.ctrlNurseSubPanelButton1.Location = new System.Drawing.Point(3, 376);
            this.ctrlNurseSubPanelButton1.Name = "ctrlNurseSubPanelButton1";
            this.ctrlNurseSubPanelButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlNurseSubPanelButton1.Size = new System.Drawing.Size(232, 39);
            this.ctrlNurseSubPanelButton1.TabIndex = 9;
            // 
            // ctrlHeadNurse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrlHeadNurse";
            this.Load += new System.EventHandler(this.ctrlHeadNurse_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Buttons.ctrlNurseSubPanelButton ctrlNurseSubPanelButton1;
    }
}
