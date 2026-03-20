using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.procedures
{
    public static class clsOperationsDAL
    {
        //Operations

        static public bool GetOperationInfoByID(int OperationID, ref int MedicalRecordID, ref int SpecilizationNeededID, ref int OperationResultID, ref int ServiceID,ref int RoomID)
        {

            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
SELECT 
       MedicalRecordID,
       SpecilizationNeededID,
       OperationResultID,
       ServiceID,
RoomID
  FROM Operations
  where OperationID=@OperationID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@OperationID", OperationID);
           

            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {




                    MedicalRecordID = Convert.ToInt32(Reader["MedicalRecordID"]);
                    SpecilizationNeededID = Convert.ToInt32(Reader["SpecilizationNeededID"]);
                    OperationResultID = Convert.ToInt32(Reader["OperationResultID"]);
                    ServiceID = Convert.ToInt32(Reader["ServiceID"]);
                    RoomID = Convert.ToInt32(Reader["RoomID"]);

                    Found = true;



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Found;




        }
        static public int AddNewOperation(int MedicalRecordID,  int SpecilizationNeededID,  int OperationResultID,  int ServiceID,  int RoomID)
        {
            int OperationID = -1;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
INSERT INTO Operations
           (MedicalRecordID
           ,SpecilizationNeededID
           ,OperationResultID
           ,ServiceID
,RoomID)
     VALUES
           (@MedicalRecordID
           ,@SpecilizationNeededID
           ,@OperationResultID
           ,@ServiceID
,@RoomID)
		   select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
            command.Parameters.AddWithValue("@SpecilizationNeededID", SpecilizationNeededID);
            command.Parameters.AddWithValue("@OperationResultID", OperationResultID);
            command.Parameters.AddWithValue("@ServiceID", ServiceID);
            command.Parameters.AddWithValue("@RoomID", RoomID);

            try
            {

                Connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null & int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    OperationID = InsertedID;





                }





            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return OperationID;




        }


        static public bool GetOperationInfoByServiceID(int ServiceID , ref int MedicalRecordID, ref int SpecilizationNeededID, ref int OperationResultID, ref int OperationID, ref int RoomID)
        {

            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
SELECT 
       MedicalRecordID,
       SpecilizationNeededID,
       OperationResultID,
       OperationID,
RoomID
  FROM Operations
  where  ServiceID=@ServiceID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ServiceID", ServiceID);


            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {




                    MedicalRecordID = Convert.ToInt32(Reader["MedicalRecordID"]);
                    SpecilizationNeededID = Convert.ToInt32(Reader["SpecilizationNeededID"]);
                    OperationResultID = Convert.ToInt32(Reader["OperationResultID"]);
                    OperationID = Convert.ToInt32(Reader["OperationID"]);
                    RoomID = Convert.ToInt32(Reader["RoomID"]);

                    Found = true;



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Found;




        }

        static public bool UpdateOperationInfo(int OperationID,  int MedicalRecordID,  int SpecilizationNeededID,  int OperationResultID,  int ServiceID,  int RoomID)
        {
            bool Updated = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE Operations
   SET MedicalRecordID = @MedicalRecordID
      ,SpecilizationNeededID = @SpecilizationNeededID
      ,OperationResultID = @OperationResultID
      ,ServiceID = @ServiceID
      ,RoomID = @RoomID
 WHERE OperationID=@OperationID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
            command.Parameters.AddWithValue("@SpecilizationNeededID", SpecilizationNeededID);

            command.Parameters.AddWithValue("@OperationResultID", OperationResultID);
            command.Parameters.AddWithValue("@ServiceID", ServiceID);


            command.Parameters.AddWithValue("@RoomID", RoomID);
            command.Parameters.AddWithValue("@OperationID", OperationID);



            try
            {
                Connection.Open();
                int Result = command.ExecuteNonQuery();
                if (Result > 0)
                {

                    Updated = true;
                }
            }
            catch (Exception ex) { }
            finally { Connection.Close(); }


            return Updated;




        }


        static public bool DeleteOperation(int OperationID)
        {




            bool Delete = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"Delete from Operations
 WHERE OperationID=@OperationID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@OperationID", OperationID);


            try
            {
                Connection.Open();
                int Result = command.ExecuteNonQuery();
                if (Result > 0)
                {

                    Delete = true;
                }
            }
            catch (Exception ex) { }
            finally { Connection.Close(); }


            return Delete;





        }


     


        static public bool ISExist(int OperationID)
        {
            bool Exist = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
SELECT 
     Found=1 from Operations
  where OperationID=@OperationID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@OperationID", OperationID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    Exist = true;



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Exist;




        }


        static public DataTable GetAllOperationsforAdmin()
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            DataTable dtOperations = new DataTable();
            string Query = @"SELECT distinct Operations.OperationID, Operations.MedicalRecordID, Specilizations.Specilization, OperationResults.Result, OperationRooms.RoomNum, Services.Date, 
                  Services.ServiceStartTime, Services.ServiceEndTime, Services.PatientID, Persons.FirstName, Persons.LastName, Persons.Phone, Services.PaymentID, PaymentStatus.Status,ServiceState.State
FROM     Operations INNER JOIN
                  Specilizations ON Operations.SpecilizationNeededID = Specilizations.SpecilizationID INNER JOIN
                  OperationRooms ON Operations.RoomID = OperationRooms.OperationRoomID INNER JOIN
                  OperationResults ON Operations.OperationResultID = OperationResults.OperationResultID INNER JOIN
                  Services ON Operations.ServiceID = Services.ServiceID INNER JOIN
                  Patients ON Patients.PatientID = Services.PatientID INNER JOIN
                  Persons ON Persons.PersonID = Patients.PersonID INNER JOIN
                  Payments ON Payments.PaymentID = Services.PaymentID INNER JOIN
                  ServiceState ON Services.ServiceStateID = ServiceState.StateID INNER JOIN

                  PaymentStatus ON Payments.PaymentStatusID = PaymentStatus.StatusID left JOIN
                  OperationStaff ON Operations.OperationID = OperationStaff.OperationID left JOIN
                  Employees ON  OperationStaff.EmployeeID = Employees.EmployeeID";
            SqlCommand command = new SqlCommand(Query, Connection);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dtOperations.Load(Reader);


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtOperations;




        }
      




        static public DataTable GetAllOperationsforPatient(int PatientID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            DataTable dtOperations = new DataTable();
            string Query = @"SELECT distinct Operations.OperationID, Operations.MedicalRecordID, Specilizations.Specilization, OperationResults.Result, OperationRooms.RoomNum, Services.Date, 
                  Services.ServiceStartTime, Services.ServiceEndTime, Services.PatientID, Persons.FirstName, Persons.LastName, Persons.Phone, Services.PaymentID, PaymentStatus.Status,ServiceState.State
FROM     Operations INNER JOIN
                  Specilizations ON Operations.SpecilizationNeededID = Specilizations.SpecilizationID INNER JOIN
                  OperationRooms ON Operations.RoomID = OperationRooms.OperationRoomID INNER JOIN
                  OperationResults ON Operations.OperationResultID = OperationResults.OperationResultID INNER JOIN
                  Services ON Operations.ServiceID = Services.ServiceID INNER JOIN
                  Patients ON Patients.PatientID = Services.PatientID INNER JOIN
                  Persons ON Persons.PersonID = Patients.PersonID INNER JOIN
                  Payments ON Payments.PaymentID = Services.PaymentID INNER JOIN
                  ServiceState ON Services.ServiceStateID = ServiceState.StateID INNER JOIN

                  PaymentStatus ON Payments.PaymentStatusID = PaymentStatus.StatusID left JOIN
                  OperationStaff ON Operations.OperationID = OperationStaff.OperationID left JOIN
                  Employees ON  OperationStaff.EmployeeID = Employees.EmployeeID
where Services.PatientID=@ID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ID", PatientID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dtOperations.Load(Reader);


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtOperations;




        }
     


        
        static public DataTable GetAllOperationsforStaffMember(int MemberID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            DataTable dtOperations = new DataTable();
            string Query = @"SELECT distinct Operations.OperationID, Operations.MedicalRecordID, Specilizations.Specilization, OperationResults.Result, OperationRooms.RoomNum, Services.Date, 
                  Services.ServiceStartTime, Services.ServiceEndTime, Services.PatientID, Persons.FirstName, Persons.LastName, Persons.Phone, Services.PaymentID, PaymentStatus.Status,ServiceState.State
FROM     Operations INNER JOIN
                  Specilizations ON Operations.SpecilizationNeededID = Specilizations.SpecilizationID INNER JOIN
                  OperationRooms ON Operations.RoomID = OperationRooms.OperationRoomID INNER JOIN
                  OperationResults ON Operations.OperationResultID = OperationResults.OperationResultID INNER JOIN
                  Services ON Operations.ServiceID = Services.ServiceID INNER JOIN
                  Patients ON Patients.PatientID = Services.PatientID INNER JOIN
                  Persons ON Persons.PersonID = Patients.PersonID INNER JOIN
                  Payments ON Payments.PaymentID = Services.PaymentID INNER JOIN
                  ServiceState ON Services.ServiceStateID = ServiceState.StateID INNER JOIN

                  PaymentStatus ON Payments.PaymentStatusID = PaymentStatus.StatusID left JOIN
                  OperationStaff ON Operations.OperationID = OperationStaff.OperationID left JOIN
                  Employees ON  OperationStaff.EmployeeID = Employees.EmployeeID
where OperationStaff.EmployeeID=@ID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ID", MemberID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dtOperations.Load(Reader);


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtOperations;




        }
      



    }
}
