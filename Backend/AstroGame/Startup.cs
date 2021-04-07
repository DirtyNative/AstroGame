using AstroGame.Api.Extensions;
using AstroGame.Api.Filters;
using AstroGame.Api.Helpers;
using AstroGame.Shared.Apis;
using AstroGame.Shared.Middlewares;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Storage.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using AstroGame.Api.Services;
using Hangfire;

namespace AstroGame.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: Check if that helps anything
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;

            services.AddControllers();
            services
                //.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>()
                .RegisterServices(Configuration)
                .ConfigureDatabase(Configuration)
                .RegisterServiceApis(Configuration)
                .ConfigureAutoMapper()
                .ConfigureHangfire(Configuration);

            //services.AddHostedService<SolarSystemGeneratorService>();

            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
                options.SerializerSettings.SerializationBinder = new KnownTypesBinder()
                {
                    KnownTypes = typeof(Planet).Assembly.GetTypes()
                };
            });

            services.AddIdentityServerAuthentication(Configuration);

            services.AddIdentityServerAuthenticationForSwagger<AuthorizeCheckOperationFilter>(Configuration, "v1",
                "AstroGame API", new Dictionary<string, string>
                {
                    {Scopes.ApiScope, "AstroGameApi"}
                });


            services.AddSignalR();

            //services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "AstroGame", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AstroGameDataContext dataContext)
        {
            // migrate any database changes on startup (includes initial db creation)
            dataContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AstroGame v1");
                    //c.DocumentTitle = "AstroGame";

                    c.OAuthClientId("astrogame.swagger");

                    //c.OAuthClientSecret("c6b5e39d22bf8d6b4f09ffc9241fb2d89c82344e9fa1e286d0cf2b866921468f");
                    c.OAuthAppName("AstroGame - Swagger");
                    //c.OAuthUsePkce();
                });
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseHangfireDashboard();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}