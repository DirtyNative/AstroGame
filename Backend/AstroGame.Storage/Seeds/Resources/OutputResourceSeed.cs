using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Resources
{
    public class OutputResourceSeed : IEntityTypeConfiguration<OutputResource>
    {
        public void Configure(EntityTypeBuilder<OutputResource> builder)
        {
            builder.HasData(
                //////////////////////////////
                // Hydrogen Extractor
                //////////////////////////////

                // Hydrogen
                new OutputResource()
                {
                    Id = Guid.Parse("792F2B69-3726-42CA-9EF3-015FB5B2E486"),
                    BuildingId = Guid.Parse("8A0A5DAB-F877-4714-8E6B-1B578F480268"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000001"),
                    BaseValue = 35,
                    Multiplier = 1.18,
                },

                //////////////////////////////
                // Helium Extractor
                //////////////////////////////

                // Helium
                new OutputResource()
                {
                    Id = Guid.Parse("F2486781-2189-49A4-A644-E6D93E0FF7C4"),
                    BuildingId = Guid.Parse("8DDE001B-A19D-43A1-B151-CDE09A85C214"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000002"),
                    BaseValue = 37,
                    Multiplier = 1.15,
                },

                //////////////////////////////
                // Oxygen Extractor
                //////////////////////////////

                // Oxygen
                new OutputResource()
                {
                    Id = Guid.Parse("F2486784-2189-49A4-A644-E6D93E0FF7F4"),
                    BuildingId = Guid.Parse("ADAB9B7C-53E7-4F89-AA62-61B8A6D8B60F"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000008"),
                    BaseValue = 37,
                    Multiplier = 1.13,
                },

                //////////////////////////////
                // Iron Mine
                //////////////////////////////

                // Iron
                new OutputResource()
                {
                    Id = Guid.Parse("24A0EFE4-27D2-43C6-BB7B-61B36C129B00"),
                    BuildingId = Guid.Parse("5B2AA6BC-9754-42EB-B519-39EDD989F9BB"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 40,
                    Multiplier = 1.1,
                },

                

                //////////////////////////////
                // Silicon Mine
                //////////////////////////////

                // Silicon
                new OutputResource()
                {
                    Id = Guid.Parse("A53E9771-E133-431B-9471-9DBD0CA5D245"),
                    BuildingId = Guid.Parse("E200EF94-6EB9-46C8-BA08-3DD86AC3B373"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000011"),
                    BaseValue = 38,
                    Multiplier = 1.08,
                },

                

                //////////////////////////////
                // Aluminum smelting plant
                //////////////////////////////

                // Aluminum
                new OutputResource()
                {
                    Id = Guid.Parse("A49F760C-3168-410B-9F8A-39BFFCC766E8"),
                    BuildingId = Guid.Parse("44517245-CB20-4324-A275-4D8642207AD4"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000010"),
                    BaseValue = 37,
                    Multiplier = 1.1,
                },

                //////////////////////////////
                // Titanium Mine
                //////////////////////////////

                // Aluminum
                new OutputResource()
                {
                    Id = Guid.Parse("DD746CE3-B795-4700-8E7F-0F82E7BFE80F"),
                    BuildingId = Guid.Parse("B8063D0E-D06E-4B2E-A7E6-4812D7DD5A3E"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000015"),
                    BaseValue = 30,
                    Multiplier = 1.1,
                },

                //////////////////////////////
                // Iridium Mine
                //////////////////////////////

                // Aluminum
                new OutputResource()
                {
                    Id = Guid.Parse("2825A2EE-2C89-4EB3-A2FA-ECC20C2A8602"),
                    BuildingId = Guid.Parse("9B09D3F5-FBCA-4148-B6A3-355CE7B75240"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000026"),
                    BaseValue = 35,
                    Multiplier = 1.08,
                }
            );
        }
    }
}