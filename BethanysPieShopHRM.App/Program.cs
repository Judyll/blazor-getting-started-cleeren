using BethanysPieShopHRM.App.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.App
{
    public class Program
    {
        /**
         * The entry point of the application
         */
        public static async Task Main(string[] args)
        {
            /**
             * Set-up the web assembly host
             */
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            /**
             * Assigning the root component and associating the App class to the <app> tag
             * that we are using in the index.html
             */
            builder.RootComponents.Add<App>("app");
            /**
             * Just like ASP.NET CORE, Blazor also contains a dependency injection container.
             * The below is injecting the HttpClient in the services collection of our Blazor
             * application. 
             */
            // builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            /**
             * We are now bringing in the http client factory and its services and we are 
             * registering the EmployeeDataService with its interface and it will automatically
             * get an http client injected instance. We are setting it up that the base
             * address is the endpoint of our API.
             */
            builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client => client.BaseAddress = new Uri("https://localhost:44340"));
            /**
             * This now runs the web assembly host.
             */
            await builder.Build().RunAsync();
        }
    }
}
