using System;
using System.Data.SqlServerCe;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace MBSAI
{
    class DBUtils
    {
        private DBUtils()
        {
        }

        private string databaseName = "medsupinventsys";
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBUtils _instance = null;
        public static DBUtils Instance()
        {
            if (_instance == null)
                _instance = new DBUtils();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server=localhost; database={0}; UID=root; password=;", databaseName);
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
