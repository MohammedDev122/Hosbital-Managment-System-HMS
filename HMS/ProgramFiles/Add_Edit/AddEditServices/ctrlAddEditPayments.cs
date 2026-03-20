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

namespace HMS.Add_Edit.AddEditServices
{
    public partial class ctrlAddEditPayments : ctrlAddEditBase
    {
        int _AccountantID = -1;
        public ctrlAddEditPayments()
        {
            InitializeComponent();
            clsFillcmb.FillCmbPaymentMethod(cmbPaymentMethod);
            clsFillcmb.FillCmbPaymentState(cmbPaymentStatus);
        }
        public void SetAccounantID(int accountantID)
        {
            _AccountantID = accountantID;
        }
        protected string GetPaymentMethodstring(clsPayments.enMethod Method)
        {

            switch (Method)
            {

                case (clsPayments.enMethod.enVisa):
                    return "Visa";
               
                default:
                    return "Cash";


            }
        }
        protected clsPayments.enMethod GetPaymentMethod(string Method)
        {

            switch (Method)
            {

                case ("Visa"):
                    return clsPayments.enMethod.enVisa;

                default:
                    return clsPayments.enMethod.enCash; ;


            }
        }
        protected string GetPaymentStatestring(clsPayments.enPaymentStatus state)
        {

            switch (state)
            {

                case (clsPayments.enPaymentStatus.enPayed):
                    return "Payed";
                case (clsPayments.enPaymentStatus.enCancelled):
                    return "Cancelled";
                default:
                    return "bending";


            }
        }
        protected clsPayments.enPaymentStatus GetPaymentState(string state)
        {

            switch (state)
            {

                case ("Payed"):
                    return clsPayments.enPaymentStatus.enPayed;
                case ("Cancelled"):
                    return clsPayments.enPaymentStatus.enCancelled;
                default:
                    return clsPayments.enPaymentStatus.enBending;


            }
        }

        protected void FillPaymentInfo(int PaymentID)
        {
            clsPayments Payments = clsPayments.GetPaymentInfoByID(PaymentID);
            lblID.Text = Convert.ToString(ID);
            lblPaymentDate.Text=Convert.ToString(Payments.PaymentDate);
            lblPayedAmmount.Text = Convert.ToString(Payments.PayedAmmount);
            cmbPaymentMethod.SelectedIndex = cmbPaymentMethod.Items.IndexOf(GetPaymentMethodstring(Payments.PaymentMethod));
            clsAccountant Accountant=clsAccountant.FindByID(Payments.AccountantID);
            if (Accountant != null)
            {

                lblAccountantID.Text = Convert.ToString(Accountant.AccountantID);
                lblAccountantName.Text = Accountant.FirstName + " " + Accountant.LastName;



            }
            else {
                 Accountant = clsAccountant.FindByID(_AccountantID);
                if (Accountant != null)
                {
                    lblAccountantID.Text = Convert.ToString(Accountant.AccountantID);
                    lblAccountantName.Text = Accountant.FirstName + " " + Accountant.LastName;
                }
            }
            if(Payments.AccountID!=-1)
            {
                txtAccountID.Text=Convert.ToString(Payments.AccountID);
            }
            else
            {
                txtAccountID.Text = "";
            }
            cmbPaymentStatus.SelectedIndex = cmbPaymentStatus.Items.IndexOf(GetPaymentStatestring(Payments.status));

          




        }
        override protected void FillInfo(int ID)
        {
            
            clsPayments Payment = clsPayments.GetPaymentInfoByID(ID);

                if (ID != -1)
                {
                    if (Payment != null)
                    {

                        setAddEdit("Edit Payment");
                        _Mode = enMode.enUpdate;
                        FillPaymentInfo(Payment.PaymentID);
                        if (Payment.status != clsPayments.enPaymentStatus.enBending)
                        {

                            btnSave.Enabled = false;
                            btnSelectAccount.Visible = false;
                        }
                        else
                        {
                        if (_AccountantID != -1)
                        {
                            btnSave.Enabled = true;
                            btnSelectAccount.Visible = true;
                        }
                        else
                        {

                            btnSave.Enabled = false;



                        }

                        //FillInfo

                    }
                }
               
            

            }

          



        }
        protected void UpdatePayment(clsPayments Payment)
        {
           
            Payment.status = GetPaymentState(cmbPaymentStatus.SelectedItem.ToString());
            if(int.TryParse(Convert.ToString(lblAccountantID.Text),out int AccountantID)){

                Payment.AccountantID = AccountantID;





            }
            
            Payment.PaymentMethod=GetPaymentMethod(cmbPaymentMethod.SelectedItem.ToString());


            if (int.TryParse(Convert.ToString(txtAccountID.Text), out int AccountID))
            {

                Payment.AccountID = AccountID;





            }
            if (Payment.PaymentMethod == clsPayments.enMethod.enCash | clsProtect1.Compute(txtPassword.Text) == clsBankAccount.FindAccountByID(Payment.AccountID)?.Password)
            {
                if (Payment.Save())
                {
                    FillInfo(Payment.PaymentID);

                }
                else
                {
                    MessageBox.Show(Payment.Cause.ToString(), "Error");
                }
            }
            else
            {
                MessageBox.Show("Wrong Password/Account", "Error");

            }
        }
        private void ctrlAddEditPayments_Load(object sender, EventArgs e)
        {

        }

        private void btnSelectAccountant_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsPayments Payment = clsPayments.GetPaymentInfoByID(ID);
            UpdatePayment(Payment);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
