using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Databases;
using AstroGame.Api.Factories;
using AstroGame.Api.Repositories;
using AstroGame.Api.Repositories.Resources;
using AstroGame.Api.Repositories.Stellar;
using AstroGame.Generator.Generators.ResourceGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AstroGame.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(
                (provider) => new StarGeneratorFactory(provider,
                        provider.GetService<StarPrefabRepository>())
                    .Create());

            services.AddScoped(
                (provider) => new PlanetGeneratorFactory(provider,
                        planetPrefabRepository: provider.GetService<PlanetPrefabRepository>(),
                        planetAtmospherePrefabRepository: provider.GetService<PlanetAtmospherePrefabRepository>(),
                        ringsPrefabRepository: provider.GetService<RingsPrefabRepository>(),
                        cloudsPrefabRepository: provider.GetService<CloudsPrefabRepository>(),
                        resourceGenerator: provider.GetService<ResourceGenerator>())
                    .Create());

            services.AddScoped(
                (provider) => new MoonGeneratorFactory(provider,
                        provider.GetService<MoonPrefabRepository>())
                    .Create());

            services.AddScoped<ResourceGenerator>((provider) =>
                new ResourceGeneratorFactory(resourceRepository: provider.GetService<ResourceRepository>()).Create());

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