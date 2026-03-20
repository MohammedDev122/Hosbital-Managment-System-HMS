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
using HosbitalBussinessLayer.Medications;

namespace HMS.Add_Edit.Medications
{
    public partial class ctrlAddEditPrescriptions : ctrlAddEditBase
    {
        public ctrlAddEditPrescriptions()
        {
            InitializeComponent();
            clsFillcmb.FillCmbPrescriptionState(cmbPrescriptionState);

        }

        int SignedDoctorID = -1;
        public void SetDoctorID(int DoctorID)
        {
            SignedDoctorID=DoctorID;
        }


        string GetState(clsPrescription.enPrescriptionState state)
        {
            switch (state)
            {
                case (clsPrescription.enPrescriptionState.enFullydispensed):
                    return "Fullydispensed";
                case (clsPrescription.enPrescriptionState.enPartiallydispensed):
                    return "Partiallydispensed";
                case (clsPrescription.enPrescriptionState.enCancelled):
                    return "Cancelled";
                default:
                    return "Still";






            }
        }
        protected void FillprescriptionInfo(int PrescriptionID)
        {
            clsPrescription Prescription = clsPrescription.FindPrescriptionByID(PrescriptionID);
            lblID.Text = Convert.ToString(ID);
            clsPatients Patient=clsPatients.FindByID(clsMedicalRecords.FindMedicalRecordByID(Prescription.MedicalRecordID).PatientID);
            lblPatientName.Text = Patient.FirstName+" "+Patient.LastName;
            lblPatientID.Text=Patient.PatientID.ToString();
            txtMedicalRecordID.Text = Prescription.MedicalRecordID.ToString();
            cmbPrescriptionState.SelectedIndex = cmbPrescriptionState.Items.IndexOf(GetState(Prescription.State));




        }

        override protected void FillInfo(int ID)
        {
            clsPrescription Prescription = clsPrescription.FindPrescriptionByID(ID);

            if (ID != -1)
            {
                if (Prescription != null)
                {

                    setAddEdit("Edit Prescription");
                    _Mode = enMode.enUpdate;
                    FillprescriptionInfo(Prescription.PrescriptionID);
                    clsMedicalRecords MedRec=clsMedicalRecords.FindMedicalRecordByID(Prescription.MedicalRecordID);
                  btnGetMedicalRecord.Enabled = false;
                    txtMedicalRecordID.Enabled = false;
                    //FillInfo
                    if (Prescription.State == clsPrescription.enPrescriptionState.enCancelled|| Prescription.State == clsPrescription.enPrescriptionState.enFullydispensed||MedRec.State==clsMedicalRecords.enState.enCancelled)
                    {
                        btnPrescripedMed.Enabled = false;
                        btnSave.Enabled = false;

                       


                    }

                }
                else
                {
                    setAddEdit("Add New Prescription");
                    _Mode = enMode.enAddNew;
                    btnPrescripedMed.Enabled = true;
                    btnSave.Enabled = true;

                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Prescription");
                _Mode = enMode.enAddNew;

                //new Record


            }






        }
        protected void AddNewPrescription(clsPrescription Prescription)
        {
            if (int.TryParse(Convert.ToString(txtMedicalRecordID.Text), out int recID)) {
                Prescription.MedicalRecordID = recID;
                }

            Prescription.State = GetPrescriptionStateString(cmbPrescriptionState.SelectedItem.ToString());
          
       
           
            if (Prescription.Save())
            {
                ID = Prescription.PrescriptionID;
                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Prescription.FailCause.ToString(), "Error");
            }
        }

        clsPrescription.enPrescriptionState GetPrescriptionStateString(string PrescriptionState)
        {

            switch (PrescriptionState)
            {

                case ("Partiallydispensed"):

                    return clsPrescription.enPrescriptionState.enPartiallydispensed;
                case ("Fullydispensed"):

                    return clsPrescription.enPrescriptionState.enFullydispensed;
                case ("Cancelled"):

                    return clsPrescription.enPrescriptionState.enCancelled;

                default:
                    return clsPrescription.enPrescriptionState.enStill;

            }
        }
        protected void UpdatePrescription(clsPrescription Prescription)
        {
            if (int.TryParse(Convert.ToString(txtMedicalRecordID.Text), out int recID))
            {
                Prescription.MedicalRecordID = recID;
            }

            Prescription.State = GetPrescriptionStateString(cmbPrescriptionState.SelectedItem.ToString());
            if (Prescription.Save())
            {
                FillInfo(Prescription.PrescriptionID);

            }
            else
            {
                MessageBox.Show(Prescription.FailCause.ToString(), "Error");
            }
        }

         protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsPrescription Prescription = new clsPrescription();

                AddNewPrescription(Prescription);
            }
            else
            {

                clsPrescription Prescription = clsPrescription.FindPrescriptionByID(ID);
                UpdatePrescription(Prescription);
                FillInfo(Prescription.PrescriptionID);




            }
        }


      
      

      
     
        bool CheckIfRecordisDoneByDoctor(int RecordID, int DoctorID)
        {
            DataTable dt = clsMedicalRecords.GetAllRecords(clsViews.enShowing.enInfoEmployeeOwner, DoctorID);
            foreach (DataRow dr in dt.Rows)
            {

                if (RecordID == Convert.ToInt32(dr["RecordID"]))
                {

                    return true;
                }


            }
            return false;
        }
        private void txtMedicalRecordID_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(Convert.ToString(lblID.Text), out int OperationID))
            {
                if (int.TryParse(Convert.ToString(txtMedicalRecordID.Text), out int id))
                {

                    clsMedicalRecords record = clsMedicalRecords.FindMedicalRecordByID(id);
                    if (record != null)
                    {
                        clsDoctors Doctor = clsDoctors.FindByID(SignedDoctorID);
                        if (Doctor != null)
                        {
                           
                                if (CheckIfRecordisDoneByDoctor(record.RecordID,SignedDoctorID))
                                {
                                    lblPatientID.Text = record.PatientID.ToString();
                                    clsPatients patient = clsPatients.FindByID(record.PatientID);
                                    lblPatientName.Text = patient.FirstName + " " + patient.LastName;
                                    btnSave.Enabled = true;
                                }
                                else
                                {
                                    lblPatientID.Text = "............";
                                    lblPatientName.Text = "..............";
                                    btnSave.Enabled = false;
                                }
                            
                           
                        }
                        else
                        {
                            lblPatientID.Text = "............";
                            lblPatientName.Text = "..............";
                            btnSave.Enabled = false;
                        }


                        }
                    else
                    {
                        lblPatientID.Text = "............";
                        lblPatientName.Text = "..............";
                        btnSave.Enabled = false;
                    }

                }
                else
                {
                    lblPatientID.Text = "............";
                    lblPatientName.Text = "..............";
                    btnSave.Enabled = false;
                }
            }
            else
            {

                clsMedicalRecords record = clsMedicalRecords.FindMedicalRecordByID(Convert.ToInt32(txtMedicalRecordID.Text));

                lblPatientID.Text = record.PatientID.ToString();
                clsPatients patient = clsPatients.FindByID(record.PatientID);
                lblPatientName.Text = patient.FirstName + " " + patient.LastName;
                btnSave.Enabled = true;
            }
        }
     
      
        void FillRecordAndPatientInfo(ctrlMedicalRecordSelectListForDoctor.info Info)
        {
            txtMedicalRecordID.Text = Convert.ToString(Info.RecordID);
            clsPatients Patient = clsPatients.FindByID(Info.PatientID);
            lblPatientID.Text = Convert.ToString(Patient.PatientID);
            lblPatientName.Text = Patient.FirstName + " " + Patient.LastName;


        }
        private void btnGetMedicalRecord_Click(object sender, EventArgs e)
        {

            frmMedicalRecordSelectListForDoc frmMedRecListForDoc = new frmMedicalRecordSelectListForDoc(SignedDoctorID);
            frmMedRecListForDoc.Selected = FillRecordAndPatientInfo;
            frmMedRecListForDoc.MdiParent = clsMDIParent.MDIPARENT;
            frmMedRecListForDoc.Dock = DockStyle.Fill;
            try
            {
                frmMedRecListForDoc.Show();
            }
            catch { }
            }



       
        private void AddEditPrescriptions_Load(object sender, EventArgs e)
        {
            if (SignedDoctorID == -1)
            {


                btnSave.Enabled = false;
                btnGetMedicalRecord.Enabled = false;
                txtMedicalRecordID.Enabled = false;

            }
            else
            {
                if (clsDoctors.FindByID(SignedDoctorID) == null)
                {
                    btnSave.Enabled = false;
                    btnGetMedicalRecord.Enabled = false;
                    txtMedicalRecordID.Enabled = false;
                }
            }
        }

        private void btnPrescripedMed_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(lblID.Text), out int id)) {
                frmAddPrescripedMed frm = new frmAddPrescripedMed(ID);
                frm.MdiParent = clsMDIParent.MDIPARENT;
                frm.Dock = DockStyle.Fill;
                try {
                    frm.Show();
                }catch { }
                }
        }
    }
}
