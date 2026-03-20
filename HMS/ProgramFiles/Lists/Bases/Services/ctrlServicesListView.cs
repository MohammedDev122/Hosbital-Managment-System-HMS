using HosbitalBussinessLayer;
using HosbitalBussinessLayer.Procedures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Lists.Bases.Services
{
    public partial class ctrlServicesListView : ctrlBaseDGV
    {
        protected string PaymentStatusFilter = "";
        protected string ServiceStatusFilter = "";
        public ctrlServicesListView()
        {
            InitializeComponent();
            FillCmbSearch();
            FillCmbPaymentState();
            FillCmbServiceState();
            ID = -1;
            FullData= clsServices.GetAll(ID, Showing);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Payment ID");
            cmbSearch.Items.Insert(0, "Patient ID");
            cmbSearch.Items.Insert(0, "Service ID");
            cmbSearch.SelectedIndex = 0;

        }
        protected void FillCmbPaymentState()
        {

            cmbPayment.Items.Clear();
            cmbPayment.Items.Add( "All");
            cmbPayment.Items.Add("Payed");
            cmbPayment.Items.Add("Cancelled");
            cmbPayment.Items.Add("Bending");

            cmbPayment.SelectedIndex = 0;

        }
        protected void FillCmbServiceState()
        {

            cmbService.Items.Clear();
            cmbService.Items.Add("All");
            cmbService.Items.Add("Finished");
            cmbService.Items.Add("bending");
            cmbService.Items.Add("Cancelled");

            cmbService.SelectedIndex = 0;

        }

        
        private void ctrlServicesListView_Load(object sender, EventArgs e)
        {

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
            if (ServiceStatusFilter.Length > 0)
            {
                FilterString = AddAnd(FilterString);
                FilterString += ServiceStatusFilter;

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
        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox cmb = (ComboBox)sender;
            string FixedString="'"+cmb.SelectedItem.ToString()+"'";
            GetPaymentStatusFilter(FixedString);
            refreshDataGrid();

        }
        protected void GetServiceStatusFilter(string SerivceFilter)
        {
            if (SerivceFilter != "'All'")
            {
                ServiceStatusFilter = $"State={SerivceFilter}";


            }
            else
            {
                ServiceStatusFilter = "";
            }


        }

        private void cmbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string FixedString = "'" + cmb.SelectedItem.ToString() + "'";
            GetServiceStatusFilter(FixedString);
            refreshDataGrid();
        }
    }
}
