using AstroGame.Core.Extensions;
using AstroGame.Core.Structs;
using AstroGame.Shared.Models.Players;
using AstroGame.Shared.Models.Resources;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using AstroGame.Storage.Converters;
using AstroGame.Storage.Extensions;
using AstroGame.Storage.TypeConfigurations.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AstroGame.Storage.Database
{
    public class AstroGameDataContext : DbContext
    {
        public AstroGameDataContext()
        {
        }

        public AstroGameDataContext(DbContextOptions<AstroGameDataContext> options) : base(options)
        {
        }

        public DbSet<StellarObject> StellarObjects { get; set; }
        public DbSet<Moon> Moons { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<BlackHole> BlackHoles { get; set; }

        public DbSet<Galaxy> Galaxies { get; set; }
        public DbSet<SolarSystem> SolarSystems { get; set; }
        public DbSet<MultiObjectSystem> MultiObjectSystems { get; set; }
        public DbSet<StellarSystem> StellarSystems { get; set; }

        public DbSet<Resource> Resources { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<StellarObjectResource> StellarObjectResources { get; set; }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(MoonEntityTypeConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            var vector3Converter =
                new ValueConverter<Vector3, string>(vector3 => vector3.ToString(), s => s.ToVector3());

            modelBuilder.UseValueConverterForType<Vector3>(vector3Converter);
            modelBuilder.UseValueConverterForType<Coordinates>(new CoordinateStringConverter());

            base.OnModelCreating(modelBuilder);
        }
    }
}