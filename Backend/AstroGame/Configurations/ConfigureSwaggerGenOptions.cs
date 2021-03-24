using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AstroGame.Api.Filters;
using AstroGame.Shared.Apis;
using IdentityModel.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AstroGame.Api.Configurations
{
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ConfigureSwaggerGenOptions(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public void Configure(SwaggerGenOptions options)
        {
            var discoveryDocument = GetDiscoveryDocument();

            options.OperationFilter<AuthorizeOperationFilter>();
            options.DescribeAllParametersInCamelCase();
            options.CustomSchemaIds(x => x.FullName);
            options.SwaggerDoc("v1", CreateOpenApiInfo());

            options.AddSecurityDefinition("OAuth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,

                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri(discoveryDocument.AuthorizeEndpoint),
                        TokenUrl = new Uri(discoveryDocument.TokenEndpoint),
                        Scopes = new Dictionary<string, string>
                        {
                            {Scopes.ApiScope, "Balea Server HTTP Api"}
                        },
                    }
                },
                Description = "Balea Server OpenId Security Scheme"
            });
        }

        private DiscoveryDocumentResponse GetDiscoveryDocument()
        {
            return _httpClientFactory
                .CreateClient()
                .GetDiscoveryDocumentAsync("https://localhost:7556")
                .GetAwaiter()
                .GetResult();
        }

        private OpenApiInfo CreateOpenApiInfo()
        {
            return new OpenApiInfo()
            {
                Title = "My Awesome API",
                Version = "v1",
                Description = "My Awesome API",
                Contact = new OpenApiContact() {Name = "API", Url = new Uri("https://github.com/lurumad")},
                License = new OpenApiLicense()
            };
        }
    }
}