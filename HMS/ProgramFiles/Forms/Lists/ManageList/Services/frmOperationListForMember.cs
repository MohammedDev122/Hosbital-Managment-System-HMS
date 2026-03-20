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
    public partial class frmOperationListForMember : Form
    {
        public frmOperationListForMember(int EmployeeID)
        {
            InitializeComponent();
            ctrlOperationListViewForStaffMember1.SetID(EmployeeID);
            ctrlOperationListViewForStaffMember1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }

        private void frmOperationListForMember_Load(object sender, EventArgs e)
        {

        }

        private void ctrlOperationListViewForStaffMember1_Load(object sender, EventArgs e)
        {

        }
    }
}
