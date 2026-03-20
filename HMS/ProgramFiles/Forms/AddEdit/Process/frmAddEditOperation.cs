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
    public partial class frmAddEditOperation : Form
    {
        public Action ReloadCallingDGV;
        public frmAddEditOperation(int OperationID,int MemberID)
        {
            InitializeComponent();
            ctrlAddEditOperation1.SetID(OperationID);
            ctrlAddEditOperation1.SetSignedMember(MemberID);
            ctrlAddEditOperation1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            ReloadCallingDGV?.Invoke();
            this.Close();
        }
        private void frmAddEditOperation_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddEditOperation1_Load(object sender, EventArgs e)
        {

        }
    }
}
