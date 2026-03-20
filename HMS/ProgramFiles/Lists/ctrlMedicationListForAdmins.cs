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

namespace HMS.Lists
{
    public partial class ctrlMedicationListForAdmins : ctrlMedicationsListBase
    {
        public ctrlMedicationListForAdmins()
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
            RefillDGV(clsMedications.GetAllMedication(clsViews.enShowing.enAdmin));

        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Medication with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditMedication Medication = new frmAddEditMedication(ID,this.ID);
                    Medication.MdiParent = clsMDIParent.MDIPARENT;
                    Medication.Dock = DockStyle.Fill;
                    Medication.ReloadCallingDGV = RefillThisDGV;

                    Medication.Show();


                }
            }
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Medication with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.ID = this.ID;
                    frmAddEditMedication Medication = new frmAddEditMedication(ID, this.ID);
                    Medication.MdiParent = clsMDIParent.MDIPARENT;
                    Medication.Dock = DockStyle.Fill;
                    Medication.ReloadCallingDGV = RefillThisDGV;

                    Medication.Show();

                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditMedication Medication = new frmAddEditMedication(-1, this.ID);
            Medication.MdiParent = clsMDIParent.MDIPARENT;
            Medication.Dock = DockStyle.Fill;
            Medication.ReloadCallingDGV = RefillThisDGV;

            Medication.Show();

        }
        private void ctrlMedicationListForAdmins_Load(object sender, EventArgs e)
        {

        }
    }
}
