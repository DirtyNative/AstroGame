using AstroGame.Api.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AstroGame.Api
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
                .AddEnvironmentalJsonFile("Configurations/AppSettings.json")
                .AddEnvironmentalJsonFile("Configurations/DatabaseConnection.json")
                .Build();

            return WebHost.CreateDefaultBuilder(args)
                .SetEnvironment()
                .UseConfiguration(configuration)
                .UseUrls($"https://*:{configuration["AstroGame:LocalPort"]}")
                .UseStartup<Startup>();
        }
    }
}