using System;
using System.Data;
using System.Data.SQLite;

namespace SalesPro_DataAccessLayer
{
    public class clsInstallmentsDAL
    {
        // Get an installment by InstallmentID
        public static bool GetInstallmentByID(int InstallmentID, ref int SalesInvoiceID, ref int InstallmentNumber,
            ref double InstallmentAmount, ref DateTime DueDate, ref DateTime? PaymentDate, ref int StatusID,
            ref int UserID, ref int? GuarantorID, ref int quantity, ref int ProductID)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Installments WHERE InstallmentID = @InstallmentID";
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
                            SalesInvoiceID = Convert.ToInt32(reader["SalesInvoiceID"]);
                            InstallmentNumber = Convert.ToInt32(reader["InstallmentNumber"]);
                            InstallmentAmount = Convert.ToDouble(reader["InstallmentAmount"]);
                            DueDate = Convert.ToDateTime(reader["DueDate"]);
                            PaymentDate = reader["PaymentDate"] is DBNull ? (DateTime?)null : Convert.ToDateTime(reader["PaymentDate"]);
                            StatusID = Convert.ToInt32(reader["StatusID"]);
                            UserID = Convert.ToInt32(reader["UserID"]);
                            GuarantorID = reader["GuarantorID"] is DBNull ? (int?)null : Convert.ToInt32(reader["GuarantorID"]);
                            quantity = Convert.ToInt32(reader["Quantity"]);
                            ProductID = Convert.ToInt32(reader["ProductID"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving installment: " + ex.Message);
                }
            }
            return IsFound;
        }
        public static bool GetInstallmentByInvoiceID(ref int InstallmentID, int SalesInvoiceID, ref int InstallmentNumber,
            ref double InstallmentAmount, ref DateTime DueDate, ref DateTime? PaymentDate, ref int StatusID,
            ref int UserID, ref int? GuarantorID, ref int quantity, ref int ProductID)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT *FROM Installments WHERE SalesInvoiceID = @SalesInvoiceID LIMIT 1;";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceID", SalesInvoiceID);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            InstallmentID = Convert.ToInt32(reader["InstallmentID"]);
                            InstallmentNumber = Convert.ToInt32(reader["InstallmentNumber"]);
                            InstallmentAmount = Convert.ToDouble(reader["InstallmentAmount"]);
                            DueDate = Convert.ToDateTime(reader["DueDate"]);
                            PaymentDate = reader["PaymentDate"] is DBNull ? (DateTime?)null : Convert.ToDateTime(reader["PaymentDate"]);
                            StatusID = Convert.ToInt32(reader["StatusID"]);
                            UserID = Convert.ToInt32(reader["UserID"]);
                            GuarantorID = reader["GuarantorID"] is DBNull ? (int?)null : Convert.ToInt32(reader["GuarantorID"]);
                            quantity = Convert.ToInt32(reader["Quantity"]);
                            ProductID = Convert.ToInt32(reader["ProductID"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving installment: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Get all installments

        public static DataTable GetAllInstallments()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
SELECT
    i.InstallmentID,
    p.PersonName,
    si.SalesInvoiceID,
    i.InstallmentNumber,
    i.InstallmentAmount,
    i.DueDate
FROM
    Installments i
INNER JOIN
    SalesInvoices si ON i.SalesInvoiceID = si.SalesInvoiceID
INNER JOIN
    Customers c ON c.CustomerID = si.CustomerID
INNER JOIN
    People p ON p.PersonID = c.PersonID
INNER JOIN
    InstallmentStatus is2 ON is2.StatusID = i.StatusID
WHERE i.StatusID IN (1) and si.invoiceStatus = 1 
GROUP BY
    si.SalesInvoiceID";

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
                    Console.WriteLine("Error retrieving installments: " + ex.Message);
                }
            }

            return dataTable1;
        }

        public static DataTable GetAllInstallmentsByIfPaidOrNot(bool IsPaid)
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
SELECT
    i.InstallmentID,
    p.PersonName,
    si.SalesInvoiceID,
    i.InstallmentNumber,
    i.InstallmentAmount,
    i.DueDate,
    si.IsPaid
FROM
    Installments i
INNER JOIN
    SalesInvoices si ON i.SalesInvoiceID = si.SalesInvoiceID
INNER JOIN
    Customers c ON c.CustomerID = si.CustomerID
INNER JOIN
    People p ON p.PersonID = c.PersonID
INNER JOIN
    InstallmentStatus is2 ON is2.StatusID = i.StatusID
