using System;
using System.Data;
using System.Data.SQLite;
using System.Runtime.InteropServices;

namespace SalesPro_DataAccessLayer
{
    public class clsSalesInvoicesDAL
    {

        public static bool GetSalesInvoiceByID(int SalesInvoiceID, ref int CustomerID, ref DateTime SalesInvoiceDate,
            ref double SalesInvoiceTotal, ref int SalesInvoicePaymentType, ref int UserID, ref bool IsPaid, ref int InvoiceStatus, ref double SalesInvoiceTotalAfterDiscount)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM SalesInvoices WHERE SalesInvoiceID = @SalesInvoiceID";
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
                            CustomerID = Convert.ToInt32(reader["CustomerID"]);
                            SalesInvoiceDate = Convert.ToDateTime(reader["SalesInvoiceDate"]);
                            SalesInvoiceTotal = Convert.ToDouble(reader["SalesInvoiceTotal"]);
                            SalesInvoicePaymentType = Convert.ToInt32(reader["SalesInvoicePaymentTypeID"]);
                            UserID = Convert.ToInt32(reader["UserID"]);
                            IsPaid = Convert.ToBoolean(reader["IsPaid"]);
                            InvoiceStatus = Convert.ToInt32(reader["InvoiceStatus"]);
                            SalesInvoiceTotalAfterDiscount = Convert.ToDouble(reader["SalesInvoiceTotalAfterDiscount"]);
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error retrieving sales invoice: " + ex.Message);
                }
            }
            return IsFound;
        }


        public static DataTable GetAllSalesInvoices()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM SalesInvoices";

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

                    Console.WriteLine("Error retrieving sales invoices: " + ex.Message);
                }
            }

            return dataTable1;
        }
        public static DataTable GetAllSalesInvoicesWithDetails()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 
    si.SalesInvoiceID,
    p.PersonName,
    si.SalesInvoiceDate,
    sit.Quantity * sit.UnitPrice AS TotalPrice,  
    u.UserName,
    CASE 
        WHEN si.IsPaid = 1 THEN 'Yes' 
        ELSE 'No' 
    END AS Paid, 
    CASE 
        WHEN si.SalesInvoicePaymentTypeID = 1 THEN 'Cash'
        WHEN si.SalesInvoicePaymentTypeID = 2 THEN 'Installments'
        ELSE 'Other' 
    END AS ""Payment Method"",
    CASE
        WHEN si.InvoiceStatus = 1 THEN 'Active'
        WHEN si.InvoiceStatus = 2 THEN 'Retrieved'
        ELSE 'Canceled' 
    END AS InvoiceStatus,
    pr.ProductName,
    sit.SalesInvoiceItemID,
    sit.Quantity,
    sit.UnitPrice,
    si.SalesInvoiceTotalAfterDiscount
FROM 
    SalesInvoices si 
INNER JOIN 
    SalesInvoiceItems sit ON si.SalesInvoiceID = sit.SalesInvoiceID
INNER JOIN 
    Customers c ON c.CustomerID = si.CustomerID
INNER JOIN 
    People p ON p.PersonID = c.PersonID
INNER JOIN 
    Users u ON u.UserID = si.UserID
