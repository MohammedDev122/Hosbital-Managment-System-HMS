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
using static System.Windows.Forms.AxHost;

namespace HMS.Add_Edit.AddEditPerson.AddEditPatient
{
    public partial class ctrlAddEditPatient : ctrlAddEditPerson
    {
        public ctrlAddEditPatient()
        {
            InitializeComponent();
            _FillStateComboBox();
        }
        void _FillStateComboBox()
        {

            cmbState.Items.Clear();



            cmbState.Items.Add("Alive");

            cmbState.Items.Add("Dead");
            cmbState.Items.Add("Emergency");

            cmbState.SelectedIndex = 0;
        }
        string _GetPatientState(clsPatients.enState state)
        {

            switch (state) { 
            
            case(clsPatients.enState.enAlive):
                    return "Alive";
                case (clsPatients.enState.enDead):
                    return "Dead";
                default:
                    return "Emergency";
            
            
            }
        }
        override protected void FillInfo(int ID)
        {
            clsPatients Patient = clsPatients.FindByID(ID);

            if (ID != -1)
            {
                if (Patient != null)
                {

                    setAddEdit("Edit Patient");
                    _Mode = enMode.enUpdate;
                    FillPersonInfo(Patient.PersonID);
                    lblID.Text=Patient.PatientID.ToString();
                    txtAcessKey.Text=Patient.PatientAccessKey;
                    cmbState.SelectedIndex = cmbState.Items.IndexOf(_GetPatientState(Patient.PatientState));
                    btnInheritedInfo.Visible = false;

                    //FillInfo

                }
                else
                {
                    setAddEdit("Add New Patient");
                    _Mode = enMode.enAddNew;
                    btnInheritedInfo.Visible = true;


                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Patient");
                _Mode = enMode.enAddNew;
                btnInheritedInfo.Visible = true;

                //new Record


            }






        }
        clsPatients.enState GetPatientState(string State)
        {

            switch (State.ToLower())
            {

                case ("alive"):
                    return clsPatients.enState.enAlive;
                case ("dead"):
                    return clsPatients.enState.enDead;
                default:
                    return clsPatients.enState.enEmergency;


            }




        }
        protected void AddNewPatients(clsPatients Patients)
        {
            Patients.FirstName = txtFirstName.Text;
            Patients.LastName = txtLastName.Text;
            Patients.Gender = Convert.ToChar(cmbGender.SelectedItem.ToString());
            Patients.Phone = txtPhone.Text;
            Patients.DateofBirth = dtpDateOfBirth.Value;
            Patients.CountryID = clsCountries.FindCountryByName(cmbCountry.SelectedItem.ToString()).CountryID;
            Patients.Account.AccountNum = txtAccountName.Text;
            if (double.TryParse(Convert.ToString(txtAmmountOfMoney.Text), out double Ammount))
            {
                Patients.Account.AmmountOfMoney = Ammount;
            }
            Patients.Account.Password = txtPassword.Text;
            Patients.PatientAccessKey=txtAcessKey.Text;
            Patients.PatientState=GetPatientState(cmbState.SelectedItem.ToString());
            if (Patients.SavePatient(InheritedID))
            {
                ID = Patients.PatientID;
                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Patients.Cause.ToString(), "Error");
            }
        }
        protected void UpdatePatient(clsPatients Patient)
        {
            Patient.FirstName = txtFirstName.Text;
            Patient.LastName = txtLastName.Text;
            Patient.Gender = Convert.ToChar(cmbGender.SelectedItem.ToString());
            Patient.Phone = txtPhone.Text;
            Patient.DateofBirth = dtpDateOfBirth.Value;
            Patient.CountryID = clsCountries.FindCountryByName(cmbCountry.SelectedItem.ToString()).CountryID;
            Patient.Account.AccountNum = txtAccountName.Text;
            Patient.PatientAccessKey = txtAcessKey.Text;
            Patient.PatientState = GetPatientState(cmbState.SelectedItem.ToString());
            if (!string.IsNullOrWhiteSpace(txtAmmountOfMoney.Text))
            {
                Patient.Account.AmmountOfMoney = Convert.ToDouble(txtAmmountOfMoney.Text);
            }
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                Patient.Account.Password = txtPassword.Text;
            }
            if (Patient.SavePatient())
            {
                FillInfo(Patient.PatientID);

            }
            else
            {
                MessageBox.Show(Patient.Cause.ToString(), "Error");
            }
        }

        override protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsPatients Patient = new clsPatients();

                AddNewPatients(Patient);
            }
            else
            {

                clsPatients Patient = clsPatients.FindByID(ID);
                UpdatePatient(Patient);





            }
        }
        private void ctrlAddEditPatient_Load(object sender, EventArgs e)
        {

        }
        private void btnInheritedInfo_Click(object sender, EventArgs e)
        {
            frmPersonSelectList frmPerson = new frmPersonSelectList();

            frmPerson.OnPersonSelected += FillPersonInfo;
            frmPerson.MdiParent = clsMDIParent.MDIPARENT;
            frmPerson.Dock = DockStyle.Fill;
            try
            {
                frmPerson.Show();
            }
            catch { }

        }
        private void txtPasswordCheck_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
