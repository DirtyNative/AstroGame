using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Buildings
{
    public class DynamicBuildingCostSeed : IEntityTypeConfiguration<DynamicBuildingCost>
    {
        public void Configure(EntityTypeBuilder<DynamicBuildingCost> builder)
        {
            builder.HasData(
                //////////////////////////////
                // Hydrogen Extractor
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("58D5BE3E-1D49-4C0A-AE2C-F46791D0E919"),
                    BuildingId = Guid.Parse("8A0A5DAB-F877-4714-8E6B-1B578F480268"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 68,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Helium Extractor
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("DF3F2C81-7BB8-4913-8817-57C352C07AED"),
                    BuildingId = Guid.Parse("8DDE001B-A19D-43A1-B151-CDE09A85C214"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 250,
                    Multiplier = 1.55,
                },

                // Silicon
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("9C85B65C-72E6-4E41-9106-D35580C0F9AB"),
                    BuildingId = Guid.Parse("8DDE001B-A19D-43A1-B151-CDE09A85C214"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000011"),
                    BaseValue = 100,
                    Multiplier = 1.4,
                },

                //////////////////////////////
                // Lithium Extractor
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("EC330D07-7DCD-40AC-9151-1D53BC6CE6D4"),
                    BuildingId = Guid.Parse("20EF5BEB-8D80-4EA1-980A-1B77649B4249"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 250,
                    Multiplier = 1.55,
                },

                //////////////////////////////
                // Beryllium Reductor
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("760DC621-3BAB-4E9A-AE53-FED5DCD76F85"),
                    BuildingId = Guid.Parse("81B33A6B-C9A6-446C-BF61-441931A9F2AB"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 250,
                    Multiplier = 1.55,
                },

                //////////////////////////////
                // Boron Reductor
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("2F921C53-C7BA-426B-8C37-553F9CF37BEF"),
                    BuildingId = Guid.Parse("7D3B17D6-3084-4725-A259-CFF46FC3A554"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 250,
                    Multiplier = 1.55,
                },

                //////////////////////////////
                // Carbon Extractor
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("1EBA7135-5378-4276-B163-5E631FB6A2C2"),
                    BuildingId = Guid.Parse("08F6708B-DD2A-427A-9E49-E24810452421"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 250,
                    Multiplier = 1.55,
                },

                //////////////////////////////
                // Nitrogen Destillator
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("0A0E9EF7-6926-4871-9F51-7AD94E8DC8E1"),
                    BuildingId = Guid.Parse("35C9D3C1-BB03-4C2A-B6DD-EB34C0BFCF0D"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 250,
                    Multiplier = 1.55,
                },

                //////////////////////////////
                // Oxygen Extractor
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("6FD807B8-043A-4E62-B9C9-6B8DFF135DA0"),
                    BuildingId = Guid.Parse("ADAB9B7C-53E7-4F89-AA62-61B8A6D8B60F"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 250,
                    Multiplier = 1.55,
                },

                //////////////////////////////
                // Magnesium Reductor
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("8FF89127-91E6-4DC0-A375-7DD3D9125870"),
                    BuildingId = Guid.Parse("BDCAE1CC-D8E2-4DD5-97B6-8CDE1162F6EE"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 250,
                    Multiplier = 1.55,
                },

                //////////////////////////////
                // Aluminum smelting plant
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("DAFACE0D-0BBC-4E5B-A11E-55BCE19C4B0B"),
                    BuildingId = Guid.Parse("44517245-CB20-4324-A275-4D8642207AD4"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 500,
                    Multiplier = 1.6,
                },

                // Silicon
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("01951251-4FDB-4AD6-98F1-AE001E779B04"),
                    BuildingId = Guid.Parse("44517245-CB20-4324-A275-4D8642207AD4"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000011"),
                    BaseValue = 400,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Silicon Mine
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("778A6F92-E76D-4C0A-A03F-FA5E1D31BCA2"),
                    BuildingId = Guid.Parse("E200EF94-6EB9-46C8-BA08-3DD86AC3B373"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 300,
                    Multiplier = 1.4,
                },

                //////////////////////////////
                // Phosphorus Miner
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("15474D59-20C5-463C-BDF0-BC9B09F7E08A"),
                    BuildingId = Guid.Parse("E5C2C36B-3393-4599-B054-77458C7E74E8"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 300,
                    Multiplier = 1.4,
                },

                //////////////////////////////
                // Sulfur Mine
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("8F367705-7C4E-4A3D-9761-1B91DBB1AA55"),
                    BuildingId = Guid.Parse("6D519575-BCFB-49F7-AEF9-15A4B8364B32"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 300,
                    Multiplier = 1.4,
                },

                //////////////////////////////
                // Chlorine Dissolver
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("306A853B-8583-4A1E-8ACE-C49EC34EF991"),
                    BuildingId = Guid.Parse("89B6448B-CA4E-43D4-A8BB-69B6F5C55211"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 300,
                    Multiplier = 1.4,
                },

                //////////////////////////////
                // Titanium Mine
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("4D6DDF71-901C-4734-B6CD-23FD2D701002"),
                    BuildingId = Guid.Parse("B8063D0E-D06E-4B2E-A7E6-4812D7DD5A3E"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 800,
                    Multiplier = 1.3,
                },

                // Silicon
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("36DDEC13-5B03-4E09-B1D4-EB9865FA3EC6"),
                    BuildingId = Guid.Parse("B8063D0E-D06E-4B2E-A7E6-4812D7DD5A3E"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000011"),
                    BaseValue = 900,
                    Multiplier = 1.6,
                },

                //////////////////////////////
                // Iron Mine
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("76F6AFE9-670A-4BA5-90D8-01891F15A6A2"),
                    BuildingId = Guid.Parse("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 60,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Cobalt Melting Plant
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("F4B92197-1ECA-4003-94FF-EB47AE854CEB"),
                    BuildingId = Guid.Parse("B8D93F41-D6C2-4CE8-9763-840ECB53BF44"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 60,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Nickel Melting Plant
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("7D09ED30-8FA3-4E8D-BFA2-8702539F6AE9"),
                    BuildingId = Guid.Parse("A0500EB9-8F5C-4FD0-90AF-4BE209939464"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 60,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Copper Melting Plant
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("DAEE009B-8819-4CCF-944A-0E5E35A95D3F"),
                    BuildingId = Guid.Parse("C8D6228C-4C68-444D-BDF9-BB16279A5EB8"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 60,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Zinc Mine
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("18F5C558-4FF8-483D-812C-B0E9E49EB9F6"),
                    BuildingId = Guid.Parse("4DF104B3-64B6-4843-BA43-4B5B98F08C2B"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 60,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Gallium smelting plant
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("1B7CCEC7-F828-4C20-81ED-08472BEA2486"),
                    BuildingId = Guid.Parse("626D4D9B-F90E-4E24-8F84-054E709AFA2A"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 60,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Germanium Dissolver
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("261C88EA-3595-4A65-9823-A3C245D0E9C6"),
                    BuildingId = Guid.Parse("0998D19E-C02F-41E2-B2FD-BA5C6FC7DEF1"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 60,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Palladium Mine
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("F9814F8D-6DCE-4F44-818B-63426AE1BC27"),
                    BuildingId = Guid.Parse("405A352F-943D-40F7-9E8A-359872D25E84"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 60,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Silver Mine
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("B385D85D-7DC0-48E6-B9F0-B84AC3A26540"),
                    BuildingId = Guid.Parse("428801F4-4777-4589-9A64-CB97BCEF71CB"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 60,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Tin Mine
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("EF756673-3AE1-4E35-951B-5BF3EF24A6F0"),
                    BuildingId = Guid.Parse("45168D04-86CB-499C-AEC9-A8255580071E"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 60,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Iridium Mine
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("EA28699A-C944-48A1-B6FF-30F8536CB840"),
                    BuildingId = Guid.Parse("9B09D3F5-FBCA-4148-B6A3-355CE7B75240"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 700,
                    Multiplier = 1.25,
                },

                // Silicon
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("40F3ACCC-BA71-4306-95F5-67421AEB89F0"),
                    BuildingId = Guid.Parse("9B09D3F5-FBCA-4148-B6A3-355CE7B75240"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000011"),
                    BaseValue = 600,
                    Multiplier = 1.5,
                },

                // Titanium
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("0E521620-3A9D-4F1A-9822-E7A1FB746246"),
                    BuildingId = Guid.Parse("9B09D3F5-FBCA-4148-B6A3-355CE7B75240"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000015"),
                    BaseValue = 500,
                    Multiplier = 1.6,
                },

                //////////////////////////////
                // Platinum Mine
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("41333116-1CE5-4625-96B6-1F7C75F1BD38"),
                    BuildingId = Guid.Parse("31B2747D-FF1B-49B1-BF97-782BDB28CBA2"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 60,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Gold Mine
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("651E720F-9C3A-4F1F-9095-FCC82CCC0D36"),
                    BuildingId = Guid.Parse("A6A8F230-DDE3-464D-9EDD-76CFC9882CBB"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 60,
                    Multiplier = 1.5,
                },

                //////////////////////////////
                // Plutonium Reactor
                //////////////////////////////

                // Iron
                new DynamicBuildingCost()
                {
                    Id = Guid.Parse("1F147721-9F55-4856-B160-6BE4B097B2F6"),
                    BuildingId = Guid.Parse("357F7740-3CA7-4FF8-81C6-9CF22289A709"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    BaseValue = 60,
                    Multiplier = 1.5,
                }
            );
        }
    }
}