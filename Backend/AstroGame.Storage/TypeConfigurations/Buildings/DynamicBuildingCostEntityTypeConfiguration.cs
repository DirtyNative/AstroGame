using AstroGame.Shared.Models.Buildings;
using AstroGame.Shared.Models.Technologies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class DynamicBuildingCostEntityTypeConfiguration : IEntityTypeConfiguration<DynamicBuildingCost>
    {
        public void Configure(EntityTypeBuilder<DynamicBuildingCost> builder)
        {
            builder.ToTable("DynamicBuildingCosts");
            builder.HasBaseType<TechnologyCost>();
            //builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.Resource)
                .WithMany()
                .HasForeignKey(e => e.ResourceId);

            builder.HasOne(e => e.Technology)
                .WithMany(e => e.TechnologyCosts as IEnumerable<DynamicBuildingCost>)
                .HasForeignKey(e => e.TechnologyId);
        }
    }
}