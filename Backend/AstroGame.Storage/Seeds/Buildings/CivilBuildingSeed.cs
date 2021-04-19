using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Buildings
{
    public class CivilBuildingSeed : IEntityTypeConfiguration<CivilBuilding>
    {
        public void Configure(EntityTypeBuilder<CivilBuilding> builder)
        {
            builder.HasData(
                new CivilBuilding()
                {
                    Id = Guid.Parse("75021A39-C0C1-46F0-B155-F1CDFB9FBC00"),
                    Name = "Small Shipyard",
                    Description = "TODO",
                    BuildableOn = StellarObjectType.Planet,
                    AssetName = "9.jpg",
                    Order = 1,
                });
        }
    }
}
