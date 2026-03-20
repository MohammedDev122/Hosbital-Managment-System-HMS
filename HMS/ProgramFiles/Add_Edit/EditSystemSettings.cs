using HosbitalBussinessLayer.System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Add_Edit
{
    public partial class EditSystemSettings : ctrlAddEditBase
    {
        public EditSystemSettings()
        {
            InitializeComponent();
            clsFillcmb.FillLanguageComboBox(cmbLang);
            clsFillcmb.FillThemesComboBox(cmbThemes);


        }

        private void AddEditSystemSettings_Load(object sender, EventArgs e)
        {
            lblAddEdit.Text = "system settings";

        }

        private void cmbLang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        clsSystem.enLanguage GetLaguage(string Language)
        {
            switch (Language) {
                case ("Arabic"):
                    return clsSystem.enLanguage.enArabic;
                case ("Russian"):
                    return clsSystem.enLanguage.enRussian;
                default:
              return      clsSystem.enLanguage.enEnglish;
              
           


            }
        }
        clsSystem.enThemes GetTheme(string Theme)
        {
            switch (Theme)
            {
                case ("Blue & White"):
                    return clsSystem.enThemes.enThemeOption1;
                case ("Gray & White"):
                    return clsSystem.enThemes.enThemeOption3;
                default:
                    return clsSystem.enThemes.enThemeOption2;




            }
        }
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            clsSystem system=clsSystem.GetSystemInfo();
           
            if (system.UpdateSystem(GetLaguage(cmbLang.SelectedItem.ToString()), GetTheme(cmbThemes.SelectedItem.ToString())))
            {


                MessageBox.Show("System Has Been Succissfully Updated You Have To Repote the Program to Apply Changes");

            }



        }
    }
}
