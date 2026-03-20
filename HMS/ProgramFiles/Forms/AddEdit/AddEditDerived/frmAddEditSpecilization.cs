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
    public partial class frmAddEditSpecilization : Form
    {
      public  Action ReloadCallingDGV;
        public frmAddEditSpecilization(int SpecilizationID)
        {
            InitializeComponent();
            ctrlAddEditSpecilization1.SetID(SpecilizationID);
            ctrlAddEditSpecilization1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            ReloadCallingDGV?.Invoke();
            this.Close();
        }
        private void frmAddEditSpecilization_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditSpecilization1_Load(object sender, EventArgs e)
        {

        }
    }
}
