using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AstroGame.Api.Filters
{
    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public AuthorizeCheckOperationFilter(List<string> scopes)
        {
            Scopes = scopes;
        }

        public List<string> Scopes { get; }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasAuthorize = context.MethodInfo.DeclaringType != null && context.MethodInfo.DeclaringType
                .GetCustomAttributes(true).OfType<AuthorizeAttribute>()
                .Any();

            if (hasAuthorize == false)
            {
                return;
            }

            operation.Responses.Add("401", new OpenApiResponse
            {
                Description = "Unauthorized"
            });
            operation.Responses.Add("403", new OpenApiResponse
            {
                Description = "Forbidden"
            });

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "oauth2",
                                Type = ReferenceType.SecurityScheme
                            },

                            UnresolvedReference = true
                        },
                        Scopes
                    }
                }
            };
        }
    }
}