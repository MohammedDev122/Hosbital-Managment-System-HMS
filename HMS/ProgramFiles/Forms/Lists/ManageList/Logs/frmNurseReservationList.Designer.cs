namespace HMS
{
    partial class frmNurseReservationList
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
            this.ctrlNurseReservationListForNurse1 = new HMS.Lists.Owners.Employee.ctrlNurseReservationListForNurse();
            this.SuspendLayout();
            // 
            // ctrlNurseReservationListForNurse1
            // 
            this.ctrlNurseReservationListForNurse1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlNurseReservationListForNurse1.Location = new System.Drawing.Point(0, 0);
            this.ctrlNurseReservationListForNurse1.Name = "ctrlNurseReservationListForNurse1";
            this.ctrlNurseReservationListForNurse1.Size = new System.Drawing.Size(1367, 532);
            this.ctrlNurseReservationListForNurse1.TabIndex = 0;
            this.ctrlNurseReservationListForNurse1.Load += new System.EventHandler(this.ctrlNurseReservationListForNurse1_Load);
            // 
            // frmNurseReservationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 532);
            this.Controls.Add(this.ctrlNurseReservationListForNurse1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNurseReservationList";
            this.Text = "frmNurseReservationList";
            this.Load += new System.EventHandler(this.frmNurseReservationList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Owners.Employee.ctrlNurseReservationListForNurse ctrlNurseReservationListForNurse1;
    }
}