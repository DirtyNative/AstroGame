using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Api.Databases.TypeConfigurations.Objects
{
    public class MoonEntityTypeConfiguration : IEntityTypeConfiguration<Moon>
    {
        public void Configure(EntityTypeBuilder<Moon> builder)
        {
            builder.ToTable("Moons");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<StellarObject>();

            builder.HasOne(e => e.ParentSystem)
                .WithOne(e => e.CenterObject as Moon).HasForeignKey<SingleObjectSystem>(e => e.CenterObjectId);
        }
    }
}