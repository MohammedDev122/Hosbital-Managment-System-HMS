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
    public partial class frmDiagnosisForDoctor : Form
    {
        public frmDiagnosisForDoctor(int EmployeeID)
        {
            InitializeComponent();
            ctrlDiagnosisListViewForDoctor1.SetID(EmployeeID);
            ctrlDiagnosisListViewForDoctor1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }

        private void frmDiagnosisForDoctor_Load(object sender, EventArgs e)
        {

        }

        private void ctrlDiagnosisListViewForDoctor1_Load(object sender, EventArgs e)
        {

        }
    }
}
