namespace HMS.Add_Edit.AddEditServices
{
    partial class ctrlAddEditService
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPaymentID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbServiceState = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.btnSelectPatient = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPaymentState = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblPatientPhone = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAddEdit
            // 
            this.lblAddEdit.Size = new System.Drawing.Size(75, 38);
            this.lblAddEdit.Text = "Add";
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(54, 159);
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(149, 159);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label1.Location = new System.Drawing.Point(54, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Service Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label2.Location = new System.Drawing.Point(57, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Start Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label3.Location = new System.Drawing.Point(65, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "End Time:";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblEndTime.Location = new System.Drawing.Point(207, 313);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(55, 29);
            this.lblEndTime.TabIndex = 6;
            this.lblEndTime.Text = "......";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label5.Location = new System.Drawing.Point(482, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 29);
            this.label5.TabIndex = 7;
            this.label5.Text = "Patient ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label6.Location = new System.Drawing.Point(994, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 29);
            this.label6.TabIndex = 8;
            this.label6.Text = "Payment ID:";
            // 
            // lblPaymentID
            // 
            this.lblPaymentID.AutoSize = true;
            this.lblPaymentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblPaymentID.Location = new System.Drawing.Point(1152, 167);
            this.lblPaymentID.Name = "lblPaymentID";
            this.lblPaymentID.Size = new System.Drawing.Size(62, 29);
            this.lblPaymentID.TabIndex = 9;
            this.lblPaymentID.Text = ".......";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label9.Location = new System.Drawing.Point(57, 367);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(171, 29);
            this.label9.TabIndex = 11;
            this.label9.Text = "Service State:";
            // 
            // cmbServiceState
            // 
            this.cmbServiceState.FormattingEnabled = true;
            this.cmbServiceState.Location = new System.Drawing.Point(250, 372);
            this.cmbServiceState.Name = "cmbServiceState";
            this.cmbServiceState.Size = new System.Drawing.Size(121, 24);
            this.cmbServiceState.TabIndex = 12;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "YY/MM/DD";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(228, 224);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDate.TabIndex = 14;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(220, 274);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(200, 22);
            this.dtpStartTime.TabIndex = 15;
            // 
            // btnSelectPatient
            // 
            this.btnSelectPatient.Location = new System.Drawing.Point(767, 167);
            this.btnSelectPatient.Name = "btnSelectPatient";
            this.btnSelectPatient.Size = new System.Drawing.Size(52, 23);
            this.btnSelectPatient.TabIndex = 16;
            this.btnSelectPatient.Text = "......";
            this.btnSelectPatient.UseVisualStyleBackColor = true;
            this.btnSelectPatient.Click += new System.EventHandler(this.btnSelectPatient_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label10.Location = new System.Drawing.Point(994, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 29);
            this.label10.TabIndex = 17;
            this.label10.Text = "Payment State:";
            // 
            // lblPaymentState
            // 
            this.lblPaymentState.AutoSize = true;
            this.lblPaymentState.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblPaymentState.Location = new System.Drawing.Point(1205, 213);
            this.lblPaymentState.Name = "lblPaymentState";
            this.lblPaymentState.Size = new System.Drawing.Size(62, 29);
            this.lblPaymentState.TabIndex = 18;
            this.lblPaymentState.Text = ".......";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1142, 405);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 38);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPatientID
            // 
            this.txtPatientID.Location = new System.Drawing.Point(629, 159);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(100, 22);
            this.txtPatientID.TabIndex = 20;
            this.txtPatientID.TextChanged += new System.EventHandler(this.txtPatientID_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label4.Location = new System.Drawing.Point(482, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 29);
            this.label4.TabIndex = 21;
            this.label4.Text = "Patient Name:";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblPatientName.Location = new System.Drawing.Point(679, 224);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(55, 29);
            this.lblPatientName.TabIndex = 22;
            this.lblPatientName.Text = "......";
            // 
            // lblPatientPhone
            // 
            this.lblPatientPhone.AutoSize = true;
            this.lblPatientPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblPatientPhone.Location = new System.Drawing.Point(679, 267);
            this.lblPatientPhone.Name = "lblPatientPhone";
            this.lblPatientPhone.Size = new System.Drawing.Size(55, 29);
            this.lblPatientPhone.TabIndex = 24;
            this.lblPatientPhone.Text = "......";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label12.Location = new System.Drawing.Point(482, 267);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(179, 29);
            this.label12.TabIndex = 23;
            this.label12.Text = "Patient Phone:";
            // 
            // ctrlAddEditService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPatientPhone);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPatientID);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPaymentState);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSelectPatient);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cmbServiceState);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblPaymentID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ctrlAddEditService";
            this.Load += new System.EventHandler(this.ctrlAddEditService_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblEndTime, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.lblPaymentID, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.cmbServiceState, 0);
            this.Controls.SetChildIndex(this.dtpDate, 0);
            this.Controls.SetChildIndex(this.dtpStartTime, 0);
            this.Controls.SetChildIndex(this.btnSelectPatient, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.lblPaymentState, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.txtPatientID, 0);
            this.Controls.SetChildIndex(this.lblAddEdit, 0);
            this.Controls.SetChildIndex(this.label, 0);
            this.Controls.SetChildIndex(this.lblID, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblPatientName, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.lblPatientPhone, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label lblEndTime;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label lblPaymentID;
        protected System.Windows.Forms.Label label9;
        protected System.Windows.Forms.ComboBox cmbServiceState;
        protected System.Windows.Forms.DateTimePicker dtpDate;
        protected System.Windows.Forms.DateTimePicker dtpStartTime;
        protected System.Windows.Forms.Button btnSelectPatient;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.Label lblPaymentState;
        protected System.Windows.Forms.Button btnSave;
        protected System.Windows.Forms.TextBox txtPatientID;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label lblPatientName;
        protected System.Windows.Forms.Label lblPatientPhone;
        protected System.Windows.Forms.Label label12;
    }
}
