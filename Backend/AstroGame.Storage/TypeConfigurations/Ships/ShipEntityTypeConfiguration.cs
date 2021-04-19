using AstroGame.Shared.Models.Ships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Ships
{
    public class ShipEntityTypeConfiguration : IEntityTypeConfiguration<Ship>
    {
        public void Configure(EntityTypeBuilder<Ship> builder)
        {
            builder.ToTable("Ships");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasMany(e => e.ConstructionCosts)
                .WithOne(e => e.Ship)
                .HasForeignKey(e => e.ShipId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Fuel)
                .WithOne()
                .HasForeignKey<Ship>(e => e.FuelId);
        }
    }
}