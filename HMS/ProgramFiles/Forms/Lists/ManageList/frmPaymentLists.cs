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
    public partial class frmPaymentLists : Form
    {
        public frmPaymentLists(int EmployeeID)
        {
            InitializeComponent();
            ctrlPaymentListForAdmins1.SetID(EmployeeID);
            ctrlPaymentListForAdmins1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }

        private void ctrlPaymentListForAdmins1_Load(object sender, EventArgs e)
        {

        }
    }
}
