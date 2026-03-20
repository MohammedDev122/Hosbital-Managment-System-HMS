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
    public partial class ctrlAddEditPharmecyRecord : ctrlAddEditBase
    {
        public ctrlAddEditPharmecyRecord()
        {
            InitializeComponent();
        }
        int _PharmacistID = -1;
        public void SetEmployeeID(int EmployeeID)
        {
            _PharmacistID = clsEmployees.GetEmployeeRoleID(EmployeeID);
        }


        protected void FillPharmecyRecInfo(int RecordID)
        {
            clsPharmacyRecord PharmecyRec = clsPharmacyRecord.GetPharmecyRecordInfoByID(RecordID);
            lblID.Text = Convert.ToString(ID);

            lblPharmacistID.Text = PharmecyRec.PharmacistID.ToString();
            lblPatientID.Text = PharmecyRec.PatientID.ToString();
            txtPrescriptionID.Text = PharmecyRec.PrescriptionID.ToString();
            lblPaymentID.Text = PharmecyRec.PaymentID.ToString();
            lblTotalCost.Text = clsPayments.GetPaymentInfoByID(PharmecyRec.PaymentID).PayedAmmount.ToString();
            if (PharmecyRec.Date != null)
            {
                dtpDate.Value = Convert.ToDateTime(PharmecyRec.Date);
            }


        }

        override protected void FillInfo(int ID)
        {
            clsPharmacyRecord PharmecyRec = clsPharmacyRecord.GetPharmecyRecordInfoByID(ID);

            if (ID != -1)
            {
                if (PharmecyRec != null)
                {

                    setAddEdit("Edit Pharmecy Record");
                    _Mode = enMode.enUpdate;
                    FillPharmecyRecInfo(PharmecyRec.RecordID);
                    txtPrescriptionID.ReadOnly = true;
                    btnGetPrescription.Enabled = false;

                    //FillInfo
                    clsPayments Payment = clsPayments.GetPaymentInfoByID(PharmecyRec.PaymentID);
                    if ((Payment.status == clsPayments.enPaymentStatus.enCancelled) || (Payment.status == clsPayments.enPaymentStatus.enPayed))
                    {
                        txtPrescriptionID.ReadOnly = true;
                        btnGetPrescription.Enabled = false;
                        btnSave.Enabled = false;
                        btnBasket.Enabled = false;


                    }
                    clsPharmacists pharmacist = clsPharmacists.FindByID(_PharmacistID);
                    if (pharmacist != null)
                    {
                        if (pharmacist.EmployeeState != clsPharmacists.enState.enFired)
                        {
                            btnBasket.Enabled = true;

                        }

                    }

                }
                else
                {
                    setAddEdit("Add New Pharmecy Record");
                    _Mode = enMode.enAddNew;
                    clsPharmacists pharmacist = clsPharmacists.FindByID(_PharmacistID);
                    if (pharmacist != null)
                    {
                        if (pharmacist.EmployeeState != clsPharmacists.enState.enFired)
                        {
                            lblPharmacistID.Text = _PharmacistID.ToString();


                        }

                    }
                    btnBasket.Enabled = false;

                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Pharmecy Record");
                _Mode = enMode.enAddNew;
                clsPharmacists pharmacist = clsPharmacists.FindByID(_PharmacistID);
                if (pharmacist != null)
                {
                    if (pharmacist.EmployeeState != clsPharmacists.enState.enFired)
                    {
                        lblPharmacistID.Text = _PharmacistID.ToString();

                    }

                }
                btnBasket.Enabled = false;

                //new Record


            }






        }
        protected void AddNewPharmecyRec(clsPharmacyRecord PharmecyRec)
        {
            if (int.TryParse(Convert.ToString(txtPrescriptionID.Text), out int PrescriptionID))
                PharmecyRec.PrescriptionID = PrescriptionID;

            PharmecyRec.PharmacistID = _PharmacistID;

            if (PharmecyRec.Save())
            {
                ID = PharmecyRec.RecordID;
                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(PharmecyRec.Cause.ToString(), "Error");
            }
        }

        protected void UpdatePharmecyRec(clsPharmacyRecord PharmecyRec)
        {

            if (PharmecyRec.Save())
            {
                FillInfo(PharmecyRec.RecordID);

            }
            else
            {
                MessageBox.Show(PharmecyRec.Cause.ToString(), "Error");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsPharmacyRecord PharmecyRec = new clsPharmacyRecord();

                AddNewPharmecyRec(PharmecyRec);
                FillInfo(PharmecyRec.RecordID);

            }
            else
            {

                clsPharmacyRecord PharmecyRec = clsPharmacyRecord.GetPharmecyRecordInfoByID(ID);
                UpdatePharmecyRec(PharmecyRec);
                FillInfo(PharmecyRec.RecordID);




            }
        }








        private void txttxtPrescriptionID_TextChanged(object sender, EventArgs e)
        {

            if (int.TryParse(Convert.ToString(txtPrescriptionID.Text), out int id))
            {

                clsPrescription Prescription = clsPrescription.FindPrescriptionByID(id);
                if (Prescription != null)
                {
                    if (Prescription.State != clsPrescription.enPrescriptionState.enFullydispensed || Prescription.State != clsPrescription.enPrescriptionState.enCancelled)
                    {
                        clsPatients patient = clsPatients.FindByID(clsMedicalRecords.FindMedicalRecordByID(Prescription.MedicalRecordID).PatientID);
                        lblPatientID.Text = patient.PatientID.ToString();
                        btnSave.Enabled = true;
                    }

                    else
                    {
                        lblPatientID.Text = "............";

                        btnSave.Enabled = false;
                    }
                }

                else
                {
                    lblPatientID.Text = "............";

                    btnSave.Enabled = false;
                }
            }


            else
            {
                lblPatientID.Text = "............";

                btnSave.Enabled = false;
            }

        }


    
        
       
    
        void FillPrescriptionInfo(int PrescriptionID)
        {
            txtPrescriptionID.Text = Convert.ToString(PrescriptionID);
           


        }
      

        

      
        private void ctrlAddEditRecord_Load(object sender, EventArgs e)
        {
            if (_PharmacistID == -1)
            {


                btnSave.Enabled = false;
                btnBasket.Enabled = false;
                btnGetPrescription.Enabled = false;
                txtPrescriptionID.Enabled = false;

            }
            else
            {
                if (clsPharmacists.FindByID(_PharmacistID) == null)
                {
                    btnSave.Enabled = false;
                    btnBasket.Enabled = false;
                    btnGetPrescription.Enabled = false;
                    txtPrescriptionID.Enabled = false;
                }
            }
        }
        void _UpdateCost()
        {
            lblTotalCost.Text = clsPayments.GetPaymentInfoByID(Convert.ToInt32(lblPaymentID.Text)).PayedAmmount.ToString();


        }

        private void btnBasket_Click(object sender, EventArgs e)
        {
            clsPharmacyRecord Rec = clsPharmacyRecord.GetPharmecyRecordInfoByID(ID);
            frmAddItemsToBasket frmBasket = new frmAddItemsToBasket(Rec.Basket.BasketID, Rec.PrescriptionID);
            frmBasket.MdiParent = clsMDIParent.MDIPARENT;
            frmBasket.Dock = DockStyle.Fill;
            try
            {
                frmBasket.Show();
                frmBasket.UpdatePrice = _UpdateCost;
            }
            catch { }
            }

        private void btnGetPrescription_Click(object sender, EventArgs e)
        {
         
                frmPrescriptionSelectList frmPrescriptionList =new  frmPrescriptionSelectList();
            frmPrescriptionList.MdiParent = clsMDIParent.MDIPARENT;
            frmPrescriptionList.Dock = DockStyle.Fill;
            try
            {
                frmPrescriptionList.Show();
                frmPrescriptionList.OnIDSelected = FillPrescriptionInfo;
            }
            catch { }

        }
    }
}
