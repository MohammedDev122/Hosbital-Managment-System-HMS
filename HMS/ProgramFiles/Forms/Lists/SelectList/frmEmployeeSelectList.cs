using HMS.Lists.Admins;
using HMS.Lists.Others.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS
{
    public partial class frmEmployeeSelectList : Form
    {
        public frmEmployeeSelectList(string Department)
        {
            InitializeComponent();
            ctrlEmployeeListViewForOthers1.Department=Department;
            ctrlEmployeeListViewForOthers1.CloseForm = CloseForm;
            ctrlEmployeeListViewForOthers1.onIDSelected = ctrlEmployeeListViewForOthers1_onIDSelected;
        }
        void CloseForm()
        {
            this.Close();
        }
        public  Action<int> EmployeeIDSelected;
        private void frmEmployeeSelectList_Load(object sender, EventArgs e)
        {
            

        }

    

        private void ctrlEmployeeListViewForOthers1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlEmployeeListViewForOthers1_onIDSelected(object sender, int e)
        {
            
            if (e != -1)
            {
                EmployeeIDSelected?.Invoke(e);
                this.Close();



            }
        }

        private void InitializeComponent()
        {
            this.ctrlEmployeeListViewForOthers1 = new HMS.Lists.Others.Employee.ctrlEmployeeListViewForOthers();
            this.SuspendLayout();
            // 
            // ctrlEmployeeListViewForOthers1
            // 
            this.ctrlEmployeeListViewForOthers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlEmployeeListViewForOthers1.Location = new System.Drawing.Point(0, 0);
            this.ctrlEmployeeListViewForOthers1.Name = "ctrlEmployeeListViewForOthers1";
            this.ctrlEmployeeListViewForOthers1.Size = new System.Drawing.Size(1372, 470);
            this.ctrlEmployeeListViewForOthers1.TabIndex = 0;
            this.ctrlEmployeeListViewForOthers1.Load += new System.EventHandler(this.ctrlEmployeeListViewForOthers1_Load_1);
            // 
            // frmEmployeeSelectList
            // 
            this.ClientSize = new System.Drawing.Size(1372, 470);
            this.Controls.Add(this.ctrlEmployeeListViewForOthers1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEmployeeSelectList";
            this.ResumeLayout(false);

        }

        private void ctrlEmployeeListViewForOthers1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
