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
    public partial class frmPrescriptionList : Form
    {
        public frmPrescriptionList(int employeeID)
        {
            InitializeComponent();
            ctrlPrescriptionListForDoctor1.SetID(employeeID);
            ctrlPrescriptionListForDoctor1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }
        private void frmPrescriptionList_Load(object sender, EventArgs e)
        {

        }

        private void ctrlPrescriptionListForDoctor1_Load(object sender, EventArgs e)
        {

        }
    }
}
