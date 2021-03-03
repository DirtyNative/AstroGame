using AstroGame.Shared.Models.Prefabs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Api.Databases.TypeConfigurations.Prefabs
{
    public class RingsPrefabEntityTypeConfiguration : IEntityTypeConfiguration<RingsPrefab>
    {
        public void Configure(EntityTypeBuilder<RingsPrefab> builder)
        {
            builder.ToTable("RingsPrefabs");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<Prefab>();
        }
    }
}
