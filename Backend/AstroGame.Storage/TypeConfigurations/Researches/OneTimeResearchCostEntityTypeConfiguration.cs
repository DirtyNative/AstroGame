using AstroGame.Shared.Models.Researches;
using AstroGame.Shared.Models.Technologies;
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
            builder.HasBaseType<TechnologyCost>();

            builder.HasOne(e => e.Resource)
                .WithMany()
                .HasForeignKey(e => e.ResourceId);

            builder.HasOne(e => e.Technology)
                .WithMany(e => e.TechnologyCosts as IEnumerable<OneTimeResearchCost>)
                .HasForeignKey(e => e.TechnologyId);
        }
    }
}