WHERE i.StatusID IN (1) AND si.InvoiceStatus = 1 AND si.IsPaid = @IsPaid
GROUP BY
    si.SalesInvoiceID";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@IsPaid", IsPaid); // Directly use the boolean value

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
                    Console.WriteLine("Error retrieving installments: " + ex.Message);
                }
            }

            return dataTable1;
        }
        public static DataTable GetAllInstallmentsByInvoiceId(int SalesInvoiceID)
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
SELECT 
    i.InstallmentID,
    i.InstallmentNumber,
    i.InstallmentAmount,
    i.DueDate,
    i.PaymentDate,
    CASE 
        WHEN ip.PaymentAmount IS NULL THEN 'none'
        ELSE CAST(ip.PaymentAmount AS VARCHAR)
    END AS PaymentAmount,
    is2.StatusName
FROM 
    Installments i
INNER JOIN 
    InstallmentStatus is2 ON is2.StatusID = i.StatusID
LEFT JOIN 
    InstallmentPayments ip ON ip.InstallmentID = i.InstallmentID
WHERE 
    i.SalesInvoiceID = @SalesInvoiceID
    AND (ip.InstallmentID IS NOT NULL OR NOT EXISTS (SELECT 1 FROM InstallmentPayments WHERE InstallmentID = i.InstallmentID));
