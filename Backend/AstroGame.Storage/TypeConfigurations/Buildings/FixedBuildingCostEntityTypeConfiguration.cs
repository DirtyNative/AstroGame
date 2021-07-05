using AstroGame.Shared.Models.Buildings;
using AstroGame.Shared.Models.Technologies;
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
            builder.HasBaseType<TechnologyCost>();

            builder.HasOne(e => e.Resource)
                .WithMany()
                .HasForeignKey(e => e.ResourceId);

            builder.HasOne(e => e.Technology)
                .WithMany(e => e.TechnologyCosts as IEnumerable<FixedBuildingCost>)
                .HasForeignKey(e => e.TechnologyId);
        }
    }
}
