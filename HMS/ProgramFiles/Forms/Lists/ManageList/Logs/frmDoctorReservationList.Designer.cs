namespace HMS
{
    partial class frmDoctorReservationList
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
            this.ctrlDoctorReservationForDoctorList1 = new HMS.Lists.Owners.Employee.ctrlDoctorReservationForDoctorList();
            this.SuspendLayout();
            // 
            // ctrlDoctorReservationForDoctorList1
            // 
            this.ctrlDoctorReservationForDoctorList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlDoctorReservationForDoctorList1.Location = new System.Drawing.Point(0, 0);
            this.ctrlDoctorReservationForDoctorList1.Name = "ctrlDoctorReservationForDoctorList1";
            this.ctrlDoctorReservationForDoctorList1.Size = new System.Drawing.Size(1392, 530);
            this.ctrlDoctorReservationForDoctorList1.TabIndex = 0;
            this.ctrlDoctorReservationForDoctorList1.Load += new System.EventHandler(this.ctrlDoctorReservationForDoctorList1_Load);
            // 
            // frmDoctorReservationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 530);
            this.Controls.Add(this.ctrlDoctorReservationForDoctorList1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDoctorReservationList";
            this.Text = "frmDoctorReservationList";
            this.Load += new System.EventHandler(this.frmDoctorReservationList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Owners.Employee.ctrlDoctorReservationForDoctorList ctrlDoctorReservationForDoctorList1;
    }
}