";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceID", SalesInvoiceID);
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
                    Console.WriteLine("Error retrieving installments: " + ex.Message);
                }
            }

            return dataTable1;
        }

        // Add a new installment (without ProductID)
        public static int AddNewInstallment1(int SalesInvoiceID, int InstallmentNumber, double InstallmentAmount,
            DateTime DueDate, DateTime? PaymentDate, int StatusID, int UserID, int? GuarantorID, int quantity)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                INSERT INTO Installments (SalesInvoiceID, InstallmentNumber, InstallmentAmount, 
                                         DueDate, PaymentDate, StatusID, UserID, GuarantorID,quantity)
                VALUES (@SalesInvoiceID, @InstallmentNumber, @InstallmentAmount, 
                        @DueDate, @PaymentDate, @StatusID, @UserID, @GuarantorID,@quantity);
                SELECT last_insert_rowid();";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceID", SalesInvoiceID);
                command.Parameters.AddWithValue("@InstallmentNumber", InstallmentNumber);
                command.Parameters.AddWithValue("@InstallmentAmount", InstallmentAmount);
                command.Parameters.AddWithValue("@DueDate", DueDate);
                command.Parameters.AddWithValue("@PaymentDate", (object)PaymentDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@StatusID", StatusID);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@GuarantorID", (object)GuarantorID ?? DBNull.Value);
                command.Parameters.AddWithValue("@quantity", quantity);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();

                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        return InsertedID;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding new installment: " + ex.Message);
                }
            }
            return -1;
        }

        // Add a new installment (with ProductID and stock update)
        public static int AddNewInstallment(int SalesInvoiceID, int InstallmentNumber, double InstallmentAmount,
            DateTime DueDate, DateTime? PaymentDate, int StatusID, int UserID, int? GuarantorID, int quantity, int ProductID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                SQLiteTransaction transaction = connection.BeginTransaction();

                try
                {
                    string insertInstallmentsQuery = @"
            INSERT INTO Installments (SalesInvoiceID, InstallmentNumber, InstallmentAmount, 
                                      DueDate, PaymentDate, StatusID, UserID, GuarantorID, Quantity, ProductID) 
            VALUES (@SalesInvoiceID, @InstallmentNumber, @InstallmentAmount, 
                    @DueDate, @PaymentDate, @StatusID, @UserID, @GuarantorID, @Quantity, @ProductID);
            SELECT last_insert_rowid();";

                    SQLiteCommand insertInstallmentsCommand = new SQLiteCommand(insertInstallmentsQuery, connection, transaction);
                    insertInstallmentsCommand.Parameters.AddWithValue("@SalesInvoiceID", SalesInvoiceID);
                    insertInstallmentsCommand.Parameters.AddWithValue("@InstallmentNumber", InstallmentNumber);
                    insertInstallmentsCommand.Parameters.AddWithValue("@InstallmentAmount", InstallmentAmount);
                    insertInstallmentsCommand.Parameters.AddWithValue("@DueDate", DueDate);
                    insertInstallmentsCommand.Parameters.AddWithValue("@PaymentDate", (object)PaymentDate ?? DBNull.Value);
                    insertInstallmentsCommand.Parameters.AddWithValue("@StatusID", StatusID);
                    insertInstallmentsCommand.Parameters.AddWithValue("@UserID", UserID);
                    insertInstallmentsCommand.Parameters.AddWithValue("@GuarantorID", (object)GuarantorID ?? DBNull.Value);
                    insertInstallmentsCommand.Parameters.AddWithValue("@Quantity", quantity);
                    insertInstallmentsCommand.Parameters.AddWithValue("@ProductID", ProductID);

                    object result = insertInstallmentsCommand.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {


                        //need to update the code because it change the quantity as long as the function is run


                        //        string updateProductsQuery = @"
                        //UPDATE Products 
                        //SET StockQuantity = StockQuantity - @Quantity
                        //WHERE ProductID = @ProductID;";

                        //        SQLiteCommand updateProductsCommand = new SQLiteCommand(updateProductsQuery, connection, transaction);
                        //        updateProductsCommand.Parameters.AddWithValue("@Quantity", quantity);
                        //        updateProductsCommand.Parameters.AddWithValue("@ProductID", ProductID);

                        //        updateProductsCommand.ExecuteNonQuery();

                        transaction.Commit();
                        return InsertedID;
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error adding new installment and updating stock: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return -1;
        }

        // Update an existing installment (with ProductID)
        public static bool UpdateInstallment(int InstallmentID, int SalesInvoiceID, int InstallmentNumber,
            double InstallmentAmount, DateTime DueDate, DateTime? PaymentDate, int StatusID, int UserID, int? GuarantorID, int quantity, int ProductID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                UPDATE Installments SET
                    SalesInvoiceID = @SalesInvoiceID,
                    InstallmentNumber = @InstallmentNumber,
                    InstallmentAmount = @InstallmentAmount,
                    DueDate = @DueDate,
                    PaymentDate = @PaymentDate,
                    StatusID = @StatusID,
                    UserID = @UserID,
                    GuarantorID = @GuarantorID,
                    quantity = @quantity,
                    ProductID = @ProductID 
                WHERE InstallmentID = @InstallmentID;";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@InstallmentID", InstallmentID);
                command.Parameters.AddWithValue("@SalesInvoiceID", SalesInvoiceID);
                command.Parameters.AddWithValue("@InstallmentNumber", InstallmentNumber);
                command.Parameters.AddWithValue("@InstallmentAmount", InstallmentAmount);
                command.Parameters.AddWithValue("@DueDate", DueDate);
                command.Parameters.AddWithValue("@PaymentDate", (object)PaymentDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@StatusID", StatusID);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@GuarantorID", (object)GuarantorID ?? DBNull.Value);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@ProductID", ProductID); // Added ProductID parameter

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating installment: " + ex.Message);
                    return false;
                }
            }
            return RowsAffected > 0;
        }

        // Delete an installment
        public static bool DeleteInstallment(int InstallmentID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Installments WHERE InstallmentID = @InstallmentID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@InstallmentID", InstallmentID);
                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting installment: " + ex.Message);
                }
            }
            return RowsAffected > 0;
        }


        public static int GetOutstandingBalanceByInvoiceID(int SalesInvoiceID)
        {
            int outstandingBalance = 0;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
SELECT 
si.SalesInvoiceTotalAfterDiscount -
     SUM ((
        SELECT COALESCE(SUM(ip.PaymentAmount), 0) 
        FROM InstallmentPayments ip 
        WHERE ip.InstallmentID = i.InstallmentID
    )) AS OutstandingBalance
FROM 
    Installments i 
INNER JOIN 
    SalesInvoices si ON si.SalesInvoiceID = i.SalesInvoiceID 
    where i.SalesInvoiceID = @SalesInvoiceID
        ";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceID", SalesInvoiceID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int balance))
                    {
                        outstandingBalance = balance;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving outstanding balance: " + ex.Message);
                }
            }
            return outstandingBalance;
        }

        public static int GetTotalPaymentsByInvoiceID(int SalesInvoiceID)
        {
            int outstandingBalance = 0;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
SELECT 
     SUM ((
        SELECT COALESCE(SUM(ip.PaymentAmount), 0) 
        FROM InstallmentPayments ip 
        WHERE ip.InstallmentID = i.InstallmentID
    )) AS TotalPayments
FROM 
    Installments i 
INNER JOIN 
    SalesInvoiceItems sii ON sii.SalesInvoiceID = i.SalesInvoiceID 
    where i.SalesInvoiceID = @SalesInvoiceID
        ";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceID", SalesInvoiceID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int balance))
                    {
                        outstandingBalance = balance;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving outstanding balance: " + ex.Message);
                }
            }
            return outstandingBalance;
        }
    }
}