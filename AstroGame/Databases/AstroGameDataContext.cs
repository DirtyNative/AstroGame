using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;

namespace AstroGame.Api.Databases
{
    public class AstroGameDataContext : DbContext
    {
        public AstroGameDataContext()
        {
        }

        public AstroGameDataContext(DbContextOptions<AstroGameDataContext> options) : base(options)
        {
        }

        public DbSet<Moon> Moons { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<SolarSystem> SolarSystems { get; set; }
        public DbSet<MultiObjectSystem> MultiObjectSystems { get; set; }
        public DbSet<SingleObjectSystem> SingleObjectSystems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(MoonEntityTypeConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}