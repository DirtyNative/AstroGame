using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class BuildingCostEntityTypeConfiguration : IEntityTypeConfiguration<BuildingCost>
    {
        public void Configure(EntityTypeBuilder<BuildingCost> builder)
        {
            builder.ToTable("BuildingCosts");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.Resource)
                .WithMany()
                .HasForeignKey(e => e.ResourceId);

            builder.HasOne(e => e.Building)
                .WithMany(e => e.BuildingCosts)
                .HasForeignKey(e => e.BuildingId);
        }
    }
}