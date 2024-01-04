using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GRPC_Server.DatsbseInteractors
{
    internal class OrdersDatabaseInteractor
    {
        async public static Task<List<Order>> getOrders(int restaurantId, MySqlConnection connection)
        {
            var orders = new List<Order>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM orders where restaurant_id=@rest_id;";
                command.Parameters.AddWithValue("@rest_id", restaurantId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        orders.Add(new Order { Id = reader.GetInt32(0), restaurantId = reader.GetInt32(1), longitude = reader.GetFloat(4), latitude = reader.GetFloat(5), userId = reader.GetInt32(2)
                        , date = reader.GetDateTime(3)});
                    }
                }
            }
            return orders;
        }

        async public static Task<List<Dish>> getDishesInOrder(int orderId, MySqlConnection connection)
        {
            var orders = new List<Dish>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM dishes_in_orders where order_id=@order_id;";
                command.Parameters.AddWithValue("@order_id", orderId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        orders.Add(new Dish { Id = reader.GetInt32(1)});
                    }
                }
            }
            return orders;
        }

        async static public Task<int> getOrderId(int restaurantId, int userId, DateTime date, MySqlConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Select order_id from orders  where restaurant_id = @rest_id and user_id = @user_id and date = @date;";

                command.Parameters.AddWithValue("@rest_id", restaurantId);
                command.Parameters.AddWithValue("@user_id", userId);
                command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd hh:mm:ss"));
                Console.WriteLine(date.ToString("yyyy-MM-dd hh:mm:ss"));

                using (var reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    return reader.GetInt32(0);
                }
            }
        }

        async public static Task<bool> addOrder(Order order, List<int> dishesId, MySqlConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                var currentDate = DateTime.Now;
                command.CommandText = "INSERT INTO orders (restaurant_id, user_id, Longitude, Latitude, date) values " +
                    "(@rest_id, @user_id, @long, @lat, @date);";
                command.Parameters.AddWithValue("@rest_id", order.restaurantId);
                command.Parameters.AddWithValue("@user_id", order.userId);
                command.Parameters.AddWithValue("@long", order.longitude);
                command.Parameters.AddWithValue("@lat", order.latitude);
                command.Parameters.AddWithValue("@date", currentDate);
                try
                {
                    await command.ExecuteNonQueryAsync();
                }
                catch { return false; }

                int orderId = await getOrderId(order.restaurantId, order.userId, currentDate, connection);

                command.CommandText = "INSERT INTO dishes_in_orders (order_id, dish_id) values " +
                    "(@order_id, @dish_id);";
                command.Parameters.AddWithValue("@order_id", orderId);
                command.Parameters.Add("@dish_id", MySqlDbType.Int32);
                foreach (var dish_id in dishesId) {
                    command.Parameters["@dish_id"].Value = dish_id;
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch { return false; }
                }

            }
            return true;
        }
    }
}
