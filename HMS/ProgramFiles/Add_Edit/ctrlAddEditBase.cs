using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Add_Edit
{
    public partial class ctrlAddEditBase : UserControl
    {
        protected int ID = -1;
        protected enum enMode { enUpdate,enAddNew}
        protected enMode _Mode;
        public ctrlAddEditBase()
        {
            InitializeComponent();
        }
        public void SetID(int ID)
        {
            this.ID = ID;
        }
        virtual protected void setAddEdit(string AddEdit)
        {
            lblAddEdit.Text = AddEdit;  
        }
      virtual  protected void FillInfo(int ID)
        {
            if (ID != -1)
            {
                setAddEdit("Edit");
                lblID.Text=Convert.ToString(ID);
                _Mode = enMode.enUpdate;
                //FillInfo
            }
            if (ID == -1)
            {
                setAddEdit("Add");
                _Mode = enMode.enAddNew;
                //new Record


            }






        }

        private void AddEditBase_Load(object sender, EventArgs e)
        {
            FillInfo(ID);
        }
      public   Action CloseForm;
        protected void button1_Click(object sender, EventArgs e)
        {
CloseForm?.Invoke();
                }
    }
}
