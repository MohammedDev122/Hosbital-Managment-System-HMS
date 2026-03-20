using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer
{
    static public class clsBanckAcountDAL
    {


        static public int AddNewBankAccount(string AccountNum,
             string Password, double AmmountOfMoney)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int AccountID = -1;
            string Query = @"INSERT INTO BankAccounts
           (Password
           ,Name
           ,Ammount)
     VALUES
           (@Password
           ,@Name
           ,@Ammount)
select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@Name", AccountNum);
            Command.Parameters.AddWithValue("@Ammount", AmmountOfMoney);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    AccountID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return AccountID;


        }

        static public bool GetBankAccountInfoByID(int id, ref string AccountNum, ref double AmmountOfMoney,
           ref string Password)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Password
      ,Name
      ,Ammount
  FROM BankAccounts
where AccountID=@AccountID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountID", id);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    AccountNum = Convert.ToString(Reader["Name"]);
                    Password = Convert.ToString(Reader["Password"]);
                    AmmountOfMoney = Convert.ToDouble(Reader["Ammount"]);

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

        static public bool UpdateBankAccountInfo(int id, string AccountNum, double AmmountOfMoney,
            string Password)
        {
            bool Updated = false;
            if (!IsExist(id))
                return Updated;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE BankAccounts
                           SET Password = @Password
                           ,Name =@Name
                           ,Ammount = @Ammount
                           WHERE AccountID=@AccountID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Name", AccountNum);
            command.Parameters.AddWithValue("@Ammount", AmmountOfMoney);
            command.Parameters.AddWithValue("@AccountID", id);
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
        static public bool IsExist(int ID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Found=1
  FROM BankAccounts
where AccountID=@AccountID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountID", ID);

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

        static public bool IsExist(string AccountNum)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Found=1
  FROM BankAccounts
where Name=@Name";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Name", AccountNum);

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
        static public bool DeleteAccount(int ID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(ID))
                return Deleteed;
            string Querey = @"DELETE FROM BankAccounts
                            WHERE AccountID=@AccountID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@AccountID", ID);
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



        static public DataTable GetAllBankAccounts()
        {
            DataTable dtBankAccounts = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = "select * from BankAccounts";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtBankAccounts.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtBankAccounts;











        }

    }
}
