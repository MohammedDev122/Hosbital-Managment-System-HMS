using HMS.Lists.Bases.Patient;
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

namespace HMS.Lists.Admins.Persons.Patient
{
    public partial class ctrlPatientListViewForAdmin : ctrlPatientListViewBase
    {
        public ctrlPatientListViewForAdmin()
        {
            InitializeComponent();
            Showing = clsViews.enShowing.enAdmin;
            DGV1.DataSource = clsPatients.GetAll(Showing);
            ItemsToBeAddedToContextMenu();
        }
        override protected void ItemsToBeAddedToContextMenu()
        {

            ItemsInfo[] items = new ItemsInfo[] { new ItemsInfo("Edit", editToolStripMenuItem_Click), new ItemsInfo("Add", addToolStripMenuItem_Click) };
            AlterContextMenu.Invoke(this, items);


        }
        void RefilThisDGV()
        {


            RefillDGV(clsPatients.GetAll(clsViews.enShowing.enAdmin));
        }
        override protected async void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Patient with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmPatientAddEdit frmPatient = new frmPatientAddEdit(ID);
                    frmPatient.MdiParent = clsMDIParent.MDIPARENT;
                    frmPatient.Dock = DockStyle.Fill;
                    frmPatient.RelodTheCallingForm = RefilThisDGV;

                    frmPatient.Show();
                   


                }
            }
        }

        private void ctrlPatientListViewForAdmin_Load(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPatientAddEdit frmPatient = new frmPatientAddEdit(-1);
            frmPatient.MdiParent = clsMDIParent.MDIPARENT;
            frmPatient.Dock = DockStyle.Fill;
            frmPatient.RelodTheCallingForm = RefilThisDGV;

            frmPatient.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Patient with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmPatientAddEdit frmPatient = new frmPatientAddEdit(ID);
                    frmPatient.MdiParent = clsMDIParent.MDIPARENT;
                    frmPatient.Dock = DockStyle.Fill;
                    frmPatient.RelodTheCallingForm = RefilThisDGV;

                    frmPatient.Show();


                }
            }
        }
    }
}
