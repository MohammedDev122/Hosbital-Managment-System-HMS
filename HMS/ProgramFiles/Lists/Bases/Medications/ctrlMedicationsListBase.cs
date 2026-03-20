using HosbitalBussinessLayer;
using HosbitalBussinessLayer.DerivedTables;
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
    public partial class ctrlMedicationsListBase : ctrlBaseDGV
    {
        string CatorgyFilter = "";
        public ctrlMedicationsListBase()
        {
            InitializeComponent();
            Showing = clsViews.enShowing.enAdmin;
            FillCmbSearch();
            FillCmbCatorgy();
            FullData =clsMedications.GetAllMedication(Showing);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
            




        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Medication Name");
            cmbSearch.Items.Insert(0, "Medication ID");
            cmbSearch.SelectedIndex = 0;

        }
        protected void FillCmbCatorgy()
        {

            cmbCatorgy.Items.Clear();
           DataTable dataTable=clsMedicalCatorgies.GetAllCatorgies();
            cmbCatorgy.Items.Add("All");

            foreach (DataRow row in dataTable.Rows) {

                cmbCatorgy.Items.Add(row["Catorgy"]);




            }

            cmbCatorgy.SelectedIndex = 0;

        }
        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
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


                case (1):
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

        private void ctrlMedicationsListBase_Load(object sender, EventArgs e)
        {

        }
        void GetCatorgyFilter(string Catorgy)
        {
            if (Catorgy != "'All'")
            {
                CatorgyFilter =$"Catorgy={Catorgy}";


            }
            else
            {
                CatorgyFilter = "";
            }



        }
     override   protected void GetAllFileterResult() {

            FilterString = "";
            if (searchFilter.Length > 0) {

                FilterString = AddAnd(FilterString);
                FilterString += searchFilter;
            
            }
            if (CatorgyFilter.Length > 0)
            {

                FilterString = AddAnd(FilterString);
                FilterString += CatorgyFilter;

            }






        }
        private void cmbCatorgy_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox cmb = (ComboBox)sender;
            string FixedString="'"+cmb.SelectedItem.ToString()+"'";
            GetCatorgyFilter(FixedString);
            refreshDataGrid();


        }
    }
}
