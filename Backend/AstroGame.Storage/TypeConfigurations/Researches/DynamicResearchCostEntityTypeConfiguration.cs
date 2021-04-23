using AstroGame.Shared.Models.Researches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace AstroGame.Storage.TypeConfigurations.Researches
{
    public class DynamicResearchCostEntityTypeConfiguration : IEntityTypeConfiguration<DynamicResearchCost>
    {
        public void Configure(EntityTypeBuilder<DynamicResearchCost> builder)
        {
            builder.ToTable("DynamicResearchCosts");
            builder.HasBaseType<ResearchCost>();

            builder.HasOne(e => e.Resource)
                .WithMany()
                .HasForeignKey(e => e.ResourceId);

            builder.HasOne(e => e.Research)
                .WithMany(e => e.ResearchCosts as IEnumerable<DynamicResearchCost>)
                .HasForeignKey(e => e.ResearchId);
        }
    }
}