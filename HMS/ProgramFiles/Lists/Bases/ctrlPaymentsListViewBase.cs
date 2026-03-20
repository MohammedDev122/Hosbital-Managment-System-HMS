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

namespace HMS.Lists.Bases
{
    public partial class ctrlPaymentListView : ctrlBaseDGV
    {
        string PaymentStatusFilter = "";
        string PaymentMethodFilter = "";
        public ctrlPaymentListView()
        {
           
            InitializeComponent();

            FillCmbSearch();
            FillCmbPaymentState();
            FillCmbMethod();
            FullData = clsPayments.GetAll();
            BS.DataSource = FullData;
            DGV1.DataSource = BS;


        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Accountant ID");
            cmbSearch.Items.Insert(0, "Payment ID");
            cmbSearch.SelectedIndex = 0;

        }
        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int PaymentID))
                    {
                        GetSearchFileter(($"CONVERT(PaymentID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else if (string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;


                case (1):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int AccountantID))
                    {
                        GetSearchFileter(($"CONVERT(AccountantID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else if (string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;


             

            }

        }
        protected void FillCmbMethod()
        {

            cmbPaymentMethod.Items.Clear();
            cmbPaymentMethod.Items.Insert(0, "Visa");
            cmbPaymentMethod.Items.Insert(0, "Cash");
            cmbPaymentMethod.Items.Insert(0, "All");

            cmbPaymentMethod.SelectedIndex = 0;

        }
        protected void FillCmbPaymentState()
        {

            cmbPaymentStatus.Items.Clear();
            cmbPaymentStatus.Items.Add("All");
            cmbPaymentStatus.Items.Add("Payed");
            cmbPaymentStatus.Items.Add("Cancelled");
            cmbPaymentStatus.Items.Add("Bending");

            cmbPaymentStatus.SelectedIndex = 0;

        }
        override protected void GetAllFileterResult()
        {
            FilterString = "";

            if (searchFilter.Length > 0)
            {
                FilterString = AddAnd(FilterString);
                FilterString += searchFilter;

            }
            if (PaymentStatusFilter.Length > 0)
            {
                FilterString = AddAnd(FilterString);
                FilterString += PaymentStatusFilter;

            }
            if (PaymentMethodFilter.Length > 0)
            {
                FilterString = AddAnd(FilterString);
                FilterString += PaymentMethodFilter;

            }



        }

        protected void GetPaymentStatusFilter(string PaymentStatus)
        {
            if (PaymentStatus != "'All'")
            {
                PaymentStatusFilter = $"Status={PaymentStatus}";


            }
            else
            {
                PaymentStatusFilter = "";
            }


        }
        protected void GetPaymentMethodFilter(string PaymentMethod)
        {
            if (PaymentMethod != "'All'")
            {
                PaymentMethodFilter = $"Method={PaymentMethod}";


            }
            else
            {
                PaymentMethodFilter = "";
            }


        }
      















        private void ctrlPaymentsListViewBase_Load(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int PaymentID))
                    {
                        GetSearchFileter(($"CONVERT(PaymentID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }
                    break;


                case (1):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int AccountantID))
                    {
                        GetSearchFileter(($"CONVERT(AccountantID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;



            }

        }

        private void cmbPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string FixedString = "'" + cmb.SelectedItem.ToString() + "'";
            GetPaymentStatusFilter(FixedString);
            refreshDataGrid();
        }

        private void cmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string FixedString = "'" + cmb.SelectedItem.ToString() + "'";
            GetPaymentMethodFilter(FixedString);
            refreshDataGrid();
        }
    }
}
