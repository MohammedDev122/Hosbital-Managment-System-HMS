using HosbitalDataAccessLayer.systemDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HosbitalBussinessLayer.System.clsSystem;

namespace HosbitalBussinessLayer.System
{
    public class clsSystem
    {
        int ID = 1;
     public   enum enLanguage { enArabic=1,enEnglish=2,enRussian=3}
        public enLanguage Language= enLanguage.enArabic;
        public enum enThemes { enThemeOption1=1, enThemeOption2=2, enThemeOption3=3}
       public enThemes themes=enThemes.enThemeOption1;
        private clsSystem(enLanguage language,enThemes themes)
        {

            this.ID = 1;
            this.Language = language;
            this.themes=themes;




        }
     
        public bool UpdateSystem(enLanguage language, enThemes themes) {



         return   clsSystemSettingsDAL.UpdateSystemSettingsInfo(ID, Convert.ToInt32(language), Convert.ToInt32(themes));
        
        
        
        
        
        
        }
static public clsSystem GetSystemInfo()
        {

            int Language = -1;
            int Theme = -1;
            clsSystemSettingsDAL.GetSystemSettingsInfoByID(1,ref Language,ref Theme);
            return new clsSystem((enLanguage)Language,(enThemes)Theme);



        }





    }
}
