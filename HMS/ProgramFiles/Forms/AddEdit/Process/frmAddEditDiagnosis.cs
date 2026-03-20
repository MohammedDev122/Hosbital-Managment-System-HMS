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
    public partial class frmAddEditDiagnosis : Form
    {
        public Action ReloadCallingDGV;
        public frmAddEditDiagnosis(int DiagnosisID,int EmployeeID)
        {
            
            InitializeComponent();
            ctrlAddEditDiagnosis1.SetID(DiagnosisID);
            clsEmployees employees=clsEmployees.FindByID(EmployeeID);
            if (employees != null) {
                ctrlAddEditDiagnosis1.SetSignedDepartment(employees.DepartmentID);
                if (employees.DepartmentID == 9)
                {


                    ctrlAddEditDiagnosis1.SetSignedDoctor(clsEmployees.GetEmployeeRoleID(EmployeeID));
                } }
            ctrlAddEditDiagnosis1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            ReloadCallingDGV?.Invoke();
            this.Close();
        }
        private void frmAddEditDiagnosis_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditDiagnosis1_Load(object sender, EventArgs e)
        {

        }
    }
}
