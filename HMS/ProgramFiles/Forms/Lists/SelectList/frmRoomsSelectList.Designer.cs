namespace HMS
{
    partial class frmRoomsSelectList
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
            this.ctrlOperationRoomForOthers1 = new HMS.Lists.Others.ctrlOperationRoomForOthers();
            this.SuspendLayout();
            // 
            // ctrlOperationRoomForOthers1
            // 
            this.ctrlOperationRoomForOthers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlOperationRoomForOthers1.Location = new System.Drawing.Point(0, 0);
            this.ctrlOperationRoomForOthers1.Name = "ctrlOperationRoomForOthers1";
            this.ctrlOperationRoomForOthers1.Size = new System.Drawing.Size(1370, 478);
            this.ctrlOperationRoomForOthers1.TabIndex = 0;
            this.ctrlOperationRoomForOthers1.onIDSelected += new System.EventHandler<int>(this.ctrlOperationRoomForOthers1_onIDSelected);
            this.ctrlOperationRoomForOthers1.Load += new System.EventHandler(this.ctrlOperationRoomForOthers1_Load);
            // 
            // frmRoomsSelectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 478);
            this.Controls.Add(this.ctrlOperationRoomForOthers1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRoomsSelectList";
            this.Text = "frmRoomsSelectList";
            this.Load += new System.EventHandler(this.frmRoomsSelectList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Others.ctrlOperationRoomForOthers ctrlOperationRoomForOthers1;
    }
}