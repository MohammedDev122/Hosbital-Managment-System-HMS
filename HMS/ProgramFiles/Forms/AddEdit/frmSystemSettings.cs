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
    public partial class frmSystemSettings : Form
    {
        public frmSystemSettings()
        {
            InitializeComponent();
            editSystemSettings1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }

        private void frmSystemSettings_Load(object sender, EventArgs e)
        {

        }

        private void editSystemSettings1_Load(object sender, EventArgs e)
        {

        }
    }
}
