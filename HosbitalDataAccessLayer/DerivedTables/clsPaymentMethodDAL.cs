using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.DerivedTables
{
    static public class clsPaymentMethodDAL
    {


        
    


        static public int AddNewPaymentMethod(string Method)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int MethodID = -1;
            string Query = @"INSERT INTO PaymentMethods
           (Method
          )
     VALUES
           (@Method
           )
select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Method", Method);
         

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    MethodID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return MethodID;


        }

        static public bool GetPaymentMethodInfoByID(int MethodID, ref string Method)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Method
  FROM PaymentMethods
where MethodID=@MethodID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@MethodID", MethodID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    Method = Convert.ToString(Reader["Method"]);
                   

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

        static public bool IsExist(int PaymentMethodID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Found=1
  FROM paymentMethods
where MethodID=@MethodID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@MethodID", PaymentMethodID);

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

        static public bool IsExist(string PaymentMethod)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Found=1
  FROM PaymentMethods
where Method=@PaymentMethod";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PaymentMethod", PaymentMethod);

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
        static public bool DeleteMethod(int PaymentMethodID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(PaymentMethodID))
                return Deleteed;
            string Querey = @"DELETE FROM PaymentMethods
                            WHERE MethodID=@MethodID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@MethodID", PaymentMethodID);
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

        static public bool UpdateMethod(int PaymentMethodID, string PaymentMethod)
        {
            bool Updated = false;

            if (!IsExist(PaymentMethodID)) return Updated;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);


            string Query = @"
UPDATE PaymentMethods
   SET Method = @PaymentMethod
 WHERE MethodID=@MethodID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@MethodID", PaymentMethodID);

            Command.Parameters.AddWithValue("@PaymentMethod", PaymentMethod);

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

        static public DataTable GetAllMethods()
        {
            DataTable dtPaymentMethods = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = "select * from PaymentMethods";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtPaymentMethods.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtPaymentMethods;











        }

    }














}

