using AstroGame.Shared.Models.Ships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Ships
{
    public class ShipConstructionCostEntityTypeConfiguration : IEntityTypeConfiguration<ShipConstructionCost>
    {
        public void Configure(EntityTypeBuilder<ShipConstructionCost> builder)
        {
            builder.ToTable("ShipConstructionCosts");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.Resource)
                .WithMany()
                .HasForeignKey(e => e.ResourceId);

            builder.HasOne(e => e.Ship)
                .WithMany(e => e.ConstructionCosts)
                .HasForeignKey(e => e.ShipId);
        }
    }
}