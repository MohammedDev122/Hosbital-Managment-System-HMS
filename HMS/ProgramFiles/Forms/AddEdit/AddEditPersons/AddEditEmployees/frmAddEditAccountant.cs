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
    public partial class frmAddEditAccountant : Form
    {
        public Action ReloadCallingDGV;
        public frmAddEditAccountant(int AccountantID)
        {
            InitializeComponent();
            ctrlAddEditAccountant1.SetID(AccountantID);
            ctrlAddEditAccountant1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            ReloadCallingDGV?.Invoke();
            this.Close();
        }
        private void frmAddEditAccountant_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditAccountant1_Load(object sender, EventArgs e)
        {

        }
    }
}
