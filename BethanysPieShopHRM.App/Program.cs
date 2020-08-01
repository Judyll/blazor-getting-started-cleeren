using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            /**
             * This now runs the web assembly host.
             */
            await builder.Build().RunAsync();
        }
    }
}
