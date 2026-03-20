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
    public partial class frmAddEditLogin : Form
    {
        public Action ReloadCallingDGV;
        public frmAddEditLogin(int LogginID)
        {
            InitializeComponent();
            ctrlAddEditLogin1.SetID(LogginID);
            ctrlAddEditLogin1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            ReloadCallingDGV?.Invoke();
            this.Close();
        }
        private void frmAddEditLogin_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditLogin1_Load(object sender, EventArgs e)
        {

        }
    }
}
