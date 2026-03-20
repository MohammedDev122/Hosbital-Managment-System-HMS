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
    public partial class ctrlAddEditPrescripedMed : ctrlAddEditBase
    {
        public ctrlAddEditPrescripedMed()
        {
            InitializeComponent();
        }
        int _PrescriptionID = -1;
        int _MedicationID = -1;

        public void SetPrescriptionID(int PrescriptionID)
        {
            _PrescriptionID=PrescriptionID;
        }
        public void SetMedicationID(int MedicationID)
        {
            _MedicationID = MedicationID;
        }



        string GetState(clsPrescripedMed.enState State)
        {
            switch (State)
            {
                case (clsPrescripedMed.enState.enDispensed):
                    return "Dispensed";
                default:
                    return "Still";
              





            }
        }
        protected void FillPrescripedMedInfo(int PrescripMedID)
        {
            clsPrescripedMed PrescripedMed = clsPrescripedMed.FindPrescripedMedicationByID(PrescripMedID);
            lblID.Text = Convert.ToString(ID);

            lblPrescriptionID.Text = PrescripedMed.PrescriptionID.ToString();
            lblMedID.Text = PrescripedMed.MedicationID.ToString();
            lblState.Text = GetState(PrescripedMed.State);
            lblMedName.Text = clsMedications.FindMedicationByID(PrescripedMed.MedicationID).MedicationName;
            txtDossage.Text=PrescripedMed.Dosage.ToString();
            dtpStartDate.Value=PrescripedMed.StartDate;
            dtpEndDate.Value=PrescripedMed.EndDate;
            txtInstructions.Text = PrescripedMed.Instructions;
        }

        override protected void FillInfo(int ID)
        {
            clsPrescripedMed PrescripedMed = clsPrescripedMed.FindPrescripedMedicationByID(ID);

            if (ID != -1)
            {
                if (PrescripedMed != null)
                {

                    setAddEdit("Edit Prescriped Medication");
                    _Mode = enMode.enUpdate;
                    FillPrescripedMedInfo(PrescripedMed.PrescripedMedID);
                  
                    //FillInfo
                    if (PrescripedMed.State == clsPrescripedMed.enState.enDispensed)
                    {
                        btnSave.Enabled = false;
                     


                    }

                }
                else
                {
                    setAddEdit("Add New Prescriped Medication");
                    _Mode = enMode.enAddNew;

                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Prescriped Medication");
                _Mode = enMode.enAddNew;

                //new Record


            }






        }
        protected void AddNewPrescripedMed(clsPrescripedMed PrescripedMed)
        {
            PrescripedMed.StartDate = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day);
            PrescripedMed.EndDate = new DateTime(dtpEndDate.Value.Year, dtpEndDate.Value.Month, dtpEndDate.Value.Day);

            if (double.TryParse(Convert.ToString(txtDossage.Text), out double Dossage))
                PrescripedMed.Dosage = Dossage;
            if (!string.IsNullOrWhiteSpace(txtInstructions.Text))
            {
                PrescripedMed.Instructions = txtInstructions.Text;
            }
            PrescripedMed.PrescriptionID = _PrescriptionID;
            PrescripedMed.MedicationID = _MedicationID;
          
            if (PrescripedMed.Save())
            {
                ID = PrescripedMed.PrescripedMedID;
                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(PrescripedMed.FailCause.ToString(), "Error");
            }
        }

        protected void UpdatePrescripedMedication(clsPrescripedMed PrescripedMed)
        {
            PrescripedMed.StartDate = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day);
            PrescripedMed.EndDate = new DateTime(dtpEndDate.Value.Year, dtpEndDate.Value.Month, dtpEndDate.Value.Day);

            if (double.TryParse(Convert.ToString(txtDossage.Text), out double Dossage))
                PrescripedMed.Dosage = Dossage;
            if (!string.IsNullOrWhiteSpace(txtInstructions.Text))
            {
                PrescripedMed.Instructions = txtInstructions.Text;
            }

            if (PrescripedMed.Save())
            {
                FillInfo(PrescripedMed.PrescripedMedID);

            }
            else
            {
                MessageBox.Show(PrescripedMed.FailCause.ToString(), "Error");
            }
        }

         protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsPrescripedMed PrescripedMed = new clsPrescripedMed();

                AddNewPrescripedMed(PrescripedMed);
            }
            else
            {

                clsPrescripedMed PrescripedMed = clsPrescripedMed.FindPrescripedMedicationByID(ID);
                UpdatePrescripedMedication(PrescripedMed);
                FillInfo(PrescripedMed.PrescripedMedID);




            }
        }


     
       

   
       
 
    
        private void ctrlAddEditPrescripedMed_Load(object sender, EventArgs e)
        {
            if (ID == -1)
            {
                if (_PrescriptionID == -1)
                {
                    btnSave.Enabled = false;
                }
                else
                {
                    lblPrescriptionID.Text = _PrescriptionID.ToString();
                }
                if (_MedicationID == -1)
                {
                    btnSave.Enabled = false;
                }
                else
                {
                    lblMedID.Text = _MedicationID.ToString();
                    lblMedName.Text = clsMedications.FindMedicationByID(_MedicationID).MedicationName;

                }
            }
            else
            {
                clsPrescripedMed prescripedMed = clsPrescripedMed.FindPrescripedMedicationByID(ID);
                lblMedID.Text = prescripedMed.MedicationID.ToString();
                lblMedName.Text = clsMedications.FindMedicationByID(prescripedMed.MedicationID).MedicationName;
                lblPrescriptionID.Text = prescripedMed.PrescripedMedID.ToString();

            }
        }
    }
}
