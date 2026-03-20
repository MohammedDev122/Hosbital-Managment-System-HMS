using HosbitalBussinessLayer.Logs;
using HosbitalBussinessLayer.Procedures;
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

namespace HMS.ViewInfo.ViewServicesInfo.ViewPaymentsInfo
{
    public partial class ctrlPaymentInfo : UserControl
    {
        public ctrlPaymentInfo()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
        protected void EmptyPaymentRec()
        {
            lblPaymentID.Text = "_";
            lblAccountID.Text = "_";
            
            lblAccountantID.Text = "_";

            lblAccountantName.Text = "_";
            lblAmmount.Text = "_";
            lblDate.Text = "_";
            lblMethod.Text = "_";
            lblStatus.Text = "_";


        }
        string _GetPaymentStatus(clsPayments.enPaymentStatus status)
        {

            if (status == clsPayments.enPaymentStatus.enPayed)
            {
                return "Payed";
            }
            else if (status == clsPayments.enPaymentStatus.enCancelled)
            {
                return "Cancelled";
            }
            else {
                return "pending";
            }
        }
        string _GetPaymentMethod(clsPayments.enMethod Method)
        {

            if (Method == clsPayments.enMethod.enVisa)
            {
                return "Visa";
            }
            else
            {
                return "Cash";
            }
            
        }
        protected void FillPaymentRec(clsPayments Payments)
        {
            lblPaymentID.Text = Convert.ToString(Payments.PaymentID);
            if (Payments.AccountID != -1)
            {

                lblAccountID.Text = Convert.ToString(Payments.AccountID);



            }
            else
            {
                lblAccountID.Text = "_";
            }
            lblAccountantID.Text = Convert.ToString(Payments.AccountantID);

            clsAccountant Accountant = clsAccountant.FindByID(Payments.AccountantID);
            lblAccountantName.Text = Accountant.FirstName + " " + Accountant.LastName;
            lblAmmount.Text = Convert.ToString(Payments.PayedAmmount);
            lblDate.Text = Convert.ToString(Payments.PaymentDate);
            lblMethod.Text= _GetPaymentMethod(Payments.PaymentMethod);
            lblStatus.Text = _GetPaymentStatus(Payments.status);




        }
         protected void btnSearch_Click(object sender, EventArgs e)
        {
            int PaymentID = -1;
            if (int.TryParse(Convert.ToString(txtSearch.Text), out int ID))
            {
                PaymentID = ID;
                clsPayments Payments = clsPayments.GetPaymentInfoByID(PaymentID);
                if (Payments != null)
                {
                    FillPaymentRec(Payments);
                }
                else
                {
                    EmptyPaymentRec();
                }
            }

        }
        private void ctrlPaymentInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
