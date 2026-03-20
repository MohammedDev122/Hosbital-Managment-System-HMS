using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace HosbitalDataAccessLayer.LogsDAL
{
    public static class clsLoginsDAL

    {
        //Logins
        static public bool GetLoginInfoByID(int ID, ref string LoginName,
            ref string Password, ref byte Permissions, ref int EmployeeID
            , ref string PhotoPath, ref int StatusID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT 
      LoginName
      ,Password
      ,Permissions
      ,EmployeeID
,PhotoPath
      ,StatusID
  FROM Logins
  where ID=@ID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ID", ID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    LoginName = (string)Reader["LoginName"];
                    Password = (string)Reader["Password"];
                    Permissions = (byte)Reader["Permissions"];
                    EmployeeID = (int)Reader["EmployeeID"];
                    
                    PhotoPath = Convert.ToString(Reader["PhotoPath"]);
                    StatusID = Convert.ToInt32(Reader["StatusID"]);
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
        static public bool GetLoginInfoByEmployeeID(int EmployeeID, ref string LoginName,
          ref string Password, ref byte Permissions, ref int ID 
          , ref string PhotoPath, ref int StatusID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT 
      LoginName
      ,Password
      ,Permissions
      ,ID
,PhotoPath
      ,StatusID
  FROM Logins
  where EmployeeID=@EmployeeID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    LoginName = (string)Reader["LoginName"];
                    Password = (string)Reader["Password"];
                    Permissions = (byte)Reader["Permissions"];
                    ID = (int)Reader["ID"];

                    PhotoPath = Convert.ToString(Reader["PhotoPath"]);
                    StatusID = Convert.ToInt32(Reader["StatusID"]);
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
        static public bool GetLoginInfoByLoginName(string LoginName , ref int EmployeeID,
        ref string Password, ref byte Permissions, ref int ID
        , ref string PhotoPath, ref int StatusID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT 
      EmployeeID
      ,Password
      ,Permissions
      ,ID
,PhotoPath
      ,StatusID
  FROM Logins
  where LoginName=@LoginName";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LoginName", LoginName);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    EmployeeID =Convert.ToInt32(Reader["EmployeeID"]);
                    Password = (string)Reader["Password"];
                    Permissions = (byte)Reader["Permissions"];
                    ID = (int)Reader["ID"];

                    PhotoPath = Convert.ToString(Reader["PhotoPath"]);
                    StatusID = Convert.ToInt32(Reader["StatusID"]);
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
        static  bool GetLoginIDByLoginName(string LoginName, ref int ID
   )
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT 
     
      ID
  FROM Logins
  where LoginName=@LoginName";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LoginName", LoginName);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                   
                    ID = (int)Reader["ID"];

                   
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
        static public int AddNewLogins(string LoginName,
             string Password, byte Permissions, int EmployeeID
            , string PhotoPath, int StatusID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int ID = -1;
            if (IsExist(LoginName))
            {
                return -1;
            }
            string Query = @"INSERT INTO Logins
           (LoginName
           ,Password
           ,Permissions
           ,EmployeeID
           ,PhotoPath
           ,StatusID
)
     VALUES
           (@LoginName
           ,@Password
           ,@Permissions
           ,@EmployeeID
           ,@PhotoPath
           ,@StatusID
)
		   select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LoginName", LoginName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@Permissions", Permissions);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            if (PhotoPath == string.Empty)
            {
                Command.Parameters.AddWithValue("@PhotoPath", DBNull.Value);

            }
            else
            Command.Parameters.AddWithValue("@PhotoPath", PhotoPath);
            Command.Parameters.AddWithValue("@StatusID", StatusID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    ID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return ID;
        }



        static public bool UpdateLogins(int ID, string LoginName,
             string Password, byte Permissions, int EmployeeID
            , string PhotoPath, int StatusID)
        {
            bool Updated = false;
            if (!IsExist(ID)) return Updated;



            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            if (IsExist(LoginName))
            {
                int x = -1;
                GetLoginIDByLoginName(LoginName, ref x);
                if (ID != x)
                {
                    return false;
                }
            }

            string Query = @"UPDATE Logins
   SET LoginName = @LoginName
      ,Password = @Password
      ,Permissions = @Permissions
      ,EmployeeID = @EmployeeID
      ,PhotoPath = @PhotoPath
,StatusID=@StatusID
 WHERE ID=@ID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LoginName", LoginName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@Permissions", Permissions);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            Command.Parameters.AddWithValue("@PhotoPath", PhotoPath);
            Command.Parameters.AddWithValue("@StatusID", StatusID);
            Command.Parameters.AddWithValue("@ID", ID);

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
        static public bool IsExist(int ID)
        {
            bool Exist = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select Found=1 from Logins 
                          where ID=@ID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@ID", ID);
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
        static public bool IsExist(string LoginName)
        {
            bool Exist = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select Found=1 from Logins 
                          where LoginName=@LoginName";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@LoginName", LoginName);
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

        static public bool DeleteLogin(int ID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(ID))
                return Deleteed;
            string Querey = @"DELETE FROM Logins
                            WHERE ID=@ID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@ID", ID);
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






        static public DataTable GetAllLogins()
        {
            DataTable dtLogins = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = "select Logins.ID As LoginID,LoginName,Password,Permissions,EmployeeID,PhotoPath,LogStatus.Status from Logins inner join LogStatus on Logins.StatusID=LogStatus.ID";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtLogins.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtLogins;











        }











    }
}
