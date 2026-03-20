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
    public partial class frmPatientAddEdit : Form
    {
        public frmPatientAddEdit(int PatientID)
        {
            InitializeComponent();
            ctrlAddEditPatient1.SetID(PatientID);
            ctrlAddEditPatient1.CloseForm = CloseForm;
        }
        public Action RelodTheCallingForm; 
        void CloseForm()
        {
            this.Close();
            RelodTheCallingForm?.Invoke();
        }

        private void frmPatientAddEdit_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditPatient1_Load(object sender, EventArgs e)
        {

        }
    }
}
