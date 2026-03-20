using HMS.Add_Edit.Medications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS
{
    public partial class frmAddEditPrescripedMed : Form
    {
        public frmAddEditPrescripedMed(int ID, int PrescriptionID, int MedID)
        {
            InitializeComponent();
            if (ID != -1)
            {
                ctrlAddEditPrescripedMed1.SetID(ID);
            }
            else { 
            ctrlAddEditPrescripedMed1.SetMedicationID(MedID);
            ctrlAddEditPrescripedMed1.SetPrescriptionID(PrescriptionID);
        }
            ctrlAddEditPrescripedMed1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }
        private void frmAddEditPrescripedMed_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditPrescripedMed1_Load(object sender, EventArgs e)
        {

        }
    }
}
