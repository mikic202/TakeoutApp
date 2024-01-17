using Takeout_Server.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(o => o.AddDefaultPolicy(builder =>
{
	builder.AllowAnyOrigin()
		   .AllowAnyMethod()
		   .AllowAnyHeader()
		   .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
}));

builder.Services.AddGrpc();

var app = builder.Build();

app.UseCors();
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

// Configure the HTTP request pipeline.
app.MapGrpcService<TakeoutServer>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

/*using GRPC_Server.DatsbseInteractors;
using MySqlConnector;
using Signin;

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
	var reply = new RestaurantInfoReply();
	conn.Open();
	var restaurnt = await RestaurantDatabaseInteractor.getRestaurantInformation(4, conn);
	reply.RestaurantName = restaurnt["restaurnatName"];
	Console.WriteLine(restaurnt["Longitude"]);
	reply.RestaurantLocation = new Location.Location { Longitude = (int)decimal.Parse(restaurnt["Longitude"]), Latitude = (int)decimal.Parse(restaurnt["Latitude"])};
}*/


