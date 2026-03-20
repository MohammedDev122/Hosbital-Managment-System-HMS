namespace HMS
{
    partial class frmRoomReservationsList
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
            this.ctrlRoomReservationListForAdmins1 = new HMS.Lists.Admins.ctrlRoomReservationListForAdmins();
            this.SuspendLayout();
            // 
            // ctrlRoomReservationListForAdmins1
            // 
            this.ctrlRoomReservationListForAdmins1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRoomReservationListForAdmins1.Location = new System.Drawing.Point(0, 0);
            this.ctrlRoomReservationListForAdmins1.Name = "ctrlRoomReservationListForAdmins1";
            this.ctrlRoomReservationListForAdmins1.Size = new System.Drawing.Size(1334, 661);
            this.ctrlRoomReservationListForAdmins1.TabIndex = 0;
            this.ctrlRoomReservationListForAdmins1.Load += new System.EventHandler(this.ctrlRoomReservationListForAdmins1_Load);
            // 
            // frmRoomReservationsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 661);
            this.Controls.Add(this.ctrlRoomReservationListForAdmins1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRoomReservationsList";
            this.Text = "frmRoomReservationsList";
            this.Load += new System.EventHandler(this.frmRoomReservationsList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlRoomReservationListForAdmins ctrlRoomReservationListForAdmins1;
    }
}