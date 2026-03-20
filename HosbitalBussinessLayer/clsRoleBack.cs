using HosbitalBussinessLayer.Logs;
using HosbitalDataAccessLayer;
using HosbitalDataAccessLayer.LogsDAL;
using HosbitalDataAccessLayer.MediationsDAL;
using HosbitalDataAccessLayer.procedures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;


namespace HosbitalBussinessLayer
{
    [Documentation("this Class is responsiple for stepping back of any process in the system when the chain of process fail")]
    static public class clsRoleBack
    {
        static public bool DeleteAccount(int AccountID)
        {


            return clsBanckAcountDAL.DeleteAccount(AccountID);

        
      
        }
        static public bool DeletePrescripedMed(int PrescripedMedID)
        {


            return clsPrescripedMedDAL.DeletePrescripedMedication(PrescripedMedID);

        }
        static public bool DeleteMedicalRecord(int RecordID)
        {


            return clsMedicalRecordDAL.DeleteRecord(RecordID);

        }

        static public bool DeletePatientLog(int LogID)
        {

            
            return clsPatientLogDAL.DeleteLog(LogID);

        }


        public static bool DeletePerson(int PersonID)
        {
           

                return clsPersonDAL.DeletePerson(PersonID);
           
        }


        static public bool DeleteEmployee(int employeeID)
        {

           
                return clsEmployeeDAL.DeleteEmployee(employeeID);
           
        }

        static public bool DeletePayment(int PaymentID)
        {
            return clsPaymentsDAL.DeletePayment(PaymentID);
        }



        static public bool DeleteService(int ServiceID)
        {
            return clsServicesDAL.DeleteService(ServiceID);
        }

        static public bool DeleteDoctorReservation(int ReservationID)
        {
            return clsDoctorReservationDAL.DeleteDoctorReservation(ReservationID);
        }
        static public bool DeleteNurseReservation(int ReservationID)
        {
            return clsNurseReservationsDAL.DeleteNurseReservation(ReservationID);
        }


        static public bool DeleteDoctorReservation(int DoctorID, int ServiceID)
        {
            return clsDoctorReservationDAL.DeleteDoctorReservation(DoctorID, ServiceID);
        }
        static public bool DeleteNurseReservation(int NurseID, int ServiceID)
        {
            return clsNurseReservationsDAL.DeleteNurseReservation(NurseID, ServiceID);
        }
        static public bool DeleteAllDoctorsReservationForOperation(int ServiceID)
        {

            DataTable dt = clsDoctorReservation.GetServiceReservations(ServiceID);
            foreach (DataRow row in dt.Rows) {


                if (!DeleteDoctorReservation(Convert.ToInt32(row["ReservationID"])))
                {
                    return false;
                }
            
            
            }
            return true;

        }
        static public bool DeleteAllNurseReservationForOperation(int ServiceID)
        {

            DataTable dt = clsNurseReservation.GetServiceReservations(ServiceID);
            foreach (DataRow row in dt.Rows)
            {


                if (!DeleteNurseReservation(Convert.ToInt32(row["ReservationID"])))
                {
                    return false;
                }


            }
            return true;

        }


        static public bool DeleteRoomReservation(int RoomReservationID)
        {

            return clsRoomReservationsDAL.DeleteRoomReservation(RoomReservationID);

        }


        static public bool DeletePharmecyRec(int RecID)
        {

            return clsPharmacyRecordDAL.DeleteRec(RecID);

        }
















    }
}
