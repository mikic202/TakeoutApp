using Dish;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GRPC_Server.DatsbseInteractors;
using Microsoft.AspNetCore.Identity;
using MySqlConnector;
using ProtoRegister;
using Signin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takeout;

namespace Takeout_Server.Services
{
    public class TakeoutServer : TakeOutService.TakeOutServiceBase
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
                if (!await UserDatabsaeInteractor.checkUserExistance(request.Usertname, conn))
                {
                    return new SigninReply { Outcome = false };
                }
                var user_info = await UserDatabsaeInteractor.getUserInformation(request.Usertname, conn);
                if (!user_info["Password"].Equals(request.Password))
                {
                    return new SigninReply { Outcome = false };
                }
                var reply = new SigninReply { Outcome = true, UserId = int.Parse(user_info["UserId"]) };
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
                if (!restaurantInfo["Password"].Equals(request.Password))
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
                return new RegisterRestaurantReply { Outcome = await RestaurantDatabaseInteractor.registerRestaurant(requrst.RestaurantName, requrst.Password, requrst.RestaurantLocation.Longitude, requrst.RestaurantLocation.Latitude, conn) };
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
                return new addDishReply
                {
                    Outcome = await DishDatabseInteractor.addDish(requrst.DishName, requrst.DishDescription, requrst.DishPrice, requrst.RestaurantId, conn),
                    DishId = await DishDatabseInteractor.getDishId(requrst.DishName, requrst.RestaurantId, conn)
                };
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
                return new modifyDishReply
                {
                    Outcome = await DishDatabseInteractor.modifyDish(request.DishId, request.DishName, request.DishDescription, request.DishPrice, conn)
                };
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
                foreach (Order order_to_add in await OrdersDatabaseInteractor.getOrders(request.RestaurantId, conn))
                {
                    var order = new ProtoOrder();
                    foreach (var dish in await DishDatabseInteractor.fillDishInfo(await OrdersDatabaseInteractor.getDishesInOrder(order_to_add.Id, conn), conn))
                    {
                        order.Dishes.Add(new ProtoDish { DishId = dish.Id, DishName = dish.Name, DishDescription = dish.Description, DishPrice = dish.Price });
                    }
                    order.DeliveryLocation = new Location.Location();
                    order.DeliveryLocation.Latitude = (int)order_to_add.latitude;
                    order.DeliveryLocation.Longitude = (int)order_to_add.longitude;
                    order.OrderDate = Timestamp.FromDateTime(DateTime.SpecifyKind(order_to_add.date, DateTimeKind.Utc));
                    order.OrderId = order_to_add.Id;
                    order.UserId = order_to_add.userId;
                    reply.Orders.Add(order);
                }

            }
            return reply;
        }

        public override async Task<addOrderResponse> AddOrder(addOrderRequest request, ServerCallContext context)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                Port = 3306,
                Database = "takout_db",
                UserID = "root",
                Password = "",
            };
            var order = new Order();
            order.fillWithProtoOrder(request.Order);
            List<int> dishes = new List<int> { };
            foreach (var dish in request.Order.Dishes)
            {
                dishes.Add(dish.DishId);
            }
            var reply = new addOrderResponse();
            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                conn.Open();
                reply = new addOrderResponse { Outcome = await OrdersDatabaseInteractor.addOrder(order, dishes, conn) };
            }
            return reply;
        }

        public override async Task<orderInfoResponse> GetOrderInfo(orderInfoRequest request, ServerCallContext context)
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
                var order = await OrdersDatabaseInteractor.getOrderInfo(request.OrderId, conn);
                return new orderInfoResponse
                {
                    Order = new ProtoOrder
                    {
                        OrderId = order.Id,
                        UserId = order.userId,
                        RestaurantId = order.restaurantId,
                        OrderStatus = order.status,
                        OrderDate = new Timestamp { Seconds = order.date.Second },
                        DeliveryLocation = new Location.Location { Latitude = (int)order.latitude, Longitude = (int)order.longitude }
                    }
                };
            }
        }

        public override async Task<setOrderStatusResponse> SetOrderStatus(setOrderStatusRequest request, ServerCallContext context)
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
                return new setOrderStatusResponse { Outcome = await OrdersDatabaseInteractor.changeOrderStatus(request.OrderId, request.OrderStatus, conn) };
            }
        }

        public override async Task<ModifyRestaurantInformationResponse> ModifyRestaurantInfo(ModifyRestaurantInformationRequest request, ServerCallContext context)
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
                if (!(await RestaurantDatabaseInteractor.getRestaurantInformation(request.RestaurantId, conn))["Password"].Equals(request.Password))
                {
                    return new ModifyRestaurantInformationResponse { Outcome = false };
                }
                return new ModifyRestaurantInformationResponse
                {
                    Outcome = await RestaurantDatabaseInteractor.setRestaurantInformation(request.RestaurantId, request.RestaurantName,
                    request.RestaurantLocation.Latitude, request.RestaurantLocation.Longitude, conn)
                };
            }
        }
        public override async Task<ModifyRestaurantPasswordResponse> ModifyRestaurantPassword(ModifyRestaurantPasswordRequest request, ServerCallContext context)
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
				if (!(await RestaurantDatabaseInteractor.getRestaurantInformation(request.RestaurantId, conn))["Password"].Equals(request.Password))
				{
                    return new ModifyRestaurantPasswordResponse { Outcome = false };
                }
                return new ModifyRestaurantPasswordResponse
                {
                    Outcome = await RestaurantDatabaseInteractor.setRestaurantPassword(request.RestaurantId, request.Password, conn)
                };
            }
        }

		public override async Task<RestaurantInfoReply> GetRestaurantInfo(RestaurantInfoRequest request, ServerCallContext context)
		{
            var reply = new RestaurantInfoReply();
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
                var restaurnt = await RestaurantDatabaseInteractor.getRestaurantInformation(request.RestaurantId, conn);
                reply.RestaurantName = restaurnt["restaurnatName"];
                Console.WriteLine(restaurnt["Longitude"]);
				reply.RestaurantLocation = new Location.Location { Longitude = (int)decimal.Parse(restaurnt["Longitude"]), Latitude = (int)decimal.Parse(restaurnt["Latitude"]) };
			}
			return reply;
		}

        public override async Task<AllDishesResponse> GetAllDishes(AllDishesRequest request, ServerCallContext context)
        {
            var reply = new AllDishesResponse();
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
                var dishes = await DishDatabseInteractor.getRestaurantsDishes(request.RestaurantId, conn);
                foreach(var dish in dishes)
                {
                    reply.Dishes.Add(new ProtoDish { DishDescription = dish.Description, DishId = dish.Id, DishPrice = dish.Price, DishName = dish.Name });
                }
            }
            return reply;
        }

		public override async Task<deleteDishResponse> DeleteDish(deleteDishRequest request, ServerCallContext context)
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
				return new deleteDishResponse
				{
                    Outcome = await DishDatabseInteractor.deleteDish(request.DishId, conn)
				};
			}
		}
	}

}
