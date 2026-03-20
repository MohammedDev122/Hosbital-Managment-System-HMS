using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.procedures
{
    public static class clsPharmacyRecordDAL

    {
        //PharmacyRecords
        static public bool GetPharmacyRecInfo(int RecordID, ref int PharmacistID, ref int PatientId, ref int PrescriptionID, ref int PaymentID, ref DateTime? Date,ref int BasketID)
        {
            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
SELECT 
      PharmacistID
      ,PatientId
      ,PrescriptionID
      ,PaymentID
      ,Date
,BasketID
  FROM PharmacyRecords
  where RecordID=@RecordID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@RecordID", RecordID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {

                    PharmacistID = Convert.ToInt32(Reader["PharmacistID"]);


                    PatientId = Convert.ToInt32(Reader["PatientId"]);
                    PrescriptionID = Convert.ToInt32(Reader["PrescriptionID"]);
                    PaymentID = Convert.ToInt32(Reader["PaymentID"]);
                    BasketID = Convert.ToInt32(Reader["BasketID"]); ;
                    if (DateTime.TryParse(Convert.ToString(Reader["Date"]),out DateTime date))
                    {
                        Date=date;
                    }
                    else
                    {
                        Date = null;
                    }

                    Found = true;



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Found;




        }
        static public int AddNewRecord(int PharmacistID, int PatientId, int PrescriptionID, int PaymentID, DateTime? Date,int BasketID)
        {
            int RecordID = -1;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
INSERT INTO PharmacyRecords
           (PharmacistID
           ,PatientId
           ,PrescriptionID
           ,PaymentID
           ,Date
,BasketID
           )
     VALUES
           (@PharmacistID
           ,@PatientId
           ,@PrescriptionID
           ,@PaymentID
           ,@Date
,@BasketID)

		   select SCOPE_IDENTITY();
";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PharmacistID", PharmacistID);
            command.Parameters.AddWithValue("@PatientId", PatientId);
            command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);
            command.Parameters.AddWithValue("@BasketID", BasketID);

            if (Date!=null)
            command.Parameters.AddWithValue("@Date", Date);
            else
                command.Parameters.AddWithValue("@Date", DBNull.Value);




            try
            {

                Connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null & int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    RecordID = InsertedID;





                }





            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return RecordID;




        }



        static public bool UpdatePharmacyRecInfo(int RecordID, int PharmacistID, int PatientId, int PrescriptionID, int PaymentID, DateTime? Date,int BasketID)
        {
            bool Updated = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE PharmacyRecords
   SET PharmacistID = @PharmacistID
      ,PatientId = @PatientId
      ,PrescriptionID = @PrescriptionID
      ,PaymentID = @PaymentID
      ,Date = @Date
,BasketID=@BasketID
 WHERE RecordID=@RecordID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PharmacistID", PharmacistID);
            command.Parameters.AddWithValue("@PatientId", PatientId);
            command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);
            command.Parameters.AddWithValue("@BasketID", BasketID);

            if (Date != null)
                command.Parameters.AddWithValue("@Date", Date);
            else
                command.Parameters.AddWithValue("@Date", DBNull.Value);
            command.Parameters.AddWithValue("@RecordID", RecordID);



            try
            {
                Connection.Open();
                int Result = command.ExecuteNonQuery();
                if (Result > 0)
                {

                    Updated = true;
                }
            }
            catch (Exception ex) { }
            finally { Connection.Close(); }


            return Updated;




        }


        static public bool DeleteRec(int RecordID)
        {




            bool Delete = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"Delete from PharmacyRecords
 WHERE RecordID=@RecordID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@RecordID", RecordID);


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


        static public DataTable GetAllPharmacyRecs()
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            DataTable dtPharmecyRec = new DataTable();
            string Query = @"SELECT PharmacyRecords.RecordID,PharmecyBasket.NumOfItems, PharmacyRecords.PharmacistID, Persons.FirstName+' '+ Persons.LastName as PharmacistName, PharmacyRecords.PatientId, Persons_1.FirstName +' '+ Persons_1.LastName AS PatientName, 
                  PharmacyRecords.PrescriptionID, 
                  PharmacyRecords.PaymentID, PaymentStatus.Status as PaymentState
FROM     PharmacyRecords INNER JOIN
                  Pharmacists ON PharmacyRecords.PharmacistID = Pharmacists.PharmacistID INNER JOIN
                  Patients ON PharmacyRecords.PatientId = Patients.PatientID INNER JOIN
                  Persons AS Persons_1 ON Patients.PersonID = Persons_1.PersonID INNER JOIN
                  Employees ON Pharmacists.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID INNER JOIN
                
                  Prescriptions ON PharmacyRecords.PrescriptionID = Prescriptions.PrescriptionID INNER JOIN
                  PrescriptionStates ON Prescriptions.PrescriptionStateID = PrescriptionStates.ID INNER JOIN
                  Payments ON PharmacyRecords.PaymentID = Payments.PaymentID INNER JOIN
                  PaymentStatus ON Payments.PaymentStatusID = PaymentStatus.StatusID left join 
				  PharmecyBasket on PharmacyRecords.BasketID=PharmecyBasket.BasketID
";
            SqlCommand command = new SqlCommand(Query, Connection);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dtPharmecyRec.Load(Reader);


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtPharmecyRec;




        }

        static public DataTable GetAllPharmacyRecsForPatient(int PatientID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            DataTable dtPharmecyRec = new DataTable();
            string Query = @"SELECT PharmacyRecords.RecordID,PharmecyBasket.NumOfItems, PharmacyRecords.PharmacistID, Persons.FirstName+' '+ Persons.LastName as PharmacistName, PharmacyRecords.PatientId, Persons_1.FirstName +' '+ Persons_1.LastName AS PatientName, 
                  PharmacyRecords.PrescriptionID, 
                  PharmacyRecords.PaymentID, PaymentStatus.Status as PaymentState
FROM     PharmacyRecords INNER JOIN
                  Pharmacists ON PharmacyRecords.PharmacistID = Pharmacists.PharmacistID INNER JOIN
                  Patients ON PharmacyRecords.PatientId = Patients.PatientID INNER JOIN
                  Persons AS Persons_1 ON Patients.PersonID = Persons_1.PersonID INNER JOIN
                  Employees ON Pharmacists.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID INNER JOIN
                
                  Prescriptions ON PharmacyRecords.PrescriptionID = Prescriptions.PrescriptionID INNER JOIN
                  PrescriptionStates ON Prescriptions.PrescriptionStateID = PrescriptionStates.ID INNER JOIN
                  Payments ON PharmacyRecords.PaymentID = Payments.PaymentID INNER JOIN
                  PaymentStatus ON Payments.PaymentStatusID = PaymentStatus.StatusID left join 
				  PharmecyBasket on PharmacyRecords.BasketID=PharmecyBasket.BasketID

where patients.patientID=@patientID
";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PatientID", PatientID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dtPharmecyRec.Load(Reader);


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtPharmecyRec;




        }

        static public bool ISExist(int RecordID)
        {
            bool Exist = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
SELECT 
     Found=1 from PharmacyRecords
  where RecordID=@RecordID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@RecordID", RecordID);
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







    }
}
