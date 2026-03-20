using HMS.Add_Edit.Medications;
using HosbitalBussinessLayer;
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
    public partial class frmEditPayment : Form
    {
        public Action ReloadCallingDGV;
        
        public frmEditPayment(int EmployeeID,int PaymentID)
        {
            InitializeComponent();
            ctrlAddEditPayments1.SetID(PaymentID);
            ctrlAddEditPayments1.SetAccounantID(clsEmployees.GetEmployeeRoleID(EmployeeID));
            ctrlAddEditPayments1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            ReloadCallingDGV?.Invoke();

            this.Close();
        }
        private void frmEditPayment_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditPayments1_Load(object sender, EventArgs e)
        {

        }
    }
}
