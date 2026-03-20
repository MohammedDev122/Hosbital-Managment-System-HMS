using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.MediationsDAL
{
    static public class clsPharmecyBasketDAL


    { //PharmecyBasket
        static public int AddNewBasket(
                 int PharmecyRecordID, double TotalPrice)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int BasketID = -1;
            string Query = @"
INSERT INTO PharmecyBasket
           (PharmecyRecordID
           ,TotalPrice
)
     VALUES (@PharmecyRecordID
           , @TotalPrice
)
			 select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PharmecyRecordID", PharmecyRecordID);
            Command.Parameters.AddWithValue("@TotalPrice", TotalPrice);
         

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    PharmecyRecordID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return PharmecyRecordID;


        }

        static public bool GetBasketInfoByID(int BasketID,ref int PharmecyRecordID,ref double TotalPrice)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT BasketID
      ,PharmecyRecordID
,TotalPrice

     
  FROM PharmecyBasket
where BasketID=@BasketID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@BasketID", BasketID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {


                    TotalPrice = Convert.ToDouble(Reader["TotalPrice"]);
                    PharmecyRecordID = Convert.ToInt32(Reader["PharmecyRecordID"]);


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

        static public bool UpdateBasketInfo(int BasketID,  int PharmecyRecordID,  double TotalPrice)
        {
            bool Updated = false;
            if (!IsExist(BasketID))
                return Updated;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE PharmecyBasket
                           SET PharmecyRecordID = @PharmecyRecordID
                           ,TotalPrice =@TotalPrice
 
                           WHERE BasketID=@BasketID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@BasketID", BasketID);
            command.Parameters.AddWithValue("@PharmecyRecordID", PharmecyRecordID);
            command.Parameters.AddWithValue("@TotalPrice", TotalPrice);
           
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
        static public bool IsExist(int BasketID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Found=1
  FROM PharmecyBasket
where BasketID=@BasketID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@BasketID", BasketID);

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

        static public bool DeleteBasket(int BasketID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(BasketID))
                return Deleteed;
            string Querey = @"DELETE FROM PharmecyBasket
                            WHERE BasketID=@BasketID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@BasketID", BasketID);
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



        static public DataTable GetAllBaskets()
        {
            DataTable dtBaskets = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT PharmecyBasket.BasketID, PharmecyBasket.PharmecyRecordID, PharmacyRecords.PharmacistID, PharmacyRecords.PatientId, PharmecyBasket.TotalPrice
FROM     PharmecyBasket INNER JOIN
                  PharmacyRecords ON PharmecyBasket.PharmecyRecordID = PharmacyRecords.RecordID";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtBaskets.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtBaskets;











        }












    }
}
