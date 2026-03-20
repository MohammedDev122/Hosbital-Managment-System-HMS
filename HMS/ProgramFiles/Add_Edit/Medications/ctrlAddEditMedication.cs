using HosbitalBussinessLayer.DerivedTables;
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
    public partial class ctrlAddEditMedication : ctrlAddEditBase
    {
        public ctrlAddEditMedication()
        {
            InitializeComponent();
            clsFillcmb.FillCmbCatorgy(cmbCatorgy);

        }
        protected int PharmacistID = -1;
      
       
        protected void SelectCAtorgy(string CatorgyName)
        {
            cmbCatorgy.SelectedIndex = cmbCatorgy.Items.IndexOf(CatorgyName);

        }
        public void SetPharmacistID(int PharmacistID) { 
        this.PharmacistID = PharmacistID;
        }
     
        protected void FillMedInfo(int MedID)
        {
            clsMedications medication = clsMedications.FindMedicationByID(MedID);
            lblID.Text = Convert.ToString(ID);
            txtMedName.Text = medication.MedicationName;
            txtPrice.Text = Convert.ToString(medication.Price);
            txtNotes.Text = medication.Notes;
            SelectCAtorgy(clsMedicalCatorgies.FindCatorgyByID(medication.CatorgyID).Catorgy);
            txtQuantity.Text = Convert.ToString(medication.Quantity);
         





        }
        override protected void FillInfo(int ID)
        {
            clsMedications Med = clsMedications.FindMedicationByID(ID);

            if (ID != -1)
            {
                if (Med != null)
                {

                    setAddEdit("Edit Medication");
                    _Mode = enMode.enUpdate;
                    FillMedInfo(Med.MedicationID);
                    //FillInfo

                }
                else
                {
                    setAddEdit("Add New Medication");
                    _Mode = enMode.enAddNew;

                }
              

            }
            if (ID == -1)
            {
                setAddEdit("Add New Medication");
                _Mode = enMode.enAddNew;
                //new Record


            }
            if (PharmacistID == -1)
            {
                btnSave.Enabled = false;
            }





        }
      
        protected void AddNewMed(clsMedications Med)
        {
            Med.MedicationName = txtMedName.Text;
            Med.Notes = txtNotes.Text;
            Med.CatorgyID = clsMedicalCatorgies.FindCatorgyByName(cmbCatorgy.SelectedItem.ToString()).CatorgyID;
            if(int.TryParse(Convert.ToString(txtQuantity.Text), out int quantity))
            {
                Med.Quantity = quantity;
            }
            if (double.TryParse(Convert.ToString(txtPrice.Text), out double Price))
            {
                Med.Price = Price;
            }
          
            if (Med.Save())
            {
                ID = Med.MedicationID;
                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Med.FailCause.ToString(), "Error");
            }
        }
        protected void UpdateMed(clsMedications Med)
        {
            Med.MedicationName = txtMedName.Text;
            Med.Notes = txtNotes.Text;
            Med.CatorgyID = clsMedicalCatorgies.FindCatorgyByName(cmbCatorgy.SelectedItem.ToString()).CatorgyID;
            if (int.TryParse(Convert.ToString(txtQuantity.Text), out int quantity))
            {
                Med.Quantity = quantity;
            }
            if (double.TryParse(Convert.ToString(txtPrice.Text), out double Price))
            {
                Med.Price = Price;
            }

            if (Med.Save())
            {
                ID = Med.MedicationID;
                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Med.FailCause.ToString(), "Error");
            }
        }

         protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsMedications Med = new clsMedications();

                AddNewMed(Med);
            }
            else
            {

                clsMedications Med = clsMedications.FindMedicationByID(ID);
                UpdateMed(Med);





            }
        }

      

        private void ctrlAddEditMedication_Load(object sender, EventArgs e)
        {
            FillInfo(ID);

        }
    }
}
