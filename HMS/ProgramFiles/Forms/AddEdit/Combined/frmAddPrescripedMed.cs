using HMS.Lists.Admins;
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
    public partial class frmAddPrescripedMed : Form
    {
        public frmAddPrescripedMed(int PrescriptionID)
        {
            InitializeComponent();
            ctrlPrescripedMedListForPatient1.setPrescriptionID(PrescriptionID);
            ctrlMedicationListForOthers1.OnSelectedID += ctrlPrescripedMedListForPatient1.AddNewPrescripedMedication;
            ctrlPrescripedMedListForPatient1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }
        private void frmAddPrescripedMed_Load(object sender, EventArgs e)
        {

        }

        private void ctrlMedicationListForOthers1_OnSelectedID(object sender, int e)
        {
          
        }

        private void ctrlPrescripedMedListForPatient1_Load(object sender, EventArgs e)
        {

        }
    }
}
