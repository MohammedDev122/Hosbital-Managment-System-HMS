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
    public partial class ctrlPharmaceyRecordListForAdmin : ctrlPharmecyRecordBaseList
    {
        public ctrlPharmaceyRecordListForAdmin()
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

            RefillDGV(clsPharmacyRecord.GetAll());



        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clsEmployees employee = clsEmployees.FindByID(this.ID);
            if (employee != null) {
                if (employee.DepartmentID == 6)
                {
                    if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
                    {
                        if (MessageBox.Show($"You want to edit This Record with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            frmAddEditPharmecyRecords frmPhRec = new frmAddEditPharmecyRecords(ID, this.ID);
                            frmPhRec.MdiParent = clsMDIParent.MDIPARENT;
                            frmPhRec.Dock = DockStyle.Fill;
                            frmPhRec.ReloadCallingDGV = RefillThisDGV;

                            frmPhRec.Show();


                        }
                    }
                }
                else
                {
                    MessageBox.Show("only pharmacist have the permission to add & edit Records!", "error");
                }

            }
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsEmployees employee = clsEmployees.FindByID(this.ID);
            if (employee != null)
            {
                if (employee.DepartmentID == 6)
                {
                    if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
                    {
                        if (MessageBox.Show($"You want to edit This Record with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            frmAddEditPharmecyRecords frmPhRec = new frmAddEditPharmecyRecords(ID, this.ID);

                            frmPhRec.MdiParent = clsMDIParent.MDIPARENT;
                            frmPhRec.Dock = DockStyle.Fill;
                            frmPhRec.ReloadCallingDGV = RefillThisDGV;

                            frmPhRec.Show();


                        }
                    }
                }
                else
                {
                    MessageBox.Show("only pharmacist have the permission to add & edit Records!", "error");
                }

            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsEmployees employee = clsEmployees.FindByID(this.ID);
            if (employee != null)
            {
                if (clsEmployees.FindByID(this.ID).DepartmentID == 6)
                {
                    frmAddEditPharmecyRecords frmPhRec = new frmAddEditPharmecyRecords(-1, this.ID);
                    frmPhRec.MdiParent = clsMDIParent.MDIPARENT;
                    frmPhRec.Dock = DockStyle.Fill;
                    frmPhRec.ReloadCallingDGV = RefillThisDGV;

                    frmPhRec.Show();
                }
                else
                {
                    MessageBox.Show("only pharmacist have the permission to add & edit Records!", "error");
                }

            }
        }
        private void ctrlPharmaceyRecord_Load(object sender, EventArgs e)
        {
           
        }
    }
}
