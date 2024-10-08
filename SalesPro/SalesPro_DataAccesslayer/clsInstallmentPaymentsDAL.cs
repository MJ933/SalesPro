using System;
using System.Data;
using System.Data.SQLite;

namespace SalesPro_DataAccessLayer
{
    public class clsInstallmentPaymentsDAL
    {
        // Get an installment payment by PaymentID
        public static bool GetInstallmentPaymentByPaymentID(int PaymentID, ref int InstallmentID, ref DateTime PaymentDate,
            ref double PaymentAmount, ref string PaymentType, ref int UserID, ref string PaymentNotes,
            ref int PaymentStatusID)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM InstallmentPayments WHERE PaymentID = @PaymentID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PaymentID", PaymentID);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            InstallmentID = Convert.ToInt32(reader["InstallmentID"]);
                            PaymentDate = Convert.ToDateTime(reader["PaymentDate"]);
                            PaymentAmount = Convert.ToDouble(reader["PaymentAmount"]);
                            PaymentType = reader["PaymentType"].ToString();
                            UserID = Convert.ToInt32(reader["UserID"]);
                            PaymentNotes = reader["PaymentNotes"].ToString();
                            PaymentStatusID = Convert.ToInt32(reader["PaymentStatusID"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving installment payment: " + ex.Message);
                }
            }
            return IsFound;
        }
        public static bool GetInstallmentPaymentByInstallmentID(ref int PaymentID, int InstallmentID, ref DateTime PaymentDate,
            ref double PaymentAmount, ref string PaymentType, ref int UserID, ref string PaymentNotes,
            ref int PaymentStatusID)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM InstallmentPayments WHERE InstallmentID = @InstallmentID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@InstallmentID", InstallmentID);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            PaymentID = Convert.ToInt32(reader["PaymentID"]);
                            PaymentDate = Convert.ToDateTime(reader["PaymentDate"]);
                            PaymentAmount = Convert.ToDouble(reader["PaymentAmount"]);
                            PaymentType = reader["PaymentType"].ToString();
                            UserID = Convert.ToInt32(reader["UserID"]);
                            PaymentNotes = reader["PaymentNotes"].ToString();
                            PaymentStatusID = Convert.ToInt32(reader["PaymentStatusID"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving installment payment: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Get all installment payments
        public static DataTable GetAllInstallmentPayments()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM InstallmentPayments";

                SQLiteCommand command = new SQLiteCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dataTable1.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving installment payments: " + ex.Message);
                }
            }

