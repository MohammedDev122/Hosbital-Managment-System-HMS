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

namespace HMS.Lists.Bases.DerivedTables
{
    public partial class ctrlBasketItemsListBase : ctrlBaseDGV
    {
        public ctrlBasketItemsListBase()
        {
            InitializeComponent();
            FillCmbSearch();
            FullData = clsItems.GetItemsForBasket(ID);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Medication Name");
            cmbSearch.Items.Insert(0, "Item ID");
            cmbSearch.SelectedIndex = 0;

        }
        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int ItemID))
                    {
                        GetSearchFileter(($"CONVERT(ItemID, 'System.String') like '{txtSearch.Text}%'"));
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

        private void ctrlBasketItemsListBase_Load(object sender, EventArgs e)
        {

        }
    }
}
