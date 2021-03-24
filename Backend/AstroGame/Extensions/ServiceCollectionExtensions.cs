using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Factories;
using AstroGame.Core.Storage;
using AstroGame.Generator.Generators;
using AstroGame.Generator.Generators.ResourceGenerators;
using AstroGame.Shared.Apis;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Storage.Database;
using AstroGame.Storage.Repositories.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using Microsoft.AspNetCore.Builder;

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

            services.AddScoped<IStellarObjectGenerator<Star>>(
                (provider) => new StarGeneratorFactory(provider)
                    .Create());

            services.AddScoped<IStellarObjectGenerator<Planet>>(
                (provider) => new PlanetGeneratorFactory(provider,
                        provider.GetService<ResourceStellarObjectGenerator>())
                    .Create());

            services.AddScoped<IStellarObjectGenerator<Moon>>(
                (provider) => new MoonGeneratorFactory(provider)
                    .Create());

            services.AddScoped<IStellarObjectGenerator<BlackHole>>((provider) =>
                new BlackHoleGeneratorFactory(provider).Create());

            services.AddScoped((provider) =>
                new ResourceGeneratorFactory(provider.GetService<ResourceRepository>()).Create());

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
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("AstroGame.Storage"));
                options.UseSqlServer(builder => { builder.EnableRetryOnFailure(); });
            });

            return services;
        }

        public static IServiceCollection RegisterServiceApis(this IServiceCollection services,
            IConfiguration configuration)
        {
            var serviceConnections = new ApiConnections();
            configuration.GetSection("ApiConnections").Bind(serviceConnections);

            // IdentityService
            services.AddRefitClient<IAuthorizationApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(serviceConnections.AuthorizationApi));

            return services;
        }

        /// <summary>
        /// Registers the api to be authenticated via IdentityServer4
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddIdentityServerAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            var serviceConnections = new ApiConnections();
            configuration.GetSection("ApiConnections").Bind(serviceConnections);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = serviceConnections.AuthorizationApi;
                    options.RequireHttpsMetadata = false;
                    options.ApiName = Scopes.ApiScope;
                });

            return services;
        }

        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps("AstroGame.Api"));

            services.AddSingleton(config.CreateMapper());

            return services;
        }
    }
}