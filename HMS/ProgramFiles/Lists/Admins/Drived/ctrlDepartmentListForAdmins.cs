using HMS.Lists.Bases.DerivedTables;
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
    public partial class ctrlDepartmentListForAdmins : ctrlDepartmentsListBase
    {
        public ctrlDepartmentListForAdmins()
        {
            InitializeComponent();
            ItemsToBeAddedToContextMenu();
        }
        override protected void ItemsToBeAddedToContextMenu()
        {

            ItemsInfo[] items = new ItemsInfo[] { new ItemsInfo("Edit", editToolStripMenuItem_Click) };
            AlterContextMenu.Invoke(this, items);


        }
        public void RefilThisDGV()
        {
            RefillDGV(clsDeparmtments.GetAllDepartments());

        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Department with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditDepartment frmDepartment = new frmAddEditDepartment(ID);
                    frmDepartment.MdiParent = clsMDIParent.MDIPARENT;
                    frmDepartment.Dock = DockStyle.Fill;
                    frmDepartment.ReloadCallingDGV = RefilThisDGV;

                    frmDepartment.Show();


                }
            }
        }

        private void ctrlDepartmentListForAdmins_Load(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {

              frmAddEditDepartment frmDepartment=new frmAddEditDepartment(ID);
                frmDepartment.MdiParent = clsMDIParent.MDIPARENT;
                frmDepartment.Dock = DockStyle.Fill;
                frmDepartment.ReloadCallingDGV = RefilThisDGV;

                frmDepartment.Show();
              



            }

        }
    }
}
