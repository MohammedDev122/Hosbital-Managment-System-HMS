using HosbitalBussinessLayer.Medications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Lists.Bases.Medications
{
    public partial class ctrlPrescribtionBaseList : ctrlBaseDGV
    {


        string StateFilter = "";
        public ctrlPrescribtionBaseList()
        {
            InitializeComponent();
            FillCmbSearch();
            FillCmbState();
            FillCmbSearch();
            FullData =clsPrescription.GetAllPrescriptions(Showing);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;




        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Patient Name");
            cmbSearch.Items.Insert(0, "Patient ID");
            cmbSearch.Items.Insert(0, "Medical Record ID");

            cmbSearch.Items.Insert(0, "Prescription ID");
            cmbSearch.SelectedIndex = 0;

        }
        protected void FillCmbState()
        {

            cmbState.Items.Clear();
            cmbState.Items.Insert(0, "Cancelled");
            cmbState.Items.Insert(0, "Still");
            cmbState.Items.Insert(0, "Partiallydispensed");
            cmbState.Items.Insert(0, "Fullydispensed");
            cmbState.Items.Insert(0, "All");
            cmbState.SelectedIndex = 0;

        }
        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int PrescriptionID))
                    {
                        GetSearchFileter(($"CONVERT(PrescriptionID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
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
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }
                    break;
                case (2):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int PatientID))
                    {
                        GetSearchFileter(($"CONVERT(PatientID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }
                    break;

                case (3):
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    {
                        GetSearchFileter(($"PatientName like '{txtSearch.Text}%'"));
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
        void GetStateFilter(string State)
        {
            if (State != "'All'")
            {
                StateFilter = $"State={State}";


            }
            else
            {
                StateFilter = "";
            }



        }
        override protected void GetAllFileterResult()
        {

            FilterString = "";
            if (searchFilter.Length > 0)
            {

                FilterString = AddAnd(FilterString);
                FilterString += searchFilter;

            }
            if (StateFilter.Length > 0)
            {

                FilterString = AddAnd(FilterString);
                FilterString += StateFilter;

            }
        }


            private void ctrlPrescribtionBaseList_Load(object sender, EventArgs e)
        {

        }

        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb=(ComboBox)sender;
            string FixedString="'"+cmb.SelectedItem.ToString()+"'";
            GetStateFilter(FixedString);
            refreshDataGrid();
        }
    }
}