            return dataTable1;
        }

        // Add a new installment payment with transaction
        public static int AddNewInstallmentPayment(int InstallmentID, DateTime PaymentDate, double PaymentAmount,
string PaymentType, int UserID, string PaymentNotes, int PaymentStatusID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Begin transaction
                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insert into InstallmentPayments
                            string insertQuery = @"
                    INSERT INTO InstallmentPayments (InstallmentID, PaymentDate, PaymentAmount, 
                                                     PaymentType, UserID, PaymentNotes, PaymentStatusID)
                    VALUES (@InstallmentID, @PaymentDate, @PaymentAmount, 
                            @PaymentType, @UserID, @PaymentNotes, @PaymentStatusID);
                    SELECT last_insert_rowid();";

                            SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection, transaction);
                            insertCommand.Parameters.AddWithValue("@InstallmentID", InstallmentID);
                            insertCommand.Parameters.AddWithValue("@PaymentDate", PaymentDate);
                            insertCommand.Parameters.AddWithValue("@PaymentAmount", PaymentAmount);
                            insertCommand.Parameters.AddWithValue("@PaymentType", PaymentType);
                            insertCommand.Parameters.AddWithValue("@UserID", UserID);
                            insertCommand.Parameters.AddWithValue("@PaymentNotes", PaymentNotes);
                            insertCommand.Parameters.AddWithValue("@PaymentStatusID", PaymentStatusID);

                            object result = insertCommand.ExecuteScalar();
                            int insertedID = Convert.ToInt32(result);

                            // Update Installments with conditional status update
                            string updateQuery = @"
                    UPDATE Installments SET
                        PaymentDate = @PaymentDate,
                        StatusID = CASE
                            WHEN @PaymentAmount >= (SELECT InstallmentAmount FROM Installments WHERE InstallmentID = @InstallmentID) THEN 2 -- Paid
                            WHEN @PaymentAmount < (SELECT InstallmentAmount FROM Installments WHERE InstallmentID = @InstallmentID) THEN 4 -- Partial Payment
                            ELSE 1 -- Pending
                        END
                    WHERE InstallmentID = @InstallmentID;";

                            SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection, transaction);
                            updateCommand.Parameters.AddWithValue("@PaymentDate", PaymentDate);
                            updateCommand.Parameters.AddWithValue("@PaymentAmount", PaymentAmount);
                            updateCommand.Parameters.AddWithValue("@InstallmentID", InstallmentID);

                            updateCommand.ExecuteNonQuery();

                            // Commit transaction
                            transaction.Commit();

                            return insertedID;
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction in case of error
                            transaction.Rollback();
                            Console.WriteLine("Transaction failed: " + ex.Message);
                            return -1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error adding new installment payment: " + ex.Message);
                    return -1;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        // Update an existing installment payment
        public static bool UpdateInstallmentPayment1(int PaymentID, int InstallmentID, DateTime PaymentDate,
            double PaymentAmount, string PaymentType, int UserID, string PaymentNotes, int PaymentStatusID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                UPDATE InstallmentPayments SET
                    InstallmentID = @InstallmentID,
                    PaymentDate = @PaymentDate,
                    PaymentAmount = @PaymentAmount,
                    PaymentType = @PaymentType,
                    UserID = @UserID,
                    PaymentNotes = @PaymentNotes,
                    PaymentStatusID = @PaymentStatusID
                WHERE PaymentID = @PaymentID;";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PaymentID", PaymentID);
                command.Parameters.AddWithValue("@InstallmentID", InstallmentID);
                command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
                command.Parameters.AddWithValue("@PaymentAmount", PaymentAmount);
                command.Parameters.AddWithValue("@PaymentType", PaymentType);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@PaymentNotes", PaymentNotes);
                command.Parameters.AddWithValue("@PaymentStatusID", PaymentStatusID);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error updating installment payment: " + ex.Message);
                    return false;
                }
            }
            return RowsAffected > 0;
        }
        // Update an existing installment payment
        public static bool UpdateInstallmentPayment(int PaymentID, int InstallmentID, DateTime PaymentDate,
            double PaymentAmount, string PaymentType, int UserID, string PaymentNotes, int PaymentStatusID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Begin transaction
                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Update InstallmentPayments
                            string updatePaymentQuery = @"
                    UPDATE InstallmentPayments SET
                        InstallmentID = @InstallmentID,
                        PaymentDate = @PaymentDate,
                        PaymentAmount = @PaymentAmount,
                        PaymentType = @PaymentType,
                        UserID = @UserID,
                        PaymentNotes = @PaymentNotes,
                        PaymentStatusID = @PaymentStatusID
                    WHERE PaymentID = @PaymentID;";

                            SQLiteCommand updatePaymentCommand = new SQLiteCommand(updatePaymentQuery, connection, transaction);
                            updatePaymentCommand.Parameters.AddWithValue("@PaymentID", PaymentID);
                            updatePaymentCommand.Parameters.AddWithValue("@InstallmentID", InstallmentID);
                            updatePaymentCommand.Parameters.AddWithValue("@PaymentDate", PaymentDate);
                            updatePaymentCommand.Parameters.AddWithValue("@PaymentAmount", PaymentAmount);
                            updatePaymentCommand.Parameters.AddWithValue("@PaymentType", PaymentType);
                            updatePaymentCommand.Parameters.AddWithValue("@UserID", UserID);
                            updatePaymentCommand.Parameters.AddWithValue("@PaymentNotes", PaymentNotes);
                            updatePaymentCommand.Parameters.AddWithValue("@PaymentStatusID", PaymentStatusID);

                            int RowsAffected = updatePaymentCommand.ExecuteNonQuery();

                            // Update Installments with conditional status update
                            string updateInstallmentQuery = @"
                    UPDATE Installments SET
                        PaymentDate = @PaymentDate,
                        StatusID = CASE
                            WHEN @PaymentAmount >= (SELECT InstallmentAmount FROM Installments WHERE InstallmentID = @InstallmentID) THEN 2 -- Paid
                            WHEN @PaymentAmount < (SELECT InstallmentAmount FROM Installments WHERE InstallmentID = @InstallmentID) THEN 4 -- Partial Payment
                            ELSE 1 -- Pending
                        END
                    WHERE InstallmentID = @InstallmentID;";

                            SQLiteCommand updateInstallmentCommand = new SQLiteCommand(updateInstallmentQuery, connection, transaction);
                            updateInstallmentCommand.Parameters.AddWithValue("@PaymentDate", PaymentDate);
                            updateInstallmentCommand.Parameters.AddWithValue("@PaymentAmount", PaymentAmount);
                            updateInstallmentCommand.Parameters.AddWithValue("@InstallmentID", InstallmentID);

                            updateInstallmentCommand.ExecuteNonQuery();

                            // Commit transaction
                            transaction.Commit();

                            return RowsAffected > 0;
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction in case of error
                            transaction.Rollback();
                            Console.WriteLine("Transaction failed: " + ex.Message);
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error updating installment payment: " + ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        // Delete an installment payment
        public static bool DeleteInstallmentPayment(int PaymentID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM InstallmentPayments WHERE PaymentID = @PaymentID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PaymentID", PaymentID);
                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error deleting installment payment: " + ex.Message);
                }
            }
            return RowsAffected > 0;
        }
    }
}