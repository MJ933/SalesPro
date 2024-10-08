using System;
using System.Data;
using System.Data.SQLite;

namespace SalesPro_DataAccessLayer
{
    public class clsProductsDAL
    {
        // Get a product by ProductID (Updated to include new columns)
        public static bool GetProductByID(int ProductID, ref string ProductName, ref string ProductDescription,
            ref double PurchasePrice, ref double SellingPrice, ref int StockQuantity, ref int? SupplierID,
            ref DateTime? LastStatusDate, ref DateTime? DateAdded, ref double? InstallmentPrice)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Products WHERE ProductID = @ProductID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", ProductID);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            ProductName = reader["ProductName"].ToString();
                            ProductDescription = reader["ProductDescription"].ToString();
                            PurchasePrice = Convert.ToDouble(reader["PurchasePrice"]);
                            SellingPrice = Convert.ToDouble(reader["SellingPrice"]);
                            StockQuantity = Convert.ToInt32(reader["StockQuantity"]);
                            SupplierID = reader["SupplierID"] is DBNull ? (int?)null : Convert.ToInt32(reader["SupplierID"]);
                            LastStatusDate = reader["LastStatusDate"] is DBNull ? (DateTime?)null : Convert.ToDateTime(reader["LastStatusDate"]);
                            DateAdded = reader["DateAdded"] is DBNull ? (DateTime?)null : Convert.ToDateTime(reader["DateAdded"]);
                            InstallmentPrice = reader["InstallmentPrice"] is DBNull ? (double?)null : Convert.ToDouble(reader["InstallmentPrice"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving product: " + ex.Message);
                }
            }
            return IsFound;
        }


