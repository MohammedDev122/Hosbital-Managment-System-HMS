using HMS.Lists.Bases.Services;
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

namespace HMS.Lists.Owners.Patient
{
    public partial class ctrlDiagnosisListViewForPatient : ctrlDiagnosisListViewBase
    {
        public ctrlDiagnosisListViewForPatient()
        {
            InitializeComponent();
            FillCmbSearch();
           

        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Medical Record ID");
            cmbSearch.Items.Insert(0, "Payment ID");
            cmbSearch.Items.Insert(0, "Doctor ID");
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
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int DoctorID))
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
        private void ctrlDiagnosisListViewForPatient_Load(object sender, EventArgs e)
        {

            Showing = clsViews.enShowing.enPatientOwner;
            FullData = clsDiagnosis.GetAll(this.ID, Showing);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }
    }
}
