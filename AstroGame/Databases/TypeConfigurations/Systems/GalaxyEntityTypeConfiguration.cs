using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Api.Databases.TypeConfigurations.Systems
{
    public class GalaxyEntityTypeConfiguration : IEntityTypeConfiguration<Galaxy>
    {
        public void Configure(EntityTypeBuilder<Galaxy> builder)
        {
            builder.ToTable("Galaxies");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<StellarSystem>();
        }
    }
}