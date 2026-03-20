namespace HMS
{
    partial class frmPrescriptionSelectList
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
            this.ctrlPrescriptionsListForOthers1 = new HMS.Lists.Others.ctrlPrescriptionsListForOthers();
            this.SuspendLayout();
            // 
            // ctrlPrescriptionsListForOthers1
            // 
            this.ctrlPrescriptionsListForOthers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPrescriptionsListForOthers1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPrescriptionsListForOthers1.Name = "ctrlPrescriptionsListForOthers1";
            this.ctrlPrescriptionsListForOthers1.Size = new System.Drawing.Size(1532, 585);
            this.ctrlPrescriptionsListForOthers1.TabIndex = 0;
            this.ctrlPrescriptionsListForOthers1.Load += new System.EventHandler(this.ctrlPrescriptionsListForOthers1_Load);
            // 
            // frmPrescriptionSelectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 585);
            this.Controls.Add(this.ctrlPrescriptionsListForOthers1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPrescriptionSelectList";
            this.Text = "frmPrescriptionSelectList";
            this.Load += new System.EventHandler(this.frmPrescriptionSelectList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Others.ctrlPrescriptionsListForOthers ctrlPrescriptionsListForOthers1;
    }
}