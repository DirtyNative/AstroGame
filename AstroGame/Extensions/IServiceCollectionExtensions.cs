using AstroGame.Api.Databases;
using AstroGame.Api.Repositories;
using AstroGame.Generator.Generators.NameGenerators;
using AstroGame.Generator.Generators.ObjectGenerators;
using AstroGame.Generator.Generators.SystemGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AstroGame.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<MoonSystemGenerator>();
            services.AddScoped<PlanetSystemGenerator>();
            services.AddScoped<SolarSystemGenerator>();

            services.AddScoped<MoonGenerator>();
            services.AddScoped<PlanetGenerator>();
            services.AddScoped<StarGenerator>();

            services.AddScoped<SolarSystemNameGenerator>();

            services.AddScoped<SolarSystemRepository>();

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