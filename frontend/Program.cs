using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using frontend;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Use the backend running locally when in development, otherwise use the app origin
var backendBaseAddress = builder.HostEnvironment.IsDevelopment() ? "http://localhost:5099/" : builder.HostEnvironment.BaseAddress;

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(backendBaseAddress) });

await builder.Build().RunAsync();
