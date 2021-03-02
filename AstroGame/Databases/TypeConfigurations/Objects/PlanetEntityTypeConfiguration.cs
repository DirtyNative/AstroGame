using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Api.Databases.TypeConfigurations.Objects
{
    public class PlanetEntityTypeConfiguration : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> builder)
        {
            builder.ToTable("Planets");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<StellarObject>();
            builder.HasOne(e => e.ParentSystem)
                .WithOne(e => e.CenterObject as Planet).HasForeignKey<SingleObjectSystem>(e => e.CenterObjectId);

            builder.HasOne(e => e.Prefab).WithMany().HasForeignKey(e => e.PrefabId);

            builder.HasOne(e => e.AtmospherePrefab).WithMany().HasForeignKey(e => e.AtmospherePrefabId);
            builder.HasOne(e => e.CloudsPrefab).WithMany().HasForeignKey(e => e.CloudsPrefabId);
            builder.HasOne(e => e.RingsPrefab).WithMany().HasForeignKey(e => e.RingPrefabId);

            /*builder.HasMany(e => e.Resources).WithOne(e => e.StellarObject as Planet)
                .HasForeignKey(e => e.StellarObjectId); */

            //builder.HasMany(e => e.Resources).WithOne().HasForeignKey(e => e.StellarObjectId);
        }
    }
}