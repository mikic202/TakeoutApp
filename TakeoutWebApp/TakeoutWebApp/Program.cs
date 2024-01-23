

using Blazored.LocalStorage;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TakeoutWebApp;
using Grpc.Net.Client.Web;
using static TakeoutWebApp.Pages.Orders;
using Takeout;

string MyAllowSpecificOriginss = "_myAllowSpecificOrigins";


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
/*builder.Services.AddSingleton(services =>
{
	var httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
	var config = services.GetRequiredService<IConfiguration>();
	var backendUrl = "http://localhost:10001";
	return GrpcChannel.ForAddress(backendUrl, new GrpcChannelOptions { HttpHandler = httpHandler });
});*/

builder.Services
	.AddGrpcClient<TakeOutService.TakeOutServiceClient>(options =>
	{
		options.Address = new Uri("https://takeoutserver20240123213756.azurewebsites.net");
	})
	.ConfigurePrimaryHttpMessageHandler(
		() => new GrpcWebHandler(new HttpClientHandler()));

builder.Services.AddCors(o => o.AddDefaultPolicy(builder =>
{
	builder.AllowAnyOrigin()
		   .AllowAnyMethod()
		   .AllowAnyHeader()
		   .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
}));


builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();


await builder.Build().RunAsync();
