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
    public partial class frmAddEditDoctor : Form
    {
        public Action ReloadCallingDGV;
        public frmAddEditDoctor(int DoctorID)
        {
            InitializeComponent();
            ctrlAddEditDoctor1.SetID(DoctorID);
            ctrlAddEditDoctor1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            ReloadCallingDGV?.Invoke();
            this.Close();
        }
        private void frmAddEditDoctor_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditDoctor1_Load(object sender, EventArgs e)
        {

        }
    }
}
