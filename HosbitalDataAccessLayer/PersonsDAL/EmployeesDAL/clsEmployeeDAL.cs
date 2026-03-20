using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer
{
    static public class clsEmployeeDAL
    {






        static public bool GetEmployeeInfoByID(int id
        ,ref double Salery, ref int DepartmentID, ref byte WorkingDays,ref int personID,ref int StateID,ref DateTime EmployementDate, ref DateTime? DueDate)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT 
      PersonID
      ,Salery
      ,DepartmentID
      ,WorkingDays
,StateID
,EmployementDate
,DueDate
  FROM Employees
where EmployeeID=@ID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ID", id);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    Salery = Convert.ToDouble(Reader["Salery"]);
                    WorkingDays = Convert.ToByte(Reader["WorkingDays"]);
                    DepartmentID = Convert.ToInt32(Reader["DepartmentID"]);
                    personID = Convert.ToInt32(Reader["PersonID"]);
                    StateID = Convert.ToInt32(Reader["StateID"]);
                    EmployementDate = Convert.ToDateTime(Reader["EmployementDate"]);
                    if (DateTime.TryParse(Convert.ToString(Reader["DueDate"]), out DateTime Date))
                        DueDate = Date;
                    else
                        DueDate = null;
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

        static string _SearchEmployeeRoleQuery(int DepartmentID)
        {
            switch (DepartmentID)
            {

                case (5):
                    return @" SELECT
       NurseID
  FROM Nurses
  where EmployeeID = @ID";
                        break;
                case (6):
                    return @"   SELECT
       PharmacistID
  FROM Pharmacists
  where EmployeeID = @ID";
                    break;
                case (9):
                    return @" SELECT
       DoctorID
  FROM Doctors
  where EmployeeID = @ID";
                    break;
                case (10):
                    return @"  SELECT
      AccountantID
  FROM Accountants
  where EmployeeID = @ID";
                    break;
                default:
                    return "-1";




            }





        }

        static public int GetEmployeeRoleIDByEmployeeID(int id,int DepatmentID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int RoleID = -1;
            string Query = _SearchEmployeeRoleQuery(DepatmentID);
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ID", id);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    RoleID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return RoleID;

        }

        static public int AddNewEmployee(double Salery, int Department, int PersonID, DateTime EmployementDate, DateTime? DueDate, byte WorkingDays = 0, int StateID = 1)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int EmployeeID = -1;
            if (!clsPersonDAL.IsExist(PersonID))
                return EmployeeID;
            if (IsAlreadyAsigned(PersonID))
                return EmployeeID;
            string Query = @"INSERT INTO Employees
           (PersonID
           ,Salery
           ,DepartmentID
           ,WorkingDays,
StateID,
EmployementDate,
DueDate)
     VALUES
           (@PersonID
           ,@Salery
           ,@DepartmentID
           ,@WorkingDays,
@StateID,@EmployementDate,
@DueDate)
		   select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@Salery", Salery);
            Command.Parameters.AddWithValue("@DepartmentID", Department);
            Command.Parameters.AddWithValue("@WorkingDays", WorkingDays);
            Command.Parameters.AddWithValue("@StateID", StateID);
            Command.Parameters.AddWithValue("@EmployementDate", EmployementDate);
if(DueDate != null)
                Command.Parameters.AddWithValue("@DueDate", DueDate);
else
                Command.Parameters.AddWithValue("@DueDate", DBNull.Value);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    EmployeeID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return EmployeeID;













        }
      
        static public bool UpdateEmployee(int EmployeeID,double Salery, int DepartmentID, byte WorkingDays,int StateID, DateTime EmployementDate, DateTime? DueDate)
        {
            bool Updated = false;
            if (!IsExist(EmployeeID)) return Updated;      
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);


            string Query = @"UPDATE Employees
   SET 
      Salery = @Salery
      ,DepartmentID = @DepartmentID
     , WorkingDays = @WorkingDays
,StateID=@StateID
,EmployementDate=@EmployementDate
,DueDate=@DueDate
 WHERE  EmployeeID=@EmployeeID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Salery", Salery);
            Command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
            Command.Parameters.AddWithValue("@WorkingDays", WorkingDays);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            Command.Parameters.AddWithValue("@StateID", StateID);
            Command.Parameters.AddWithValue("@EmployementDate", EmployementDate);
            if (DueDate != null)
                Command.Parameters.AddWithValue("@DueDate", DueDate);
            else
                Command.Parameters.AddWithValue("@DueDate", DBNull.Value);



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
        static public bool IsExist(int EmployeeID)
        {
            bool Exist = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select Found=1 from Employees 
                          where EmployeeID=@EmployeeID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
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


    


        static public bool DeleteEmployee(int ID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(ID))
                return Deleteed;
            //if(!clsPersonDAL.DeletePerson(GetPersonIDByEmployeeID(ID)))
            // return Deleteed;
            string Querey = @"DELETE FROM Employees
                            WHERE EmployeeID=@EmployeeID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@EmployeeID", ID);
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





        static public DataTable GetAllEmployees()
        {
            DataTable dtEmployees = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT Employees.EmployeeID, Persons.FirstName, Persons.LastName, Persons.Phone, Persons.BirthDate, Persons.Gender, Persons.AccountID, Countries.CountryName, Employees.Salery, Departments.DepartmentName, 
                  Employees.WorkingDays, EmployeeStates.State, Employees.EmployementDate, Employees.DueDate
FROM     Employees INNER JOIN
                  EmployeeStates ON Employees.StateID = EmployeeStates.StateID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID INNER JOIN
                  Departments ON Employees.DepartmentID = Departments.DepartmentID INNER JOIN
                  Countries ON Persons.CountryID = Countries.CountryID";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtEmployees.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtEmployees;











        }
      
        static public bool GetEmployeeInfoByPersonID(int Personid
       , ref double Salery, ref int DepartmentID, ref byte WorkingDays, ref int EmployeeID,ref int StateID, ref DateTime EmployementDate, ref DateTime? DueDate)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT 
EmployeeID
      
      ,Salery
      ,DepartmentID
      ,WorkingDays
,StateID
,EmployementDate
,DueDate
  FROM Employees
where PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", Personid);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    Salery = Convert.ToDouble(Reader["Salery"]);
                    WorkingDays = Convert.ToByte(Reader["WorkingDays"]);
                    DepartmentID = Convert.ToInt32(Reader["DepartmentID"]);
                    EmployeeID = Convert.ToInt32(Reader["EmployeeID"]);
                    StateID = Convert.ToInt32(Reader["StateID"]);
                    EmployementDate = Convert.ToDateTime(Reader["EmployementDate"]);
                    if (DateTime.TryParse(Convert.ToString(Reader["DueDate"]),out DateTime Date))
                        DueDate = Convert.ToDateTime(Reader["DueDate"]);
                    else
                        DueDate =null;

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


        static bool IsAlreadyAsigned(int PersonID)
        {
            bool Assigned = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select found=1 from Employees where PersonID=@PersonID

";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
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
