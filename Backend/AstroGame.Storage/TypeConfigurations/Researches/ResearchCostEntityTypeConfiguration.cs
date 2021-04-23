using AstroGame.Shared.Models.Researches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Researches
{
    public class ResearchCostEntityTypeConfiguration : IEntityTypeConfiguration<ResearchCost>
    {
        public void Configure(EntityTypeBuilder<ResearchCost> builder)
        {
            builder.ToTable("ResearchCosts");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
        }
    }
}