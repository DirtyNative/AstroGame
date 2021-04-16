using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Buildings
{
    public class ConveyorBuildingSeed : IEntityTypeConfiguration<ConveyorBuilding>
    {
        public void Configure(EntityTypeBuilder<ConveyorBuilding> builder)
        {
            builder.HasData(
                //////////////////////////////
                // Planet
                //////////////////////////////

                // Production
                new ConveyorBuilding()
                {
                    Id = Guid.Parse("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                    Name = "Iron Mine",
                    Description =
                        "Produces the most basic building material ever seen in space.. But we all need it everywhere.",
                    Order = 1,
                    AssetName = "2.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new ConveyorBuilding()
                {
                    Id = Guid.Parse("8A0A5DAB-F877-4714-8E6B-1B578F480268"),
                    Name = "Hydrogen Extractor",
                    Description =
                        "Extracts Hydrogen molecules from within the atmosphere to produce an industrial product.",
                    Order = 2,
                    AssetName = "6.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new ConveyorBuilding()
                {
                    Id = Guid.Parse("E200EF94-6EB9-46C8-BA08-3DD86AC3B373"),
                    Name = "Silicon Mine",
                    Description =
                        "We need silicon to produce electronics which we need for quiet all of our constructs.",
                    Order = 3,
                    AssetName = "7.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new ConveyorBuilding()
                {
                    Id = Guid.Parse("8DDE001B-A19D-43A1-B151-CDE09A85C214"),
                    Name = "Helium Extractor",
                    Description =
                        "Helium is one of the most important parts to generate fuels.",
                    Order = 4,
                    AssetName = "9.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new ConveyorBuilding()
                {
                    Id = Guid.Parse("44517245-CB20-4324-A275-4D8642207AD4"),
                    Name = "Aluminum smelting plant",
                    Description =
                        "TODO",
                    Order = 4,
                    AssetName = "11.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new ConveyorBuilding()
                {
                    Id = Guid.Parse("B8063D0E-D06E-4B2E-A7E6-4812D7DD5A3E"),
                    Name = "Titanium Mine",
                    Description =
                        "TODO",
                    Order = 4,
                    AssetName = "17.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new ConveyorBuilding()
                {
                    Id = Guid.Parse("9B09D3F5-FBCA-4148-B6A3-355CE7B75240"),
                    Name = "Iridium Mine",
                    Description = "TODO",
                    Order = 4,
                    AssetName = "18.jpg",
                    BuildableOn = StellarObjectType.Planet,
                }
            );
        }
    }
}