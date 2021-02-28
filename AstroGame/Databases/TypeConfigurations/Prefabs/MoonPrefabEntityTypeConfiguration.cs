using AstroGame.Shared.Models.Prefabs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Api.Databases.TypeConfigurations.Prefabs
{
    public class MoonPrefabEntityTypeConfiguration : IEntityTypeConfiguration<MoonPrefab>
    {
        public void Configure(EntityTypeBuilder<MoonPrefab> builder)
        {
            builder.ToTable("MoonPrefabs");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<Prefab>();
        }
    }
}