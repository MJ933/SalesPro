using System;
using System.Data;
using System.Data.SQLite;

namespace SalesPro_DataAccessLayer
{
    public class clsSalesInvoiceItemsDAL
    {
        // Get a sales invoice item by SalesInvoiceItemID
        public static bool GetSalesInvoiceItemBySalesInvoicesItemID(int SalesInvoiceItemID, ref int SalesInvoiceID, ref int ProductID,
            ref int Quantity, ref double UnitPrice, ref int UserID)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM SalesInvoiceItems WHERE SalesInvoiceItemID = @SalesInvoiceItemID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceItemID", SalesInvoiceItemID);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            SalesInvoiceID = Convert.ToInt32(reader["SalesInvoiceID"]);
                            ProductID = Convert.ToInt32(reader["ProductID"]);
                            Quantity = Convert.ToInt32(reader["Quantity"]);
                            UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                            UserID = Convert.ToInt32(reader["UserID"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving sales invoice item: " + ex.Message);
                }
            }
            return IsFound;
        }

        public static bool GetSalesInvoiceItemBySaleInvoiceID(ref int SalesInvoiceItemID, int SalesInvoiceID, ref int ProductID,
            ref int Quantity, ref double UnitPrice, ref int UserID)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM SalesInvoiceItems WHERE SalesInvoiceID = @SalesInvoiceID";
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
                            SalesInvoiceItemID = Convert.ToInt32(reader["SalesInvoiceItemID"]);
                            ProductID = Convert.ToInt32(reader["ProductID"]);
                            Quantity = Convert.ToInt32(reader["Quantity"]);
                            UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                            UserID = Convert.ToInt32(reader["UserID"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving sales invoice item: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Get all sales invoice items
        public static DataTable GetAllSalesInvoiceItems()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM SalesInvoiceItems";

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
                    Console.WriteLine("Error retrieving sales invoice items: " + ex.Message);
                }
            }

            return dataTable1;
        }

        public static DataTable GetAllSalesInvoiceItemsByCustomerID(int CustomerID)
        {
            DataTable dataTable = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"select * from SalesInvoiceItems sit inner join SalesInvoices si
                                on si.SalesInvoiceID = sit.SalesInvoiceID
                                where si.CustomerID =@CustomerID ";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", CustomerID);

                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving sales invoice items by ID: " + ex.Message);
                }
            }

            return dataTable;
        }
        // Add a new sales invoice item
        public static int AddNewSalesInvoiceItem1(int SalesInvoiceID, int ProductID, int Quantity,
            double UnitPrice, int UserID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                INSERT INTO SalesInvoiceItems (SalesInvoiceID, ProductID, Quantity, 
                                             UnitPrice, UserID)
                VALUES (@SalesInvoiceID, @ProductID, @Quantity, 
                        @UnitPrice, @UserID);
                SELECT last_insert_rowid();";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceID", SalesInvoiceID);
                command.Parameters.AddWithValue("@ProductID", ProductID);
                command.Parameters.AddWithValue("@Quantity", Quantity);
                command.Parameters.AddWithValue("@UnitPrice", UnitPrice);
                command.Parameters.AddWithValue("@UserID", UserID);

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
                    // Log exception (optional)
                    Console.WriteLine("Error adding new sales invoice item: " + ex.Message);
                }
            }
            return -1;
        }

        public static int AddNewSalesInvoiceItem(int SalesInvoiceID, int ProductID, int Quantity,
    double UnitPrice, int UserID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                SQLiteTransaction transaction = connection.BeginTransaction();

                try
                {
                    string insertQuery = @"
            INSERT INTO SalesInvoiceItems (SalesInvoiceID, ProductID, Quantity, 
                                         UnitPrice, UserID)
            VALUES (@SalesInvoiceID, @ProductID, @Quantity, 
                    @UnitPrice, @UserID);
            SELECT last_insert_rowid();";

                    SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection, transaction);
                    insertCommand.Parameters.AddWithValue("@SalesInvoiceID", SalesInvoiceID);
                    insertCommand.Parameters.AddWithValue("@ProductID", ProductID);
                    insertCommand.Parameters.AddWithValue("@Quantity", Quantity);
                    insertCommand.Parameters.AddWithValue("@UnitPrice", UnitPrice);
                    insertCommand.Parameters.AddWithValue("@UserID", UserID);

                    object result = insertCommand.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        string updateQuery = @"
                UPDATE Products 
                SET StockQuantity = StockQuantity - @Quantity 
                WHERE ProductID = @ProductID;";

                        SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection, transaction);
                        updateCommand.Parameters.AddWithValue("@Quantity", Quantity);
                        updateCommand.Parameters.AddWithValue("@ProductID", ProductID);

                        updateCommand.ExecuteNonQuery();

                        transaction.Commit();
                        return InsertedID;
                    }
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of error
                    transaction.Rollback();
                    // Log exception (optional)
                    Console.WriteLine("Error adding new sales invoice item: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return -1;
        }


        // Update an existing sales invoice item
        public static bool UpdateSalesInvoiceItem(int SalesInvoiceItemID, int SalesInvoiceID, int ProductID,
            int Quantity, double UnitPrice, int UserID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                UPDATE SalesInvoiceItems SET
                    SalesInvoiceID = @SalesInvoiceID,
                    ProductID = @ProductID,
                    Quantity = @Quantity,
                    UnitPrice = @UnitPrice,
                    UserID = @UserID
                WHERE SalesInvoiceItemID = @SalesInvoiceItemID;";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceItemID", SalesInvoiceItemID);
                command.Parameters.AddWithValue("@SalesInvoiceID", SalesInvoiceID);
                command.Parameters.AddWithValue("@ProductID", ProductID);
                command.Parameters.AddWithValue("@Quantity", Quantity);
                command.Parameters.AddWithValue("@UnitPrice", UnitPrice);
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error updating sales invoice item: " + ex.Message);
                    return false;
                }
            }
            return RowsAffected > 0;
        }

        // Delete a sales invoice item
        public static bool DeleteSalesInvoiceItem(int SalesInvoiceItemID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM SalesInvoiceItems WHERE SalesInvoiceItemID = @SalesInvoiceItemID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceItemID", SalesInvoiceItemID);
                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error deleting sales invoice item: " + ex.Message);
                }
            }
            return RowsAffected > 0;
        }
    }
}