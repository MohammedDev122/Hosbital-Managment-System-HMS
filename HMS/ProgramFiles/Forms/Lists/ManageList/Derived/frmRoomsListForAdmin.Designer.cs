namespace HMS.Forms
{
    partial class frmRoomsListForAdmin
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
            this.ctrlOperationRoomListAdmins1 = new HMS.Lists.Admins.ctrlOperationRoomListAdmins();
            this.SuspendLayout();
            // 
            // ctrlOperationRoomListAdmins1
            // 
            this.ctrlOperationRoomListAdmins1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlOperationRoomListAdmins1.Location = new System.Drawing.Point(0, 0);
            this.ctrlOperationRoomListAdmins1.Name = "ctrlOperationRoomListAdmins1";
            this.ctrlOperationRoomListAdmins1.Size = new System.Drawing.Size(1391, 478);
            this.ctrlOperationRoomListAdmins1.TabIndex = 0;
            this.ctrlOperationRoomListAdmins1.Load += new System.EventHandler(this.ctrlOperationRoomListAdmins1_Load);
            // 
            // frmRoomsListForAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1391, 478);
            this.Controls.Add(this.ctrlOperationRoomListAdmins1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRoomsListForAdmin";
            this.Text = "frmRoomsListForAdmin";
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlOperationRoomListAdmins ctrlOperationRoomListAdmins1;
    }
}