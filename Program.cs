using Microsoft.AspNetCore.Components.Web;  
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;  
using RecipeOrganizer; 
using RecipeOrganizer.Services;  
using System.Net.Http;  
using System; // Required for Uri  

var builder = WebAssemblyHostBuilder.CreateDefault(args);  

// Register the main application component  
builder.RootComponents.Add<App>("#app");  
builder.RootComponents.Add<HeadOutlet>("head::after");  

// Configure HttpClient with the base address from the hosting environment  
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });  

// Register services for dependency injection  
builder.Services.AddSingleton<RecipeService>(); // Ensure RecipeService is properly namespace-qualified  

// Build and run the application  
await builder.Build().RunAsync();