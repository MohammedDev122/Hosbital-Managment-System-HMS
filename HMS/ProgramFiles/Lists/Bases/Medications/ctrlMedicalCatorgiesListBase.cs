using HosbitalBussinessLayer.DerivedTables;
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
    public partial class ctrlMedicalCatorgiesListBase : ctrlBaseDGV
    {
        public ctrlMedicalCatorgiesListBase()
        {
            InitializeComponent();
            FillCmbSearch();
            FullData=clsMedicalCatorgies.GetAllCatorgies();
            BS.DataSource = FullData;
            DGV1.DataSource = BS;


        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Catorgy Name");
            cmbSearch.Items.Insert(0, "Catorgy ID");
            cmbSearch.SelectedIndex = 0;

        }
        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int ID))
                    {
                        GetSearchFileter(($"CONVERT(ID, 'System.String') like '{txtSearch.Text}%'"));
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
                        GetSearchFileter(($"Catorgy like '{txtSearch.Text}%'"));
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

        private void ctrlMedicalCatorgiesListBase_Load(object sender, EventArgs e)
        {

        }
    }
}
