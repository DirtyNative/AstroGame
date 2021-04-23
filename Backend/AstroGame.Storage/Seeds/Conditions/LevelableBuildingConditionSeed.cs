using AstroGame.Shared.Models.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Conditions
{
    public class LevelableBuildingConditionSeed : IEntityTypeConfiguration<LevelableBuildingCondition>
    {
        public void Configure(EntityTypeBuilder<LevelableBuildingCondition> builder)
        {
            builder.HasData(new LevelableBuildingCondition()
            {
                Id = Guid.Parse("73180255-1CAE-4F66-BDD6-7F6BA892CAFE"),
                BuildingId = Guid.Parse("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                NeededLevel = 6
            });
        }
    }
}
