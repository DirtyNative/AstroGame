using AstroGame.Shared.Models.Prefabs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Api.Databases.TypeConfigurations.Prefabs
{
    public class StarPrefabEntityTypeConfiguration : IEntityTypeConfiguration<StarPrefab>
    {
        public void Configure(EntityTypeBuilder<StarPrefab> builder)
        {
            builder.ToTable("StarPrefabs");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<Prefab>();
        }
    }
}