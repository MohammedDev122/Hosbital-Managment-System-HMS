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
    public partial class ctrlNurseListForAdmins : ctrlNurseViewBase
    {
        public ctrlNurseListForAdmins()
        {
            InitializeComponent();
            Showing = clsViews.enShowing.enAdmin;
            FullData= clsNurses.GetAll(Showing); ;
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
            RefillDGV(clsNurses.GetAll(clsViews.enShowing.enAdmin));

        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Nurse with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditNurse frmNurse = new frmAddEditNurse(ID);
                    frmNurse.MdiParent = clsMDIParent.MDIPARENT;
                    frmNurse.RelodTheCallingForm = RefillThisDGV;
                    frmNurse.Dock = DockStyle.Fill;
                    frmNurse.Show();


                }
            }
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Nurse with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditNurse frmNurse = new frmAddEditNurse(ID);
                    frmNurse.MdiParent = clsMDIParent.MDIPARENT;
                    frmNurse.Dock = DockStyle.Fill;
                    frmNurse.RelodTheCallingForm = RefillThisDGV;

                    frmNurse.Show();

                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditNurse frmNurse = new frmAddEditNurse(-1);
            frmNurse.MdiParent = clsMDIParent.MDIPARENT;
            frmNurse.Dock = DockStyle.Fill;
            frmNurse.RelodTheCallingForm = RefillThisDGV;

            frmNurse.Show();

        }

        private void ctrlNurseListForAdmins_Load(object sender, EventArgs e)
        {

        }
    }
}
