using System;
using System.Collections.Generic;
using AstroGame.Api.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using AstroGame.Shared.Apis;


namespace AstroGame.Api.Helpers
{
    public static class IdentityHelpers
	{
		public static IServiceCollection AddIdentityServerAuthentication(this IServiceCollection services,
			IConfiguration configuration, string apiName, string secret = "clientSecret")
		{
			services.AddAuthentication("Bearer")
				.AddIdentityServerAuthentication(options =>
				{
					var serviceConnections = new ApiConnections();
					configuration.GetSection("ApiConnections").Bind(serviceConnections);

					options.Authority = serviceConnections.AuthorizationApi;
					options.ApiName = apiName;
					options.ApiSecret = secret;
				});

			return services;
		}

		public static IServiceCollection AddIdentityServerAuthenticationForSwagger<T>(this IServiceCollection services,
			IConfiguration configuration,
			string apiVersion, string apiName, Dictionary<string, string> scopes)
			where T : AuthorizeCheckOperationFilter
		{
			var serviceConnections = new ApiConnections();
			configuration.GetSection("ApiConnections").Bind(serviceConnections);
			var identityServiceConnection = serviceConnections.AuthorizationApi;

			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc(apiVersion, new OpenApiInfo
				{
					Title = apiName,
					Version = apiVersion,
				});

				options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
				{
					Type = SecuritySchemeType.OAuth2,
					Flows = new OpenApiOAuthFlows
					{
						Password = new OpenApiOAuthFlow
						{
							AuthorizationUrl = new Uri(identityServiceConnection + "/connect/authorize",
								UriKind.Absolute),
                            TokenUrl = new Uri(identityServiceConnection + "/connect/token"),
							Scopes = scopes
						}
					}
				});

				options.OperationFilter<T>(new List<string>(scopes.Values));
			});

			return services;
		}
	}
}
