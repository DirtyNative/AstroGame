using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Api.Databases.TypeConfigurations.Systems
{
    public class SolarSystemEntityTypeConfiguration : IEntityTypeConfiguration<SolarSystem>
    {
        public void Configure(EntityTypeBuilder<SolarSystem> builder)
        {
            builder.ToTable("SolarSystems");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<MultiObjectSystem>();
        }
    }
}