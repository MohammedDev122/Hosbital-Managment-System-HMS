namespace HMS.Lists.Bases.Services
{
    partial class ctrlServicesListView
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
            this.cmbPayment = new System.Windows.Forms.ComboBox();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(198, 39);
            this.label1.Text = "Service List";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label3.Location = new System.Drawing.Point(1005, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Payment State";
            // 
            // cmbPayment
            // 
            this.cmbPayment.FormattingEnabled = true;
            this.cmbPayment.Location = new System.Drawing.Point(1191, 81);
            this.cmbPayment.Name = "cmbPayment";
            this.cmbPayment.Size = new System.Drawing.Size(121, 24);
            this.cmbPayment.TabIndex = 5;
            this.cmbPayment.SelectedIndexChanged += new System.EventHandler(this.cmbPayment_SelectedIndexChanged);
            // 
            // cmbService
            // 
            this.cmbService.FormattingEnabled = true;
            this.cmbService.Location = new System.Drawing.Point(1191, 110);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(121, 24);
            this.cmbService.TabIndex = 7;
            this.cmbService.SelectedIndexChanged += new System.EventHandler(this.cmbService_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label4.Location = new System.Drawing.Point(1005, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Service State";
            // 
            // ctrlServicesListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbService);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPayment);
            this.Controls.Add(this.label3);
            this.Name = "ctrlServicesListView";
            this.Load += new System.EventHandler(this.ctrlServicesListView_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.cmbSearch, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbPayment, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbService, 0);
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPayment;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.Label label4;
    }
}
