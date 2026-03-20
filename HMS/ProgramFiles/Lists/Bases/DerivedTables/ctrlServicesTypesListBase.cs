using HosbitalBussinessLayer.DerivedTables;
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

namespace HMS.Lists.Bases.DerivedTables
{
    public partial class ctrlServicesTypesListBase : ctrlBaseDGV
    {
        public ctrlServicesTypesListBase()
        {
            InitializeComponent();
            FillCmbSearch();
            FullData =clsServiceTypes.GetAllTypes();
            BS.DataSource = FullData;
            DGV1.DataSource = BS;



        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Service Name");
            cmbSearch.Items.Insert(0, "Type ID");
            cmbSearch.SelectedIndex = 0;

        }
        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int TypeID))
                    {
                        GetSearchFileter(($"CONVERT(TypeID, 'System.String') like '{txtSearch.Text}%'"));
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
                        GetSearchFileter(($"ServiceName like '{txtSearch.Text}%'"));
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

        private void ctrlServicesTypesListBase_Load(object sender, EventArgs e)
        {

        }
    }
}
