using HosbitalBussinessLayer.utility.Navigator;
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
    public partial class Form1 : Form
    {
       public int ID=-1;
        public Form1()
        {

            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void ctrlPersonList1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlDiagnosisListViewForPatient1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditEmployee1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditPayments1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditPatient1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditOperation1_Load(object sender, EventArgs e)
        {

        }

        private void btnDoccument_Click(object sender, EventArgs e)
        {
            CodeDocumentationNavigator.DoccumentProject();
        }
    }
}
