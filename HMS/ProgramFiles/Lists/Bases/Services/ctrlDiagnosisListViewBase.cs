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
    public partial class ctrlDiagnosisListViewBase : ctrlServicesListView
    {
        string SpecilizationFilter = "";
        public ctrlDiagnosisListViewBase()
        {
            InitializeComponent();
            FillCmbSearch();
            FillCmbSpecilization();
       FullData = clsDiagnosis.GetAll(ID, Showing); ;
            BS.DataSource= FullData;
            DGV1.DataSource = BS;
            RearangeDGV();
        }
       
        protected void FillCmbSpecilization()
        {

            cmbSpecilization.Items.Clear();
           cmbSpecilization.Items.Add("All");
         DataTable dt=clsSpecilization.GetAllSpecilizations();
            foreach (DataRow dr in dt.Rows) {
                cmbSpecilization.Items.Add(dr["Specilization"]);
            
            
            }
            cmbSpecilization.SelectedIndex = 0;

        }

    protected    void RearangeDGV()
        {
            if (DGV1.Columns.Count > 0)
            {
                DGV1.Columns["ServiceEndTime"].DisplayIndex = 12;
                DGV1.Columns["ServiceStartTime"].DisplayIndex = 11;

                DGV1.Columns["Date"].DisplayIndex = 10;
            }


        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Medical Record ID");
            cmbSearch.Items.Insert(0, "Doctor ID");
            cmbSearch.Items.Insert(0, "Payment ID");
            cmbSearch.Items.Insert(0, "Patient ID");
            cmbSearch.Items.Insert(0, "Diagnosis ID");
            cmbSearch.SelectedIndex = 0;

        }

        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int ServiceID))
                    {
                        GetSearchFileter(($"CONVERT(DiagnosisID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else if (string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;


                case (1):
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
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int DocID))
                    {
                        GetSearchFileter(($"CONVERT(DoctorID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else if (string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;

                case (4):
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




            }
        }

        private void ctrlDiagnosisListViewBase_Load(object sender, EventArgs e)
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


        }

        void GetSpecilizationFilter(string Specilization)
        {
            if(Specilization!="'All'")
            {
                SpecilizationFilter =$"Specilization={ Specilization}";
            }
            else
            {
                SpecilizationFilter = "";
            }


        }
        private void cmbSpecilization_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb=(ComboBox)sender;
            string FixedString="'"+cmb.SelectedItem.ToString()+"'";
            GetSpecilizationFilter(FixedString);
            refreshDataGrid();


        }
    }
}
