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
    public partial class ctrlServicesTypesListForAdmins : ctrlServicesTypesListBase
    {
        public ctrlServicesTypesListForAdmins()
        {
            InitializeComponent();
            ItemsToBeAddedToContextMenu();
        }
        override protected void ItemsToBeAddedToContextMenu()
        {

            ItemsInfo[] items = new ItemsInfo[] { new ItemsInfo("Edit", editToolStripMenuItem_Click) };
            AlterContextMenu.Invoke(this, items);


        }

        private void ctrlServicesTypesListForAdmins_Load(object sender, EventArgs e)
        {

        }
        public void RefilThisDGV()
        {
            FullData = clsServiceTypes.GetAllTypes();
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                frmAddEditServiceTypes frmAddEditService = new frmAddEditServiceTypes(ID);
                frmAddEditService.MdiParent = clsMDIParent.MDIPARENT;
                frmAddEditService.Dock = DockStyle.Fill;
                frmAddEditService.ReloadCallingDGV = RefilThisDGV;
                frmAddEditService.Show();

               
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {

                frmAddEditServiceTypes frmAddEditService = new frmAddEditServiceTypes(ID);
                frmAddEditService.MdiParent = clsMDIParent.MDIPARENT;
                frmAddEditService.Dock = DockStyle.Fill;
                frmAddEditService.ReloadCallingDGV = RefilThisDGV;

                frmAddEditService.Show();
               

            }
        }
    }
}
