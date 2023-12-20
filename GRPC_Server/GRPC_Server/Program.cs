using Grpc.Core;
using GRPC_Server;
using GRPC_Server.DatsbseInteractors;
using MySqlConnector;
using Signin;

//const int Port = 10001;
//Server server = new Server
//{
//	Services = { LoggingInProvider.BindService(new SignInServer()) },
//	Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) },
//};
//server.Start();

//Console.WriteLine("Greeter Server on " + Port);
//Console.WriteLine("Press any key to stop the server");
//Console.ReadKey();

//server.ShutdownAsync().Wait();

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
	var outcome = await UserDatabsaeInteractor.getUserInformation("some_user", conn);
	Console.WriteLine(outcome["UserId"]);
	conn.Close();
}