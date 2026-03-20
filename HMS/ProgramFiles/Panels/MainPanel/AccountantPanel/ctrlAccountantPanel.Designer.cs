namespace HMS.ProgramFiles.Panels.MainPanel.AccountantPanel
{
    partial class ctrlAccountantPanel
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
            this.ctrlPaymentsButton1 = new HMS.Buttons.Procedures.ctrlPaymentsButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlMyLogsListButton1
            // 
            this.ctrlMyLogsListButton1.Size = new System.Drawing.Size(202, 50);
            // 
            // ctrlMyPersonalInfoButton1
            // 
            this.ctrlMyPersonalInfoButton1.Size = new System.Drawing.Size(202, 50);
            // 
            // ctrlSystSettButton1
            // 
            this.ctrlSystSettButton1.Size = new System.Drawing.Size(202, 50);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlPaymentsButton1);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.Controls.SetChildIndex(this.ctrlSystSettButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyPersonalInfoButton1, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlMyLogsListButton1, 0);
            this.panel1.Controls.SetChildIndex(this.btnShrink, 0);
            this.panel1.Controls.SetChildIndex(this.ctrlPaymentsButton1, 0);
            // 
            // ctrlPaymentsButton1
            // 
            this.ctrlPaymentsButton1.Location = new System.Drawing.Point(3, 113);
            this.ctrlPaymentsButton1.Name = "ctrlPaymentsButton1";
            this.ctrlPaymentsButton1.Panel = null;
            this.ctrlPaymentsButton1.Size = new System.Drawing.Size(202, 50);
            this.ctrlPaymentsButton1.TabIndex = 4;
            // 
            // ctrlAccountantPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrlAccountantPanel";
            this.Load += new System.EventHandler(this.ctrlAccountantPanel_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public HMS.Buttons.Procedures.ctrlPaymentsButton ctrlPaymentsButton1;
    }
}
