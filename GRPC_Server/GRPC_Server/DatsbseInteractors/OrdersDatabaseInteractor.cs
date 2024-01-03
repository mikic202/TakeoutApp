using MySqlConnector;
using System;
using System.Collections.Generic;
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
                        orders.Add(new Order { Id = reader.GetInt32(0), restaurantId = reader.GetInt32(1), longitude = reader.GetFloat(3), latitude = reader.GetFloat(3) });
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
    }
}
