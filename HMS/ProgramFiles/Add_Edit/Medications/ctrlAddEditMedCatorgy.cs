using HMS.Lists.Others.Employee;
using HosbitalBussinessLayer.Logs;
using HosbitalBussinessLayer.Procedures;
using HosbitalBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HosbitalBussinessLayer.DerivedTables;

namespace HMS.Add_Edit.Medications
{
    public partial class ctrlAddEditMedCatorgy : ctrlAddEditBase
    {
        public ctrlAddEditMedCatorgy()
        {
            InitializeComponent();
        }
    

        protected void FillCatorgyInfo(int CatorgyID)
        {
            clsMedicalCatorgies Catorgy = clsMedicalCatorgies.FindCatorgyByID(CatorgyID);
            lblID.Text = Convert.ToString(ID);

            txtCatorgy.Text = Catorgy.Catorgy;
            lblNumOfMedication.Text = Catorgy.NumOfMedication.ToString();
           
        }

        override protected void FillInfo(int ID)
        {
            clsMedicalCatorgies Catorgy = clsMedicalCatorgies.FindCatorgyByID(ID);

            if (ID != -1)
            {
                if (Catorgy != null)
                {

                    setAddEdit("Edit Catorgy");
                    _Mode = enMode.enUpdate;
                    FillCatorgyInfo(Catorgy.CatorgyID);
                  

                }
                else
                {
                    setAddEdit("Add New Catorgy");
                    _Mode = enMode.enAddNew;

                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Catorgy");
                _Mode = enMode.enAddNew;

                //new Record


            }






        }
        protected void AddNewCatorgy(clsMedicalCatorgies Catorgy)
        {
            Catorgy.Catorgy =txtCatorgy.Text;
          
            if (Catorgy.Save())
            {
                ID = Catorgy.CatorgyID;
                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Catorgy.FailCause.ToString(), "Error");
            }
        }

       
        protected void UpdateCatorgy(clsMedicalCatorgies Catorgy)
        {
            Catorgy.Catorgy = txtCatorgy.Text;

            if (Catorgy.Save())
            {
                ID = Catorgy.CatorgyID;
                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Catorgy.FailCause.ToString(), "Error");
            }
        }

         protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsMedicalCatorgies Catorgy = new clsMedicalCatorgies();

                AddNewCatorgy(Catorgy);
            }
            else
            {

                clsMedicalCatorgies Catorgy = clsMedicalCatorgies.FindCatorgyByID(ID);
                UpdateCatorgy(Catorgy);
                FillInfo(Catorgy.CatorgyID);




            }
        }

        private void ctrlAddEditMedCatorgy_Load(object sender, EventArgs e)
        {

        }
    }
}
