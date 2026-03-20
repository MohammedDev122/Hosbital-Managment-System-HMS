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
    public partial class frmMedicationList : Form
    {
        public frmMedicationList(int EmployeeID)
        {
            InitializeComponent();
            ctrlMedicationListForAdmins1.CloseForm = CloseForm;
            ctrlMedicationListForAdmins1.SetID(EmployeeID);
        }
        void CloseForm()
        {
            this.Close();
        }

        private void ctrlMedicationListForAdmins1_Load(object sender, EventArgs e)
        {

        }
    }
}
