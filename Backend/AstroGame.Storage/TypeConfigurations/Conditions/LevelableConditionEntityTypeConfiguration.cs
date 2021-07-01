using AstroGame.Shared.Models.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Conditions
{
    public class LevelableConditionEntityTypeConfiguration : IEntityTypeConfiguration<LevelableCondition>
    {
        public void Configure(EntityTypeBuilder<LevelableCondition> builder)
        {
            builder.ToTable("LevelableConditions");
            builder.HasBaseType<Condition>();
        }
    }
}