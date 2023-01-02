using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MudBlazor.Services;
using Video.Streaming.Platform.Ui.Client;
using Video.Streaming.Platform.Ui.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<FetchDataService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7128");
});
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddScoped<IUserPreferencesService,UserPreferencesService>();
await builder.Build().RunAsync();