using HosbitalDataAccessLayer;
using HosbitalDataAccessLayer.DerivedTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer.DerivedTables
{
    /// <summary>
    ///Determines The Service Type And It's Cost
    /// </summary>
    [Documentation("this Class Is Used To Manage the Services in the Hospital and set up it's Price")]
    public class clsServiceTypes
    {
        public int TypeID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public string ServiceName { get; set; }
     
        public double ServiceCost {  get; set; }
        enum enMode { enAddNew, enUpdate }
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode Mode = enMode.enAddNew;
        /// <summary>
        /// Indicates why saving the Service Type failed.
        /// </summary>
        public clsFailCauses.enServicesTypesFailCause Cause { get; [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")]
            private set; }
        [Documentation("this is used to assign the object from the Code")]

        public clsServiceTypes()
        {
            this.TypeID = -1;
            this.ServiceName = "";
            this.ServiceCost = 0;
            Mode = enMode.enAddNew;
            Cause = clsFailCauses.enServicesTypesFailCause.enUnKnownError;

        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsServiceTypes(int TypeID, string ServiceName, double ServiceCost)
        {
            this.TypeID = TypeID;
            this.ServiceName = ServiceName;
            this.ServiceCost = ServiceCost;

            Mode = enMode.enUpdate;
            Cause = clsFailCauses.enServicesTypesFailCause.enUnKnownError;

        }
        static public clsServiceTypes FindServiceTypeByID(int TypeID)
        {
            string ServiceName = "";
            double ServiceCost = 0;
            if (clsServicesTypesDAL.GetServiceTypeByID(TypeID, ref ServiceName, ref ServiceCost))
            {
                return new clsServiceTypes(TypeID, ServiceName, ServiceCost);
            }

            return null;



        }
        static public bool DeleteType(int TypeID)
        {


            return clsServicesTypesDAL.DeleteType(TypeID);

        }
     bool _CheckIfDataIsCorrect()
        {

            if (this.ServiceName.Length == 0)
            {
                Cause = clsFailCauses.enServicesTypesFailCause.enVeryShortServiceName;
                return false;
            }
            if (this.ServiceCost < 0)
            {
                Cause = clsFailCauses.enServicesTypesFailCause.enServiceCostBellowZero;
                return false;
            }
            return true;
        }
        bool _AddNewType()
        {
            if (_CheckIfDataIsCorrect())
            {
                this.TypeID = clsServicesTypesDAL.AddNewType(this.ServiceName, this.ServiceCost);
            }
            return this.TypeID != -1;



        }

        /// <summary>
        ///Saves The Changes to DB
        /// </summary>
        /// <returns>true if the changes stored successfully</returns>
        public bool Save()
        {
            switch (Mode)
            {
                case (enMode.enAddNew):

                    if (_AddNewType())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
                case (enMode.enUpdate):
                    if (_UpdateType())
                    {
                        return true;
                    }
                    return false;


            }
            return false;
        }
        bool _UpdateType()
        {
            if (_CheckIfDataIsCorrect())
            {
                return clsServicesTypesDAL.UpdateType(this.TypeID, this.ServiceName, this.ServiceCost);
            }
            return false;
        }
        static public DataTable GetAllTypes()
        {

            return clsServicesTypesDAL.GetAllTypes();
        }
        static public bool Exist(int TypeID)
        {
            return clsServicesTypesDAL.Exist(TypeID);
        }

    }

}


