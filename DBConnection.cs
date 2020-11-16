using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WPMigrator
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        private string databaseName = string.Empty;
        private string databaseHost = string.Empty;
        private string databaseUser = string.Empty;
        private string databasePass = string.Empty;

        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string DatabaseHost
        {
            get { return databaseHost; }
            set { databaseHost = value; }
        }

        public string DatabaseUser
        {
            get { return databaseUser; }
            set { databaseUser = value; }
        }

        public string DatabasePass
        {
            get { return databasePass; }
            set { databasePass = value; }
        }

        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", databaseHost, databaseName, databaseUser, databasePass);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
