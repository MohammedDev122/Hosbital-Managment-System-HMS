using HMS.Lists.Bases.Services;
using HosbitalBussinessLayer;
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

namespace HMS.Lists.Admins
{
    public partial class ctrlDiagnosisListViewForAdmins : ctrlDiagnosisListViewBase
    {
        public ctrlDiagnosisListViewForAdmins()
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


            RefillDGV(clsDiagnosis.GetAll(-1, clsViews.enShowing.enAdmin));

        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Appointment with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditDiagnosis frmEmployee = new frmAddEditDiagnosis(ID,this.ID);
                    frmEmployee.MdiParent = clsMDIParent.MDIPARENT;
                    frmEmployee.Dock = DockStyle.Fill;
                    frmEmployee.ReloadCallingDGV = RefillThisDGV;

                    frmEmployee.Show();


                }
            }
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Appointment with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditDiagnosis frmEmployee = new frmAddEditDiagnosis(ID, this.ID);
                    frmEmployee.MdiParent = clsMDIParent.MDIPARENT;
                    frmEmployee.Dock = DockStyle.Fill;
                    frmEmployee.ReloadCallingDGV = RefillThisDGV;

                    frmEmployee.Show();

                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditDiagnosis frmEmployee = new frmAddEditDiagnosis(-1, this.ID);
            frmEmployee.MdiParent = clsMDIParent.MDIPARENT;
            frmEmployee.Dock = DockStyle.Fill;
            frmEmployee.ReloadCallingDGV = RefillThisDGV;

            frmEmployee.Show();

        }

        private void ctrlDiagnosisListViewForAdmins_Load(object sender, EventArgs e)
        {

        }
    }
}
