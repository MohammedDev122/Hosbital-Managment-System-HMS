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
    public partial class frmAddEditEmployee : Form
    {
       public Action ReloadCallingDGV;
        public frmAddEditEmployee(int EmployeeID)
        {
            InitializeComponent();
            ctrlAddEditEmployee1.SetID(EmployeeID);
            ctrlAddEditEmployee1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            ReloadCallingDGV?.Invoke();
            this.Close();
        }
        private void frmAddEditEmployee_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditEmployee1_Load(object sender, EventArgs e)
        {

        }
    }
}
