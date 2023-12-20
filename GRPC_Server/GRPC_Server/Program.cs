using Grpc.Core;
using GRPC_Server;
using Signin;

const int Port = 10001;
Server server = new Server
{
	Services = { LoggingInProvider.BindService(new SignInServer()) },
	Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) },
};
server.Start();

Console.WriteLine("Greeter Server on " + Port);
Console.WriteLine("Press any key to stop the server");
Console.ReadKey();

server.ShutdownAsync().Wait();