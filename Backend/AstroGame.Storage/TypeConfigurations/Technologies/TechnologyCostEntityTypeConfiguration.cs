using AstroGame.Shared.Models.Technologies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Technologies
{
    public class TechnologyCostEntityTypeConfiguration : IEntityTypeConfiguration<TechnologyCost>
    {
        public void Configure(EntityTypeBuilder<TechnologyCost> builder)
        {
            builder.ToTable("TechnologyCosts");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
        }
    }
}
