using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

		async public static Task<bool> registerRestaurant(string restaurantName, string password, float longitude, float latitude, MySqlConnection connection)
		{
			// password should be hashed on the users end
			if( await checkRestaurantsExistance(restaurantName, connection))
			{
				return false;
			}
			using (var command = connection.CreateCommand())
			{
				command.CommandText = $"INSERT INTO restaurants (restaurnat_name, password, longitude, latitude) values (\"{restaurantName}\", \"{password}\", {longitude}, {latitude});";
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

        async public static Task<Dictionary<string, string>> getRestaurantInformation(int restaurantId, MySqlConnection connection)
        {
            var userInfo = new Dictionary<string, string>();
            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM restaurants where restaurantId = \"{restaurantId}\";";

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        await reader.ReadAsync();
                        userInfo["restaurnatName"] = reader.GetString(1);
                        userInfo["Password"] = reader.GetString(2);
                        userInfo["RestaurantId"] = reader.GetInt32(0).ToString();
						userInfo["Longitude"] = reader.GetDecimal(3).ToString();
						userInfo["Latitude"] = reader.GetDecimal(4).ToString();
					}
                }
            }
            finally { }
            return userInfo;
        }

        async public static Task<bool> setRestaurantInformation(int restaurantId, string restaurantName, float latitude, float Longitude, MySqlConnection connection)
		{
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "update restaurants set restaurnat_name=@price, latitude=@description, longitude=@name where restaurantId=@rest_id";
                command.Parameters.AddWithValue("@price", restaurantName);
                command.Parameters.AddWithValue("@description", latitude);
                command.Parameters.AddWithValue("@name", Longitude);
                command.Parameters.AddWithValue("@rest_id", restaurantId);
				//await command.ExecuteNonQueryAsync();
				try
                {
                    await command.ExecuteNonQueryAsync();
                }
                catch { return false; }

            }
            return true;
        }

        async public static Task<bool> setRestaurantPassword(int restaurantId, string password, MySqlConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "update restaurants set password = @pass where restaurantId=@dish_id";
                command.Parameters.AddWithValue("@pass", password);
                command.Parameters.AddWithValue("@dish_id", restaurantId);
                try
                {
                    await command.ExecuteNonQueryAsync();
                }
                catch { return false; }

            }
            return true;
        }
    }
}
