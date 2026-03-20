using HosbitalBussinessLayer.DerivedTables;
using HosbitalBussinessLayer;
using HosbitalBussinessLayer.Logs.SystemLoginsAndLogs;
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
    public partial class ctrlAddEditLogin : ctrlAddEditBase
    {
        public ctrlAddEditLogin()
        {
            InitializeComponent();
        }
     
        override protected void FillInfo(int ID)
        {
            clsLogins Logins = clsLogins.FindLoginInfoByID(ID);

            if (ID != -1)
            {
                if (Logins != null)
                {

                    setAddEdit("Edit Logins");
                    _Mode = enMode.enUpdate;
                    FillLoginInfo(Logins);
                    //FillInfo

                }
                else
                {
                    setAddEdit("Add New Login");
                    btnSave.Enabled = false;    
                    _Mode = enMode.enAddNew;

                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Login");
                btnSave.Enabled = false;
                _Mode = enMode.enAddNew;


            }






        }
      
        protected void AddNewLogin(clsLogins Login)
        {
          
            //if (Login.Save())
            //{
            //    ID = Login.ID;
            //    FillInfo(ID);

            //}
            //else
            //{
            //    MessageBox.Show(Login.Cause.ToString(), "Error");
            //}
        }
        protected void UpdateLogin(clsLogins Login)
        {
            Login.LoginName = txtLoginName.Text;
            if (!string.IsNullOrWhiteSpace(txtLoginPassword.Text))
            {
                Login.Password = txtLoginPassword.Text;
            }
            Login.PhotoPath = txtPhotoPath.Text;
           
            if (Login.Save())
            {
                FillInfo(Login.ID);

            }
            else
            {
                MessageBox.Show(Login.Cause.ToString(), "Error");
            }
        }

        virtual protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {

            }
            else
            {

                clsLogins login = clsLogins.FindLoginInfoByID(ID);
                UpdateLogin(login);





            }
        }
        protected void FillLoginInfo(clsLogins login)
        {

            txtLoginName.Text = login.LoginName;
            txtPhotoPath.Text = login.PhotoPath;
            if (!string.IsNullOrEmpty(txtPhotoPath.Text))
            {
                pictureBox1.BackgroundImage = Image.FromFile(login.PhotoPath);
            }

        }
        private void btnGetPhotoPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "openFileDialog1")
            {
                txtPhotoPath.Text = openFileDialog1.FileName;


                pictureBox1.BackgroundImage = Image.FromFile(txtPhotoPath.Text);
            }

        }
        private void ctrlAddEditLogin_Load(object sender, EventArgs e)
        {
            FillInfo(ID);

        }
    }
}
