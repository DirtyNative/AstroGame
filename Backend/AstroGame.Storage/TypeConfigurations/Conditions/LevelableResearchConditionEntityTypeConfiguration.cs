using AstroGame.Shared.Models.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Conditions
{
    public class
        LevelableResearchConditionEntityTypeConfiguration : IEntityTypeConfiguration<LevelableResearchCondition>
    {
        public void Configure(EntityTypeBuilder<LevelableResearchCondition> builder)
        {
            builder.ToTable("LevelableResearchConditions");
            builder.HasBaseType<ResearchCondition>();
        }
    }
}