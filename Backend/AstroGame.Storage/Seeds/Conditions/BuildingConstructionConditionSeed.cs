using AstroGame.Shared.Models.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Conditions
{
    public class BuildingConstructionConditionSeed : IEntityTypeConfiguration<BuildingConstructionCondition>
    {
        public void Configure(EntityTypeBuilder<BuildingConstructionCondition> builder)
        {
            builder.HasData(new BuildingConstructionCondition()
            {
                Id = Guid.Parse("D17FCFED-CC17-4E75-9517-EBD23A531BED"),
                BuildingId = Guid.Parse("B8D93F41-D6C2-4CE8-9763-840ECB53BF44"),
                ConditionId = Guid.Parse("73180255-1CAE-4F66-BDD6-7F6BA892CAFE"),
            });
        }
    }
}
