using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Buildings
{
    public class FixedBuildingSeed : IEntityTypeConfiguration<FixedBuilding>
    {
        public void Configure(EntityTypeBuilder<FixedBuilding> builder)
        {
            builder.HasData(
                new FixedBuilding()
                {
                    Id = Guid.Parse("75021A39-C0C1-46F0-B155-F1CDFB9FBC00"),
                    BuildingType = BuildingType.CivilBuilding,
                    Name = "Small Shipyard",
                    Description = "TODO",
                    BuildableOn = StellarObjectType.Planet,
                    AssetName = "9.jpg",
                    Order = 1,
                });
        }
    }
}