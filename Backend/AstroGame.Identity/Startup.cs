using AstroGame.Identity.Configurations;
using AstroGame.Identity.Extensions;
using AstroGame.Identity.Validators;
using AstroGame.Shared.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AstroGame.Identity
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.RegisterServices(Configuration);
            services.ConfigureDatabase(Configuration);

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddMemoryCache();

            services.AddIdentityServer()
                //.AddResourceStore<ResourceStore>()
                .AddDeveloperSigningCredential()
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                .ConfigureIdentityServerDatabaseConnection(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (Environment.IsDevelopment() || Environment.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }

            // Seed the Database with correct values
            Config.InitializeDatabase(app);

            app.UseStaticFiles();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }
	}
}
