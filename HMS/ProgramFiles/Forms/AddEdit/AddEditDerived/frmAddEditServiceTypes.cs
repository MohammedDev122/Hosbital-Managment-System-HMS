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
    public partial class frmAddEditServiceTypes : Form
    {

        public Action ReloadCallingDGV;
        public frmAddEditServiceTypes(int TypeID)
        {
            InitializeComponent();
            ctrlEditServicesTypes1.SetID(TypeID);
            ctrlEditServicesTypes1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            ReloadCallingDGV?.Invoke();
            this.Close();
        }

        private void frmAddEditServiceTypes_Load(object sender, EventArgs e)
        {

        }

        private void ctrlEditServicesTypes1_Load(object sender, EventArgs e)
        {

        }
    }
}
