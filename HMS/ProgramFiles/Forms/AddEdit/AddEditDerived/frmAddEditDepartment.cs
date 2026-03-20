using HMS.Add_Edit.AddEditPerson.AddEditEmployees;
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
    public partial class frmAddEditDepartment : Form
    {
        public Action ReloadCallingDGV;
        public frmAddEditDepartment(int DepartmentID)
        {
            InitializeComponent();
            ctrlAddEditDepartments1.SetID(DepartmentID);
            ctrlAddEditDepartments1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            ReloadCallingDGV?.Invoke();

            this.Close();
        }
        private void frmAddEditDepartment_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditDepartments1_Load(object sender, EventArgs e)
        {

        }
    }
}
