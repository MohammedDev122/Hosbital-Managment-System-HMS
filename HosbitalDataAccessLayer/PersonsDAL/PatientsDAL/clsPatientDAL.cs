using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer
{
    static public class clsPatientDAL
    {



      
        static public bool GetPatientInfoByID(int id
        ,ref int PatientStateID, ref int personID,ref string AccessKey)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT 
     *
  FROM Patients
where PatientID=@ID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ID", id);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                 
                    PatientStateID = Convert.ToInt32(Reader["PatientStateID"]);
                    personID = Convert.ToInt32(Reader["PersonID"]);
                    AccessKey = Convert.ToString(Reader["AccessKey"]);
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
      
        static public int AddNewPatient( int PatientStateID, int PersonID,string AccessKey)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int PatientID = -1;
            if (!clsPersonDAL.IsExist(PersonID))
                return PatientID;
            if(IsAlreadyAsigned(PersonID))
                return PatientID;
            string Query = @"INSERT INTO Patients
           (PersonID
           ,PatientStateID,AccessKey)
     VALUES
           (@PersonID
           ,@PatientStateID,@AccessKey
           )
		   select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@PatientStateID", PatientStateID);
            Command.Parameters.AddWithValue("@AccessKey", AccessKey);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    PatientID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return PatientID;













        }
      
        static public bool UpdatePatient(int PatientID, int PatientStateID,string AccessKey)
        {
            bool Updated = false;
            if (!IsExist(PatientID)) return Updated;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);


            string Query = @"UPDATE Patients
   SET 
 
      PatientStateID = @PatientStateID,
    AccessKey=@AccessKey
 WHERE  PatientID=@PatientID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PatientID", PatientID);
            Command.Parameters.AddWithValue("@PatientStateID", PatientStateID);
            Command.Parameters.AddWithValue("@AccessKey", AccessKey);

            try
            {
                Connection.Open();
                int RowsAffected = Command.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    Updated = true;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return Updated;



        }
        static public bool IsExist(int PatientID)
        {
            bool Exist = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select Found=1 from Patients 
                          where PatientID=@PatientID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@PatientID", PatientID);
            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Exist = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return Exist;


        }


        static public int GetPersonIDByPatientID(int PatientID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int PersonID = -1;
            string Query = @"SELECT    
PersonID
  FROM Patients
  where PatientID=@ID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ID", PatientID);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    PersonID = InsertedID;
                }
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return PersonID;







        }


        static public bool DeletePatient(int PatientID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(PatientID))
                return Deleteed;
            //if(!clsPersonDAL.DeletePerson(GetPersonIDByEmployeeID(ID)))
            // return Deleteed;
            string Querey = @"DELETE FROM Patients
                            WHERE PatientID=@PatientID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@PatientID", PatientID);
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





        static public DataTable GetAllPatientsForAdmin()
        {
            DataTable dtPatients = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT Patients.PatientID, Persons.FirstName, Persons.LastName, Persons.Phone, Persons.BirthDate, Persons.Gender, Persons.AccountID, Countries.CountryName, PatientState.State,Patients.AccessKey
FROM     Patients INNER JOIN
                  PatientState ON Patients.PatientStateID = PatientState.StateID INNER JOIN
                  Persons ON Patients.PersonID = Persons.PersonID INNER JOIN
                  Countries ON Persons.CountryID = Countries.CountryID";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtPatients.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtPatients;











        }
    




        static public DataTable GetAllPatientsForOthers()
        {
            DataTable dtPatients = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT Patients.PatientID, Persons.FirstName, Persons.LastName, Persons.Phone
FROM     Patients INNER JOIN
                  Persons ON Patients.PersonID = Persons.PersonID
where PatientStateID!=2";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtPatients.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtPatients;











        }
     

        static bool IsAlreadyAsigned(int PersonID)
        {
            bool Assigned = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select found=1 from Patients where PersonID=@PersonID
";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Assigned = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return Assigned;



        }

    }
}
