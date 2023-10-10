using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project.src
{
    internal class DatabaseManager
    {
        private SQLiteConnection sqlDB;


        public DatabaseManager()
        {
            sqlDB = sqlDB;
        }


        /// <summary>
        /// Creates a SQLite Database connection
        /// </summary>
        /// <returns></returns>
        public SQLiteConnection CreateConnection(string source)
        {
            SQLiteConnection sqlDBConnection;
            sqlDBConnection = new SQLiteConnection($"Data Source=C:/Users/infra/source/repos/ProtoDB Project/src/DBs/{source}");
            try
            {
                sqlDBConnection.Open();
            }
            catch (Exception cannotCreate) 
            {
                Console.WriteLine("Database cannot instantiate.");
            }

            return sqlDBConnection;
        }


        //Testing SQLite stuff
        //Creates a table
        public void CreateTable(SQLiteConnection sqlConnection)
        {
            SQLiteCommand sqCmd;
            string createTable = "CREATE TABLE Users(Col1 VARCHAR(20), Col2, INT)";
            sqCmd = sqlConnection.CreateCommand();
            sqCmd.CommandText = createTable;
            sqCmd.ExecuteNonQuery();
        }

        //Inserts data to Users table
        public void InsertData(SQLiteConnection sqlConnection, string username, int policy)
        {
            SQLiteCommand sqCmd;
            sqCmd = sqlConnection.CreateCommand();
            sqCmd.CommandText = $"INSERT INTO Users(Col1, Col2) VALUES('{username} ', 1);";
            sqCmd.ExecuteNonQuery();
            sqCmd.CommandText = $"INSERT INTO Users(Col1, Col2) VALUES('{policy} ', 2);";
            sqCmd.ExecuteNonQuery();
        }

        //Reads Data from Users table
        public void ReadData(SQLiteConnection sqlConnection)
        {
            SQLiteDataReader sqReadData;
            SQLiteCommand sqCmd;
            sqCmd = sqlConnection.CreateCommand();
            sqCmd.CommandText = "SELECT * FROM Users";
            sqReadData = sqCmd.ExecuteReader();
            while (sqReadData.Read())
            {
                string readLine = sqReadData.GetString(0);
                Console.WriteLine(readLine);
            }
            sqlConnection.Close();
        }



        //Testing SQLite

    }
}
