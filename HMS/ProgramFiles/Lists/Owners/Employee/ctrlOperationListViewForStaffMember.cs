using HMS.Lists.Bases.Services;
using HosbitalBussinessLayer.Procedures;
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

namespace HMS.Lists.Owners.Employee
{
    public partial class ctrlOperationListViewForStaffMember : ctrlOperationListViewBase
    {
        public ctrlOperationListViewForStaffMember()
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
            RefillDGV(clsOperations.GetAll(this.ID, clsViews.enShowing.enInfoEmployeeOwner));

        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Operation with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditOperation frmOp = new frmAddEditOperation(ID, this.ID);
                    frmOp.MdiParent = clsMDIParent.MDIPARENT;
                    frmOp.Dock = DockStyle.Fill;
                    frmOp.ReloadCallingDGV = RefillThisDGV;

                    frmOp.Show();

                }
            }

        }
        private void ctrlOperationListViewForStaffMember_Load(object sender, EventArgs e)
        {
            Showing = clsViews.enShowing.enInfoEmployeeOwner;
            FullData = clsOperations.GetAll(ID, Showing);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsEmployees employee=clsEmployees.FindByID(ID);
            if (employee != null) {
                if (employee.DepartmentID == 9)
                {

                    frmAddEditOperation frmOp = new frmAddEditOperation(-1, ID);
                    frmOp.MdiParent = clsMDIParent.MDIPARENT;
                    frmOp.Dock = DockStyle.Fill;
                    frmOp.ReloadCallingDGV = RefillThisDGV;

                    frmOp.Show();


                }
                else
                {
                    MessageBox.Show("only Doctor Can Add Operation!", "error");
                }
                    }


        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV1.Columns.Count > 0)
            {
                if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
                {
                    if (MessageBox.Show($"You want to edit This Operation with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        frmAddEditOperation frmOp = new frmAddEditOperation(ID, this.ID);
                        frmOp.MdiParent = clsMDIParent.MDIPARENT;
                        frmOp.Dock = DockStyle.Fill;
                        frmOp.ReloadCallingDGV = RefillThisDGV;

                        frmOp.Show();

                    }
                }
            }

        }
    }
}
