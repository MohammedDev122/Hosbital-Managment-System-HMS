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
    public partial class frmOperationList : Form
    {
        public frmOperationList()
        {
            InitializeComponent();
            ctrlOperationListViewForAdmins1.CloseForm = CloseForm;
            ctrlOperationListViewForAdmins1.SetID(LoggedEmployee.LoggedEmployeeID);
        }
        void CloseForm()
        {
            this.Close();
        }

        private void ctrlOperationListViewForAdmins1_Load(object sender, EventArgs e)
        {

        }
    }
}
