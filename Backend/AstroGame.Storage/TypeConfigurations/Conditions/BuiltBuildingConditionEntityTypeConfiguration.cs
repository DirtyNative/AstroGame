using AstroGame.Shared.Models.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Conditions
{
    public class BuiltBuildingConditionEntityTypeConfiguration : IEntityTypeConfiguration<BuiltBuildingCondition>
    {
        public void Configure(EntityTypeBuilder<BuiltBuildingCondition> builder)
        {
            builder.ToTable("BuiltBuildingConditions");
            builder.HasBaseType<BuildingCondition>();
        }
    }
}