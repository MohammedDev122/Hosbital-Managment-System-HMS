using HMS.Lists.Bases.DerivedTables;
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
    public partial class ctrlSpecilizationListForAdmins : ctrlSpecilizationsListBase
    {
        public ctrlSpecilizationListForAdmins()
        {
            InitializeComponent();
            ItemsToBeAddedToContextMenu();
        }
        override protected void ItemsToBeAddedToContextMenu()
        {

            ItemsInfo[] items = new ItemsInfo[] { new ItemsInfo("Edit", editToolStripMenuItem_Click), new ItemsInfo("Add", addToolStripMenuItem_Click) };
            AlterContextMenu.Invoke(this, items);


        }

        private void ctrlSpecilizationListForAdmins_Load(object sender, EventArgs e)
        {

        }
        public void RefillThisDGV()
        {
            RefillDGV(clsSpecilization.GetAllSpecilizations());



        }
    override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Specilization with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditSpecilization frmSpecs = new frmAddEditSpecilization(ID);
                    frmSpecs.MdiParent = clsMDIParent.MDIPARENT;
                    frmSpecs.Dock = DockStyle.Fill;
                    frmSpecs.ReloadCallingDGV = RefillThisDGV;

                    frmSpecs.Show();
                }
            }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Specilization with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditSpecilization frmSpecs = new frmAddEditSpecilization(ID);
                    frmSpecs.MdiParent = clsMDIParent.MDIPARENT;
                    frmSpecs.Dock = DockStyle.Fill;
                    frmSpecs.ReloadCallingDGV = RefillThisDGV;

                    frmSpecs.Show();
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditSpecilization frmSpecs = new frmAddEditSpecilization(-1);
            frmSpecs.MdiParent = clsMDIParent.MDIPARENT;
            frmSpecs.Dock = DockStyle.Fill;
            frmSpecs.ReloadCallingDGV = RefillThisDGV;

            frmSpecs.Show();

        }
    }
}
