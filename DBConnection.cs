using System;
using MySql.Data.MySqlClient;

namespace WPMigrator
{
    public class DBConnection
    {

        private MySqlConnection connection = null;
        private string databaseName = string.Empty;
        private string databaseHost = string.Empty;
        private string databaseUser = string.Empty;
        private string databasePass = string.Empty;
        private int databasePort;

        // Private constructor to create a database connection instance
        public DBConnection(string databaseName, string databaseUser, string databasePass, string databaseHost, int databasePort)
        {
            this.databaseName = databaseName;
            this.databaseHost = databaseHost;
            this.databaseUser = databaseUser;
            this.databasePass = databasePass;
            this.databasePort = databasePort;
        }


        public MySqlConnection GetConnection
        {
            get { return connection; }
        }

        public bool IsConnect()
        {
            if (connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}; port={4}", databaseHost, databaseName, databaseUser, databasePass, databasePort);
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
