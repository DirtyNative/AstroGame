using AstroGame.Shared.Models.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Conditions
{
    public class NeededConditionEntityTypeConfiguration : IEntityTypeConfiguration<NeededCondition>
    {
        public void Configure(EntityTypeBuilder<NeededCondition> builder)
        {
            builder.ToTable("NeededConditions");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
        }
    }
}
