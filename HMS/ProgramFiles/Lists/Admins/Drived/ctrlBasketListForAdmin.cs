using HMS.Lists.Bases.DerivedTables;
using HosbitalBussinessLayer.Medications;
using HosbitalBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Lists.Admins
{
    public partial class ctrlBasketListForAdmin : ctrlBasketItemsListBase
    {
        public ctrlBasketListForAdmin()
        {
            InitializeComponent();
        }
        public void AddNewItem(object obj, int PrescripedMed)
        {
            clsBasket Basket = clsBasket.FindBasketByID(ID);
            if (Basket != null)
            {
                if (!Basket.AddItemToBasket(PrescripedMed))
                {
                    MessageBox.Show($"{Basket.FailCause}", "info");
                }


                FullData = clsItems.GetItemsForBasket(ID);
                BS.DataSource = FullData;
                DGV1.DataSource = BS;
            }
            //open form to enter the rest info of prescriped medication
        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = Convert.ToInt32(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value);
            if (MessageBox.Show($"You want to remove Item  with  {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsItems.FindItemByID(ID) !=null)
                {
                    clsBasket Basket=clsBasket.FindBasketByID(this.ID);
                    if (Basket.RemoveItemFromBasketItem(ID))
                    {
                        FullData = clsItems.GetItemsForBasket(this.ID);
                        BS.DataSource = FullData;
                        DGV1.DataSource = BS;



                    }
                }
               else
                {
                    MessageBox.Show($"You can't remove Item with ID:{ID}, because it already dispensed!", "error");
                }

            }
        }
        private void ctrlBasketListForAdmin_Load(object sender, EventArgs e)
        {
            FullData = clsItems.GetItemsForBasket(ID);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }
    }
}
