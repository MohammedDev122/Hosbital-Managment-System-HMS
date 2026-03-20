using HMS.Lists.Bases.LogsAndRec;
using HosbitalBussinessLayer;
using HosbitalBussinessLayer.Logs.SystemLoginsAndLogs;
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
    public partial class ctrlLoginsListForAdmin : ctrlLoginsListBase
    {
        public ctrlLoginsListForAdmin()
        {
            InitializeComponent();
            ItemsToBeAddedToContextMenu();
        }
        override protected void ItemsToBeAddedToContextMenu()
        {

            ItemsInfo[] items = new ItemsInfo[] { new ItemsInfo("Edit", editToolStripMenuItem_Click) };
            AlterContextMenu.Invoke(this, items);


        } 
        void RefillThisDGV()
        {

            RefillDGV(clsLogins.GetAllLogins());


        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Login with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditLogin frmLogin = new frmAddEditLogin(ID);
                    frmLogin.MdiParent = clsMDIParent.MDIPARENT;
                    frmLogin.Dock = DockStyle.Fill;
                    frmLogin.ReloadCallingDGV = RefillThisDGV;

                    frmLogin.Show();


                }
            }
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Login with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditLogin frmLogin = new frmAddEditLogin(ID);
                    frmLogin.MdiParent = clsMDIParent.MDIPARENT;
                    frmLogin.Dock = DockStyle.Fill;
                    frmLogin.ReloadCallingDGV = RefillThisDGV;

                    frmLogin.Show();


                }
            }
        }

     

        private void ctrlLoginsListForAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
