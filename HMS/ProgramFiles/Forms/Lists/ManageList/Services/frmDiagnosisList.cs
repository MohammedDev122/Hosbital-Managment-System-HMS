using HMS.Lists.Admins;
using HMS.Lists.Admins.Procedure;
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
    public partial class frmDiagnosisList : Form
    {
        public frmDiagnosisList()
        {
            InitializeComponent();
            ctrlDiagnosisListViewForAdmins1.CloseForm = CloseForm;
            ctrlDiagnosisListViewForAdmins1.SetID(LoggedEmployee.LoggedEmployeeID);

        }
        void CloseForm()
        {
            this.Close();
        }
        private void frmDiagnosisList_Load(object sender, EventArgs e)
        {

        }

        private void ctrlDiagnosisListViewForAdmins1_Load(object sender, EventArgs e)
        {

        }
    }
}
