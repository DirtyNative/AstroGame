using AstroGame.Shared.Models.Researches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace AstroGame.Storage.TypeConfigurations.Researches
{
    public class OneTimeResearchCostEntityTypeConfiguration : IEntityTypeConfiguration<OneTimeResearchCost>
    {
        public void Configure(EntityTypeBuilder<OneTimeResearchCost> builder)
        {
            builder.ToTable("OneTimeResearchCosts");
            builder.HasBaseType<ResearchCost>();

            builder.HasOne(e => e.Resource)
                .WithMany()
                .HasForeignKey(e => e.ResourceId);

            builder.HasOne(e => e.Research)
                .WithMany(e => e.ResearchCosts as IEnumerable<OneTimeResearchCost>)
                .HasForeignKey(e => e.ResearchId);
        }
    }
}