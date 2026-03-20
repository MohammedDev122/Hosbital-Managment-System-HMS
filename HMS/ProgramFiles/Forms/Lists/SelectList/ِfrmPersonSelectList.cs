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
    public partial class frmPersonSelectList : Form
    {
        int _PersonID = -1;
        public frmPersonSelectList()
        {
            InitializeComponent();
            ctrlPersonList1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }
        public event Action<int> OnPersonSelected;



        private void _ِfrmPersonSelectList_Load(object sender, EventArgs e)
        {

        }

        private void ctrlPersonList1_OnSelectedID(object sender, int e)
        {
            _PersonID = e;
            if (_PersonID != -1)
            {
                OnPersonSelected?.Invoke(e);

                this.Close();
            }
        }

        private void ctrlPersonList1_Load(object sender, EventArgs e)
        {

        }
    }
}
