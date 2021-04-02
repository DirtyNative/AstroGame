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
              
                //////////////////////////////
                // Iron Mine
                //////////////////////////////
                
                // Iron
                new BuildingCost()
                {
                    Id = Guid.Parse("76F6AFE9-670A-4BA5-90D8-01891F15A6A2"),
                    BuildingId = Guid.Parse("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 60,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Hydrogen Extractor
                //////////////////////////////
                
                // Iron
                new BuildingCost()
                {
                    Id = Guid.Parse("58D5BE3E-1D49-4C0A-AE2C-F46791D0E919"),
                    BuildingId = Guid.Parse("8A0A5DAB-F877-4714-8E6B-1B578F480268"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 68,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Silicon Mine
                //////////////////////////////

                // Iron
                new BuildingCost()
                {
                    Id = Guid.Parse("778A6F92-E76D-4C0A-A03F-FA5E1D31BCA2"),
                    BuildingId = Guid.Parse("E200EF94-6EB9-46C8-BA08-3DD86AC3B373"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 300,
                    Multiplier = 1.4,
                },

                //////////////////////////////
                // Helium Extractor
                //////////////////////////////

                // Iron
                new BuildingCost()
                {
                    Id = Guid.Parse("DF3F2C81-7BB8-4913-8817-57C352C07AED"),
                    BuildingId = Guid.Parse("8DDE001B-A19D-43A1-B151-CDE09A85C214"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 250,
                    Multiplier = 1.55,
                },

                // Silicon
                new BuildingCost()
                {
                    Id = Guid.Parse("9C85B65C-72E6-4E41-9106-D35580C0F9AB"),
                    BuildingId = Guid.Parse("8DDE001B-A19D-43A1-B151-CDE09A85C214"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000011"),
                    BaseValue = 100,
                    Multiplier = 1.4,
                },

                //////////////////////////////
                // Aluminum smelting plant
                //////////////////////////////

                // Iron
                new BuildingCost()
                {
                    Id = Guid.Parse("DAFACE0D-0BBC-4E5B-A11E-55BCE19C4B0B"),
                    BuildingId = Guid.Parse("44517245-CB20-4324-A275-4D8642207AD4"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 500,
                    Multiplier = 1.6,
                },

                // Silicon
                new BuildingCost()
                {
                    Id = Guid.Parse("01951251-4FDB-4AD6-98F1-AE001E779B04"),
                    BuildingId = Guid.Parse("44517245-CB20-4324-A275-4D8642207AD4"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000011"),
                    BaseValue = 400,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Titanium Mine
                //////////////////////////////

                // Iron
                new BuildingCost()
                {
                    Id = Guid.Parse("4D6DDF71-901C-4734-B6CD-23FD2D701002"),
                    BuildingId = Guid.Parse("B8063D0E-D06E-4B2E-A7E6-4812D7DD5A3E"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 800,
                    Multiplier = 1.3,
                },

                // Silicon
                new BuildingCost()
                {
                    Id = Guid.Parse("36DDEC13-5B03-4E09-B1D4-EB9865FA3EC6"),
                    BuildingId = Guid.Parse("B8063D0E-D06E-4B2E-A7E6-4812D7DD5A3E"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000011"),
                    BaseValue = 900,
                    Multiplier = 1.6,
                },

                //////////////////////////////
                // Iridium Mine
                //////////////////////////////

                // Iron
                new BuildingCost()
                {
                    Id = Guid.Parse("EA28699A-C944-48A1-B6FF-30F8536CB840"),
                    BuildingId = Guid.Parse("9B09D3F5-FBCA-4148-B6A3-355CE7B75240"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 700,
                    Multiplier = 1.25,
                },

                // Silicon
                new BuildingCost()
                {
                    Id = Guid.Parse("40F3ACCC-BA71-4306-95F5-67421AEB89F0"),
                    BuildingId = Guid.Parse("9B09D3F5-FBCA-4148-B6A3-355CE7B75240"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000011"),
                    BaseValue = 600,
                    Multiplier = 1.5,
                },

                // Titanium
                new BuildingCost()
                {
                    Id = Guid.Parse("0E521620-3A9D-4F1A-9822-E7A1FB746246"),
                    BuildingId = Guid.Parse("9B09D3F5-FBCA-4148-B6A3-355CE7B75240"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000015"),
                    BaseValue = 500,
                    Multiplier = 1.6,
                }
            );
        }
    }
}