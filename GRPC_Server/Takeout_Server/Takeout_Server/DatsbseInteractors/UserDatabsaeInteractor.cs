using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPC_Server.DatsbseInteractors
{
	internal static class UserDatabsaeInteractor
	{
		static string TableName = "users";

		async public static Task<bool> checkUserExistance(string username, MySqlConnection connection)
		{
			using (var command = connection.CreateCommand())
			{
				command.CommandText = $"SELECT count(*) FROM users where username = \"{username}\";";

				using (var reader = await command.ExecuteReaderAsync())
				{
					await reader.ReadAsync();
					if(reader.GetInt32(0) == 0)
					{
						return false;
					}
				}
			}
			return true;
		}

		async public static Task<Dictionary<string, string>> getUserInformation(string username, MySqlConnection connection)
		{
			var userInfo = new Dictionary<string, string>();
			if (! await UserDatabsaeInteractor.checkUserExistance(username, connection) ) {
				return userInfo;
			}
			using (var command = connection.CreateCommand())
			{
				command.CommandText = $"SELECT * FROM users where username = \"{username}\";";

				using (var reader = await command.ExecuteReaderAsync())
				{
					await reader.ReadAsync();
					userInfo["Username"] = username;
					userInfo["Password"] = reader.GetString(2);
					userInfo["UserId"] = reader.GetInt32(0).ToString();
				}
			}
			return userInfo;
		}
	}
}
