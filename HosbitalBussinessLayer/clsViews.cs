using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer
{
    [Documentation("this Class Responsiple for managing how the user Retrive the Data")]
    static public class clsViews
    {
         public enum enShowing { enAdmin,enOther,enInfoEmployeeOwner,enPatientOwner};
    }
}
