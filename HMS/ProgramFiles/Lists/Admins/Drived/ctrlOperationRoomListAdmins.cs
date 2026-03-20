using HMS.Forms;
using HMS.Lists.Bases.DerivedTables;
using HMS.Lists.Bases.Services;
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
    public partial class ctrlOperationRoomListAdmins : ctrlOperationRoomsListBase
    {

        public ctrlOperationRoomListAdmins()
        {
            InitializeComponent();
            ItemsToBeAddedToContextMenu();
        }
        override protected void ItemsToBeAddedToContextMenu()
        {

            ItemsInfo[] items = new ItemsInfo[] { new ItemsInfo("Add", addToolStripMenuItem_Click), new ItemsInfo("Edit", editToolStripMenuItem_Click) };
            AlterContextMenu.Invoke(this, items);


        }
        private void ctrlOperationListAdmins_Load(object sender, EventArgs e)
        {

        }
        public void RefilThisDGV()
        {
            RefillDGV(clsOperationRoom.GetAllOperationRooms());


        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Room with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int RecordID))
                    {

                        frmAddEditRoom frmRoom = new frmAddEditRoom(RecordID);
                        frmRoom.MdiParent = clsMDIParent.MDIPARENT;
                        frmRoom.Dock = DockStyle.Fill;
                        frmRoom.ReloadCallingDGV = RefilThisDGV;

                        frmRoom.Show();
                    }

                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditRoom frmRoom = new frmAddEditRoom(-1);
            frmRoom.MdiParent = clsMDIParent.MDIPARENT;
            frmRoom.Dock = DockStyle.Fill;
            frmRoom.ReloadCallingDGV = RefilThisDGV;

            frmRoom.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Room with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int RecordID))
                    {

                        frmAddEditRoom frmRoom = new frmAddEditRoom(RecordID);
                        frmRoom.MdiParent = clsMDIParent.MDIPARENT;
                        frmRoom.Dock = DockStyle.Fill;
                        frmRoom.ReloadCallingDGV = RefilThisDGV;

                        frmRoom.Show();
                    }

                }
            }
        }    
    }
}
