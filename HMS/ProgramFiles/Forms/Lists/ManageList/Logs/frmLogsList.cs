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
    public partial class frmLogsList : Form
    {
        public frmLogsList()
        {
            InitializeComponent();
            ctrlLogsListForAdmin1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }

        private void frmLogsList_Load(object sender, EventArgs e)
        {

        }

        private void ctrlLogsListForAdmin1_Load(object sender, EventArgs e)
        {

        }
    }
}
