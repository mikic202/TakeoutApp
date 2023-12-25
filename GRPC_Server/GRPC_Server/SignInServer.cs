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
                if (!await RestaurantDatabaseInteractor.checkRestaurantsExistance(request.Usertname, conn))
                {
                    return new RestaurantSigninReply { Outcome = false };
                }
                var user_info = await RestaurantDatabaseInteractor.getRestaurantInformation(request.Usertname, conn);
                if (user_info["Password"] != request.Password)
                {
                    return new RestaurantSigninReply { Outcome = false };
                }
                var reply = new RestaurantSigninReply { Outcome = true, RestaurantId = int.Parse(user_info["RestaurantId"]) };
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
	}
}
