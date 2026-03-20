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
    public partial class frmAddEditRoom : Form
    {
        public Action ReloadCallingDGV;
        public frmAddEditRoom(int ID)
        {
            InitializeComponent();
            ctrlAddEditRoom1.SetID(ID);

            ctrlAddEditRoom1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            ReloadCallingDGV?.Invoke();
            this.Close();
        }
        private void frmAddEditRoom_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditRoom1_Load(object sender, EventArgs e)
        {

        }
    }
}
