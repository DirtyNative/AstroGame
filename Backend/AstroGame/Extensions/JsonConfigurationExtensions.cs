using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AstroGame.Api.Extensions
{
    public static class JsonConfigurationExtensions
    {
        private static bool _isDevelopment = false;
        private static bool _isStaging = false;
        private static bool _isProduction = false;

        private static Regex _environmentReplacementRegex = new Regex(@"\.json$",
            RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        static JsonConfigurationExtensions()
        {
#if DEBUG
            _isDevelopment = true;
#endif
#if STAGING
			_isStaging = true;
#endif
#if !DEBUG && !STAGING
			_isProduction = true;
#endif
        }

        public static IConfigurationBuilder AddEnvironmentalJsonFile(
            this IConfigurationBuilder builder,
            string path,
            bool optional = false,
            bool reloadOnChange = false)
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var combinePath = Path.Combine(directory, path);

            builder = builder.AddJsonFile((IFileProvider) null, combinePath, optional, reloadOnChange);

            var developmentPath = ExpandPath(combinePath, "Development");
            if (_isDevelopment && File.Exists(developmentPath))
            {
                builder = builder.AddJsonFile((IFileProvider) null, developmentPath, optional, reloadOnChange);
            }

            var stagingPath = ExpandPath(combinePath, "Staging");
            if (_isStaging && File.Exists(stagingPath))
            {
                builder = builder.AddJsonFile((IFileProvider) null, stagingPath, optional, reloadOnChange);
            }

            var productionPath = ExpandPath(combinePath, "Production");
            if (_isProduction && File.Exists(combinePath))
            {
                builder = builder.AddJsonFile((IFileProvider) null, productionPath, optional, reloadOnChange);
            }

            return builder;

            string ExpandPath(string sourcePath, string environment)
            {
                string pathWithoutExtension = _environmentReplacementRegex.Replace(sourcePath, string.Empty, 1);
                return $"{pathWithoutExtension}.{environment}.json";
            }
        }
    }
}