using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Buildings
{
    public class LevelableBuildingSeed : IEntityTypeConfiguration<LevelableBuilding>
    {
        public void Configure(EntityTypeBuilder<LevelableBuilding> builder)
        {
            builder.HasData(
                //////////////////////////////
                // Conveyor Buildings
                //////////////////////////////

                //////////////////////////////
                // Planet
                //////////////////////////////
                new LevelableBuilding()
                {
                    Id = Guid.Parse("8A0A5DAB-F877-4714-8E6B-1B578F480268"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Hydrogen Extractor",
                    Description =
                        "Extracts Hydrogen molecules from within the atmosphere to produce an industrial product.",
                    Order = 1,
                    AssetName = "6.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("8DDE001B-A19D-43A1-B151-CDE09A85C214"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Helium Extractor",
                    Description =
                        "Helium is one of the most important parts to generate fuels.",
                    Order = 2,
                    AssetName = "9.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("20EF5BEB-8D80-4EA1-980A-1B77649B4249"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Lithium Extractor",
                    Description =
                        "TODO",
                    Order = 3,
                    AssetName = "9.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("81B33A6B-C9A6-446C-BF61-441931A9F2AB"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Beryllium Reductor",
                    Description =
                        "TODO",
                    Order = 4,
                    AssetName = "9.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("7D3B17D6-3084-4725-A259-CFF46FC3A554"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Boron Reductor",
                    Description =
                        "TODO",
                    Order = 5,
                    AssetName = "9.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("08F6708B-DD2A-427A-9E49-E24810452421"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Carbon Extractor",
                    Description =
                        "TODO",
                    Order = 6,
                    AssetName = "9.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("35C9D3C1-BB03-4C2A-B6DD-EB34C0BFCF0D"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Nitrogen Destillator",
                    Description =
                        "TODO",
                    Order = 7,
                    AssetName = "9.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("ADAB9B7C-53E7-4F89-AA62-61B8A6D8B60F"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Oxygen Extractor",
                    Description =
                        "TODO",
                    Order = 8,
                    AssetName = "9.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("BDCAE1CC-D8E2-4DD5-97B6-8CDE1162F6EE"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Magnesium Reductor",
                    Description =
                        "TODO",
                    Order = 9,
                    AssetName = "9.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("44517245-CB20-4324-A275-4D8642207AD4"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Aluminum smelting plant",
                    Description =
                        "TODO",
                    Order = 10,
                    AssetName = "11.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("E200EF94-6EB9-46C8-BA08-3DD86AC3B373"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Silicon Mine",
                    Description =
                        "We need silicon to produce electronics which we need for quiet all of our constructs.",
                    Order = 11,
                    AssetName = "7.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("E5C2C36B-3393-4599-B054-77458C7E74E8"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Phosphorus Miner",
                    Description =
                        "TODO",
                    Order = 12,
                    AssetName = "7.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("6D519575-BCFB-49F7-AEF9-15A4B8364B32"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Sulfur Mine",
                    Description =
                        "TODO",
                    Order = 13,
                    AssetName = "7.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("89B6448B-CA4E-43D4-A8BB-69B6F5C55211"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Chlorine Dissolver",
                    Description =
                        "TODO",
                    Order = 14,
                    AssetName = "7.jpg",
                    BuildableOn = StellarObjectType.Planet,
                }, new LevelableBuilding()
                {
                    Id = Guid.Parse("B8063D0E-D06E-4B2E-A7E6-4812D7DD5A3E"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Titanium Mine",
                    Description =
                        "TODO",
                    Order = 15,
                    AssetName = "17.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Iron Mine",
                    Description =
                        "Produces the most basic building material ever seen in space.. But we all need it everywhere.",
                    Order = 16,
                    AssetName = "2.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("B8D93F41-D6C2-4CE8-9763-840ECB53BF44"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Cobalt Melting Plant",
                    Description =
                        "TODO",
                    Order = 17,
                    AssetName = "2.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("A0500EB9-8F5C-4FD0-90AF-4BE209939464"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Nickel Melting Plant",
                    Description =
                        "TODO",
                    Order = 18,
                    AssetName = "2.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("C8D6228C-4C68-444D-BDF9-BB16279A5EB8"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Copper Melting Plant",
                    Description =
                        "TODO",
                    Order = 19,
                    AssetName = "2.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("4DF104B3-64B6-4843-BA43-4B5B98F08C2B"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Zinc Mine",
                    Description =
                        "TODO",
                    Order = 20,
                    AssetName = "2.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("626D4D9B-F90E-4E24-8F84-054E709AFA2A"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Gallium smelting plant",
                    Description =
                        "TODO",
                    Order = 21,
                    AssetName = "2.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("0998D19E-C02F-41E2-B2FD-BA5C6FC7DEF1"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Germanium Dissolver",
                    Description =
                        "TODO",
                    Order = 22,
                    AssetName = "2.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("405A352F-943D-40F7-9E8A-359872D25E84"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Palladium Mine",
                    Description =
                        "TODO",
                    Order = 23,
                    AssetName = "2.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("428801F4-4777-4589-9A64-CB97BCEF71CB"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Silver Mine",
                    Description =
                        "TODO",
                    Order = 24,
                    AssetName = "2.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("45168D04-86CB-499C-AEC9-A8255580071E"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Tin Mine",
                    Description =
                        "TODO",
                    Order = 25,
                    AssetName = "2.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("9B09D3F5-FBCA-4148-B6A3-355CE7B75240"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Iridium Mine",
                    Description = "TODO",
                    Order = 26,
                    AssetName = "18.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("31B2747D-FF1B-49B1-BF97-782BDB28CBA2"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Platinum Mine",
                    Description =
                        "TODO",
                    Order = 27,
                    AssetName = "2.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("A6A8F230-DDE3-464D-9EDD-76CFC9882CBB"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Gold Mine",
                    Description =
                        "TODO",
                    Order = 28,
                    AssetName = "2.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },
                new LevelableBuilding()
                {
                    Id = Guid.Parse("357F7740-3CA7-4FF8-81C6-9CF22289A709"),
                    BuildingType = BuildingType.ConveyorBuilding,
                    Name = "Plutonium Reactor",
                    Description =
                        "TODO",
                    Order = 29,
                    AssetName = "2.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },

                //////////////////////////////
                // Storage Buildings
                //////////////////////////////

                //////////////////////////////
                // Planet
                //////////////////////////////
                new LevelableBuilding()
                {
                    Id = Guid.Parse("F09E72D5-28D8-4390-BDF5-3B589B61FC15"),
                    BuildingType = BuildingType.StorageBuilding,
                    Name = "Iron Store",
                    Description = "TODO",
                    Order = 1,
                    AssetName = "19.jpg",
                    BuildableOn = StellarObjectType.Planet,
                },

                //////////////////////////////
                // Civil Buildings
                //////////////////////////////

                //////////////////////////////
                // Planet
                //////////////////////////////
                new LevelableBuilding()
                {
                    Id = Guid.Parse("0233326E-2B2A-4170-993E-835417E293C6"),
                    BuildingType = BuildingType.CivilBuilding,
                    Name = "Building Grounds",
                    Description = "TODO",
                    Order = 1,
                    AssetName = "19.jpg",
                    BuildableOn = StellarObjectType.Planet,
                }
            );
        }
    }
}