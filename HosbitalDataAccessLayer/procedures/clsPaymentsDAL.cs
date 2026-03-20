using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.procedures
{
    static public class clsPaymentsDAL
    {

        static public bool GetPaymentInfo(int PaymentID, ref int PaymentMethodID, ref double PayedAmmount, ref DateTime? PaymentDate, ref int AccountantID, ref int AccountID, ref int PaymentStatusID)
        {
            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
SELECT 
      PaymentMethodID
      ,AccountantID
      ,AccountID
      ,PaymentAmmount
      ,PaymentDate
      ,PaymentStatusID
  FROM Payments
  where PaymentID=@PaymentID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);
            try
            {

                Connection.Open();
               SqlDataReader Reader= command.ExecuteReader();
                if (Reader.Read())
                {

                    PaymentMethodID = Convert.ToInt32(Reader["PaymentMethodID"]);

                    if (int.TryParse(Convert.ToString(Reader["AccountantID"]), out int Accountant))
                        AccountantID = Accountant;
                    else
                        AccountantID = -1;
                    if (int.TryParse(Convert.ToString(Reader["AccountID"]), out int Account))
                        AccountID = Account;
                    else
                        AccountID = -1;
                    PaymentStatusID = Convert.ToInt32(Reader["PaymentStatusID"]);
                    PayedAmmount = Convert.ToDouble(Reader["PaymentAmmount"]);
                    if (DateTime.TryParse(Convert.ToString(Reader["PaymentDate"]), out DateTime date))
                        PaymentDate = date;
                    else
                        PaymentDate = null;
                    Found=true;



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Found;




        }
        static public int AddNewPayment(int PaymentMethodID,  double PayedAmmount,  DateTime? PaymentDate,  int AccountantID,  int AccountID,  int PaymentStatusID)
        {
            int PaymentID = -1;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
INSERT INTO Payments
           (PaymentMethodID
           ,AccountantID
           ,AccountID
           ,PaymentAmmount
           ,PaymentDate
           ,PaymentStatusID)
     VALUES
           (@PaymentMethodID
           ,@AccountantID
           ,@AccountID
           ,@PaymentAmmount
           ,@PaymentDate
           ,@PaymentStatusID)

		   select SCOPE_IDENTITY();
";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PaymentMethodID", PaymentMethodID);
            if (AccountantID != -1)
            {
                command.Parameters.AddWithValue("@AccountantID", AccountantID);
            }
            else
            {
                command.Parameters.AddWithValue("@AccountantID", DBNull.Value);
            }
            if (AccountID != -1)
            {
                command.Parameters.AddWithValue("@AccountID", AccountID);
            }
            else
            {
                command.Parameters.AddWithValue("@AccountID", DBNull.Value);
            }

            command.Parameters.AddWithValue("@PaymentAmmount", PayedAmmount);
            if (PaymentDate != null)
            {
                command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
            }
            else
            {
                command.Parameters.AddWithValue("@PaymentDate", DBNull.Value);
            }
            command.Parameters.AddWithValue("@PaymentStatusID", PaymentStatusID);
           

            try
            {

                Connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null & int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    PaymentID = InsertedID;





                }


                


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return PaymentID;




        }



        static public bool UpdatePaymentInfo(int PaymentID,  int PaymentMethodID,double PayedAmmount,  DateTime? PaymentDate,  int AccountantID,  int AccountID, int PaymentStatusID)
        {
            bool Updated=false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE Payments
   SET PaymentMethodID = @PaymentMethodID
      ,AccountantID = @AccountantID
      ,AccountID = @AccountID
      ,PaymentAmmount = @PaymentAmmount
      ,PaymentDate = @PaymentDate
      ,PaymentStatusID = @PaymentStatusID
 WHERE PaymentID=@PaymentID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PaymentMethodID", PaymentMethodID);
            if(AccountantID!=-1)
                command.Parameters.AddWithValue("@AccountantID", AccountantID);
           else
                command.Parameters.AddWithValue("@AccountantID", DBNull.Value);

            if (AccountID != -1)
            {
                command.Parameters.AddWithValue("@AccountID", AccountID);
            }
            else
            {
                command.Parameters.AddWithValue("@AccountID", DBNull.Value);
            }

            command.Parameters.AddWithValue("@PaymentAmmount", PayedAmmount);
          if(PaymentDate!=null)
                command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
            else
                command.Parameters.AddWithValue("@PaymentDate", DBNull.Value);

            command.Parameters.AddWithValue("@PaymentStatusID", PaymentStatusID);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);


            try
            {
                Connection.Open();
                int Result=command.ExecuteNonQuery();  
                if(Result > 0)
                {

Updated = true;
                }
            }
            catch(Exception ex) { }
            finally { Connection.Close(); }


            return Updated;




        }


        static public bool DeletePayment(int PaymentID)
        {




            bool Delete = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"Delete from Payments
 WHERE PaymentID=@PaymentID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);


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


   


        static public bool ISExist(int PaymentID)
        {
            bool Exist = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
SELECT 
     Found=1 from Payments
  where PaymentID=@PaymentID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);
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

        static public DataTable GetAllPayments()
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            DataTable dtPayments = new DataTable();
            string Query = @"
SELECT Payments.PaymentID, PaymentMethods.Method, Payments.AccountantID, Persons.FirstName, Persons.LastName, Payments.AccountID, Payments.PaymentAmmount, Payments.PaymentDate, PaymentStatus.Status
FROM     Payments INNER JOIN
                  PaymentMethods ON Payments.PaymentMethodID = PaymentMethods.MethodID left JOIN
                  Accountants ON Payments.AccountantID = Accountants.AccountantID  INNER JOIN
                  PaymentStatus ON Payments.PaymentStatusID = PaymentStatus.StatusID left JOIN
                  BankAccounts ON Payments.AccountID = BankAccounts.AccountID  left JOIN
                  Employees ON Accountants.EmployeeID = Employees.EmployeeID left JOIN
                  Persons on Employees.PersonID = Persons.PersonID";
            SqlCommand command = new SqlCommand(Query, Connection);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dtPayments.Load(Reader);


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtPayments;




        }
      





    }
}
