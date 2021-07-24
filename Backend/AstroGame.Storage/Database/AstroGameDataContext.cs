using AstroGame.Core.Extensions;
using AstroGame.Core.Structs;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Shared.Models.Chats;
using AstroGame.Shared.Models.Conditions;
using AstroGame.Shared.Models.Players;
using AstroGame.Shared.Models.Researches;
using AstroGame.Shared.Models.Resources;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using AstroGame.Shared.Models.Technologies;
using AstroGame.Shared.Models.Technologies.FinishedTechnologies;
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
        public DbSet<ColonizedStellarObject> ColonizedStellarObjects { get; set; }

        public DbSet<Resource> Resources { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<StellarObjectResource> StellarObjectResources { get; set; }
        public DbSet<StoredResource> StoredResources { get; set; }
        public DbSet<ResourceSnapshot> ResourceSnapshots { get; set; }

        public DbSet<Player> Players { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<PlayerSpecies> PlayerSpecies { get; set; }
        public DbSet<Perk> Perks { get; set; }
        public DbSet<PlayerSpeciesPerk> PlayerSpeciesPerks { get; set; }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<LevelableBuilding> LevelableBuildings { get; set; }
        public DbSet<FixedBuilding> FixedBuildings { get; set; }
        public DbSet<BuildingChain> BuildingChains { get; set; }

        public DbSet<Research> Researches { get; set; }
        public DbSet<ResearchStudy> ResearchStudies { get; set; }

        public DbSet<Technology> Technologies { get; set; }
        public DbSet<FinishedTechnology> FinishedTechnologies { get; set; }
        public DbSet<PlayerDependentFinishedTechnology> PlayerDependentFinishedTechnologies { get; set; }
        public DbSet<StellarObjectDependentFinishedTechnology> StellarObjectDependentFinishedTechnologies { get; set; }
       
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<LevelableCondition> LevelableConditions { get; set; }
        public DbSet<LevelableCondition> LevelableResearchConditions { get; set; }
        public DbSet<OneTimeCondition> OneTimeConditions { get; set; }


        public DbSet<Conversation> Conversations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(MoonEntityTypeConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            var vector3Converter =
                new ValueConverter<Vector3, string>(vector3 => vector3.ToString(), s => s.ToVector3());

            modelBuilder.UseValueConverterForType<Vector3>(vector3Converter);
            modelBuilder.UseValueConverterForType<Coordinates>(new CoordinateStringConverter());

            modelBuilder.TreatDateTimeAsUtc();

            base.OnModelCreating(modelBuilder);
        }
    }
}