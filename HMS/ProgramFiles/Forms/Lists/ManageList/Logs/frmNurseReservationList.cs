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
    public partial class frmNurseReservationList : Form
    {
        public frmNurseReservationList(int EmployeeID)
        {
            InitializeComponent();
            ctrlNurseReservationListForNurse1.SetID(EmployeeID);
            ctrlNurseReservationListForNurse1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }
        private void frmNurseReservationList_Load(object sender, EventArgs e)
        {

        }

        private void ctrlNurseReservationListForNurse1_Load(object sender, EventArgs e)
        {

        }
    }
}
