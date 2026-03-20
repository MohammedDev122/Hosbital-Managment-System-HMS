using HosbitalBussinessLayer.DerivedTables;
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
using HosbitalBussinessLayer.Logs;

namespace HMS.ViewInfo.ViewServicesInfo.ViewDiagnosisInfo
{
    public partial class ctrlDiagnosisInfocs : ctrlServiceInfo
    {
        public ctrlDiagnosisInfocs()
        {
            InitializeComponent();
        }
        protected void EmptyDiagnosisRec()
        {
            EmptyServiceRec();
            lblDiagnosisID.Text = "_";
            lblMedicalRecordID.Text = "_";
            lblDiagnosisNotes.Text = "_";

            lblDoctorID.Text = "_";

            lblSpecilization.Text = "_";
            lblDoctorName.Text = "_";



        }

        protected void FillDiagnosisRec(clsDiagnosis Diagnosis)
        {
            clsServices service = clsServices.GetServiceInfoByID(Diagnosis.ServiceID);
            FillServiceRec(service);
            lblDiagnosisID.Text = Convert.ToString(Diagnosis.DiagnosisID);
            if (Diagnosis.MedicalRecord.RecordID != -1) {

                clsMedicalRecords Rec=clsMedicalRecords.FindMedicalRecordByID(Diagnosis.MedicalRecord.RecordID);
                lblMedicalRecordID.Text = Convert.ToString(Rec.RecordID);
                lblDiagnosisNotes.Text = Rec.DiagnosticNotes;



            }
            else
            {
                lblMedicalRecordID.Text ="_";
                lblDiagnosisNotes.Text = "_";
            }
            lblDoctorID.Text = Convert.ToString(Diagnosis.DoctorID);
            clsDoctors Doc=clsDoctors.FindByID(Diagnosis.DoctorID);
            lblDoctorName.Text = Doc.FirstName+" "+Doc.LastName;

            lblSpecilization.Text = clsSpecilization.FindSpecilizationByID(Diagnosis.SpecilizationID).SpecilizationName;



        }
        override protected void btnSearch_Click(object sender, EventArgs e)
        {
            int DiagnosisID= -1;
            if (int.TryParse(Convert.ToString(txtSearch.Text), out int ID))
            {
                DiagnosisID = ID;
                clsDiagnosis Operation = clsDiagnosis.GetDiagnosisInfoByID(DiagnosisID);
                if (Operation != null)
                {
                    FillDiagnosisRec(Operation);
                }
                else
                {
                    EmptyDiagnosisRec();
                }
            }

        }
        private void ctrlDiagnosisInfocs_Load(object sender, EventArgs e)
        {

        }
    }
}
