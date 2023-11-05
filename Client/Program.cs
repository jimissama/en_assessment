using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EN.Client;
using EN.Client.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IBingMapAutoSuggestService, BingMapAutoSuggestService>();
builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();
