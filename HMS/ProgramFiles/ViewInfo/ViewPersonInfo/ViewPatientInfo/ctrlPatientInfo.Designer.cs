namespace HMS
{
    partial class ctrlPatientInfo
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
            this.lblPatientID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPatientState = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.Click += new System.EventHandler(this.lblSearch_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(698, 481);
            this.label2.Visible = false;
            // 
            // lblPersonID
            // 
            this.lblPersonID.Location = new System.Drawing.Point(873, 481);
            this.lblPersonID.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(140, 29);
            this.lblTitle.Text = "Patient Info";
            // 
            // lblPatientID
            // 
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblPatientID.Location = new System.Drawing.Point(224, 184);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(27, 29);
            this.lblPatientID.TabIndex = 19;
            this.lblPatientID.Text = "_";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label5.Location = new System.Drawing.Point(545, 398);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 29);
            this.label5.TabIndex = 19;
            this.label5.Text = "State";
            // 
            // lblPatientState
            // 
            this.lblPatientState.AutoSize = true;
            this.lblPatientState.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblPatientState.Location = new System.Drawing.Point(686, 398);
            this.lblPatientState.Name = "lblPatientState";
            this.lblPatientState.Size = new System.Drawing.Size(27, 29);
            this.lblPatientState.TabIndex = 19;
            this.lblPatientState.Text = "_";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label9.Location = new System.Drawing.Point(53, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 29);
            this.label9.TabIndex = 19;
            this.label9.Text = "Patient ID:";
            // 
            // ctrlPatientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPatientState);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblPatientID);
            this.Name = "ctrlPatientInfo";
            this.Load += new System.EventHandler(this.ctrlPatientInfo_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.lblSearch, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblPersonID, 0);
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
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnAccountInfo, 0);
            this.Controls.SetChildIndex(this.lblPatientID, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lblPatientState, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPatientID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPatientState;
        private System.Windows.Forms.Label label9;
    }
}
