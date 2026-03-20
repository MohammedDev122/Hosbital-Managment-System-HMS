using HosbitalBussinessLayer;
using HosbitalBussinessLayer.DerivedTables;
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
    public partial class ctrlAddEditSpecilization : ctrlAddEditBase
    {
        public ctrlAddEditSpecilization()
        {
            InitializeComponent();
        }

        protected void FillSpecilizationInfo(int SpecilizationID)
        {
            clsSpecilization Specilization = clsSpecilization.FindSpecilizationByID(SpecilizationID);
            lblID.Text = Convert.ToString(ID);

            txtSpecilizationName.Text = Specilization.SpecilizationName;

        }

        override protected void FillInfo(int ID)
        {
            clsSpecilization Specilization = clsSpecilization.FindSpecilizationByID(ID);

            if (ID != -1)
            {
                if (Specilization != null)
                {

                    setAddEdit("Edit Specilization");
                    _Mode = enMode.enUpdate;
                    FillSpecilizationInfo(Specilization.SpecilizationID);


                }
                else
                {
                    setAddEdit("Add New Specilization");
                    _Mode = enMode.enAddNew;

                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Specilization");
                _Mode = enMode.enAddNew;

                //new Record


            }






        }
        protected void AddNewSpecilization(clsSpecilization Specilization)
        {
            Specilization.SpecilizationName = txtSpecilizationName.Text;

            if (Specilization.Save())
            {
                ID = Specilization.SpecilizationID;
                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Specilization.Cause.ToString(), "Error");
            }
        }


        protected void UpdateSpecilization(clsSpecilization Specilization)
        {
            Specilization.SpecilizationName = txtSpecilizationName.Text;

            if (Specilization.Save())
            {
                ID = Specilization.SpecilizationID;
                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Specilization.Cause.ToString(), "Error");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsSpecilization Specilization = new clsSpecilization();

                AddNewSpecilization(Specilization);
            }
            else
            {

                clsSpecilization Specilization = clsSpecilization.FindSpecilizationByID(ID);
                UpdateSpecilization(Specilization);
                FillInfo(Specilization.SpecilizationID);




            }
        }
        private void ctrlAddEditSpecilization_Load(object sender, EventArgs e)
        {

        }
    }
}
