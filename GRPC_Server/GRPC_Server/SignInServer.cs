﻿using Grpc.Core;
using GRPC_Server.DatsbseInteractors;
using MySqlConnector;
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
		public override Task<RestaurantSigninReply> SigninRestaurant(RestaurantSigninRequest request, ServerCallContext context)
		{
			var builder = new MySqlConnectionStringBuilder
			{
				Server = "127.0.0.1",
				Port = 3306,
				Database = "PAP_app",
				UserID = "root",
				Password = "",
			};
			var conn = new MySqlConnection(builder.ConnectionString);
			Console.WriteLine("Got message");
			var reply = new RestaurantSigninReply { Outcome = UserDatabsaeInteractor.checkUserExistance(request.Usertname, conn).Result };
			conn.Close();
			return Task.FromResult(reply);
		}
	}
}
