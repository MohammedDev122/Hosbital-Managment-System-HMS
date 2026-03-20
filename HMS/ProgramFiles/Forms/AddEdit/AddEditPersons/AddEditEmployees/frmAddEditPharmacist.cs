using HMS.Add_Edit.Medications;
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
    public partial class frmAddEditPharmacist : Form
    {
        public Action ReloadCallingDGV;
        public frmAddEditPharmacist(int PharmacistID)
        {
            InitializeComponent();
            ctrlAddEditPharmacist1.SetID(PharmacistID);
            ctrlAddEditPharmacist1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            ReloadCallingDGV?.Invoke();
            this.Close();
        }

        private void frmAddEditPharmacist_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditPharmacist1_Load(object sender, EventArgs e)
        {

        }
    }
}
