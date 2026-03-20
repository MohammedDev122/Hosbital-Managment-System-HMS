using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.DerivedTables
{
    public static class clsServicesTypesDAL
    {


        public static bool GetServiceTypeByID(int TypeID, ref string ServiceName,ref double ServiceCost)
        {
            bool Found = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"
select *
from ServicesTypes
where TypeID=@TypeID
";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TypeID", TypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    ServiceName = Convert.ToString(reader["ServiceName"]);
                    ServiceCost = Convert.ToDouble(reader["ServiceCost"]);
                    Found = true;

                }


            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return Found;
        }

        public static int AddNewType(string ServiceName,double ServiceCost)
        {

            int TypeID = -1;

            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"Insert into ServicesTypes (ServiceName,ServiceCost) 
values 
(@ServiceName,@ServiceCost)

select SCOPE_IDENTITY()
";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ServiceName", ServiceName);
            command.Parameters.AddWithValue("@ServiceCost", ServiceCost);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    TypeID = InsertedID;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }



            return TypeID;
        }


        public static bool UpdateType(int TypeID, string ServiceName,double ServiceCost)
        {

            bool Updated = false;

            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE ServicesTypes
   SET ServiceName = @ServiceName
,ServiceCost=@ServiceCost
 WHERE TypeID=@TypeID
";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TypeID", TypeID);
            command.Parameters.AddWithValue("@ServiceName", ServiceName);
            command.Parameters.AddWithValue("@ServiceCost", ServiceCost);


            try
            {
                connection.Open();
                int Result = command.ExecuteNonQuery();
                if (Result > 0)
                {
                    Updated = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }



            return Updated;
        }

        public static bool DeleteType(int TypeID)
        {


            bool Deleted = false;

            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"DELETE FROM ServicesTypes
      WHERE TypeID=@TypeID
";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TypeID", TypeID);

            try
            {
                connection.Open();
                int Result = command.ExecuteNonQuery();
                if (Result > 0)
                {
                    Deleted = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }



            return Deleted;






        }


        static public DataTable GetAllTypes()
        {

            DataTable DtServicesTypes = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"
select *
from ServicesTypes
";
            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {

                    DtServicesTypes.Load(reader);

                }


            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return DtServicesTypes;



        }



        public static bool Exist(int TypeID)
        {
            bool Found = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"
select found=1
from ServicesTypes
where TypeID=@TypeID
";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TypeID", TypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {


                    Found = true;

                }


            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return Found;
        }















    }
}
