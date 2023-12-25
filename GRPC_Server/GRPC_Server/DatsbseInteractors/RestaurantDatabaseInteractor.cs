using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPC_Server.DatsbseInteractors
{
	internal class RestaurantDatabaseInteractor
	{
		async public static Task<bool> checkRestaurantsExistance(string restaurantName, MySqlConnection connection)
		{
			using (var command = connection.CreateCommand())
			{
				command.CommandText = $"SELECT count(*) FROM restaurants where restaurnat_name = \"{restaurantName}\";";

				using (var reader = await command.ExecuteReaderAsync())
				{
					await reader.ReadAsync();
					if (reader.GetInt32(0) == 0)
					{
						return false;
					}
				}
			}
			return true;
		}

		async public static Task<bool> registerRestaurant(string restaurantName, string password, MySqlConnection connection)
		{
			// password should be hashed on the users end
			if( await checkRestaurantsExistance(restaurantName, connection))
			{
				return false;
			}
			using (var command = connection.CreateCommand())
			{
				command.CommandText = $"INSERT INTO restaurants (restaurnat_name, password) values (\"{restaurantName}\", \"{password}\");";
				await command.ExecuteNonQueryAsync();

			}
			return true;
		}

        async public static Task<Dictionary<string, string>> getRestaurantInformation(string username, MySqlConnection connection)
        {
            var userInfo = new Dictionary<string, string>();
            if (!await checkRestaurantsExistance(username, connection))
            {
                return userInfo;
            }
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM restaurants where restaurnat_name = \"{username}\";";

                using (var reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    userInfo["restaurnatName"] = username;
                    userInfo["Password"] = reader.GetString(2);
                    userInfo["RestaurantId"] = reader.GetInt32(0).ToString();
                }
            }
            return userInfo;
        }
    }
}
