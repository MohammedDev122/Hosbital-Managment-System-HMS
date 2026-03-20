using HMS.Add_Edit.AddEditPerson.AddEditEmployees;
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
    public partial class frmAddEditMedication : Form
    {
        public Action ReloadCallingDGV;
        public frmAddEditMedication(int MedicationID,int EmployeeID)
        {
            InitializeComponent();
            ctrlAddEditMedication1.SetID(MedicationID);
            ctrlAddEditMedication1.SetPharmacistID(clsEmployees.GetEmployeeRoleID(EmployeeID));
            ctrlAddEditMedication1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            ReloadCallingDGV?.Invoke();
            this.Close();
        }
        private void frmAddEditMedication_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditMedication1_Load(object sender, EventArgs e)
        {

        }
    }
}
