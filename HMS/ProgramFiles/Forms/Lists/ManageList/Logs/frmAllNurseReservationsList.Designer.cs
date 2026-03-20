namespace HMS
{
    partial class frmAllNurseReservationsList
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
            this.ctrlNurseReservationListForAdmins1 = new HMS.Lists.Admins.ctrlNurseReservationListForAdmins();
            this.SuspendLayout();
            // 
            // ctrlNurseReservationListForAdmins1
            // 
            this.ctrlNurseReservationListForAdmins1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlNurseReservationListForAdmins1.Location = new System.Drawing.Point(0, 0);
            this.ctrlNurseReservationListForAdmins1.Name = "ctrlNurseReservationListForAdmins1";
            this.ctrlNurseReservationListForAdmins1.Size = new System.Drawing.Size(1346, 530);
            this.ctrlNurseReservationListForAdmins1.TabIndex = 0;
            this.ctrlNurseReservationListForAdmins1.Load += new System.EventHandler(this.ctrlNurseReservationListForAdmins1_Load);
            // 
            // frmAllNurseReservationsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 530);
            this.Controls.Add(this.ctrlNurseReservationListForAdmins1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAllNurseReservationsList";
            this.Text = "frmAllNurseReservationsList";
            this.Load += new System.EventHandler(this.frmAllNurseReservationsList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlNurseReservationListForAdmins ctrlNurseReservationListForAdmins1;
    }
}