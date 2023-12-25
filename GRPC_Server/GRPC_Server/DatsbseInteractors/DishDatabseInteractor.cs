using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPC_Server.DatsbseInteractors
{
    internal class DishDatabseInteractor
    {
        async public static Task<bool> addDish(string dishName, string dishDescription, float price, int restaurantId, MySqlConnection connection)
        {
            // password should be hashed on the users end
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO dishes (dish_name, description, price, restaurant_id) values " +
                    "(@name, @description, @price, @rest_id);";
                command.Parameters.AddWithValue("@price", price) ;
                command.Parameters.AddWithValue("@description", dishDescription);
                command.Parameters.AddWithValue("@name", dishName);
                command.Parameters.AddWithValue("@rest_id", restaurantId);
                try
                {
                    await command.ExecuteNonQueryAsync();
                }
                catch { return false; }

            }
            return true;
        }

        async public static Task<bool> modifyDish(int disdId, string dishName, string dishDescription, float price, MySqlConnection connection)
        {
            // password should be hashed on the users end
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "update dishes set price=@price, description=@description, dish_name=@name where dish_id=@dish_id";
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@description", dishDescription);
                command.Parameters.AddWithValue("@name", dishName);
                command.Parameters.AddWithValue("@dish_id", disdId);
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
