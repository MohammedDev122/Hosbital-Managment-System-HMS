using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Buttons
{
    public partial class ctrlButtonBase : UserControl
    {
        public Control Panel { get; set; }
        public ctrlButtonBase()
        {
            InitializeComponent();
        }
   protected     int _SignedMemberID = LoggedEmployee.LoggedEmployeeID;
       protected int _Permission = 0;

       

        



       protected bool CloseAllOthers()
        {
            if (clsMDIParent.MDIPARENT != null)
            {
                foreach (Form frm in clsMDIParent.MDIPARENT.MdiChildren)
                {

                    frm.Close();

                }
                return true;
            }
            return false;
        }
        public void RunWhenProgramInitiated()
        {
            button1_Click(this, EventArgs.Empty);
        }
        virtual protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {

            }
        }
    }
}
