namespace HMS.Add_Edit
{
    partial class ctrlAddEditBase
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
            this.lblAddEdit = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddEdit
            // 
            this.lblAddEdit.AutoSize = true;
            this.lblAddEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F);
            this.lblAddEdit.Location = new System.Drawing.Point(609, 30);
            this.lblAddEdit.Name = "lblAddEdit";
            this.lblAddEdit.Size = new System.Drawing.Size(140, 38);
            this.lblAddEdit.TabIndex = 0;
            this.lblAddEdit.Text = "Add/Edit";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label.Location = new System.Drawing.Point(65, 132);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(44, 29);
            this.label.TabIndex = 1;
            this.label.Text = "ID:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblID.Location = new System.Drawing.Point(160, 132);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(41, 29);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "....";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "Close (X)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlAddEditBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label);
            this.Controls.Add(this.lblAddEdit);
            this.Name = "ctrlAddEditBase";
            this.Size = new System.Drawing.Size(1420, 471);
            this.Load += new System.EventHandler(this.AddEditBase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lblAddEdit;
        protected System.Windows.Forms.Label label;
        protected System.Windows.Forms.Label lblID;
        public System.Windows.Forms.Button button1;
    }
}
