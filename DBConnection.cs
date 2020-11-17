using System;
using MySql.Data.MySqlClient;

namespace WPMigrator
{
    public class DBConnection
    {

        private MySqlConnection connection = null;
        public string DatabaseName { get; set; }
        public string DatabaseHost { get; set; }
        public string DatabaseUser { get; set; }
        public int DatabasePort { get; set; }
        public string DatabasePass { get; set; }


        // private constructor to create a database connection instance
        private DBConnection()
        {
  
        }

        // avoid creating multiple instances
        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public bool IsConnect()
        {
            if (connection == null)
            {
                if (String.IsNullOrEmpty(DatabaseName))
                    return false;
                string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}; port={4}", DatabaseHost, DatabaseName, DatabaseUser, DatabasePass, DatabasePort);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        public void CloseConnection()
        {
            connection.Close();
        }
    }
}
