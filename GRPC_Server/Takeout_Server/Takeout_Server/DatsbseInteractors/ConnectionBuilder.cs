using MySqlConnector;
using System.Data.Common;

namespace Takeout_Server.DatsbseInteractors
{
    public static class ConnectionBuilder
    {
        public static MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            Server = "127.0.0.1",
            Port = 3306,
            Database = "takout_db",
            UserID = "root",
            Password = "",
        };

        public static string getConnectionString()
        {
            return builder.ConnectionString;
        }
    }
}
