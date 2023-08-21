using Microsoft.Data.Sqlite;
using System.IO;

namespace DatabaseCRUD.CoreClasses
{
    public static class DatabaseFunctions
    {
        public static void CreateDatabase(string databaseName)
        {
            string folderPath = "Database";
            string databasePath = Path.Combine(folderPath, $"{databaseName}.sqlite");
            string connectionString = $"Data Source={databasePath}";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!File.Exists(databasePath))
            {
                using (File.Create(databasePath)) { }
            }

            using SqliteConnection connection = new(connectionString);
            connection.Open();

            using (SqliteCommand command = new("CREATE TABLE IF NOT EXISTS MyTable (ID INTEGER PRIMARY KEY, Name TEXT)", connection))
            {
                command.ExecuteNonQuery();
            }

            using (SqliteCommand command = new("INSERT INTO MyTable (Name) VALUES (@Name)", connection))
            {
                command.Parameters.AddWithValue("@Name", "John Doe");
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
}
