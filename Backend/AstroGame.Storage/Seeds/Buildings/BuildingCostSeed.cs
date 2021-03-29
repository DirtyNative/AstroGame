using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Buildings
{
    public class BuildingCostSeed : IEntityTypeConfiguration<BuildingCost>
    {
        public void Configure(EntityTypeBuilder<BuildingCost> builder)
        {
            builder.HasData(
                // Iron Mine
                new BuildingCost()
                {
                    Id = Guid.Parse("76F6AFE9-670A-4BA5-90D8-01891F15A6A2"),
                    BuildingId = Guid.Parse("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 60,
                    Multiplier = 1.5,
                });
        }
    }
}