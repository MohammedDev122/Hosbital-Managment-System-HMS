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
    public partial class Doctor : Form
    {
        public Doctor(int EmployeeID)
        {
            InitializeComponent();
            clsMDIParent.MDIPARENT = this;

            ctrlDoctorPanel1.SetID(EmployeeID);
        }

        private void Doctor_Load(object sender, EventArgs e)
        {

        }
    }
}
