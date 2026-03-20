using HosbitalDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer
{
    /// <summary>
    ///Manages Hospital Departments
    /// </summary>
    [Documentation("It is Used To Manage All Departments in the System")]
    public class clsDeparmtments
    {

       public int DepartmentID {  get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
       public string DepartmentName {  get; set; }
       public int NumOfEmployees {  get; set; }
       public int DepartmentManagerID { get; set; }
        enum enMode { enAddNew=0,enUpdate=1 }

        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode Mode =enMode.enAddNew;
        /// <summary>
        /// Indicates why saving the department failed.
        /// /// </summary>\
        
        public clsFailCauses.enDepartmentsFailCause Cause
        {
            [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")]
            get; private set; }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsDeparmtments(int DepartmentID,string DepartmentName,int NumOfEmployees,int DepartmentManagerID)
        {
            this.DepartmentID = DepartmentID;
            this.DepartmentName = DepartmentName;
            this.NumOfEmployees = NumOfEmployees;
            this.DepartmentManagerID = DepartmentManagerID;
            Mode=enMode.enUpdate;
            Cause = clsFailCauses.enDepartmentsFailCause.enUnkownError;


        }
        [Documentation("this is used to assign the object from the Code")]

        public clsDeparmtments() {


            Cause = clsFailCauses.enDepartmentsFailCause.enUnkownError;

            this.DepartmentID = -1;
            this.DepartmentName = "";
            this.NumOfEmployees = 0;
            this.DepartmentManagerID = -1;
            Mode = enMode.enAddNew;






        }
       static  public clsDeparmtments FindDepartmentByID(int DepartmentID) {

            
            int DempartmentManagerID = -1;
            int NumOfEmployees = 0;
            string DepartmentName = "";
        
     if( clsDepartmentDAL.GetDepartmentInfoByID(DepartmentID,ref DepartmentName,ref DempartmentManagerID, ref NumOfEmployees))
            {
              return new clsDeparmtments(DepartmentID,DepartmentName,  NumOfEmployees, DempartmentManagerID);

            }
        return null;
        
        
        
        
        }
        static public clsDeparmtments FindDepartmentByName(string DepartmentName)
        {


            int DempartmentManagerID = -1;
            int NumOfEmployees = 0;
            int DepartmentID = -1;
            if (clsDepartmentDAL.GetDepartmentInfoByName(DepartmentName,ref DepartmentID, ref DempartmentManagerID, ref NumOfEmployees))
            {
                return new clsDeparmtments(DepartmentID, DepartmentName, NumOfEmployees, DempartmentManagerID);

            }
            return null;




        }

        [Documentation(@"it is used to check  if the deparmtent manager 
             is part of the department")]
        bool _CheckIfDataIsCorrect()
        {



            if (DepartmentID != -1)
            {
                if (DepartmentManagerID != -1)
                {
                    clsEmployees employee = clsEmployees.FindByID(DepartmentManagerID);
                    if(employee==null)
                    {
                        Cause = clsFailCauses.enDepartmentsFailCause.enWrongDepartmentManagerID;
                        return false;

                    }
                    else
                    {
                        if (employee.DepartmentID != DepartmentID)
                        {
                            Cause = clsFailCauses.enDepartmentsFailCause.enDepartmentMangerIsntEmployeeAtTheDepatment;
                            return false;
                        }
                    }


                }
            }

            if (NumOfEmployees < 0)
            {
                Cause = clsFailCauses.enDepartmentsFailCause.enNumOfEmployeesBelowZero;
                return false;
            }
            if (DepartmentName.Length == 0)
            {
                Cause = clsFailCauses.enDepartmentsFailCause.enVeryShortDepatmentName;
                return false;
            }


            return true;


        }
        private bool _AddNew()
        {
            if (_CheckIfDataIsCorrect())
            {
                this.DepartmentManagerID = -1;
                this.NumOfEmployees = 0;
                this.DepartmentID = clsDepartmentDAL.AddNewDepartment(this.DepartmentName, this.DepartmentManagerID, this.NumOfEmployees);
            }
            return this.DepartmentID != -1;



        }
        private bool _Update()
        {
            if (_CheckIfDataIsCorrect())
            {
                return clsDepartmentDAL.UpdateDepartment(this.DepartmentID, this.DepartmentName, this.DepartmentManagerID, this.NumOfEmployees);
            }
            return false;

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
                    if (_AddNew())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;
                    case (enMode.enUpdate):
                    if(_Update())
                        return true;
                    else
                        return false;

            }
            return false;
        }
        static public DataTable GetAllDepartments()
        {

            return clsDepartmentDAL.GetAllDepartments();

        }
        static public bool Exist(int DepartmentID)
        {

            return clsDepartmentDAL.IsExist(DepartmentID);


        }
        static bool Exist(string DepartmentName) { 
        
      return  clsDepartmentDAL.IsExist(DepartmentName);
        }

    }
}
