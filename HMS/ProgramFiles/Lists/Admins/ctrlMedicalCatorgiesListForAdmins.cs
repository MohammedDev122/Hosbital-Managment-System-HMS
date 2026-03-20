using HMS.Lists.Bases.Medications;
using HosbitalBussinessLayer;
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

namespace HMS.Lists.Admins
{
    public partial class ctrlMedicalCatorgiesListForAdmins : ctrlMedicalCatorgiesListBase
    {
        public ctrlMedicalCatorgiesListForAdmins()
        {
            InitializeComponent();
            ItemsToBeAddedToContextMenu();
        }
        override protected void ItemsToBeAddedToContextMenu()
        {

            ItemsInfo[] items = new ItemsInfo[] { new ItemsInfo("Edit", editToolStripMenuItem_Click), new ItemsInfo("Add", addToolStripMenuItem_Click) };
            AlterContextMenu.Invoke(this, items);


        }
        void RefillThisDGV()
        {
            RefillDGV(clsMedicalCatorgies.GetAllCatorgies());



        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Catorgy with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditMedicalCatorgies frmCat = new frmAddEditMedicalCatorgies(ID);
                    frmCat.MdiParent = clsMDIParent.MDIPARENT;
                    frmCat.Dock = DockStyle.Fill;
                    frmCat.ReloadCallingDGV = RefillThisDGV;

                    frmCat.Show();


                }
            }
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Catorgy with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditMedicalCatorgies frmCat = new frmAddEditMedicalCatorgies(ID);
                    frmCat.MdiParent = clsMDIParent.MDIPARENT;
                    frmCat.Dock = DockStyle.Fill;
                    frmCat.ReloadCallingDGV = RefillThisDGV;
                    frmCat.Show();


                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditMedicalCatorgies frmCat = new frmAddEditMedicalCatorgies(-1);
            frmCat.MdiParent = clsMDIParent.MDIPARENT;
            frmCat.Dock = DockStyle.Fill;
            frmCat.ReloadCallingDGV = RefillThisDGV;
            frmCat.Show();

        }
        private void ctrlMedicalCatorgiesListForAdmins_Load(object sender, EventArgs e)
        {

        }
    }
}
