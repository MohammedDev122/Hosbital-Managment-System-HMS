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
    public partial class frmMyLogsList : Form
    {
        public frmMyLogsList(int EmployeeID)
        {
            InitializeComponent();
            ctrllogsListForEmployee1.SetID(EmployeeID);
            ctrllogsListForEmployee1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }

        private void frmMyLogsList_Load(object sender, EventArgs e)
        {

        }

        private void ctrllogsListForEmployee1_Load(object sender, EventArgs e)
        {

        }
    }
}
