using HosbitalBussinessLayer;
using HosbitalBussinessLayer.DerivedTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS
{
    public static class clsFillcmb
    {

     
      public static  void FillCountryComboBox(ComboBox cmbCountry)
        {

            cmbCountry.Items.Clear();
            DataTable dt = clsCountries.GetAllCountries();
            foreach (DataRow dr in dt.Rows)
            {

                cmbCountry.Items.Add(dr["CountryName"]);

            }
            cmbCountry.SelectedIndex = 0;
        }

       static public void FillDebpartmentCMB(ComboBox cmbDepartment)
        {

            cmbDepartment.Items.Clear();
            DataTable dt = clsDeparmtments.GetAllDepartments();
            foreach (DataRow dr in dt.Rows)
            {
                cmbDepartment.Items.Add(dr["DepartmentName"]);


            }
            cmbDepartment.SelectedIndex = 0;
        }
        static public void FillEmployeeStateCMB(ComboBox cmbState)
        {

            cmbState.Items.Clear();
            cmbState.Items.Add("Working");
            cmbState.Items.Add("Fired");

            cmbState.SelectedIndex = 0;
        }
        static public void FillCmbPaymentMethod(ComboBox cmbPaymentMethod)
        {

            cmbPaymentMethod.Items.Clear();
            cmbPaymentMethod.Items.Insert(0, "Visa");
            cmbPaymentMethod.Items.Insert(0, "Cash");

            cmbPaymentMethod.SelectedIndex = 0;

        }
        static public void FillCmbPaymentState(ComboBox cmbPayment)
        {

            cmbPayment.Items.Clear();
            cmbPayment.Items.Add("Payed");
            cmbPayment.Items.Add("Cancelled");
            cmbPayment.Items.Add("bending");

            cmbPayment.SelectedIndex = 0;

        }

        static public void FillSpecilizationCMB(ComboBox cmbSpecilization)
        {

            cmbSpecilization.Items.Clear();
            DataTable dt = clsSpecilization.GetAllSpecilizations();
            foreach (DataRow dr in dt.Rows)
            {
                cmbSpecilization.Items.Add(dr["Specilization"]);



            }

            cmbSpecilization.SelectedIndex = 0;
        }

        static public void FillPatientStateComboBox(ComboBox cmbState)
        {

            cmbState.Items.Clear();



            cmbState.Items.Add("Alive");

            cmbState.Items.Add("Dead");
            cmbState.Items.Add("Emergency");

            cmbState.SelectedIndex = 0;
        }
        static public void FillLanguageComboBox(ComboBox cmbLang)
        {

            cmbLang.Items.Clear();



            cmbLang.Items.Add("Russian");

            cmbLang.Items.Add("English");
            cmbLang.Items.Add("Arabic");

            cmbLang.SelectedIndex = 0;
        }
        static public void FillThemesComboBox(ComboBox cmbThemes)
        {

            cmbThemes.Items.Clear();



            cmbThemes.Items.Add("Gray & White");

            cmbThemes.Items.Add("Black & White");
            cmbThemes.Items.Add("Blue & White");

            cmbThemes.SelectedIndex = 0;
        }


        static public void FillcmbcmbServiceState(ComboBox cmbServiceState)
        {

            cmbServiceState.Items.Clear();



            cmbServiceState.Items.Add("Cancelled");
            cmbServiceState.Items.Add("Finished");
            cmbServiceState.Items.Add("Bending");

            cmbServiceState.SelectedIndex = 0;
        }
        static public void FillCmbMRStateList(ComboBox cmbState)
        {

            cmbState.Items.Clear();
            cmbState.Items.Insert(0, "Cancelled");
            cmbState.Items.Insert(0, "Working");
            cmbState.Items.Insert(0, "All");
            cmbState.SelectedIndex = 0;

        }
        static public void FillCmbTypeList(ComboBox cmbType)
        {

            cmbType.Items.Clear();
            cmbType.Items.Insert(0, "Operation");
            cmbType.Items.Insert(0, "Diagnosis");
            cmbType.Items.Insert(0, "All");
            cmbType.SelectedIndex = 0;

        }
        static public void FillCmbDepartmentList(ComboBox cmbDepartment)
        {

            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Insert(0, "Nursing");
            cmbDepartment.Items.Insert(0, "Doctor");
            cmbDepartment.Items.Insert(0, "All");
            cmbDepartment.SelectedIndex = 0;

        }

        static public void FillCmbSTatusList(ComboBox cmbStatus)
        {

            cmbStatus.Items.Clear();
            cmbStatus.Items.Insert(0, "HaveAccess");
            cmbStatus.Items.Insert(0, "Denied");
            cmbStatus.Items.Insert(0, "All");
            cmbStatus.SelectedIndex = 0;

        }
        static public void FillCmbCatorgyList(ComboBox cmbCatorgy)
        {

            cmbCatorgy.Items.Clear();
            DataTable dataTable = clsMedicalCatorgies.GetAllCatorgies();
            cmbCatorgy.Items.Add("All");

            foreach (DataRow row in dataTable.Rows)
            {

                cmbCatorgy.Items.Add(row["Catorgy"]);




            }

            cmbCatorgy.SelectedIndex = 0;

        }
        static public void FillCmbCatorgy(ComboBox cmbCatorgy)
        {

            cmbCatorgy.Items.Clear();
            DataTable dataTable = clsMedicalCatorgies.GetAllCatorgies();

            foreach (DataRow row in dataTable.Rows)
            {

                cmbCatorgy.Items.Add(row["Catorgy"]);




            }

            cmbCatorgy.SelectedIndex = 0;

        }

        static public void FillCmbPrescriptionStateList(ComboBox cmbState)
        {

            cmbState.Items.Clear();
            cmbState.Items.Insert(0, "Cancelled");
            cmbState.Items.Insert(0, "Still");
            cmbState.Items.Insert(0, "Partiallydispensed");
            cmbState.Items.Insert(0, "Fullydispensed");
            cmbState.Items.Insert(0, "All");
            cmbState.SelectedIndex = 0;

        }
        static public void FillCmbPrescriptionState(ComboBox cmbState)
        {

            cmbState.Items.Clear();
            cmbState.Items.Insert(0, "Cancelled");
            cmbState.Items.Insert(0, "Still");
            cmbState.Items.Insert(0, "Partiallydispensed");
            cmbState.Items.Insert(0, "Fullydispensed");
            cmbState.SelectedIndex = 0;

        }

        static public void FillCmbPrescripedMedState(ComboBox cmbState)
        {

            cmbState.Items.Clear();
            cmbState.Items.Insert(0, "Still");
            cmbState.Items.Insert(0, "Dispensed");
            cmbState.Items.Insert(0, "All");
            cmbState.SelectedIndex = 0;

        }
        static public void FillCountryComboBoxList(ComboBox cmbCountry)
        {

            cmbCountry.Items.Clear();
            DataTable dt = clsCountries.GetAllCountries();
            cmbCountry.Items.Add("All");
            foreach (DataRow dr in dt.Rows)
            {

                cmbCountry.Items.Add(dr["CountryName"]);

            }
            cmbCountry.SelectedIndex = 0;
        }

        static public void FillEmployeeStateCMBList(ComboBox cmbState)
        {

            cmbState.Items.Clear();
            cmbState.Items.Add("All");
            cmbState.Items.Add("Working");
            cmbState.Items.Add("Fired");

            cmbState.SelectedIndex = 0;
        }
        static public void FillDebpartmentCMBList(ComboBox cmbDepartment)
        {

            cmbDepartment.Items.Clear();
            DataTable dt = clsDeparmtments.GetAllDepartments();
            cmbDepartment.Items.Add("All");
            foreach (DataRow dr in dt.Rows)
            {
                cmbDepartment.Items.Add(dr["DepartmentName"]);


            }
            cmbDepartment.SelectedIndex = 0;
        }

        static public void FillSpecilizationcmbList(ComboBox cmbSpecilization)
        { 

            cmbSpecilization.Items.Clear();
            cmbSpecilization.Items.Add("All");
            DataTable dt = clsSpecilization.GetAllSpecilizations();
            foreach (DataRow dr in dt.Rows)
            {
                cmbSpecilization.Items.Add(dr["Specilization"]);
            }
            cmbSpecilization.SelectedIndex = 0;
        }
        static public void FillCmbPaymentStateList(ComboBox cmbPayment)
        {

            cmbPayment.Items.Clear();
            cmbPayment.Items.Add("All");
            cmbPayment.Items.Add("Payed");
            cmbPayment.Items.Add("Cancelled");
            cmbPayment.Items.Add("Bending");

            cmbPayment.SelectedIndex = 0;

        }
        static public void FillCmbServiceStateList(ComboBox cmbService)
        {

            cmbService.Items.Clear();
            cmbService.Items.Add("All");
            cmbService.Items.Add("Finished");
            cmbService.Items.Add("bending");
            cmbService.Items.Add("Cancelled");

            cmbService.SelectedIndex = 0;

        }
        static public void FillcmbResultList(ComboBox cmbResult)
        {

            cmbResult.Items.Clear();
            cmbResult.Items.Add("All");
            cmbResult.Items.Add("Unknown");
            cmbResult.Items.Add("Failed");
            cmbResult.Items.Add("Succeded");


            cmbResult.SelectedIndex = 0;

        }
        static public void FillcmbResult(ComboBox cmbResult)
        {

            cmbResult.Items.Clear();
            cmbResult.Items.Add("Unknown");
            cmbResult.Items.Add("Failed");
            cmbResult.Items.Add("Succeded");


            cmbResult.SelectedIndex = 0;

        }

        static public void FillCmbPaymentMethodList(ComboBox cmbPaymentMethod)
        {

            cmbPaymentMethod.Items.Clear();
            cmbPaymentMethod.Items.Insert(0, "Visa");
            cmbPaymentMethod.Items.Insert(0, "Cash");
            cmbPaymentMethod.Items.Insert(0, "All");

            cmbPaymentMethod.SelectedIndex = 0;

        }


    }
}
