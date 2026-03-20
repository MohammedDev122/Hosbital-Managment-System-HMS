using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.LogsDAL
{
    static public class clsMedicalRecordDAL
    {

        static public int AddNewMedicalRecord(int PatientID,
              string DiagnosticNotes,int StateID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int RecordID = -1;
            string Query = @"INSERT INTO MedicalRecords
           (DiagnosticNotes
           ,PatientID,
StateID)
     VALUES
           
           (@DiagnosticNotes
           ,@PatientID,@StateID)
		   SELEct SCOPE_IDENTITY();
;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DiagnosticNotes", DiagnosticNotes);
            Command.Parameters.AddWithValue("@PatientID", PatientID);
            Command.Parameters.AddWithValue("@StateID", StateID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    RecordID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return RecordID;


        }

        static public bool GetMedicalRecordInfoByID(int RecordID, ref int PatientID, ref string DiagnosticNotes,ref int StateID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT *
  FROM MedicalRecords
  where RecordID=@RecordID
";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@RecordID", RecordID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    PatientID = Convert.ToInt32(Reader["PatientID"]);
                    DiagnosticNotes = Convert.ToString(Reader["DiagnosticNotes"]);
                    StateID= Convert.ToInt32(Reader["StateID"]);
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


        static public bool IsExist(int RecordID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Found=1
  FROM MedicalRecords
where RecordID=@RecordID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@RecordID", RecordID);

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


        static public bool DeleteRecord(int RecordID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(RecordID))
                return Deleteed;
            string Querey = @"DELETE FROM MedicalRecords
                            WHERE RecordID=@RecordID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@RecordID", RecordID);
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



        static public DataTable GetAllRecords()
        {
            DataTable dtRecords = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT MedicalRecords.RecordID, MedicalRecords.DiagnosticNotes, MedicalRecords.PatientID,  Persons.FirstName+' '+ Persons.LastName as PatientName, Persons.Phone, MedRecState.State
FROM     MedicalRecords INNER JOIN
                  Patients ON MedicalRecords.PatientID = Patients.PatientID INNER JOIN
                  Persons ON Patients.PersonID = Persons.PersonID INNER JOIN
                  MedRecState ON MedicalRecords.StateID = MedRecState.StateID";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtRecords.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtRecords;













        }
        static public DataTable GetAllRecordsForPatient(int PatientID)
        {
            DataTable dtRecords = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT MedicalRecords.RecordID, MedicalRecords.DiagnosticNotes, MedicalRecords.PatientID,Persons.FirstName+' '+ Persons.LastName as PatientName,Persons.Phone, MedRecState.State
FROM     MedicalRecords INNER JOIN
                  Patients ON MedicalRecords.PatientID = Patients.PatientID INNER JOIN
                  Persons ON Patients.PersonID = Persons.PersonID INNER JOIN
                  MedRecState ON MedicalRecords.StateID = MedRecState.StateID
where MedicalRecords.PatientID=@PatientID
";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtRecords.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtRecords;













        }
        static public DataTable GetAllRecordsForDoctor(int DoctorID)
        {
            DataTable dtRecords = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT MedicalRecords.RecordID, MedicalRecords.DiagnosticNotes, MedicalRecords.PatientID, Persons.FirstName+' '+ Persons.LastName as PatientName, Persons.Phone, MedRecState.State
FROM     MedicalRecords INNER JOIN
                  Patients ON MedicalRecords.PatientID = Patients.PatientID INNER JOIN
                  Persons ON Patients.PersonID = Persons.PersonID INNER JOIN
                  MedRecState ON MedicalRecords.StateID = MedRecState.StateID
INNER JOIN
                  Diagnoisis ON Diagnoisis.MedicalRecordID = MedicalRecords.RecordID
where Diagnoisis.DoctorID=@DoctorID
";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DoctorID", DoctorID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtRecords.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtRecords;













        }

        static public bool UpdateRecordInfo(int RecordID, int PatientID, string DiagnosticNotes,int StateID)
        {
            bool Updated = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE MedicalRecords
   SET DiagnosticNotes = @DiagnosticNotes
      ,PatientID = @PatientID
,StateID=@StateID
 WHERE RecordID=@RecordID
";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@RecordID", RecordID);
           
            command.Parameters.AddWithValue("@PatientID", PatientID);
           
            command.Parameters.AddWithValue("@DiagnosticNotes", DiagnosticNotes);
            command.Parameters.AddWithValue("@StateID", StateID);


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



    }
}
