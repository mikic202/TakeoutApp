using MySqlConnector;
using System.Data.Common;

namespace Takeout_Server.DatsbseInteractors
{
    public static class ConnectionBuilder
    {
        public static MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            Server = "takeout.mysql.database.azure.com",
            Port = 3306,
            Database = "takout_db",
            UserID = "mchomans",
            Password = "___",
        };

        public static string getConnectionString()
        {
            return builder.ConnectionString;
        }
    }
}
