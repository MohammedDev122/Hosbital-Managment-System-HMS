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
    public partial class ctrlPrescripedMedListBase : ctrlBaseDGV
    {
        string StateFilter = "";
        public ctrlPrescripedMedListBase()
        {
            InitializeComponent();
            FillCmbSearch();
            FillCmbState();

        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Medication Name");
            cmbSearch.Items.Insert(0, "Medication ID");

            cmbSearch.Items.Insert(0, "Prescriped Medication ID");
            cmbSearch.SelectedIndex = 0;

        }
        protected void FillCmbState()
        {

            cmbState.Items.Clear();
            cmbState.Items.Insert(0, "Still");
            cmbState.Items.Insert(0, "Dispensed");
            cmbState.Items.Insert(0, "All");
            cmbState.SelectedIndex = 0;

        }
        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int PrescripedMedicationID))
                    {
                        GetSearchFileter(($"CONVERT(PrescriptionMedID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }
                    break;
                case (1):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int MedicationID))
                    {
                        GetSearchFileter(($"CONVERT(MedicationID, 'System.String') like '{txtSearch.Text}%'"));
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
                        GetSearchFileter(($"MedicationName like '{txtSearch.Text}%'"));
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

        private void ctrlPrescripedMedListBase_Load(object sender, EventArgs e)
        {
            FullData = clsPrescripedMed.GetAllPrescripedMedForPrescription(ID);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
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

                StateFilter =$"State={State}";

            }
            else
                StateFilter = "";


        }
        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string FixedString="'"+cmb.SelectedItem.ToString()+"'";
            GetStateFilter(FixedString);
            refreshDataGrid();




        }
    }
}
