using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.procedures
{
    static public class clsDiagnosisDAL
    {

        static public bool GetDiagnosisInfo(int DiagnosisID, ref int DoctorID, ref int MedicalRecordID, ref int SpecilizationID, ref int ServiceID)
        {


            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
SELECT 
       DoctorID,
       MedicalRecordID,
       SpecilizationID,
       ServiceID
  FROM Diagnoisis
  where DiagnosisID=@DiagnosisID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@DiagnosisID", DiagnosisID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {




                    DoctorID = Convert.ToInt32(Reader["DoctorID"]);
                    if (int.TryParse(Convert.ToString(Reader["MedicalRecordID"]), out int RecID))
                    {
                        MedicalRecordID = RecID;
                    }
                    else
                    {
                        MedicalRecordID = -1;
                    }
                    SpecilizationID = Convert.ToInt32(Reader["SpecilizationID"]);
                    ServiceID = Convert.ToInt32(Reader["ServiceID"]);
                    Found = true;



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Found;




        }
        static public int AddNewDiagnosis(int DoctorID, int MedicalRecordID, int SpecilizationID, int ServiceID)
        {
            int DiagnosisID = -1;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
INSERT INTO Diagnoisis
           (DoctorID
           ,MedicalRecordID
           ,SpecilizationID
           ,ServiceID)
     VALUES
           (@DoctorID
           ,@MedicalRecordID
           ,@SpecilizationID
           ,@ServiceID)
		   select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@DoctorID", DoctorID);
           if(MedicalRecordID!=-1)
                command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
           else
                command.Parameters.AddWithValue("@MedicalRecordID", DBNull.Value);

            command.Parameters.AddWithValue("@SpecilizationID", SpecilizationID);


            command.Parameters.AddWithValue("@ServiceID", ServiceID);

           
            try
            {

                Connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null & int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    DiagnosisID = InsertedID;





                }





            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return DiagnosisID;




        }

        static public int GetDiagnosisIDByMedicalRecID( int MedicalRecordID)
        {


            int DiagnosisID = -1;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
SELECT 
       DiagnosisID
      
  FROM Diagnoisis
  where MedicalRecordID=@MedicalRecordID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {




                    DiagnosisID = Convert.ToInt32(Reader["DiagnosisID"]);
                  



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return DiagnosisID;




        }


        static public bool UpdateDiagnosisInfo(int DiagnosisID, int DoctorID, int MedicalRecordID, int SpecilizationID, int ServiceID)
        {
            bool Updated = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE Diagnoisis
   SET DoctorID = @DoctorID
      ,MedicalRecordID = @MedicalRecordID
      ,SpecilizationID = @SpecilizationID
      ,ServiceID = @ServiceID
 WHERE DiagnosisID=@DiagnosisID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@DiagnosisID", DiagnosisID);
            command.Parameters.AddWithValue("@DoctorID", DoctorID);
            if(MedicalRecordID!=-1)
            command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
            else
            {
                command.Parameters.AddWithValue("@MedicalRecordID", DBNull.Value);

            }

            command.Parameters.AddWithValue("@SpecilizationID", SpecilizationID);
            command.Parameters.AddWithValue("@ServiceID", ServiceID);
          


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


        static public bool DeleteDiagnosis(int DiagnosisID)
        {




            bool Delete = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"Delete from Diagnoisis
 WHERE DiagnosisID=@DiagnosisID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@DiagnosisID", DiagnosisID);


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


        static public DataTable GetAllDiagnosis()
        {  
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            DataTable dtDiagnosis = new DataTable();
            string Query = @"SELECT Diagnoisis.DiagnosisID, Diagnoisis.DoctorID, (Persons.FirstName + ' ' + Persons.LastName) AS DoctorName, Specilizations.Specilization, Services.PatientID,
Persons_1.FirstName + ' ' + Persons_1.LastName AS PatientName, Services.PaymentID, PaymentStatus.Status, Diagnoisis.MedicalRecordID, ServiceState.State, Services.Date, 
                  Services.ServiceStartTime, Services.ServiceEndTime
FROM     Diagnoisis INNER JOIN
                  Services ON Diagnoisis.ServiceID = Services.ServiceID INNER JOIN
                  Doctors ON Diagnoisis.DoctorID = Doctors.DoctorID INNER JOIN
                  Employees ON Doctors.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID INNER JOIN
                  Specilizations ON Diagnoisis.SpecilizationID = Specilizations.SpecilizationID AND Doctors.SpecilizationId = Specilizations.SpecilizationID INNER JOIN
                  Patients ON Services.PatientID = Patients.PatientID INNER JOIN
                  ServiceState ON Services.ServiceStateID = ServiceState.StateID INNER JOIN
                  Persons AS Persons_1 ON Patients.PersonID = Persons_1.PersonID INNER JOIN
                  Payments ON Services.PaymentID = Payments.PaymentID INNER JOIN
                  PaymentStatus ON PaymentStatus.StatusID = Payments.PaymentStatusID
";
            SqlCommand command = new SqlCommand(Query, Connection);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dtDiagnosis.Load(Reader);


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtDiagnosis;




        }
       

        static public DataTable GetAllDoctorDiagnosis(int DoctorID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            DataTable dtDiagnosis = new DataTable();
            string Query = @"SELECT Diagnoisis.DiagnosisID, Diagnoisis.DoctorID, (Persons.FirstName + ' ' + Persons.LastName) AS DoctorName, Specilizations.Specilization, Services.PatientID,
Persons_1.FirstName + ' ' + Persons_1.LastName AS PatientName, Services.PaymentID, PaymentStatus.Status, Diagnoisis.MedicalRecordID, ServiceState.State, Services.Date, 
                  Services.ServiceStartTime, Services.ServiceEndTime
FROM     Diagnoisis INNER JOIN
                  Services ON Diagnoisis.ServiceID = Services.ServiceID INNER JOIN
                  Doctors ON Diagnoisis.DoctorID = Doctors.DoctorID INNER JOIN
                  Employees ON Doctors.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID INNER JOIN
                  Specilizations ON Diagnoisis.SpecilizationID = Specilizations.SpecilizationID AND Doctors.SpecilizationId = Specilizations.SpecilizationID INNER JOIN
                  Patients ON Services.PatientID = Patients.PatientID INNER JOIN
                  ServiceState ON Services.ServiceStateID = ServiceState.StateID INNER JOIN
                  Persons AS Persons_1 ON Patients.PersonID = Persons_1.PersonID INNER JOIN
                  Payments ON Services.PaymentID = Payments.PaymentID INNER JOIN
                  PaymentStatus ON PaymentStatus.StatusID = Payments.PaymentStatusID
where Diagnoisis.DoctorID=@DoctorID
";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@DoctorID", DoctorID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dtDiagnosis.Load(Reader);


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtDiagnosis;




        }
      

        static public DataTable GetAllPatientDiagnosis(int PatientID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            DataTable dtDiagnosis = new DataTable();
            string Query = @"SELECT Diagnoisis.DiagnosisID, Diagnoisis.DoctorID, (Persons.FirstName + ' ' + Persons.LastName) AS DoctorName, Specilizations.Specilization, Services.PatientID,
Persons_1.FirstName + ' ' + Persons_1.LastName AS PatientName, Services.PaymentID, PaymentStatus.Status, Diagnoisis.MedicalRecordID, ServiceState.State, Services.Date, 
                  Services.ServiceStartTime, Services.ServiceEndTime
FROM     Diagnoisis INNER JOIN
                  Services ON Diagnoisis.ServiceID = Services.ServiceID INNER JOIN
                  Doctors ON Diagnoisis.DoctorID = Doctors.DoctorID INNER JOIN
                  Employees ON Doctors.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID INNER JOIN
                  Specilizations ON Diagnoisis.SpecilizationID = Specilizations.SpecilizationID AND Doctors.SpecilizationId = Specilizations.SpecilizationID INNER JOIN
                  Patients ON Services.PatientID = Patients.PatientID INNER JOIN
                  ServiceState ON Services.ServiceStateID = ServiceState.StateID INNER JOIN
                  Persons AS Persons_1 ON Patients.PersonID = Persons_1.PersonID INNER JOIN
                  Payments ON Services.PaymentID = Payments.PaymentID INNER JOIN
                  PaymentStatus ON PaymentStatus.StatusID = Payments.PaymentStatusID
where  Services.PatientID=@PatientID
";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PatientID", PatientID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dtDiagnosis.Load(Reader);


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtDiagnosis;




        }
      



        static public bool ISExist(int DiagnosisID)
        {
            bool Exist = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
SELECT 
     Found=1 from Diagnoisis
  where DiagnosisID=@DiagnosisID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@DiagnosisID", DiagnosisID);
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







    }
}
