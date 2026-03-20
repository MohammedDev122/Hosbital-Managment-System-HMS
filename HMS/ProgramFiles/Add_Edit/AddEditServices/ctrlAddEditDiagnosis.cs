using HosbitalBussinessLayer;
using HosbitalBussinessLayer.Procedures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Add_Edit.AddEditServices
{
    public partial class ctrlAddEditDiagnosis : ctrlAddEditService
    {
        int SignedDoctorID = -1;
        int SignedDepartment = -1;
        public ctrlAddEditDiagnosis()
        {
            InitializeComponent();
            clsFillcmb.FillSpecilizationCMB(cmbSpecilization);

        }
        public void SetSignedDoctor(int SignedDoctorID)
        {
            this.SignedDoctorID = SignedDoctorID;

        }
        public void SetSignedDepartment(int SignedDepartment)
        {
            this.SignedDepartment = SignedDepartment;

        }
        protected void FillDiagnosisInfo(int DiagnosisID)
        {
            clsDiagnosis Diagnosis = clsDiagnosis.GetDiagnosisInfoByID(DiagnosisID);
            lblID.Text = Convert.ToString(ID);

            if (Diagnosis.MedicalRecord != null)
            {

                lblMedicalRecordID.Text = Diagnosis.MedicalRecord.RecordID.ToString();
                txtDiagnosticNotes.Text = Diagnosis.MedicalRecord.DiagnosticNotes;


            }
            else {

                lblMedicalRecordID.Text = ".......";
                txtDiagnosticNotes.Text = "";
            }
            clsDoctors Doctor=clsDoctors.FindByID(Diagnosis.DoctorID);
            txtDoctorID.Text=Doctor.DoctorID.ToString();
            lblDoctorPhone.Text=Doctor.Phone;
            lblDoctorName.Text=Doctor.FirstName+" "+Doctor.LastName;
            cmbSpecilization.SelectedIndex=cmbSpecilization.Items.IndexOf(clsSpecilization.FindSpecilizationByID(Diagnosis.SpecilizationID).SpecilizationName);



        }

        override protected void FillInfo(int ID)
        {
            clsDiagnosis Diagnosis = clsDiagnosis.GetDiagnosisInfoByID(ID);

            if (ID != -1)
            {
                if (Diagnosis != null)
                {

                    setAddEdit("Edit Diagnosis");
                    _Mode = enMode.enUpdate;
                    FillServiceInfo(Diagnosis.ServiceID);
                    FillDiagnosisInfo(Diagnosis.DiagnosisID);
                    txtPatientID.ReadOnly = true;
                    btnSelectPatient.Visible = false;
                    txtDoctorID.ReadOnly = true;
                    btnSelectDoctor.Visible = false;
                    //FillInfo

                }
                else
                {
                    setAddEdit("Add New Diagnosis");
                    _Mode = enMode.enAddNew;

                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Diagnosis");
                _Mode = enMode.enAddNew;
                //new Record


            }






        }
        protected void AddNewDiagnosis(clsDiagnosis Diagnosis)
        {
            Diagnosis.ServiceStartDateTime = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day,
                dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, dtpStartTime.Value.Second);
            Diagnosis.State = GetServiceState(cmbServiceState.SelectedItem.ToString());
            if(int.TryParse(Convert.ToString(txtPatientID.Text),out int PatientID))
            Diagnosis.PatientID =PatientID;
            if (int.TryParse(Convert.ToString(txtDoctorID.Text), out int DoctorID))
                Diagnosis.DoctorID = DoctorID;
Diagnosis.SpecilizationID=clsSpecilization.FindSpecilizationByName(cmbSpecilization.SelectedItem.ToString()).SpecilizationID;
            if (Diagnosis.SaveDiagnnosis())
            {
                ID = Diagnosis.DiagnosisID;
                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Diagnosis.Cause.ToString(), "Error");
            }
        }
        protected void UpdateDiagnosis(clsDiagnosis Diagnosis)
        {
            Diagnosis.ServiceStartDateTime = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day,
                  dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, dtpStartTime.Value.Second);
            Diagnosis.State = GetServiceState(cmbServiceState.SelectedItem.ToString());
            if(!string.IsNullOrEmpty(txtDiagnosticNotes.Text))
            {
                Diagnosis.MedicalRecord.DiagnosticNotes = txtDiagnosticNotes.Text;


            }
            Diagnosis.SpecilizationID=clsSpecilization.FindSpecilizationByName(cmbSpecilization.SelectedItem.ToString()).SpecilizationID;

            if (Diagnosis.SaveDiagnnosis())
            {
                FillInfo(Diagnosis.DiagnosisID);

            }
            else
            {
                MessageBox.Show(Diagnosis.Cause.ToString(), "Error");
            }
        }

       override protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsDiagnosis Diagnosis = new clsDiagnosis();

                AddNewDiagnosis(Diagnosis);
            }
            else
            {

                clsDiagnosis Diagnosis = clsDiagnosis.GetDiagnosisInfoByID(ID);
                UpdateDiagnosis(Diagnosis);
                FillInfo(Diagnosis.DiagnosisID);




            }
        }


        private void txtDoctorIDTextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(txtDoctorID.Text), out int DoctorID))
            {
                clsDoctors Doctor = clsDoctors.FindByID(DoctorID);
                if (Doctor != null)
                {
                    lblDoctorName.Text = Doctor.FirstName + "  " + Doctor.LastName;
                    lblDoctorPhone.Text = Doctor.Phone;

                }
                else
                {
                    lblDoctorName.Text = ".....";
                    lblDoctorPhone.Text = ".....";
                }

            }
            else
            {
                lblDoctorName.Text = ".....";
                lblDoctorPhone.Text = ".....";
            }
        }
        private void ctrlAddEditDiagnosis_Load(object sender, EventArgs e)
        {

        }
        void fillDoctorIDTxt(int ID)
        {
            txtDoctorID.Text = ID.ToString();

        }
        private void btnSelectDoctor_Click(object sender, EventArgs e)
        {
            frmDoctorSelectList frmDoctorList = new frmDoctorSelectList();
            frmDoctorList.OnIDSelected = fillDoctorIDTxt;
            frmDoctorList.MdiParent = clsMDIParent.MDIPARENT;
            frmDoctorList.Dock = DockStyle.Fill;
            try
            {
                frmDoctorList.Show();
            }
            catch { }
            }

        private void cmbServiceState_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbServiceState.SelectedIndex == 1&&_Mode==enMode.enUpdate)
            {
                if (clsDiagnosis.GetDiagnosisInfoByID(ID).State != clsDiagnosis.enState.enFinished)
                {
                    if (SignedDepartment == 9)
                    {
                        if (SignedDoctorID == Convert.ToInt32(txtDoctorID.Text))
                        {

                        }
                        else
                        {
                            btnSave.Enabled = false;
                            MessageBox.Show("You Are Not The Doctor!", "Error");
                        }
                    }
                    else
                    {
                        btnSave.Enabled = false;
                        MessageBox.Show("You Are Not The Doctor!", "Error");
                    }
                }
            }
            else
            {
                btnSave.Enabled = true;
            }
        }

        private void btnSelectPatient_Click(object sender, EventArgs e)
        {

        }
    }
}
