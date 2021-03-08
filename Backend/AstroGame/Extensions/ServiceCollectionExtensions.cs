using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Databases;
using AstroGame.Api.Factories;
using AstroGame.Api.Repositories;
using AstroGame.Api.Repositories.Resources;
using AstroGame.Api.Repositories.Stellar;
using AstroGame.Core.Storage;
using AstroGame.Generator.Generators.ResourceGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AstroGame.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Load the configuration
            services.Configure<FileStorage>(configuration.GetSection("FileStorage"));
            var fileStorage = new FileStorage();
            configuration.GetSection("FileStorage").Bind(fileStorage);

            services.AddScoped(
                (provider) => new StarGeneratorFactory(provider)
                    .Create());

            services.AddScoped(
                (provider) => new PlanetGeneratorFactory(provider,
                        resourceGenerator: provider.GetService<ResourceGenerator>())
                    .Create());

            services.AddScoped(
                (provider) => new MoonGeneratorFactory(provider)
                    .Create());

            services.AddScoped<ResourceGenerator>((provider) =>
                new ResourceGeneratorFactory(resourceRepository: provider.GetService<ResourceRepository>()).Create());

            // The file client which provides us a location to store files
            services.AddScoped<IFileClient, LocalFileClient>(client =>
            {
                var imageDirectory = fileStorage.Path;
                return new LocalFileClient(imageDirectory);
            });


            var assembliesToBeScanned = new[] {"AstroGame"};
            services.AddServicesWithAttributeOfType<ScopedServiceAttribute>(assembliesToBeScanned);
            services.AddServicesWithAttributeOfType<SingletonServiceAttribute>(assembliesToBeScanned);
            services.AddServicesWithAttributeOfType<TransientServiceAttribute>(assembliesToBeScanned);

            return services;
        }

        public static IServiceCollection ConfigureDatabase(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<DatabaseConnection>(configuration.GetSection("DatabaseConnection"));
            var databaseConnection = new DatabaseConnection();
            configuration.GetSection("DatabaseConnection").Bind(databaseConnection);

            var connectionString = string.Format(databaseConnection.DatabaseConnectionString,
                databaseConnection.DatabaseName,
                databaseConnection.DatabaseAccount, databaseConnection.DatabasePassword);

            services.AddDbContext<AstroGameDataContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();
            });

            return services;
        }
    }
}