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

namespace HMS.Lists.Admins.Persons.Employee
{
    public partial class ctrlEmployeeListForAdmins : ctrlEmployeeList
    {
        public ctrlEmployeeListForAdmins()
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

            RefillDGV(clsEmployees.GetAll(clsViews.enShowing.enAdmin));

        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID)){
                if (MessageBox.Show($"You want to edit This Emplyee with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditEmployee frmEmployee = new frmAddEditEmployee(ID);
                    frmEmployee.MdiParent = clsMDIParent.MDIPARENT;
                    frmEmployee.Dock = DockStyle.Fill;
                    frmEmployee.ReloadCallingDGV = RefillThisDGV;

                    frmEmployee.Show();


                }
            }
        }
   

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID)){
                if (MessageBox.Show($"You want to edit This Emplyee with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditEmployee frmEmployee = new frmAddEditEmployee(ID);
                    frmEmployee.MdiParent = clsMDIParent.MDIPARENT;
                    frmEmployee.Dock = DockStyle.Fill;
                    frmEmployee.ReloadCallingDGV = RefillThisDGV;

                    frmEmployee.Show();

                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditEmployee frmEmployee = new frmAddEditEmployee(-1);
            frmEmployee.MdiParent = clsMDIParent.MDIPARENT;
            frmEmployee.Dock = DockStyle.Fill;
            frmEmployee.ReloadCallingDGV = RefillThisDGV;

            frmEmployee.Show();

        }
        private void ctrlEmployeeListForAdmins_Load(object sender, EventArgs e)
        {

        }
    }
}
