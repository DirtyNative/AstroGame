using AstroGame.Core.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AstroGame.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                //.AddEnvironmentalJsonFile("Configurations/AppSettings.json", false, true)
                .AddEnvironmentalJsonFile("Configurations/DatabaseConnection.json", false, true)
                .AddEnvironmentalJsonFile("Configurations/IdentityDatabaseConnection.json", false, true)
                //.AddEnvironmentalJsonFile("Configurations/ApiConnections.json")
                .Build();

            return WebHost.CreateDefaultBuilder(args)
                .SetEnvironment()
#if DEBUG
                .UseUrls("https://*:7556")
#elif RELEASE
				.UseUrls("https://*:8556")
#endif
                .UseStartup<Startup>()
                .UseConfiguration(configuration)
                .ConfigureLogging(logging =>
                {
                    // clear default logging providers
                    logging.ClearProviders();

                    // add built-in providers manually, as needed
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddEventSourceLogger();
                });
        }
    }
}
