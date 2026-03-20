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
    public partial class frmAddEditPharmecyRecords : Form
    {
        public Action ReloadCallingDGV;
        public frmAddEditPharmecyRecords(int RecordID,int EmployeeID)
        {
            InitializeComponent();
            ctrlAddEditPharmecyRecord1.SetID(RecordID);
            ctrlAddEditPharmecyRecord1.SetEmployeeID(EmployeeID);
            ctrlAddEditPharmecyRecord1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            ReloadCallingDGV?.Invoke();
            this.Close();
        }
        private void frmAddEditPharmecyRecords_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditPharmecyRecord1_Load(object sender, EventArgs e)
        {

        }
    }
}
