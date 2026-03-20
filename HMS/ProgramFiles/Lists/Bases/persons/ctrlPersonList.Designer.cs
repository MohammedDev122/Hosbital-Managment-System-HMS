namespace HMS
{
    partial class ctrlPersonList
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
            this.rbtnMale = new System.Windows.Forms.RadioButton();
            this.rbtnFemale = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnNon = new System.Windows.Forms.RadioButton();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(191, 39);
            this.label1.Text = "Person List";
            // 
            // cmbSearch
            // 
            this.cmbSearch.Items.AddRange(new object[] {
            "PersonID",
            "FirstName",
            "LastName"});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 102);
            // 
            // rbtnMale
            // 
            this.rbtnMale.AutoSize = true;
            this.rbtnMale.Location = new System.Drawing.Point(6, 21);
            this.rbtnMale.Name = "rbtnMale";
            this.rbtnMale.Size = new System.Drawing.Size(58, 20);
            this.rbtnMale.TabIndex = 4;
            this.rbtnMale.TabStop = true;
            this.rbtnMale.Tag = "\'M\'";
            this.rbtnMale.Text = "Male";
            this.rbtnMale.UseVisualStyleBackColor = true;
            this.rbtnMale.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // rbtnFemale
            // 
            this.rbtnFemale.AutoSize = true;
            this.rbtnFemale.Location = new System.Drawing.Point(6, 60);
            this.rbtnFemale.Name = "rbtnFemale";
            this.rbtnFemale.Size = new System.Drawing.Size(74, 20);
            this.rbtnFemale.TabIndex = 5;
            this.rbtnFemale.TabStop = true;
            this.rbtnFemale.Tag = "\'F\'";
            this.rbtnFemale.Text = "Female";
            this.rbtnFemale.UseVisualStyleBackColor = true;
            this.rbtnFemale.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnNon);
            this.groupBox1.Controls.Add(this.rbtnMale);
            this.groupBox1.Controls.Add(this.rbtnFemale);
            this.groupBox1.Location = new System.Drawing.Point(1155, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gender";
            // 
            // rbtnNon
            // 
            this.rbtnNon.AutoSize = true;
            this.rbtnNon.Location = new System.Drawing.Point(98, 40);
            this.rbtnNon.Name = "rbtnNon";
            this.rbtnNon.Size = new System.Drawing.Size(50, 20);
            this.rbtnNon.TabIndex = 6;
            this.rbtnNon.TabStop = true;
            this.rbtnNon.Tag = " ";
            this.rbtnNon.Text = "non";
            this.rbtnNon.UseVisualStyleBackColor = true;
            this.rbtnNon.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // cmbCountry
            // 
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(1155, 138);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(171, 24);
            this.cmbCountry.TabIndex = 7;
            this.cmbCountry.SelectedIndexChanged += new System.EventHandler(this.cmbCountry_SelectedIndexChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label3.Location = new System.Drawing.Point(1028, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Country:";
            // 
            // ctrlPersonList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlPersonList";
            this.Size = new System.Drawing.Size(1365, 527);
            this.Load += new System.EventHandler(this.ctrlPersonList_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.cmbSearch, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cmbCountry, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       protected System.Windows.Forms.RadioButton rbtnMale;
       protected System.Windows.Forms.RadioButton rbtnFemale;
       protected System.Windows.Forms.GroupBox groupBox1;
       protected System.Windows.Forms.RadioButton rbtnNon;
       protected System.Windows.Forms.ComboBox cmbCountry;
       protected System.Windows.Forms.Label label3;
    }
}
