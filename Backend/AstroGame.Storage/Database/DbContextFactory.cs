using AstroGame.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AstroGame.Storage.Database
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AstroGameDataContext>
    {
        public AstroGameDataContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentalJsonFile("Configurations/DatabaseConnection.json")
                .Build();

            var databaseConnection = new DatabaseConnection();
            configuration.GetSection("DatabaseConnection").Bind(databaseConnection);

            var connectionString = string.Format(databaseConnection.DatabaseConnectionString,
                databaseConnection.DatabaseName,
                databaseConnection.DatabaseAccount, databaseConnection.DatabasePassword);

            var dbContextBuilder = new DbContextOptionsBuilder<AstroGameDataContext>();
            var migrationAssemblyName = configuration.GetConnectionString("AstroGame.Shared");

            dbContextBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationAssemblyName));
            dbContextBuilder.UseSqlServer(builder => { builder.EnableRetryOnFailure(); });

            return new AstroGameDataContext(dbContextBuilder.Options);
        }
    }
}