using HMS.Add_Edit.Medications;
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

namespace HMS
{
    public partial class frmAddEditPrescription : Form
    {
        public Action ReloadCallingDGV;
        public frmAddEditPrescription(int PrescriptionID,int EmployeeID)
        {
            InitializeComponent();
            ctrlAddEditPrescriptions1.SetID(PrescriptionID);
            ctrlAddEditPrescriptions1.SetDoctorID(clsEmployees.GetEmployeeRoleID(EmployeeID));
            ctrlAddEditPrescriptions1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            ReloadCallingDGV?.Invoke();
            this.Close();
        }
        private void frmAddEditPrescription_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditPrescriptions1_Load(object sender, EventArgs e)
        {

        }
    }
}
