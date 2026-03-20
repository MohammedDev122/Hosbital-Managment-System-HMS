using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.MediationsDAL
{
    static public class clsPrescriptionDAL

    {
       


            static public int AddNewPrescription(
                 int MedicalRecordID, int PrescriptionStateID)
            {
                SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
                int PrescriptionID = -1;
                string Query = @"
INSERT INTO Prescriptions
           (MedicalRecordID
           ,PrescriptionStateID)
     VALUES
           (@MedicalRecordID
           ,@PrescriptionStateID)
			 select SCOPE_IDENTITY();";
                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
                Command.Parameters.AddWithValue("@PrescriptionStateID", PrescriptionStateID);

                try
                {
                    Connection.Open();
                    object Result = Command.ExecuteScalar();
                    if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                    {
                        PrescriptionID = InsertedID;
                    }



                }
                catch (Exception ex) { }
                finally
                {
                    Connection.Close();

                }

                return PrescriptionID;


            }

            static public bool GetPrescriptionInfoByID(int PrescriptionID, ref int MedicalRecordID, ref int PrescriptionStateID)
            {

                SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
                bool IsFound = false;
                string Query = @"SELECT MedicalRecordID
      ,PrescriptionStateID
     
  FROM Prescriptions
where PrescriptionID=@PrescriptionID";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
                try
                {
                    Connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.Read())
                    {

                        MedicalRecordID = Convert.ToInt32(Reader["MedicalRecordID"]);
                        PrescriptionStateID = Convert.ToInt32(Reader["PrescriptionStateID"]);

                        IsFound = true;
                        Reader.Close();
                    }



                }
                catch (Exception ex) { }
                finally
                {
                    Connection.Close();

                }

                return IsFound;







            }

            static public bool UpdatePrescriptionInfo(int PrescriptionID,  int MedicalRecordID,  int PrescriptionStateID)
            {
                bool Updated = false;
                if (!IsExist(PrescriptionID))
                    return Updated;
                SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
                string Query = @"UPDATE Prescriptions
                           SET MedicalRecordID = @MedicalRecordID
                           ,PrescriptionStateID =@PrescriptionStateID
                          
                           WHERE PrescriptionID=@PrescriptionID";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
                command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
                command.Parameters.AddWithValue("@PrescriptionStateID", PrescriptionStateID);
                try
                {
                    connection.Open();
                    int RowsAffected = command.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        Updated = true;
                    }

                }
                catch (Exception ex)
                {

                }
                finally { connection.Close(); }

                return Updated;

            }
            static public bool IsExist(int PrescriptionID)
            {

                SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
                bool IsFound = false;
                string Query = @"SELECT Found=1
  FROM Prescriptions
where PrescriptionID=@PrescriptionID";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);

                try
                {
                    Connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.HasRows)
                    {

                        IsFound = true;

                    }

                }
                catch (Exception ex) { }
                finally { Connection.Close(); }
                return IsFound;




            }

            static public bool DeletePrescription(int PrescriptionID)
            {
                SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
                bool Deleteed = false;
                if (!IsExist(PrescriptionID))
                    return Deleteed;
                string Querey = @"DELETE FROM Prescriptions
                            WHERE PrescriptionID=@PrescriptionID";
                SqlCommand command = new SqlCommand(Querey, Connection);
                command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
                try
                {
                    Connection.Open();
                    int RowsAffected = command.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {

                        Deleteed = true;

                    }

                }
                catch (Exception ex) { }
                finally { Connection.Close(); }
                return Deleteed;


            }



            static public DataTable GetAllPrescriptions()
            {
                DataTable dtPrescriptions = new DataTable();
                SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
                string Query = @"SELECT Prescriptions.PrescriptionID, PrescriptionStates.State, Prescriptions.MedicalRecordID, Patients.PatientID, Persons.FirstName+' '+ Persons.LastName as PatientName
FROM     Prescriptions INNER JOIN
                  PrescriptionStates ON Prescriptions.PrescriptionStateID = PrescriptionStates.ID INNER JOIN
                  MedicalRecords ON Prescriptions.MedicalRecordID = MedicalRecords.RecordID INNER JOIN
                  Patients ON MedicalRecords.PatientID = Patients.PatientID INNER JOIN
                  Persons ON Patients.PersonID = Persons.PersonID";
                SqlCommand Command = new SqlCommand(Query, Connection);


                try
                {
                    Connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        dtPrescriptions.Load(Reader);
                    }
                    Reader.Close();



                }
                catch (Exception ex) { }
                finally { Connection.Close(); }
                return dtPrescriptions;











            }
        static public DataTable GetAllPrescriptionsForPatient(int PatientID)
        {
            DataTable dtPrescriptions = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT Prescriptions.PrescriptionID, PrescriptionStates.State, Prescriptions.MedicalRecordID, Patients.PatientID, Persons.FirstName+' '+ Persons.LastName as PatientName
FROM     Prescriptions INNER JOIN
                  PrescriptionStates ON Prescriptions.PrescriptionStateID = PrescriptionStates.ID INNER JOIN
                  MedicalRecords ON Prescriptions.MedicalRecordID = MedicalRecords.RecordID INNER JOIN
                  Patients ON MedicalRecords.PatientID = Patients.PatientID INNER JOIN
                  Persons ON Patients.PersonID = Persons.PersonID
				  where Patients.PatientID=@patientID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@patientID", PatientID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtPrescriptions.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtPrescriptions;











        }
        static public DataTable GetAllPrescriptionsForDoctor(int DoctorID)
        {
            DataTable dtPrescriptions = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT Prescriptions.PrescriptionID, PrescriptionStates.State, Prescriptions.MedicalRecordID, Patients.PatientID, Persons.FirstName+' '+ Persons.LastName as PatientName
FROM     Prescriptions INNER JOIN
                  PrescriptionStates ON Prescriptions.PrescriptionStateID = PrescriptionStates.ID INNER JOIN
                  MedicalRecords ON Prescriptions.MedicalRecordID = MedicalRecords.RecordID INNER JOIN
				  Diagnoisis on Diagnoisis.MedicalRecordID=MedicalRecords.RecordID inner join
                  Patients ON MedicalRecords.PatientID = Patients.PatientID INNER JOIN
                  Persons ON Patients.PersonID = Persons.PersonID
				  where Diagnoisis.DoctorID=@DoctorID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DoctorID", DoctorID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtPrescriptions.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtPrescriptions;











        }
    }

}
