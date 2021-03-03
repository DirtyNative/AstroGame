using AstroGame.Shared.Models.Prefabs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Api.Databases.TypeConfigurations.Prefabs
{
    public class PlanetPrefabEntityTypeConfiguration : IEntityTypeConfiguration<PlanetPrefab>
    {
        public void Configure(EntityTypeBuilder<PlanetPrefab> builder)
        {
            builder.ToTable("PlanetPrefabs");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<Prefab>();

            /*builder.Property(e => e.Offset)
                .HasConversion(vector => vector.ToString(), s => s.ToVector3());

            builder.Property(e => e.Scale)
                .HasConversion(vector => vector.ToString(), s => s.ToVector3());

            builder.Property(e => e.Rotation)
                .HasConversion(vector => vector.ToString(), s => s.ToVector3()); */
        }
    }
}
