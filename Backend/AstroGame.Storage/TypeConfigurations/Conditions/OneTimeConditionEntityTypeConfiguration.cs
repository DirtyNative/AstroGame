using AstroGame.Shared.Models.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Conditions
{
    public class OneTimeConditionEntityTypeConfiguration : IEntityTypeConfiguration<OneTimeCondition>
    {
        public void Configure(EntityTypeBuilder<OneTimeCondition> builder)
        {
            builder.ToTable("OneTimeConditions");
            builder.HasBaseType<Condition>();
        }
    }
}