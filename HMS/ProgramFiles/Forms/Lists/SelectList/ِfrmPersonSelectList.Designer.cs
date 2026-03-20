namespace HMS
{
    partial class frmPersonSelectList
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
            this.ctrlPersonList1 = new HMS.ctrlPersonList();
            this.SuspendLayout();
            // 
            // ctrlPersonList1
            // 
            this.ctrlPersonList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPersonList1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPersonList1.Name = "ctrlPersonList1";
            this.ctrlPersonList1.Size = new System.Drawing.Size(1440, 533);
            this.ctrlPersonList1.TabIndex = 0;
            this.ctrlPersonList1.OnSelectedID += new System.EventHandler<int>(this.ctrlPersonList1_OnSelectedID);
            this.ctrlPersonList1.Load += new System.EventHandler(this.ctrlPersonList1_Load);
            // 
            // frmPersonSelectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 533);
            this.Controls.Add(this.ctrlPersonList1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPersonSelectList";
            this.Text = "_ِfrmPersonSelectList";
            this.Load += new System.EventHandler(this._ِfrmPersonSelectList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonList ctrlPersonList1;
    }
}