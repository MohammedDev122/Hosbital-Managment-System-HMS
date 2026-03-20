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
    public partial class ctrlAccountantListViewForAdmin : ctrlAccountantListBase
    {
        public ctrlAccountantListViewForAdmin()
        {
            InitializeComponent();
            Showing = clsViews.enShowing.enAdmin;

            FullData = clsAccountant.GetAll(Showing);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;

            ItemsToBeAddedToContextMenu();
        }
        override protected void ItemsToBeAddedToContextMenu()
        {

            ItemsInfo[] items = new ItemsInfo[] { new ItemsInfo("Edit", editToolStripMenuItem_Click), new ItemsInfo("Add", addToolStripMenuItem_Click) };
            AlterContextMenu.Invoke(this, items);


        }
        void RefillThisDGV()
        {
            RefillDGV(clsAccountant.GetAll(clsViews.enShowing.enAdmin));




        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Accountant with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditAccountant frmAccountant = new frmAddEditAccountant(ID);
                    frmAccountant.MdiParent = clsMDIParent.MDIPARENT;
                    frmAccountant.Dock = DockStyle.Fill;
                    frmAccountant.ReloadCallingDGV = RefillThisDGV;

                    frmAccountant.Show();


                }
            }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Accountant with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditAccountant frmAccountant = new frmAddEditAccountant(ID);
                    frmAccountant.MdiParent = clsMDIParent.MDIPARENT;
                    frmAccountant.Dock = DockStyle.Fill;
                    frmAccountant.ReloadCallingDGV = RefillThisDGV;

                    frmAccountant.Show();

                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditAccountant frmAccountant = new frmAddEditAccountant(-1);
            frmAccountant.MdiParent = clsMDIParent.MDIPARENT;
            frmAccountant.Dock = DockStyle.Fill;
            frmAccountant.ReloadCallingDGV = RefillThisDGV;

            frmAccountant.Show();

        }

        private void ctrlAccountantListViewForAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
