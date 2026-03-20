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
    public partial class ctrlAccountantInfo : ctrlEmployeeInfo
    {
        public ctrlAccountantInfo()
        {
            InitializeComponent();
        }
        protected void EmptyAllAccountantRec()
        {
            EmptyAllEmployeeRec();
            lblAccountantID.Text = "_";

        }
        protected void FillAccountantRec(clsAccountant accountant)
        {
            clsEmployees Employee = clsEmployees.FindByID(accountant.EmplyeeID);

            FillEmployeeInfo(Employee);
            lblAccountantID.Text = Convert.ToString(accountant.AccountantID);




        }


        override protected void lblSearch_Click(object sender, EventArgs e)
        {
            int Accountant = -1;
            if (int.TryParse(Convert.ToString(txtSearch.Text), out int ID))
            {
                Accountant = ID;
                clsAccountant Employee = clsAccountant.FindByID(Accountant);
                if (Employee != null)
                {
                    FillAccountantRec(Employee);
                }
                else
                {
                    EmptyAllAccountantRec();
                }

            }

        }

        private void ctrlAccountantInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
