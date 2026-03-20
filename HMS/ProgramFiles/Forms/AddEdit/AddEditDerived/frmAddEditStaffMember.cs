using HMS.Lists.Admins;
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
    public partial class frmAddEditStaffMember : Form
    {
        public frmAddEditStaffMember(int OperationID)
        {
            InitializeComponent();
            ctrlEmployeeListViewForOthers1.Department = "doctor' or DepartmentName= 'nursing";
            ctrlStaffForOperation1.SetID(OperationID);
            ctrlEmployeeListViewForOthers1.onIDSelected = ctrlStaffForOperation1.AddNewStaffForOperation;

            ctrlStaffForOperation1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }
        public Action <int> OnIDSelected;
        private void frmAddEditStaffMember_Load(object sender, EventArgs e)
        {

        }
     
        private void ctrlEmployeeListViewForOthers1_onIDSelected(object sender, int e)
        {
        }

        private void ctrlStaffForOperation1_Load(object sender, EventArgs e)
        {

        }
    }
}
