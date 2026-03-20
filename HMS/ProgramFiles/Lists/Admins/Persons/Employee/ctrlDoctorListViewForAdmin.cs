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

namespace HMS.Lists
{
    public partial class ctrlDoctorListViewForAdmin : ctrlDoctorListViewBase
    {
        public ctrlDoctorListViewForAdmin()
        {
            InitializeComponent();
            Showing = clsViews.enShowing.enAdmin;
            FullData= clsDoctors.GetAll(Showing);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
            ItemsToBeAddedToContextMenu();
        }
        override protected void ItemsToBeAddedToContextMenu()
        {

            ItemsInfo[] items = new ItemsInfo[] { new ItemsInfo("Edit", editToolStripMenuItem_Click), new ItemsInfo("Add", addToolStripMenuItem_Click) };
            AlterContextMenu.Invoke(this, items);


        }
        void RefillThisDGV()
        {
            RefillDGV(clsDoctors.GetAll(clsViews.enShowing.enAdmin));

        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Doctor with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditDoctor frmDoctor = new frmAddEditDoctor(ID);
                    frmDoctor.MdiParent = clsMDIParent.MDIPARENT;
                    frmDoctor.Dock = DockStyle.Fill;
                    frmDoctor.ReloadCallingDGV = RefillThisDGV;

                    frmDoctor.Show();


                }
            }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Doctor with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditDoctor frmDoctor = new frmAddEditDoctor(ID);
                    frmDoctor.MdiParent = clsMDIParent.MDIPARENT;
                    frmDoctor.Dock = DockStyle.Fill;
                    frmDoctor.ReloadCallingDGV = RefillThisDGV;

                    frmDoctor.Show();



                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditDoctor frmDoctor = new frmAddEditDoctor(-1);
            frmDoctor.MdiParent = clsMDIParent.MDIPARENT;
            frmDoctor.Dock = DockStyle.Fill;
            frmDoctor.ReloadCallingDGV = RefillThisDGV;

            frmDoctor.Show();

        }
        private void ctrlDoctorListViewForAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
