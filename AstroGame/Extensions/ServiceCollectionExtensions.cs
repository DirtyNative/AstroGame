using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Databases;
using AstroGame.Api.Factories;
using AstroGame.Api.Repositories;
using AstroGame.Generator.Generators;
using AstroGame.Generator.Generators.ObjectGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AstroGame.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            /*services.AddScoped<MoonSystemGenerator>();
            services.AddScoped<PlanetSystemGenerator>();
            services.AddScoped<SolarSystemGenerator>();

            services.AddScoped<MoonGenerator>();
            services.AddScoped<PlanetGenerator>();
            services.AddScoped<StarGenerator>();

            services.AddScoped<SolarSystemNameGenerator>();

            services.AddScoped<MultiObjectSystemRepository>();
            services.AddScoped<SingleObjectSystemRepository>();
            services.AddScoped<SolarSystemRepository>();
            services.AddScoped<StarRepository>();
            services.AddScoped<PlanetRepository>();
            services.AddScoped<MoonRepository>();

            services.AddScoped<MultiObjectSystemManager>();
            services.AddScoped<SingleObjectSystemManager>();
            services.AddScoped<SolarSystemManager>();
            services.AddScoped<StarManager>();
            services.AddScoped<PlanetRepository>();
            services.AddScoped<MoonRepository>(); */

            /*services.AddSingleton<GeneratorFactory>(provider =>
                new GeneratorFactory(provider, provider.GetService<StarPrefabRepository>())); */

            services.AddScoped(
                (provider) => new StarGeneratorFactory(provider,
                        provider.GetService<StarPrefabRepository>())
                    .Create<StarGenerator>());

            services.AddScoped(
                (provider) => new PlanetGeneratorFactory(provider,
                        provider.GetService<PlanetPrefabRepository>(),
                        provider.GetService<PlanetAtmospherePrefabRepository>())
                    .Create());

            var assembliesToBeScanned = new[] {"AstroGame"};
            //services.AddServicesOfType<IScopedService>(assembliesToBeScanned);
            //services.AddServicesOfType<ISingletonService>(assembliesToBeScanned);
            //services.AddServicesOfType<ITransientService>(assembliesToBeScanned);
            services.AddServicesWithAttributeOfType<ScopedServiceAttribute>(assembliesToBeScanned);
            services.AddServicesWithAttributeOfType<SingletonServiceAttribute>(assembliesToBeScanned);
            services.AddServicesWithAttributeOfType<TransientServiceAttribute>(assembliesToBeScanned);

            //services.AddServicesOfType<IScopedService>();

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

            services.AddDbContext<AstroGameDataContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}