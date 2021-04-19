using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class FixedBuildingCostEntityTypeConfiguration : IEntityTypeConfiguration<FixedBuildingCost>
    {
        public void Configure(EntityTypeBuilder<FixedBuildingCost> builder)
        {
            builder.ToTable("FixedBuildingCosts");
            builder.HasBaseType<BuildingCost>();
            //builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.Resource)
                .WithMany()
                .HasForeignKey(e => e.ResourceId);

            builder.HasOne(e => e.Building)
                .WithMany(e => e.BuildingCosts as IEnumerable<FixedBuildingCost>)
                .HasForeignKey(e => e.BuildingId);
        }
    }
}
