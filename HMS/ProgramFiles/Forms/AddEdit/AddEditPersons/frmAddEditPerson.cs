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
    public partial class frmAddEditPerson : Form
    {
        public frmAddEditPerson(int personID)
        {
            InitializeComponent();
            ctrlAddEditPerson1.SetID(personID);
            ctrlAddEditPerson1.CloseForm = CloseForm;
            ctrlAddEditPerson1.button1.Visible = false;
        }
        void CloseForm()
        {
            this.Close();
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditPerson1_Load(object sender, EventArgs e)
        {

        }
    }
}
