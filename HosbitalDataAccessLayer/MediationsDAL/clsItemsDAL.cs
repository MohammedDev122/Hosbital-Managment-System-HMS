using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.MediationsDAL
{
    public static class clsItemsDAL


    { //PharmecyBasketItems
        static public int AddNewItem(
                int PrescripedMedID, double Price, int BasketID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int ItemID = -1;
            string Query = @"
INSERT INTO PharmecyBasketItems
           (PrescripedMedID
           ,Price
,BasketID)
     VALUES
               (@PrescripedMedID
           ,@Price
,@BasketID)
			 select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PrescripedMedID", PrescripedMedID);
            Command.Parameters.AddWithValue("@Price", Price);
            Command.Parameters.AddWithValue("@BasketID", BasketID);
          

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    ItemID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return ItemID;


        }

        static public bool GetItemInfoByID(int ItemID, ref int PrescripedMedID, ref double Price, ref int BasketID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT ItemID
      ,PrescripedMedID
,Price
,BasketID
     
  FROM PharmecyBasketItems
where ItemID=@ItemID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ItemID", ItemID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    Price = Convert.ToDouble(Reader["Price"]);
                    PrescripedMedID = Convert.ToInt32(Reader["PrescripedMedID"]);
                    BasketID = Convert.ToInt32(Reader["BasketID"]);


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

        static public bool UpdateItemInfo(int ItemID,int PrescripedMedID, double Price, int BasketID)
        {
            bool Updated = false;
            if (!IsExist(ItemID))
                return Updated;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE PharmecyBasketItems
                           SET 
                           PrescripedMedID =@PrescripedMedID
                           ,Price =@Price
 ,BasketID =@BasketID
                           WHERE ItemID=@ItemID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ItemID", ItemID);
            command.Parameters.AddWithValue("@PrescripedMedID", PrescripedMedID);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@BasketID", BasketID);
          
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
        static public bool IsExist(int ItemID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Found=1
  FROM PharmecyBasketItems
where ItemID=@ItemID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ItemID", ItemID);

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

        static public bool DeleteItem(int ItemID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(ItemID))
                return Deleteed;
            string Querey = @"DELETE FROM PharmecyBasketItems
                            WHERE ItemID=@ItemID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@ItemID", ItemID);
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


        static public bool DeleteItemByPrescripedMedID(int PrescripedMedID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
           
            string Querey = @"DELETE FROM PharmecyBasketItems
                            WHERE PrescripedMedID=@PrescripedMedID ";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@PrescripedMedID", PrescripedMedID);
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



        static public DataTable GetAllItemsForBasket(int BasketID)
        {
            DataTable dtItems = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT PharmecyBasketItems.ItemID,  Medications.MedicationName,PharmecyBasketItems.Price
FROM     PharmecyBasketItems INNER JOIN
                  PrescripedMedications ON PharmecyBasketItems.PrescripedMedID = PrescripedMedications.PrescriptionMedID INNER JOIN
                  PrescripedMedState ON PrescripedMedications.PMStateID = PrescripedMedState.ID INNER JOIN
                  Medications ON PrescripedMedications.MedicationID = Medications.MedicationID
				  where PharmecyBasketItems.BasketID=@BasketID
";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@BasketID", BasketID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtItems.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtItems;











        }










    }
}
