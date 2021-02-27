using AstroGame.Api.Extensions;
using AstroGame.Shared.Models.Prefabs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Api.Databases.TypeConfigurations.Prefabs
{
    public class PrefabEntityTypeConfiguration : IEntityTypeConfiguration<Prefab>
    {
        public void Configure(EntityTypeBuilder<Prefab> builder)
        {
            builder.ToTable("Prefabs");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.Property(e => e.Offset)
                .HasConversion(vector => vector.ToString(), s => s.ToVector3());

            builder.Property(e => e.Scale)
                .HasConversion(vector => vector.ToString(), s => s.ToVector3());

            builder.Property(e => e.Rotation)
                .HasConversion(vector => vector.ToString(), s => s.ToVector3());


        }
    }
}