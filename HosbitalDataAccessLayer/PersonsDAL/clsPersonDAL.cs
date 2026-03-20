using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer
{
    static public class clsPersonDAL
    {

      static  public bool GetPersonInfoByID(int id, ref string FirstName,
          ref string LastName, ref string Phone, ref DateTime DateOfBirth
          , ref char Gender,ref int AccountID,ref int CountryID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT 
      FirstName
      ,LastName
      ,Phone
      ,BirthDate
,AccountID
      ,Gender
,CountryID
  FROM Persons
  where PersonID=@ID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ID", id);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    FirstName = (string)Reader["FirstName"];
                    LastName = (string)Reader["LastName"];
                    Phone = (string)Reader["Phone"];
                    DateOfBirth = (DateTime)Reader["BirthDate"];
                    Gender = Convert.ToChar(Reader["Gender"]);
                    AccountID = Convert.ToInt32(Reader["AccountID"]);
                    
                    CountryID = Convert.ToInt32(Reader["CountryID"]);
                    IsFound= true;
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


     static   public int AddNewPerson(string FirstName,
          string LastName, string Phone, DateTime DateOfBirth
         , char Gender, int AccountID,int CountryID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int PersonID = -1;
           
            string Query = @"INSERT INTO Persons
           (FirstName
           ,LastName
           ,Phone
           ,BirthDate
           ,Gender
           ,AccountID
,CountryID)
     VALUES
           (@FirstName
           ,@LastName
           ,@Phone
           ,@BirthDate
           ,@Gender
           ,@AccountID,
@CountryID)
		   select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@BirthDate", DateOfBirth);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@AccountID", AccountID);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null&&int.TryParse(Convert.ToString(Result),out int InsertedID))
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



        static public bool UpdatePerson(int PersonID,string FirstName,
        string LastName, string Phone, DateTime DateOfBirth
       , char Gender, int CountryID)
        {
            bool Updated = false;
            if(!IsExist(PersonID)) return Updated;



          
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

       
            string Query = @"UPDATE Persons
   SET FirstName = @FirstName
      ,LastName = @LastName
      ,Phone = @Phone
      ,BirthDate = @BirthDate
      ,Gender = @Gender
,CountryID=@CountryID
 WHERE PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@BirthDate", DateOfBirth);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();
                int RowsAffected = Command.ExecuteNonQuery();
                if (RowsAffected>0)
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


//        static public int GetAccountIDByPersonID(int Personid)
//        {

//            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
//            int AccountID = -1;
//            string Query = @"SELECT    
//AccountID
//  FROM Persons
//  where PersonID=@ID";
//            SqlCommand Command = new SqlCommand(Query, Connection);
//            Command.Parameters.AddWithValue("@ID", Personid);
//            try
//            {
//                Connection.Open();
//                object Result = Command.ExecuteScalar();
//                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
//                {
//                    AccountID = InsertedID;
//                }
//            }
//            catch (Exception ex) { }
//            finally
//            {
//                Connection.Close();

//            }

//            return AccountID;







//        }
        static public bool IsExist(int PersonID)
        {
            bool Exist=false;
SqlConnection connection=new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select Found=1 from Persons 
                          where personID=@PersonID";
            SqlCommand Command=new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            try { 
            
            connection.Open();
           SqlDataReader Reader= Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Exist = true;
                }
            }
            catch (Exception ex) { }
            finally {connection.Close(); }

            return Exist;


        }

        static public bool DeletePerson(int ID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(ID))
                return Deleteed;
            string Querey = @"DELETE FROM Persons
                            WHERE PersonID=@PersonID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@PersonID", ID);
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






        static public DataTable GetAllPersons()
        {
            DataTable dtPersons = new DataTable();
            SqlConnection Connection=new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT Persons.PersonID , Persons.FirstName, Persons.LastName, Persons.Phone, Persons.BirthDate, Persons.Gender, Persons.AccountID, Countries.CountryName
FROM     Persons INNER JOIN
                  Countries ON Persons.CountryID = Countries.CountryID";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtPersons.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtPersons;











        }

      




    }
}
