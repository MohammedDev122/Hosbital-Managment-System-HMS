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
    public partial class ctrlPharmecyRecordBaseList : ctrlBaseDGV
    {
        protected string StateFilter = "";
        public ctrlPharmecyRecordBaseList()
        {
            InitializeComponent();
            FillCmbSearch();
            FillCmbState();
            FullData = clsPharmacyRecord.GetAll();
            BS.DataSource = FullData;
            DGV1.DataSource = BS;




        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Payment ID");
            cmbSearch.Items.Insert(0, "Prescription ID");
            cmbSearch.Items.Insert(0, "Patient Name");
            cmbSearch.Items.Insert(0, "Patient ID");
            cmbSearch.Items.Insert(0, "Pharmacist Name");
            cmbSearch.Items.Insert(0, "Pharmacist ID");
            cmbSearch.Items.Insert(0, "Record ID");
            cmbSearch.SelectedIndex = 0;

        }
        protected void FillCmbState()
        {

            cmbState.Items.Clear();
            cmbState.Items.Insert(0, "Cancelled");
            cmbState.Items.Insert(0, "bending");
            cmbState.Items.Insert(0, "Payed");
            cmbState.Items.Insert(0, "All");
            cmbState.SelectedIndex = 0;

        }

        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int RecordID))
                    {
                        GetSearchFileter(($"CONVERT(RecordID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }
                    break;
                case (1):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int PharmacistID))
                    {
                        GetSearchFileter(($"CONVERT(PharmacistID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }
                    break;
                case (2):
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    {
                        GetSearchFileter(($"PharmacistName like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;
                case (3):
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
                case (4):
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
                case (5):
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

                case (6):
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





            }

        }
        private void ctrlPharmecyRecordBaseList_Load(object sender, EventArgs e)
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
            if (StateFilter.Length > 0)
            {

                FilterString = AddAnd(FilterString);
                FilterString += StateFilter;

            }
        }
        void GetStateFilter(string State)
        {

            if (State != "'All'")
            {

                StateFilter = $"PaymentState={State}";

            }
            else
                StateFilter = "";


        }
        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string FixedString = "'" + cmb.SelectedItem.ToString() + "'";
            GetStateFilter(FixedString);
            refreshDataGrid();




        }
    }
}
