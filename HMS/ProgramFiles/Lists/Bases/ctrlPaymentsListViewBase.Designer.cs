namespace HMS.Lists.Bases
{
    partial class ctrlPaymentListView
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPaymentStatus = new System.Windows.Forms.ComboBox();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(493, 24);
            this.label1.Size = new System.Drawing.Size(219, 39);
            this.label1.Text = "Payment List";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label3.Location = new System.Drawing.Point(655, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Payment Status";
            // 
            // cmbPaymentStatus
            // 
            this.cmbPaymentStatus.FormattingEnabled = true;
            this.cmbPaymentStatus.Location = new System.Drawing.Point(879, 113);
            this.cmbPaymentStatus.Name = "cmbPaymentStatus";
            this.cmbPaymentStatus.Size = new System.Drawing.Size(121, 24);
            this.cmbPaymentStatus.TabIndex = 5;
            this.cmbPaymentStatus.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentStatus_SelectedIndexChanged);
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(1230, 118);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(121, 24);
            this.cmbPaymentMethod.TabIndex = 7;
            this.cmbPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMethod_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label4.Location = new System.Drawing.Point(1006, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Payment Method";
            // 
            // ctrlPaymentListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPaymentStatus);
            this.Controls.Add(this.label3);
            this.Name = "ctrlPaymentListView";
            this.Load += new System.EventHandler(this.ctrlPaymentsListViewBase_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.cmbSearch, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbPaymentStatus, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbPaymentMethod, 0);
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPaymentStatus;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label label4;
    }
}
