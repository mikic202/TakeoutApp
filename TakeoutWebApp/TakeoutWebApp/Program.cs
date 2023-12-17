using Blazored.LocalStorage;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TakeoutWebApp;
using Grpc.Net.Client.Web;
//using Grpc.AspNetCore;
using static TakeoutWebApp.Pages.Orders;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddGrpc();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton(services =>
{
	Console.WriteLine("Log me in!");
	var httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
	Console.WriteLine("Log me in!");
	var config = services.GetRequiredService<IConfiguration>();
	Console.WriteLine("Log me in!");
	var backendUrl = "http://localhost:10001";
	Console.WriteLine("Log me in!");
	return GrpcChannel.ForAddress(backendUrl, new GrpcChannelOptions { HttpHandler = httpHandler });
});

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();

await builder.Build().RunAsync();
