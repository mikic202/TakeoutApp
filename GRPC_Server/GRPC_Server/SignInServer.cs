using Grpc.Core;
using Signin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPC_Server
{
	public class SignInServer : LoggingInProvider.LoggingInProviderBase
	{
		public override Task<SigninReply> Signin(SigninRequest request, ServerCallContext context)
		{
			Console.WriteLine("Got message");
			return Task.FromResult(new SigninReply {Outcome = true });
		}
	}
}
