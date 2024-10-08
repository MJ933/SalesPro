using System;
using System.Data;
using System.Data.SQLite;

namespace SalesPro_DataAccessLayer
{
    public class clsGuarantorsDAL
    {
        // Get a guarantor by GuarantorID
        public static bool GetGuarantorByID(int GuarantorID, ref int PersonID)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Guarantors WHERE GuarantorID = @GuarantorID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@GuarantorID", GuarantorID);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            PersonID = Convert.ToInt32(reader["PersonID"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving guarantor: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Get all guarantors
        public static DataTable GetAllGuarantors()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"select g.GuarantorID , PersonName, Address, Phone1, Phone2, Phone3, phone4,
                    Email, notes 
                    from People p 
                    inner join Guarantors g on p.PersonID = g.PersonID";

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
                    Console.WriteLine("Error retrieving guarantors: " + ex.Message);
                }
            }

            return dataTable1;
        }

        // Add a new guarantor
        public static int AddNewGuarantor(int PersonID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                INSERT INTO Guarantors (PersonID)
                VALUES (@PersonID);
                SELECT last_insert_rowid();";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);

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
                    Console.WriteLine("Error adding new guarantor: " + ex.Message);
                }
            }
            return -1;
        }

        // Update an existing guarantor
        public static bool UpdateGuarantor(int GuarantorID, int PersonID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                UPDATE Guarantors SET
                    PersonID = @PersonID
                WHERE GuarantorID = @GuarantorID;";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@GuarantorID", GuarantorID);
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error updating guarantor: " + ex.Message);
                    return false;
                }
            }
            return RowsAffected > 0;
        }

        // Delete a guarantor
        public static bool DeleteGuarantor(int GuarantorID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Guarantors WHERE GuarantorID = @GuarantorID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@GuarantorID", GuarantorID);
                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error deleting guarantor: " + ex.Message);
                }
            }
            return RowsAffected > 0;
        }

        // Get Guarantors Names
        public static DataTable GetGuarantorsNames()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"select PersonName from People p 
inner join Guarantors g on g.PersonID = p.PersonID;";

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
                    Console.WriteLine("Error retrieving guarantors: " + ex.Message);
                }
            }

            return dataTable1;
        }

        // Get a guarantor by name
        public static bool GetGuarantorByName(string PersonName, ref int GuarantorID)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"select GuarantorID from Guarantors g 
inner join People p on g.PersonID = p.PersonID
where PersonName = @PersonName";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PersonName", PersonName);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            GuarantorID = Convert.ToInt32(reader["GuarantorID"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving guarantor: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Check if a guarantor exists by ID
        public static bool GuarantorExists(int GuarantorID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Guarantors WHERE GuarantorID = @GuarantorID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@GuarantorID", GuarantorID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && Convert.ToInt32(result) > 0)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error checking guarantor existence: " + ex.Message);
                }
            }
            return false;
        }
    }
}