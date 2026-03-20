using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.MediationsDAL
{
    static public class clsBasketDAL

    { //PharmecyBasket
        static public int AddNewBasket(
                 double TotalPrice, Int16 NumOfItems)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int BasketID = -1;
            string Query = @"
INSERT INTO PharmecyBasket
           (TotalPrice
           ,NumOfItems
)
     VALUES
               (@TotalPrice
           ,@NumOfItems
)
			 select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TotalPrice", TotalPrice);
            Command.Parameters.AddWithValue("@NumOfItems", NumOfItems);
          

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    BasketID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return BasketID;


        }

        static public bool GetBasketInfoByID(int BasketID, ref double TotalPrice, ref Int16 NumOfItems)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT BasketID
      ,TotalPrice
,NumOfItems
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


                    NumOfItems = Convert.ToInt16(Reader["NumOfItems"]);
                    TotalPrice = Convert.ToDouble(Reader["TotalPrice"]);


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
        
                    static public int getPharmecyRecordIDbyBasketID(int BasketID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int RecordID = -1;
            string Query = @"SELECT PharmacyRecords.RecordID
FROM     PharmecyBasket INNER JOIN
                  PharmacyRecords ON PharmecyBasket.BasketID = PharmacyRecords.BasketID
where PharmecyBasket.BasketID=@BasketID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@BasketID", BasketID);
            try
            {
                Connection.Open();
                Object Result = Command.ExecuteScalar();
                if (Result != null)
                {


                    RecordID = Convert.ToInt32(Result);


                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return RecordID;







        }

        static public int GetPrescriptionIDByBasketID(int BasketID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int PrescriptionID = -1;
            string Query = @"SELECT PharmacyRecords.PrescriptionID
FROM     PharmecyBasket INNER JOIN
                  PharmacyRecords ON PharmecyBasket.BasketID = PharmacyRecords.BasketID
where PharmecyBasket.BasketID=@BasketID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@BasketID", BasketID);
            try
            {
                Connection.Open();
Object Result=Command.ExecuteScalar();
                if (Result!=null)
                {


                    PrescriptionID = Convert.ToInt32(Result);


                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return PrescriptionID;







        }

        static public bool UpdateBasketInfo(int BasketID,  double TotalPrice,  Int16 NumOfItems)
        {
            bool Updated = false;
            if (!IsExist(BasketID))
                return Updated;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE PharmecyBasket
                           SET TotalPrice = @TotalPrice
                           ,NumOfItems =@NumOfItems
                         
                           WHERE BasketID=@BasketID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@BasketID", BasketID);
            command.Parameters.AddWithValue("@TotalPrice", TotalPrice);
            command.Parameters.AddWithValue("@NumOfItems", NumOfItems);
          

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



  












    }
}
