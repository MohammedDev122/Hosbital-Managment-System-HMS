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

namespace HMS
{
    public partial class ctrlPatientInfo : ctrlPersonInfo
    {
        public ctrlPatientInfo()
        {
            InitializeComponent();
        }
        int PatientID = -1;
        string _GetPatientState(clsPatients.enState state)
        {
            if (state == clsPatients.enState.enDead)
            {
                return "Dead";
            }
            else if (state == clsPatients.enState.enAlive)
            {
                return "Alive";
            }
            else
            {
                return "Emergrncy";
            }
        }
        protected void FillPatientInfo(clsPatients patient)
        {

            FillPersonInfo(clsPerson.FindByID(patient.PersonID));
            lblPatientID.Text = Convert.ToString(patient.PatientID);
            lblPatientState.Text = _GetPatientState(patient.PatientState);

        }
        protected void EmptyAllPatientRec()
        {
            EmptyAllPersonRec();

            lblPatientID.Text = "_";
            lblPatientState.Text = "_";
        }
        override protected void lblSearch_Click(object sender, EventArgs e)
        {

            if (int.TryParse(Convert.ToString(txtSearch.Text), out int ID))
            {
                PatientID = ID;
                clsPatients Patient = clsPatients.FindByID(PatientID);
                if (Patient != null)
                {


                    FillPatientInfo(Patient);



                }
                else
                {
                    EmptyAllPatientRec();
                }
            }
        }
            private void ctrlPatientInfo_Load(object sender, EventArgs e)
            {

            }

      
    }
    } 
