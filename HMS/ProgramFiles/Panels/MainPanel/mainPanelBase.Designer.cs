namespace HMS.ProgramFiles.Panels.MainPanel
{
    partial class mainPanelBase
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
            this.ctrlSystSettButton1 = new HMS.Buttons.SystemButton.ctrlSystSettButton();
            this.ctrlMyPersonalInfoButton1 = new HMS.Buttons.User.ctrlMyPersonalInfoButton();
            this.ctrlMyLogsListButton1 = new HMS.Buttons.Records.SystemLogs.ctrlMyLogsListButton();
            this.btnShrink = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnShrink);
            this.panel1.Controls.Add(this.ctrlMyLogsListButton1);
            this.panel1.Controls.Add(this.ctrlMyPersonalInfoButton1);
            this.panel1.Controls.Add(this.ctrlSystSettButton1);
            this.panel1.Size = new System.Drawing.Size(317, 879);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ctrlSystSettButton1
            // 
            this.ctrlSystSettButton1.Location = new System.Drawing.Point(0, 722);
            this.ctrlSystSettButton1.Name = "ctrlSystSettButton1";
            this.ctrlSystSettButton1.Size = new System.Drawing.Size(109, 50);
            this.ctrlSystSettButton1.TabIndex = 0;
            // 
            // ctrlMyPersonalInfoButton1
            // 
            this.ctrlMyPersonalInfoButton1.Location = new System.Drawing.Point(3, 666);
            this.ctrlMyPersonalInfoButton1.Name = "ctrlMyPersonalInfoButton1";
            this.ctrlMyPersonalInfoButton1.Size = new System.Drawing.Size(109, 50);
            this.ctrlMyPersonalInfoButton1.TabIndex = 1;
            // 
            // ctrlMyLogsListButton1
            // 
            this.ctrlMyLogsListButton1.Location = new System.Drawing.Point(3, 610);
            this.ctrlMyLogsListButton1.Name = "ctrlMyLogsListButton1";
            this.ctrlMyLogsListButton1.Size = new System.Drawing.Size(109, 50);
            this.ctrlMyLogsListButton1.TabIndex = 2;
            // 
            // btnShrink
            // 
            this.btnShrink.BackgroundImage = global::HMS.Properties.Resources.icon;
            this.btnShrink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShrink.Location = new System.Drawing.Point(3, 3);
            this.btnShrink.Name = "btnShrink";
            this.btnShrink.Size = new System.Drawing.Size(39, 38);
            this.btnShrink.TabIndex = 3;
            this.btnShrink.UseVisualStyleBackColor = true;
            this.btnShrink.Click += new System.EventHandler(this.btnShrink_Click);
            // 
            // mainPanelBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "mainPanelBase";
            this.Size = new System.Drawing.Size(317, 879);
            this.Load += new System.EventHandler(this.mainPanelBase_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected HMS.Buttons.Records.SystemLogs.ctrlMyLogsListButton ctrlMyLogsListButton1;
        protected HMS.Buttons.User.ctrlMyPersonalInfoButton ctrlMyPersonalInfoButton1;
        protected HMS.Buttons.SystemButton.ctrlSystSettButton ctrlSystSettButton1;
        protected System.Windows.Forms.Button btnShrink;
    }
}
