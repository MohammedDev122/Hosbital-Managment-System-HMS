namespace HMS.Lists.Bases.Patient
{
    partial class ctrlPatientListViewBase
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
            this.rbtnAlive = new System.Windows.Forms.RadioButton();
            this.rbtnDead = new System.Windows.Forms.RadioButton();
            this.rbtnEmergency = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(189, 39);
            this.label1.Text = "Patient List";
            // 
            // rbtnAlive
            // 
            this.rbtnAlive.AutoSize = true;
            this.rbtnAlive.Location = new System.Drawing.Point(15, 21);
            this.rbtnAlive.Name = "rbtnAlive";
            this.rbtnAlive.Size = new System.Drawing.Size(58, 20);
            this.rbtnAlive.TabIndex = 9;
            this.rbtnAlive.TabStop = true;
            this.rbtnAlive.Tag = "";
            this.rbtnAlive.Text = "Alive";
            this.rbtnAlive.UseVisualStyleBackColor = true;
            this.rbtnAlive.CheckedChanged += new System.EventHandler(this.rbtnState_CheckedChanged);
            // 
            // rbtnDead
            // 
            this.rbtnDead.AutoSize = true;
            this.rbtnDead.Location = new System.Drawing.Point(15, 51);
            this.rbtnDead.Name = "rbtnDead";
            this.rbtnDead.Size = new System.Drawing.Size(62, 20);
            this.rbtnDead.TabIndex = 10;
            this.rbtnDead.TabStop = true;
            this.rbtnDead.Tag = "";
            this.rbtnDead.Text = "Dead";
            this.rbtnDead.UseVisualStyleBackColor = true;
            this.rbtnDead.CheckedChanged += new System.EventHandler(this.rbtnState_CheckedChanged);
            // 
            // rbtnEmergency
            // 
            this.rbtnEmergency.AutoSize = true;
            this.rbtnEmergency.Location = new System.Drawing.Point(15, 77);
            this.rbtnEmergency.Name = "rbtnEmergency";
            this.rbtnEmergency.Size = new System.Drawing.Size(97, 20);
            this.rbtnEmergency.TabIndex = 11;
            this.rbtnEmergency.TabStop = true;
            this.rbtnEmergency.Tag = "";
            this.rbtnEmergency.Text = "Emergency";
            this.rbtnEmergency.UseVisualStyleBackColor = true;
            this.rbtnEmergency.CheckedChanged += new System.EventHandler(this.rbtnState_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnAll);
            this.groupBox2.Controls.Add(this.rbtnAlive);
            this.groupBox2.Controls.Add(this.rbtnEmergency);
            this.groupBox2.Controls.Add(this.rbtnDead);
            this.groupBox2.Location = new System.Drawing.Point(795, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "State";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Location = new System.Drawing.Point(118, 51);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(51, 20);
            this.rbtnAll.TabIndex = 12;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Tag = "";
            this.rbtnAll.Text = "ALL";
            this.rbtnAll.UseVisualStyleBackColor = true;
            this.rbtnAll.CheckedChanged += new System.EventHandler(this.rbtnState_CheckedChanged);
            // 
            // ctrlPatientListViewBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "ctrlPatientListViewBase";
            this.Load += new System.EventHandler(this.ctrlPatientListViewBase_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.cmbSearch, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       protected System.Windows.Forms.RadioButton rbtnAlive;
       protected System.Windows.Forms.RadioButton rbtnDead;
       protected System.Windows.Forms.RadioButton rbtnEmergency;
       protected System.Windows.Forms.GroupBox groupBox2;
       protected System.Windows.Forms.RadioButton rbtnAll;
    }
}
