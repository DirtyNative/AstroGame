using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Prefabs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AstroGame.Api.Databases.TypeConfigurations.Prefabs
{
    public class PlanetAtmospherePrefabEntityTypeConfiguration : IEntityTypeConfiguration<PlanetAtmospherePrefab>
    {
        public void Configure(EntityTypeBuilder<PlanetAtmospherePrefab> builder)
        {
            builder.ToTable("PlanetAtmospherePrefabs");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<Prefab>();

            //builder.Property(e => e.PlanetTypes).HasConversion(new EnumToNumberConverter<>() < PlanetType > ());

            var converter = new ValueConverter<PlanetType[], string>(
                v => string.Join(";", v),
                v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(Enum.Parse<PlanetType>).ToArray());

            builder.Property(e => e.PlanetTypes)
                .HasConversion(converter);
        }
    }
}