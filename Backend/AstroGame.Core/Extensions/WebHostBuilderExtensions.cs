using Microsoft.AspNetCore.Hosting;

namespace AstroGame.Core.Extensions
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder SetEnvironment(
            this IWebHostBuilder hostBuilder)
        {
#if DEBUG
            return hostBuilder.UseEnvironment("Development");
#elif STAGING
			return hostBuilder.UseEnvironment("Staging");
#else
			return hostBuilder.UseEnvironment("Production");
#endif
        }
    }
}
