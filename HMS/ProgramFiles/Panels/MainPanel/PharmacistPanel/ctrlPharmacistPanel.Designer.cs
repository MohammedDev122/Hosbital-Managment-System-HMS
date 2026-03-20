namespace HMS.ProgramFiles.Panels.MainPanel.PharmacistPanel
{
    partial class ctrlPharmacistPanel
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
            this.ctrlPharmecyRecordsButton1 = new HMS.Buttons.Procedures.ctrlPharmecyRecordsButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlPharmecyRecordsButton1);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.Controls.SetChildIndex(this.ctrlSystSettButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyPersonalInfoButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyLogsListButton1, 0);
            this.panel1.Controls.SetChildIndex(this.btnShrink, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlPharmecyRecordsButton1, 0);
            // 
            // ctrlPharmecyRecordsButton1
            // 
            this.ctrlPharmecyRecordsButton1.Location = new System.Drawing.Point(3, 92);
            this.ctrlPharmecyRecordsButton1.Name = "ctrlPharmecyRecordsButton1";
            this.ctrlPharmecyRecordsButton1.Panel = null;
            this.ctrlPharmecyRecordsButton1.Size = new System.Drawing.Size(250, 50);
            this.ctrlPharmecyRecordsButton1.TabIndex = 4;
            // 
            // ctrlPharmacistPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrlPharmacistPanel";
            this.Load += new System.EventHandler(this.ctrlPharmacistPanel_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public HMS.Buttons.Procedures.ctrlPharmecyRecordsButton ctrlPharmecyRecordsButton1;
    }
}
