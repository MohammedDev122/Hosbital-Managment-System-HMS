using HMS.Lists.Bases;
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
    public partial class ctrlPaymentListForAdmins : ctrlPaymentListView
    {
        public ctrlPaymentListForAdmins()
        {
            InitializeComponent();
            ItemsToBeAddedToContextMenu();
        }
        override protected void ItemsToBeAddedToContextMenu()
        {

            ItemsInfo[] items = new ItemsInfo[] { new ItemsInfo("Edit", editToolStripMenuItem_Click) };
            AlterContextMenu.Invoke(this, items);


        }
        void RefillThisDGV()
        {


            RefillDGV(clsPayments.GetAll());


        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Payment with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                     frmEditPayment frmPa = new frmEditPayment(this.ID,ID);
                    frmPa.MdiParent = clsMDIParent.MDIPARENT;
                    frmPa.Dock = DockStyle.Fill;
                    frmPa.ReloadCallingDGV = RefillThisDGV;

                    frmPa.Show();


                }
            }
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Payment with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmEditPayment frmPa = new frmEditPayment(this.ID, ID);
                    frmPa.MdiParent = clsMDIParent.MDIPARENT;
                    frmPa.Dock = DockStyle.Fill;
                    frmPa.ReloadCallingDGV = RefillThisDGV;

                    frmPa.Show();


                }
            }
        }
        private void ctrlPaymentListForAdmins_Load(object sender, EventArgs e)
        {

        }
    }
}
