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

namespace HMS.Lists.Admins.Procedure
{
    public partial class ctrlOperationListViewForAdmins : ctrlOperationListViewBase
    {
        public ctrlOperationListViewForAdmins()
        {
            InitializeComponent();
            ItemsToBeAddedToContextMenu();
        }
        
        override protected void ItemsToBeAddedToContextMenu()
        {
            
            ItemsInfo[] items = new ItemsInfo[] { new ItemsInfo("Edit", editToolStripMenuItem_Click) };
            AlterContextMenu.Invoke(this, items);


        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Operation with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                     frmAddEditOperation  frmOperation= new frmAddEditOperation(ID,this.ID);
                    frmOperation.MdiParent = clsMDIParent.MDIPARENT;
                    frmOperation.Dock = DockStyle.Fill;
                    frmOperation.Show(); 
                    RefillDGV(clsOperations.GetAll(this.ID,clsViews.enShowing.enAdmin));


                }
            }
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Operation with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditOperation frmOperation = new frmAddEditOperation(ID, this.ID);
                    frmOperation.MdiParent = clsMDIParent.MDIPARENT;
                    frmOperation.Dock = DockStyle.Fill;
                    frmOperation.Show(); 
                    RefillDGV(clsOperations.GetAll(this.ID, clsViews.enShowing.enAdmin));

                }
            }
        }

   
        private void ctrlOperationListViewForAdmins_Load(object sender, EventArgs e)
        {

        }
    }
}