        // Find product by name
        public static DataTable FindProductByName(string productName)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Products WHERE ProductName LIKE @ProductName";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", "%" + productName + "%");
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error finding product by name: " + ex.Message);
                }
            }
            return dt;
        }

        // Check if product exists by ID
        public static bool ProductExistsByID(int ProductID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT EXISTS(SELECT 1 FROM Products WHERE ProductID = @ProductID)";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", ProductID);
                try
                {
                    connection.Open();
                    return (long)command.ExecuteScalar() == 1;
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error checking product existence: " + ex.Message);
                    return false;
                }
            }
        }

        // Check if a product with the given name exists
        public static bool CheckProductName(string ProductName)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Products WHERE ProductName = @ProductName";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", ProductName);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error checking product name: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Get all products
        public static DataTable GetAllProducts()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM Products";

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
                    Console.WriteLine("Error retrieving products: " + ex.Message);
                }
            }

            return dataTable1;
        }

        // Add a new product
        public static int AddNewProduct(string ProductName, string ProductDescription,
            double PurchasePrice, double SellingPrice, int StockQuantity, int? SupplierID, double? InstallmentPrice, DateTime? LastStatusDate, DateTime? DateAdded)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                INSERT INTO Products (ProductName, ProductDescription, PurchasePrice, SellingPrice, 
                                     StockQuantity, SupplierID, InstallmentPrice, LastStatusDate, DateAdded) 
                VALUES (@ProductName, @ProductDescription, @PurchasePrice, @SellingPrice, 
                        @StockQuantity, @SupplierID, @InstallmentPrice, @LastStatusDate, @DateAdded);
                SELECT last_insert_rowid();";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", ProductName);
                command.Parameters.AddWithValue("@ProductDescription", ProductDescription);
                command.Parameters.AddWithValue("@PurchasePrice", PurchasePrice);
                command.Parameters.AddWithValue("@SellingPrice", SellingPrice);
                command.Parameters.AddWithValue("@StockQuantity", StockQuantity);
                command.Parameters.AddWithValue("@SupplierID", (object)SupplierID ?? DBNull.Value);
                command.Parameters.AddWithValue("@InstallmentPrice", (object)InstallmentPrice ?? DBNull.Value);
                command.Parameters.AddWithValue("@LastStatusDate", (object)LastStatusDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@DateAdded", (object)DateAdded ?? DBNull.Value);


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
                    Console.WriteLine("Error adding new product: " + ex.Message);
                }
            }
            return -1;
        }

        // Update an existing product
        public static bool UpdateProduct(int ProductID, string ProductName, string ProductDescription,
            double PurchasePrice, double SellingPrice, int StockQuantity, int? SupplierID, double? InstallmentPrice, DateTime? LastStatusDate, DateTime? DateAdded)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                UPDATE Products SET
                    ProductName = @ProductName,
                    ProductDescription = @ProductDescription,
                    PurchasePrice = @PurchasePrice,
                    SellingPrice = @SellingPrice,
                    StockQuantity = @StockQuantity,
                    SupplierID = @SupplierID,
                    InstallmentPrice = @InstallmentPrice,
                    LastStatusDate = @LastStatusDate,
                    DateAdded = @DateAdded
                WHERE ProductID = @ProductID;";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", ProductID);
                command.Parameters.AddWithValue("@ProductName", ProductName);
                command.Parameters.AddWithValue("@ProductDescription", ProductDescription);
                command.Parameters.AddWithValue("@PurchasePrice", PurchasePrice);
                command.Parameters.AddWithValue("@SellingPrice", SellingPrice);
                command.Parameters.AddWithValue("@StockQuantity", StockQuantity);
                command.Parameters.AddWithValue("@SupplierID", (object)SupplierID ?? DBNull.Value);
                command.Parameters.AddWithValue("@InstallmentPrice", (object)InstallmentPrice ?? DBNull.Value);
                command.Parameters.AddWithValue("@LastStatusDate", (object)LastStatusDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@DateAdded", (object)DateAdded ?? DBNull.Value);


                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error updating product: " + ex.Message);
                    return false;
                }
            }
            return RowsAffected > 0;
        }

        // Delete a product
        public static bool DeleteProduct(int ProductID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", ProductID);
                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error deleting product: " + ex.Message);
                }
            }
            return RowsAffected > 0;
        }

        // Get a product by ProductName (Updated to include new columns)
        public static bool GetProductByName(string ProductName, ref int ProductID, ref string ProductDescription,
            ref double PurchasePrice, ref double SellingPrice, ref int StockQuantity, ref int? SupplierID,
            ref DateTime? LastStatusDate, ref DateTime? DateAdded, ref double? InstallmentPrice)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Products WHERE ProductName = @ProductName";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", ProductName);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            ProductID = Convert.ToInt32(reader["ProductID"]);
                            ProductDescription = reader["ProductDescription"].ToString();
                            PurchasePrice = Convert.ToDouble(reader["PurchasePrice"]);
                            SellingPrice = Convert.ToDouble(reader["SellingPrice"]);
                            StockQuantity = Convert.ToInt32(reader["StockQuantity"]);
                            SupplierID = reader["SupplierID"] is DBNull ? (int?)null : Convert.ToInt32(reader["SupplierID"]);
                            LastStatusDate = reader["LastStatusDate"] is DBNull ? (DateTime?)null : Convert.ToDateTime(reader["LastStatusDate"]);
                            DateAdded = reader["DateAdded"] is DBNull ? (DateTime?)null : Convert.ToDateTime(reader["DateAdded"]);
                            InstallmentPrice = reader["InstallmentPrice"] is DBNull ? (double?)null : Convert.ToDouble(reader["InstallmentPrice"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving product: " + ex.Message);
                }
            }
            return IsFound;
        }

        public static bool UpdateProductQuantity(int productId, int newQuantity)
        {
            int rowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "UPDATE Products SET StockQuantity = @NewQuantity WHERE ProductID = @ProductID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productId);
                command.Parameters.AddWithValue("@NewQuantity", newQuantity);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error updating product quantity: " + ex.Message);
                }
            }
            return rowsAffected > 0;
        }

        public static DataTable GetProductNames()
        {
            DataTable dt = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT ProductName FROM Products";
                SQLiteCommand command = new SQLiteCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving product names: " + ex.Message);
                }
            }

            return dt;
        }
    }

}