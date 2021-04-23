using AstroGame.Shared.Models.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Conditions
{
    public class
        LevelableBuildingConditionEntityTypeConfiguration : IEntityTypeConfiguration<LevelableBuildingCondition>
    {
        public void Configure(EntityTypeBuilder<LevelableBuildingCondition> builder)
        {
            builder.ToTable("LevelableBuildingConditions");
            builder.HasBaseType<BuildingCondition>();
        }
    }
}