using System;
using System.Data;
using System.Data.SQLite;

namespace SalesPro_DataAccessLayer
{
    public class clsSuppliersDAL
    {
        // Get a supplier by SupplierID
        public static bool GetSupplierByID(int SupplierID, ref int PersonID /*, ref ... other fields */)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Suppliers WHERE SupplierID = @SupplierID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierID", SupplierID);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            PersonID = Convert.ToInt32(reader["PersonID"]);
                            // ... retrieve other fields from the reader
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving supplier: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Get all suppliers
        public static DataTable GetAllSuppliers()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @" select s.SupplierID , PersonName, Address, Phone1, Phone2, Phone3, phone4,
                    Email, notes 
                    from People p 
                    inner join Suppliers s on p.PersonID = s.PersonID";

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
                    Console.WriteLine("Error retrieving suppliers: " + ex.Message);
                }
            }

            return dataTable1;
        }

        // Add a new supplier
        public static int AddNewSupplier(int PersonID /*, ... other fields */)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                INSERT INTO Suppliers (PersonID /*, ... other fields */)
                VALUES (@PersonID /*, ... other field values */);
                SELECT last_insert_rowid();";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                // ... add parameters for other fields

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
                    Console.WriteLine("Error adding new supplier: " + ex.Message);
                }
            }
            return -1;
        }

        // Update an existing supplier
        public static bool UpdateSupplier(int SupplierID, int PersonID /*, ... other fields */)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                UPDATE Suppliers SET
                    PersonID = @PersonID /*, ... other fields = @otherFieldValues */
                WHERE SupplierID = @SupplierID;";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierID", SupplierID);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                // ... add parameters for other fields

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error updating supplier: " + ex.Message);
                    return false;
                }
            }
            return RowsAffected > 0;
        }

        // Delete a supplier
        public static bool DeleteSupplier(int SupplierID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Suppliers WHERE SupplierID = @SupplierID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierID", SupplierID);
                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error deleting supplier: " + ex.Message);
                }
            }
            return RowsAffected > 0;
        }


        // Get Suppliers Names
        public static DataTable GetSuppliersNames()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "select * from People p inner join Suppliers s on s.PersonID = p.PersonID";
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
                    Console.WriteLine("Error retrieving suppliers: " + ex.Message);
                }
            }
            return dt;
        }

        // Search Suppliers by Name
        public static DataTable SearchSuppliersByName(string SupplierName)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "select * from People p inner join Suppliers s on p.PersonID = s.PersonID where p.PersonName like @SupplierName";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierName", "%" + SupplierName + "%");
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
                    Console.WriteLine("Error searching suppliers: " + ex.Message);
                }
            }
            return dt;
        }


        // Get SupplierID by Name
        public static int? GetSupplierIDByName(string SupplierName)
        {
            int? SupplierID = null;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "select SupplierID from Suppliers s inner join People p on p.PersonID = s.PersonID where p.PersonName like @SupplierName";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierName", "%" + SupplierName + "%");
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            SupplierID = reader.GetInt32(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving SupplierID: " + ex.Message);
                }
            }
            return SupplierID;
        }


        // Check if Supplier Exists by ID
        public static bool SupplierExistsByID(int SupplierID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT EXISTS(SELECT 1 FROM Suppliers WHERE SupplierID = @SupplierID)";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierID", SupplierID);
                try
                {
                    connection.Open();
                    return (long)command.ExecuteScalar() == 1;
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error checking supplier existence: " + ex.Message);
                    return false;
                }
            }
        }

        // Check if Supplier Exists by Name
        public static bool SupplierExistsByName(string SupplierName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT EXISTS(SELECT 1 FROM People WHERE PersonName LIKE @SupplierName)";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierName", "%" + SupplierName + "%");
                try
                {
                    connection.Open();
                    return (long)command.ExecuteScalar() == 1;
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error checking supplier existence: " + ex.Message);
                    return false;
                }
            }
        }
    }
}