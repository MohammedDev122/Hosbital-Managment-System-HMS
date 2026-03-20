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

namespace HMS.Lists.Owners.Patient
{
    public partial class ctrlPrescripedMedListForPatient : ctrlPrescripedMedListBase
    {
        int _PrescriptionID = -1;
        public ctrlPrescripedMedListForPatient()
        {
            InitializeComponent();
            FullData = clsPrescripedMed.GetAllPrescripedMedForPrescription(_PrescriptionID);
           BS.DataSource = FullData;
            DGV1.DataSource = BS;
            ItemsToBeAddedToContextMenu();
        }
      override  protected void ItemsToBeAddedToContextMenu()
        {

            ItemsInfo[] items = new ItemsInfo[] { new ItemsInfo("Edit", editToolStripMenuItem_Click) };
       AlterContextMenu.Invoke(this,items);


        }
        public void setPrescriptionID(int ID)
        {

            _PrescriptionID=ID;

        }
     public void AddNewPrescripedMedication(object obj,int MedicationID)
        {


            frmAddEditPrescripedMed frmprescripedMed = new frmAddEditPrescripedMed(ID, _PrescriptionID, MedicationID);
            frmprescripedMed.MdiParent = clsMDIParent.MDIPARENT;
            frmprescripedMed.Dock = DockStyle.Fill;
            frmprescripedMed.Show();
        
        FullData = clsPrescripedMed.GetAllPrescripedMedForPrescription(_PrescriptionID);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
          
            //open form to enter the rest info of prescriped medication
        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = Convert.ToInt32(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value);
            if (MessageBox.Show($"You want to remove prescriped med with  {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsPrescripedMed.FindPrescripedMedicationByID(ID).State == clsPrescripedMed.enState.enStill)
                {  if (clsRoleBack.DeletePrescripedMed(ID))
                    {
                        FullData = clsPrescripedMed.GetAllPrescripedMedForPrescription(_PrescriptionID);
                        BS.DataSource = FullData;
                        DGV1.DataSource = BS;



                    }
            }
                else
                {
                    MessageBox.Show($"You can't remove prescriped med with ID:{ID}, because it already dispensed!", "error");
                }
        
            }
        }
        private void ctrlPrescripedMedListForPatient_Load(object sender, EventArgs e)
        {
            FullData = clsPrescripedMed.GetAllPrescripedMedForPrescription(_PrescriptionID);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPrescripedMed frmPrescripedMed = new frmAddEditPrescripedMed(Convert.ToInt32(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), -1,-1);
            frmPrescripedMed.MdiParent = clsMDIParent.MDIPARENT;
            frmPrescripedMed.Dock = DockStyle.Fill;
            frmPrescripedMed.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
           
        }
    }
}
