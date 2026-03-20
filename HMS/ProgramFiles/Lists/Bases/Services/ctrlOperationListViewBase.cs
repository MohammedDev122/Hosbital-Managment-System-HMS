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
    public partial class ctrlOperationListViewBase : ctrlServicesListView

    {
        string SpecilizationFilter = "";
        string ResultFilter = "";
        public ctrlOperationListViewBase()
        {
            InitializeComponent();
            FillCmbSearch();
            FillCmbSpecilization();
            FillcmbResult();
            FullData = clsOperations.GetAll(ID, Showing); ;
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
            RearangeDGV();
           
            DGV1.DataSource = clsOperations.GetAll(ID, Showing);
        }
        protected void FillCmbSpecilization()
        {

            cmbSpecilization.Items.Clear();
            cmbSpecilization.Items.Add("All");
            DataTable dt = clsSpecilization.GetAllSpecilizations();
            foreach (DataRow dr in dt.Rows)
            {
                cmbSpecilization.Items.Add(dr["Specilization"]);


            }
            cmbSpecilization.SelectedIndex = 0;

        }
        protected void FillcmbResult()
        {

            cmbResult.Items.Clear();
            cmbResult.Items.Add("All");
            cmbResult.Items.Add("Unknown");
            cmbResult.Items.Add("Failed");
            cmbResult.Items.Add("Succeded");


            cmbResult.SelectedIndex = 0;

        }
        protected void RearangeDGV()
        {
            DGV1.Columns["ServiceEndTime"].DisplayIndex = 13;
            DGV1.Columns["ServiceStartTime"].DisplayIndex = 12;

            DGV1.Columns["Date"].DisplayIndex = 11;
            DGV1.Columns["Status"].DisplayIndex = 7;
            DGV1.Columns["Specilization"].DisplayIndex = 2;




        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Patient ID");
            cmbSearch.Items.Insert(0, "Room Num");
            cmbSearch.Items.Insert(0, "Payment ID");
            cmbSearch.Items.Insert(0, "Medical Record ID");
            cmbSearch.Items.Insert(0, "Operation ID");
            cmbSearch.SelectedIndex = 0;

        }
        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int OperationID))
                    {
                        GetSearchFileter(($"CONVERT(OperationID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else if (string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;


                case (1):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int MedicalRecordID))
                    {
                        GetSearchFileter(($"CONVERT(MedicalRecordID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else if (string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;


                case (2):
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



                case (3):
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($"RoomNum like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;

                case (4):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int PatientID))
                    {
                        GetSearchFileter(($"CONVERT(PatientID, 'System.String') like '{txtSearch.Text}%'"));
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

        private void ctrlOperationListViewBase_Load(object sender, EventArgs e)
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
            if (SpecilizationFilter.Length > 0)
            {
                FilterString = AddAnd(FilterString);
                FilterString += SpecilizationFilter;

            }
            if (ResultFilter.Length > 0) { 
            
            FilterString=AddAnd(FilterString);
                FilterString+= ResultFilter;
            
            }

        }

        void GetSpecilizationFilter(string Specilization)
        {
            if (Specilization != "'All'")
            {
                SpecilizationFilter = $"Specilization={Specilization}";
            }
            else
            {
                SpecilizationFilter = "";
            }


        }
        private void cmbSpecilization_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string FixedString = "'" + cmb.SelectedItem.ToString() + "'";
            GetSpecilizationFilter(FixedString);
            refreshDataGrid();


        }
        void GetResulrFilter(string Result)
        {
            if (Result != "'All'")
            {
                ResultFilter = $"Result={Result}";
            }
            else
            {
                ResultFilter = "";
            }


        }
        private void cmbResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string FixedString = "'" + cmb.SelectedItem.ToString() + "'";
            GetResulrFilter(FixedString);
            refreshDataGrid();
        }
    }
}
