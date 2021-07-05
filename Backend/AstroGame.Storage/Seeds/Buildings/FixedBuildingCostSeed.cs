using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Buildings
{
    public class FixedBuildingCostSeed : IEntityTypeConfiguration<FixedBuildingCost>
    {
        public void Configure(EntityTypeBuilder<FixedBuildingCost> builder)
        {
            builder.HasData(
                //////////////////////////////
                // Small Shipyard
                //////////////////////////////
                
                // Iron
                new FixedBuildingCost()
                {
                    Id = Guid.Parse("BD87AFE1-192E-4618-A34C-7A6E8ED7EB0B"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    TechnologyId = Guid.Parse("75021A39-C0C1-46F0-B155-F1CDFB9FBC00"),
                    Amount = 2000,
                });
        }
    }
}