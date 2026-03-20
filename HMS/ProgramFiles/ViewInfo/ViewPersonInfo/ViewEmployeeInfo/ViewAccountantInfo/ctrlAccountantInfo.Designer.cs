namespace HMS
{
    partial class ctrlAccountantInfo
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
            this.label5 = new System.Windows.Forms.Label();
            this.lblAccountantID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(776, 347);
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.Location = new System.Drawing.Point(968, 347);
            // 
            // lblSearch
            // 
            this.lblSearch.Click += new System.EventHandler(this.lblSearch_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(188, 29);
            this.lblTitle.Text = "Accountant info";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label5.Location = new System.Drawing.Point(19, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 29);
            this.label5.TabIndex = 29;
            this.label5.Text = "Accountant ID:";
            // 
            // lblAccountantID
            // 
            this.lblAccountantID.AutoSize = true;
            this.lblAccountantID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblAccountantID.Location = new System.Drawing.Point(231, 218);
            this.lblAccountantID.Name = "lblAccountantID";
            this.lblAccountantID.Size = new System.Drawing.Size(27, 29);
            this.lblAccountantID.TabIndex = 30;
            this.lblAccountantID.Text = "_";
            // 
            // ctrlAccountantInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAccountantID);
            this.Controls.Add(this.label5);
            this.Name = "ctrlAccountantInfo";
            this.Load += new System.EventHandler(this.ctrlAccountantInfo_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblEmployeeID, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.lblSalery, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.lblDepartment, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.lblWorkingDays, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.lblState, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.lblExitDate, 0);
            this.Controls.SetChildIndex(this.lblEmploymentDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblPersonID, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnAccountInfo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.lblSearch, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.lblPhone, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.lblCountryID, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.lblAccount, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.lblGender, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.lblDateOfBirth, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lblAccountantID, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAccountantID;
    }
}
