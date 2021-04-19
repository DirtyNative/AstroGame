using System.Collections.Generic;
using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class DynamicBuildingCostEntityTypeConfiguration : IEntityTypeConfiguration<DynamicBuildingCost>
    {
        public void Configure(EntityTypeBuilder<DynamicBuildingCost> builder)
        {
            builder.ToTable("DynamicBuildingCosts");
            builder.HasBaseType<BuildingCost>();
            //builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.Resource)
                .WithMany()
                .HasForeignKey(e => e.ResourceId);

            builder.HasOne(e => e.Building)
                .WithMany(e => e.BuildingCosts as IEnumerable<DynamicBuildingCost>)
                .HasForeignKey(e => e.BuildingId);
        }
    }
}