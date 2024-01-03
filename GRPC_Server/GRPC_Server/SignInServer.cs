using Dish;
using Grpc.Core;
using GRPC_Server.DatsbseInteractors;
using MySqlConnector;
using Register;
using Signin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takeout;

namespace GRPC_Server
{
	public class SignInServer : TakeOutService.TakeOutServiceBase
	{
		async public override Task<SigninReply> Signin(SigninRequest request, ServerCallContext context)
		{
			Console.WriteLine("Got message");
			var builder = new MySqlConnectionStringBuilder
			{
				Server = "127.0.0.1",
				Port = 3306,
				Database = "takout_db",
				UserID = "root",
				Password = "",
			};
			using (var conn = new MySqlConnection(builder.ConnectionString))
			{
				conn.Open();
				if(!await UserDatabsaeInteractor.checkUserExistance(request.Usertname, conn))
				{
					return new SigninReply { Outcome = false };
				}
				var user_info = await UserDatabsaeInteractor.getUserInformation(request.Usertname, conn);
				if(user_info["Password"] != request.Password)
				{
					return new SigninReply { Outcome = false };
				}
				var reply = new SigninReply { Outcome = true, UserId = int.Parse(user_info["UserId"])};
				return reply;
			}
		}
		public override async Task<RestaurantSigninReply> SigninRestaurant(RestaurantSigninRequest request, ServerCallContext context)
		{
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                Port = 3306,
                Database = "takout_db",
                UserID = "root",
                Password = "",
            };
            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                conn.Open();
                if (!await RestaurantDatabaseInteractor.checkRestaurantsExistance(request.Restaurantname, conn))
                {
                    return new RestaurantSigninReply { Outcome = false };
                }
                var restaurantInfo = await RestaurantDatabaseInteractor.getRestaurantInformation(request.Restaurantname, conn);
                if (restaurantInfo["Password"] != request.Password)
                {
                    return new RestaurantSigninReply { Outcome = false };
                }
                var reply = new RestaurantSigninReply { Outcome = true, RestaurantId = int.Parse(restaurantInfo["RestaurantId"]) };
                return reply;
            }
		}

		public override async Task<RegisterRestaurantReply> RegisterRestaurant(RegisterRestaurantRequest requrst, ServerCallContext context)
		{
			Console.WriteLine("Got register request");
			var builder = new MySqlConnectionStringBuilder
			{
				Server = "127.0.0.1",
				Port = 3306,
				Database = "takout_db",
				UserID = "root",
				Password = "",
			};
			Console.WriteLine("Greeting ");
			using (var conn = new MySqlConnection(builder.ConnectionString))
			{
				conn.Open();
				return (new RegisterRestaurantReply { Outcome = await RestaurantDatabaseInteractor.registerRestaurant(requrst.RestaurantName, requrst.Password, conn) });
			}
		}

        public override async Task<addDishReply> AddDish(addDishRequest requrst, ServerCallContext context)
        {
            Console.WriteLine("Got register request");
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                Port = 3306,
                Database = "takout_db",
                UserID = "root",
                Password = "",
            };
            Console.WriteLine("Greeting ");
            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                conn.Open();
                return (new addDishReply { Outcome = await DishDatabseInteractor.addDish(requrst.DishName, requrst.DishDescription, requrst.DishPrice, requrst.RestaurantId, conn), 
					DishId = await DishDatabseInteractor.getDishId(requrst.DishName, requrst.RestaurantId, conn) });
            }
        }

		public override async Task<modifyDishReply> ModifyDish(modifyDishRequest request, ServerCallContext context)
		{
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                Port = 3306,
                Database = "takout_db",
                UserID = "root",
                Password = "",
            };
            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                conn.Open();
                return (new modifyDishReply
                {
                    Outcome = await DishDatabseInteractor.modifyDish(request.DishId,  request.DishName, request.DishDescription, request.DishPrice, conn)
                });
            }
        }
    
        public override async Task<allOrdersResponse> GetAllOrders(allOrdersRequest request, ServerCallContext context) 
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                Port = 3306,
                Database = "takout_db",
                UserID = "root",
                Password = "",
            };
            var reply = new allOrdersResponse();
            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                conn.Open();
                foreach(Order order_to_add in await OrdersDatabaseInteractor.getOrders(request.RestaurantId, conn))
                {
                    var order = new ProtoOrder();
                    foreach(var dish in await DishDatabseInteractor.fillDishInfo(await OrdersDatabaseInteractor.getDishesInOrder(order_to_add.Id, conn), conn))
                    {
                        order.Dishes.Add(new ProtoDish { DishId = dish.Id, DishName = dish.Name, DishDescription = dish.Description, DishPrice = dish.Price });
                    }
                    order.DeliveryLocation.Latitude = (int)order_to_add.latitude;
                    order.DeliveryLocation.Longitude = (int)order_to_add.longitude;
                    reply.Orders.Add(order);
                }
                
            }
            return reply;
        }
    }

}
