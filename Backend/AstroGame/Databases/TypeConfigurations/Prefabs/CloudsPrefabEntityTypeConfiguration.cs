using AstroGame.Shared.Models.Prefabs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Api.Databases.TypeConfigurations.Prefabs
{
    public class CloudsPrefabEntityTypeConfiguration : IEntityTypeConfiguration<CloudsPrefab>
    {
        public void Configure(EntityTypeBuilder<CloudsPrefab> builder)
        {
            builder.ToTable("CloudsPrefabs");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<Prefab>();
        }
    }
}