INNER JOIN 
    Products pr ON pr.ProductID = sit.ProductID;";

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

                    Console.WriteLine("Error retrieving sales invoices: " + ex.Message);
                }
            }

            return dataTable1;
        }



        public static int AddNewSalesInvoice(int CustomerID, DateTime SalesInvoiceDate, double SalesInvoiceTotal,
            int SalesInvoicePaymentTypeID, int UserID, bool IsPaid, int InvoiceStatus, double SalesInvoiceTotalAfterDiscount)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                INSERT INTO SalesInvoices (CustomerID, SalesInvoiceDate, SalesInvoiceTotal, 
                                         SalesInvoicePaymentTypeID, UserID, IsPaid, InvoiceStatus, SalesInvoiceTotalAfterDiscount)
                VALUES (@CustomerID, @SalesInvoiceDate, @SalesInvoiceTotal, 
                        @SalesInvoicePaymentTypeID, @UserID, @IsPaid, @InvoiceStatus, @SalesInvoiceTotalAfterDiscount);
                SELECT last_insert_rowid();";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", CustomerID);
                command.Parameters.AddWithValue("@SalesInvoiceDate", SalesInvoiceDate);
                command.Parameters.AddWithValue("@SalesInvoiceTotal", SalesInvoiceTotal);
                command.Parameters.AddWithValue("@SalesInvoicePaymentTypeID", SalesInvoicePaymentTypeID);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@IsPaid", IsPaid);
                command.Parameters.AddWithValue("@InvoiceStatus", InvoiceStatus);
                command.Parameters.AddWithValue("@SalesInvoiceTotalAfterDiscount", SalesInvoiceTotalAfterDiscount);

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

                    Console.WriteLine("Error adding new sales invoice: " + ex.Message);
                }
            }
            return -1;
        }


        public static bool UpdateSalesInvoice(int SalesInvoiceID, int CustomerID, DateTime SalesInvoiceDate,
            double SalesInvoiceTotal, int SalesInvoicePaymentType, int UserID, bool IsPaid, int InvoiceStatus, double SalesInvoiceTotalAfterDiscount)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                UPDATE SalesInvoices SET
                    CustomerID = @CustomerID,
                    SalesInvoiceDate = @SalesInvoiceDate,
                    SalesInvoiceTotal = @SalesInvoiceTotal,
                    SalesInvoicePaymentType = @SalesInvoicePaymentType,
                    UserID = @UserID,
                    IsPaid = @IsPaid,
                    InvoiceStatus = @InvoiceStatus,
                    SalesInvoiceTotalAfterDiscount = @SalesInvoiceTotalAfterDiscount
                WHERE SalesInvoiceID = @SalesInvoiceID;";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceID", SalesInvoiceID);
                command.Parameters.AddWithValue("@CustomerID", CustomerID);
                command.Parameters.AddWithValue("@SalesInvoiceDate", SalesInvoiceDate);
                command.Parameters.AddWithValue("@SalesInvoiceTotal", SalesInvoiceTotal);
                command.Parameters.AddWithValue("@SalesInvoicePaymentType", SalesInvoicePaymentType);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@IsPaid", IsPaid);
                command.Parameters.AddWithValue("@InvoiceStatus", InvoiceStatus);
                command.Parameters.AddWithValue("@SalesInvoiceTotalAfterDiscount", SalesInvoiceTotalAfterDiscount);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error updating sales invoice: " + ex.Message);
                    return false;
                }
            }
            return RowsAffected > 0;
        }


        public static bool DeleteSalesInvoice(int SalesInvoiceID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM SalesInvoices WHERE SalesInvoiceID = @SalesInvoiceID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceID", SalesInvoiceID);
                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error deleting sales invoice: " + ex.Message);
                }
            }
            return RowsAffected > 0;
        }


        public static bool IsSalesInvoiceExist(int CustomerID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM SalesInvoices WHERE CustomerID = @CustomerID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", CustomerID);
                try
                {
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error checking sales invoice existence: " + ex.Message);
                    return false;
                }
            }
        }


        public static bool GetSalesInvoiceByCustomerID(int CustomerID, ref int SalesInvoiceID, ref DateTime SalesInvoiceDate,
            ref double SalesInvoiceTotal, ref int SalesInvoicePaymentType, ref int UserID, ref bool IsPaid, ref int InvoiceStatus, ref double SalesInvoiceTotalAfterDiscount)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT si.SalesInvoiceID, si.SalesInvoiceDate, si.SalesInvoiceTotal, si.SalesInvoicePaymentType, si.UserID, si.IsPaid, si.InvoiceStatus, si.SalesInvoiceTotalAfterDiscount
                    FROM SalesInvoices si 
                    INNER JOIN Customers c ON c.CustomerID = si.CustomerID
                    WHERE si.CustomerID = @CustomerID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", CustomerID);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            SalesInvoiceID = Convert.ToInt32(reader["SalesInvoiceID"]);
                            SalesInvoiceDate = Convert.ToDateTime(reader["SalesInvoiceDate"]);
                            SalesInvoiceTotal = Convert.ToDouble(reader["SalesInvoiceTotal"]);
                            SalesInvoicePaymentType = Convert.ToInt32(reader["SalesInvoicePaymentType"]);
                            UserID = Convert.ToInt32(reader["UserID"]);
                            IsPaid = Convert.ToBoolean(reader["IsPaid"]);
                            InvoiceStatus = Convert.ToInt32(reader["InvoiceStatus"]);
                            SalesInvoiceTotalAfterDiscount = Convert.ToDouble(reader["SalesInvoiceTotalAfterDiscount"]);
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error retrieving sales invoice by customer ID: " + ex.Message);
                }
            }
            return IsFound;
        }

        public static bool IsSalesInvoiceActive(int salesInvoiceID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT InvoiceStatus FROM SalesInvoices WHERE SalesInvoiceID = @SalesInvoiceID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int invoiceStatus))
                    {
                        return invoiceStatus == 1;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error checking sales invoice status: " + ex.Message);
                    return false;
                }
            }
        }
        public static bool IsSalesInvoiceRetrieved(int salesInvoiceID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT InvoiceStatus FROM SalesInvoices WHERE SalesInvoiceID = @SalesInvoiceID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int invoiceStatus))
                    {
                        return invoiceStatus == 2;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error checking sales invoice status: " + ex.Message);
                    return false;
                }
            }
        }

        // i need you to only create a function that can cancel the SaleInvoice
        public static bool CancelSalesInvoice1(int salesInvoiceID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "UPDATE SalesInvoices SET InvoiceStatus = 2 WHERE SalesInvoiceID = @SalesInvoiceID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error canceling sales invoice: " + ex.Message);
                    return false;
                }
            }
        }
        public static bool CancelSalesInvoice(int salesInvoiceID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                SQLiteTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Step 1: Update the InvoiceStatus to "Canceled" (assuming 2 represents "Canceled")
                    string updateInvoiceStatusQuery = "UPDATE SalesInvoices SET InvoiceStatus = 3 WHERE SalesInvoiceID = @SalesInvoiceID";
                    using (SQLiteCommand updateCommand = new SQLiteCommand(updateInvoiceStatusQuery, connection, transaction))
                    {
                        updateCommand.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);
                        updateCommand.ExecuteNonQuery();
                    }

                    // Step 2: Add the products back to the Products table
                    string getInvoiceItemsQuery = "SELECT ProductID, Quantity FROM SalesInvoiceItems WHERE SalesInvoiceID = @SalesInvoiceID";
                    // did you mean that this query is like get or return something like a table?
                    using (SQLiteCommand getItemsCommand = new SQLiteCommand(getInvoiceItemsQuery, connection, transaction))
                    {
                        getItemsCommand.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);
                        using (SQLiteDataReader reader = getItemsCommand.ExecuteReader())
                        //then here we read every row that matches the query filter in getInvoiceItemsQuery
                        {
                            while (reader.Read())
                            {
                                int productID = reader.GetInt32(reader.GetOrdinal("ProductID"));
                                int quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                                // and after that we get every value that matches these tow conditions to get the product id and the quantity?

                                string updateProductStockQuery = "UPDATE Products SET StockQuantity = StockQuantity + @Quantity WHERE ProductID = @ProductID";
                                using (SQLiteCommand updateStockCommand = new SQLiteCommand(updateProductStockQuery, connection, transaction))
                                {
                                    updateStockCommand.Parameters.AddWithValue("@Quantity", quantity);
                                    updateStockCommand.Parameters.AddWithValue("@ProductID", productID);
                                    updateStockCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    // Commit the transaction
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of any error
                    transaction.Rollback();
                    Console.WriteLine("Error canceling sales invoice: " + ex.Message);
                    return false;
                }
            }
        }

        public static bool RetrieveSalesInvoice(int salesInvoiceID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                SQLiteTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Step 1: Update the InvoiceStatus to "Retrieve" (assuming 2 represents "Retrieve")
                    string updateInvoiceStatusQuery = "UPDATE SalesInvoices SET InvoiceStatus = 2 WHERE SalesInvoiceID = @SalesInvoiceID";
                    using (SQLiteCommand updateCommand = new SQLiteCommand(updateInvoiceStatusQuery, connection, transaction))
                    {
                        updateCommand.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);
                        updateCommand.ExecuteNonQuery();
                    }

                    // Step 2: Add the products back to the Products table
                    string getInvoiceItemsQuery = "SELECT ProductID, Quantity FROM SalesInvoiceItems WHERE SalesInvoiceID = @SalesInvoiceID";
                    // did you mean that this query is like get or return something like a table?
                    using (SQLiteCommand getItemsCommand = new SQLiteCommand(getInvoiceItemsQuery, connection, transaction))
                    {
                        getItemsCommand.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);
                        using (SQLiteDataReader reader = getItemsCommand.ExecuteReader())
                        //then here we read every row that matches the query filter in getInvoiceItemsQuery
                        {
                            while (reader.Read())
                            {
                                int productID = reader.GetInt32(reader.GetOrdinal("ProductID"));
                                int quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                                // and after that we get every value that matches these tow conditions to get the product id and the quantity?

                                string updateProductStockQuery = "UPDATE Products SET StockQuantity = StockQuantity + @Quantity WHERE ProductID = @ProductID";
                                using (SQLiteCommand updateStockCommand = new SQLiteCommand(updateProductStockQuery, connection, transaction))
                                {
                                    updateStockCommand.Parameters.AddWithValue("@Quantity", quantity);
                                    updateStockCommand.Parameters.AddWithValue("@ProductID", productID);
                                    updateStockCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    // Commit the transaction
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of any error
                    transaction.Rollback();
                    Console.WriteLine("Error canceling sales invoice: " + ex.Message);
                    return false;
                }
            }
        }
        public static int GetInvoiceStatusAsNumber(int salesInvoiceID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT InvoiceStatus FROM SalesInvoices WHERE SalesInvoiceID = @SalesInvoiceID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int invoiceStatus))
                    {
                        return invoiceStatus;
                    }
                    else
                    {
                        return -1; // Return -1 if no status is found or if there's an issue
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving invoice status: " + ex.Message);
                    return -1; // Return -1 in case of an error
                }
            }
        }

        public static bool UpdateIsPaidIfOutstandingBalanceIsZero(int salesInvoiceID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                SQLiteTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Get the outstanding balance
                    double outstandingBalance = clsInstallmentsDAL.GetOutstandingBalanceByInvoiceID(salesInvoiceID);

                    // Get the sales invoice total
                    double salesInvoiceTotal = 0;
                    string getSalesInvoiceTotalQuery = "SELECT SalesInvoiceTotal FROM SalesInvoices WHERE SalesInvoiceID = @SalesInvoiceID";
                    using (SQLiteCommand getTotalCommand = new SQLiteCommand(getSalesInvoiceTotalQuery, connection, transaction))
                    {
                        getTotalCommand.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);
                        object result = getTotalCommand.ExecuteScalar();
                        if (result != null && double.TryParse(result.ToString(), out salesInvoiceTotal))
                        {
                            // If outstanding balance is zero, update IsPaid to true
                            string updateIsPaidQuery;

                            if (outstandingBalance <= 0)
                                updateIsPaidQuery = "UPDATE SalesInvoices SET IsPaid = 1 WHERE SalesInvoiceID = @SalesInvoiceID";

                            else
                                updateIsPaidQuery = "UPDATE SalesInvoices SET IsPaid = 0 WHERE SalesInvoiceID = @SalesInvoiceID";

                            using (SQLiteCommand updateIsPaidCommand = new SQLiteCommand(updateIsPaidQuery, connection, transaction))
                            {
                                updateIsPaidCommand.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);
                                updateIsPaidCommand.ExecuteNonQuery();
                            }

                        }
                    }

                    // Commit the transaction
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of any error
                    transaction.Rollback();
                    Console.WriteLine("Error updating IsPaid: " + ex.Message);
                    return false;
                }
            }
        }

        public static bool IsSalesInvoicePaid(int salesInvoiceID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT IsPaid FROM SalesInvoices WHERE SalesInvoiceID = @SalesInvoiceID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && bool.TryParse(result.ToString(), out bool isPaid))
                    {
                        return isPaid;
                    }
                    else
                    {
                        return false; // Return false if no status is found or if there's an issue
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error checking if sales invoice is paid: " + ex.Message);
                    return false; // Return false in case of an error
                }
            }
        }


        public static bool UpdateSalesInvoiceTotalAfterDiscount(int salesInvoiceID, double newTotalAfterDiscount)
        {
            int rowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            UPDATE SalesInvoices 
            SET SalesInvoiceTotalAfterDiscount = @NewTotalAfterDiscount
            WHERE SalesInvoiceID = @SalesInvoiceID;";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceID", salesInvoiceID);
                command.Parameters.AddWithValue("@NewTotalAfterDiscount", newTotalAfterDiscount);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating SalesInvoiceTotalAfterDiscount: " + ex.Message);
                    return false;
                }
            }
            return rowsAffected > 0;
        }
    }
}