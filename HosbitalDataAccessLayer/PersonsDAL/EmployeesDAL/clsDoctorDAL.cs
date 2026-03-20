using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace HosbitalDataAccessLayer
{
  static  public class clsDoctorDAL
    {

        static public bool GetDoctorInfoByID(int DoctorID,ref int EmployeeID,
           ref int SpecilizationID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound=false;  
            string Query = @"
SELECT 
       *
  FROM Doctors
  where DoctorID=@DoctorID
";

SqlCommand Command = new SqlCommand(Query,Connection);
            Command.Parameters.AddWithValue("@DoctorID", DoctorID);
            try { 
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read()) {


                    SpecilizationID = Convert.ToInt32(Reader["SpecilizationID"]);
                    EmployeeID = Convert.ToInt32(Reader["EmployeeID"]);
                    IsFound = true;

                }

                


            }
            catch (Exception ex) { }
            finally { 
            Connection.Close();
            
            }

            return IsFound;







        }
        static public DateTime? GetDoctorDueTime(int EmployeeID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            DateTime? DueDate = null;
            string Query = @"SELECT TOP (1) Services.Date
FROM     Diagnoisis INNER JOIN
                  Services ON Diagnoisis.ServiceID = Services.ServiceID INNER JOIN
                  Doctors ON Diagnoisis.DoctorID = Doctors.DoctorID INNER JOIN
                  Employees ON Doctors.EmployeeID = Employees.EmployeeID
				  where Employees.EmployeeID=@EmployeeID and Services.ServiceStateID=@StateID
				  order by Services.Date desc
";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            Command.Parameters.AddWithValue("@StateID", 2);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    if (DateTime.TryParse(Convert.ToString(Reader["Date"]), out DateTime Date))
                        DueDate = Date;
                    else
                        DueDate = null;

                   

                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return DueDate;







        }


        static public int AddNewDoctor(int EmployeeID,
            int specilizationID
           )
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int DoctorID = -1;
            if (!clsEmployeeDAL.IsExist(EmployeeID))
                return DoctorID;
            if (IsAlreadyAsigned(EmployeeID))
                return DoctorID;

            string Query = @"INSERT INTO Doctors
           (EmployeeID
           ,SpecilizationId)
     VALUES
           (@EmployeeID
           ,@SpecilizationId)
		   select SCOPE_IDENTITY();";


            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            Command.Parameters.AddWithValue("@SpecilizationId", specilizationID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    DoctorID = InsertedID;



                }


            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return DoctorID;













        }
        static public bool IsExist(int DoctorID)
        {
            bool Exist = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select Found=1 from Doctors 
                          where DoctorID=@DoctorID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@DoctorID", DoctorID);
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
        static public bool UpdateDoctor(int DoctorID, int SpecilizationID)
        {
            bool Updated = false;
            if (!IsExist(DoctorID)) return Updated;           
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE Doctors
   SET 
      SpecilizationId = @SpecilizationId
 WHERE DoctorID=@DoctorID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@SpecilizationId", SpecilizationID);
            Command.Parameters.AddWithValue("@DoctorID", DoctorID);
     
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
        static public bool DeleteDoctor(int DoctorID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(DoctorID))
                return Deleteed;
          
            string Querey = @"DELETE FROM Doctors
                            WHERE DoctorID=@DoctorID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@DoctorID", DoctorID);
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

        static public DataTable GetAllDoctorsforAdmin()
        {
            DataTable dtDoctors = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = "select * from DoctorAllInfoForAdmin";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtDoctors.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtDoctors;











        }
      
        static public DataTable GetAllDoctorsforOthers()
        {
            DataTable dtDoctors = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = "select * from DoctorAllInfoForOthers";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtDoctors.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtDoctors;











        }

        static bool IsAlreadyAsigned(int EmployeeID)
        {
            bool Assigned = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select found=1 from Doctors where EmployeeID=@employeeID


";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@employeeID", EmployeeID);
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
