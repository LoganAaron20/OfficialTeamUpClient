using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OfficialTeamUpClient;
using Microsoft.Extensions.DependencyInjection;
using OfficialTeamUpClient.User;
using Microsoft.AspNetCore.Components.Authorization;
using OfficialTeamUpClient.StateProviders;
using OfficialTeamUpClient.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7065") });
builder.Services.AddSingleton<UserService>();
builder.Services.AddScoped<INewsService, NewsService>();


ApiClient.Initialize(builder.Services.BuildServiceProvider().GetRequiredService<HttpClient>());

builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
