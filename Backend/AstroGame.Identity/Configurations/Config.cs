using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using AstroGame.Shared.Apis;

namespace AstroGame.Identity.Configurations
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

		public static IEnumerable<ApiResource> Apis =>
			new List<ApiResource>
			{
				new ApiResource(Scopes.ApiScope, "AstroGame")
				{
					Scopes = new List<string>
					{
                        Scopes.ApiScope
					}
				},
            };

		public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>()
		{
			new ApiScope(Scopes.ApiScope, "AstroGame API"),
		};

		public static IEnumerable<Client> Clients =>
			new List<Client>
			{
				new Client
				{
					ClientId = "astrogame.app",
					AllowedGrantTypes = new List<string>
					{
						GrantType.ClientCredentials,
						GrantType.ResourceOwnerPassword
					},
					ClientSecrets =
					{
						new Secret(
							"1a7e52d9a1494bb66649478381244ffdfc480ad4507c1f854977e6cecccab5a7"
								.Sha256()),
					},
					AllowedScopes =
					{
                        Scopes.ApiScope,
						"offline_access"
					},
					AllowOfflineAccess = true,
					RefreshTokenExpiration = TokenExpiration.Sliding,
					AccessTokenLifetime = 3600
				},

				new Client
                {
					ClientId = "astrogame.swagger",
                    ProtocolType = "oidc",
                    ClientSecrets =
                    {
                        new Secret(
                            "c6b5e39d22bf8d6b4f09ffc9241fb2d89c82344e9fa1e286d0cf2b866921468f"
                                .Sha256()),
                    },
                    ClientName = "AstroGame - Swagger",
                    AllowedGrantTypes =
                    {
                        GrantType.Implicit,
                    },
                    RedirectUris =
                    {
                        "https://localhost:7555/swagger/oauth2-redirect.html",
                        "https://stage.astrogame.app/swagger/oauth2-redirect.html",
                    },
                    AllowedScopes =
                    {
                        Scopes.SwaggerScope,
                    },
                    AllowAccessTokensViaBrowser = true
				}
            };

		public static void InitializeDatabase(IApplicationBuilder app)
		{
			using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
			serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

			var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
			context.Database.Migrate();
			context.SaveChanges();

			{
				// Remove all clients
				var all = from c in context.Clients select c;
				context.Clients.RemoveRange(all);
				context.SaveChanges();

				// Re-add them all
				foreach (var client in Clients)
				{
					context.Clients.Add(client.ToEntity());
				}

				context.SaveChanges();
			}

			{
				// Remove all clients
				var all = from c in context.IdentityResources select c;
				context.IdentityResources.RemoveRange(all);
				context.SaveChanges();

				// Re-add them all
				foreach (var resources in IdentityResources)
				{
					context.IdentityResources.Add(resources.ToEntity());
				}

				context.SaveChanges();
			}

			{
				// Remove all clients
				var all = from c in context.ApiResources select c;
				context.ApiResources.RemoveRange(all);
				context.SaveChanges();

				// Re-add them all
				foreach (var api in Apis)
				{
					context.ApiResources.Add(api.ToEntity());
				}

				context.SaveChanges();
			}

			{
				// Remove all clients
				var all = from c in context.ApiScopes select c;
				context.ApiScopes.RemoveRange(all);
				context.SaveChanges();

				// Re-add them all
				foreach (var scopes in ApiScopes)
				{
					context.ApiScopes.Add(scopes.ToEntity());
				}

				context.SaveChanges();
			}
		}
	}
}
