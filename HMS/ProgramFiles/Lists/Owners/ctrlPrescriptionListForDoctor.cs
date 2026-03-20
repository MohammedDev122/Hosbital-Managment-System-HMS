using HMS.Lists.Bases.Medications;
using HosbitalBussinessLayer;
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

namespace HMS.Lists.Admins
{
    public partial class ctrlPrescriptionListForDoctor : ctrlPrescribtionBaseList
    {
        public ctrlPrescriptionListForDoctor()
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
            RefillDGV(
                                          clsPrescription.GetAllPrescriptions(clsViews.enShowing.enInfoEmployeeOwner, clsEmployees.GetEmployeeRoleID(this.ID)));

        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Prescription with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditPrescription frmPrec= new frmAddEditPrescription(ID, clsEmployees.GetEmployeeRoleID(this.ID));
                    frmPrec.MdiParent = clsMDIParent.MDIPARENT;
                    frmPrec.Dock = DockStyle.Fill;
                    frmPrec.ReloadCallingDGV = RefillThisDGV;

                    frmPrec.Show();
                   
                }
            }
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Prescription with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditPrescription frmPrec = new frmAddEditPrescription(ID, clsEmployees.GetEmployeeRoleID(this.ID));
                    frmPrec.MdiParent = clsMDIParent.MDIPARENT;
                    frmPrec.Dock = DockStyle.Fill;
                    frmPrec.ReloadCallingDGV = RefillThisDGV;

                    frmPrec.Show();
                      }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPrescription frmPrec = new frmAddEditPrescription(-1, this.ID);
            frmPrec.MdiParent = clsMDIParent.MDIPARENT;
            frmPrec.Dock = DockStyle.Fill;
            frmPrec.Show();
           }
        private void ctrlPrescriptionListForAdmins_Load(object sender, EventArgs e)
        {
            RefillDGV(
            clsPrescription.GetAllPrescriptions(clsViews.enShowing.enInfoEmployeeOwner,clsEmployees.GetEmployeeRoleID(this.ID)));
        }
    }
}
