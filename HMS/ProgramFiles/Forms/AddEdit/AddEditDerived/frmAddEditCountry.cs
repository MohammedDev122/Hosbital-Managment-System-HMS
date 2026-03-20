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
    public partial class frmAddEditCountry : Form
    {
        public frmAddEditCountry(int CountryID)
        {
            InitializeComponent();
            ctrlAddEditCountry1.SetID(CountryID);
            ctrlAddEditCountry1.CloseForm = CloseForm;
        }
        public Action ReloadCallingDGV;
        void CloseForm()
        {
            ReloadCallingDGV?.Invoke();

            this.Close();
        }

        private void frmAddEditCountry_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditCountry1_Load(object sender, EventArgs e)
        {

        }
    }
}
