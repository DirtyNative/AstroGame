using AstroGame.Api.Databases.TypeConfigurations.Objects;
using AstroGame.Api.Extensions;
using AstroGame.Shared.Models.Prefabs;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnityEngine;

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

        public DbSet<MoonPrefab> MoonPrefabs { get; set; }
        public DbSet<PlanetPrefab> PlanetPrefabs { get; set; }
        public DbSet<StarPrefab> StarPrefabs { get; set; }

        public DbSet<PlanetAtmospherePrefab> PlanetAtmospherePrefabs { get; set; }
        public DbSet<RingsPrefab> RingsPrefabs { get; set; }
        public DbSet<CloudsPrefab> CloudsPrefabs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(MoonEntityTypeConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            var vector3Converter =
                new ValueConverter<Vector3, string>(vector3 => vector3.ToString(), s => s.ToVector3());

            modelBuilder.UseValueConverterForType<Vector3>(vector3Converter);

            base.OnModelCreating(modelBuilder);
        }
    }
}