using AstroGame.Shared.Models.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using AstroGame.Shared.Enums;

namespace AstroGame.Storage.Seeds.Players
{
    public class SpeciesSeed : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.HasData(
               
                // Swarm
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0001-f767e933b649"),
                    SpeciesType = SpeciesType.Swarm,
                    AssetName = "Alien_AI.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0001-ee1bd82b1062"),
                    SpeciesType = SpeciesType.Swarm,
                    AssetName = "Alien_AI_red.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0001-e78d009741ad"),
                    SpeciesType = SpeciesType.Swarm,
                    AssetName = "Alien_extradimensional_01.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0001-be5807e86491"),
                    SpeciesType = SpeciesType.Swarm,
                    AssetName = "Alien_extradimensional_02.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0001-305c25f034d7"),
                    SpeciesType = SpeciesType.Swarm,
                    AssetName = "Alien_extradimensional_03.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0001-a4bea66e94c2"),
                    SpeciesType = SpeciesType.Swarm,
                    AssetName = "Alien_Swarm.png"
                },

                // Arthropoid
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-5cedabc2eb68"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_18.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-292ed1175ce1"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_19.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-5aaeb4e06b38"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_20.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-5b960184b0db"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_massive_11.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-a783cc04fafa"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_massive_12.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-0ea9d5234afb"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_massive_13.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-6d2c7313dcf6"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_massive_14.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-7268b02c24eb"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_massive_15.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-ed8d781ff41b"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_massive_16.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-2a9b2afc1a1e"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_massive_17.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-e1a194845eda"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_normal_06.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-5edf18e174ef"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_normal_07.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-f801ce1701fc"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_normal_08.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-111c578bbf31"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_normal_08.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-8a190f13b5dd"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_normal_09.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-62f458ececf0"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_normal_10.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-0bd8bc8b5c04"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_slender_01.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-f8e74a276650"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_slender_03.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0003-25c639b710ed"),
                    SpeciesType = SpeciesType.Arthropoid,
                    AssetName = "Arthropoid_slender_05.png"
                },

                // Avian
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-579805ddbf3e"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_18.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-461e17de2b81"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_massive_11.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-beb2f37aabca"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_massive_12.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-d9b3206f5bde"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_massive_13.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-df4f7fa13342"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_massive_14.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-26e3d161cc91"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_massive_15.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-009e992f1667"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_massive_16.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-e4561c11b129"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_massive_17.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-59b4a036598a"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_normal_06.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-ba43849d85ac"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_normal_07.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-a41cbfc3a2d0"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_normal_08.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-c94ddb578e15"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_normal_09.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-f2d51ca358e1"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_normal_10.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-79f7dc57a6ef"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_slender_01.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-d1abb18ac955"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_slender_02.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-e9b1c9f53b00"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_slender_03.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-eca3989cff8c"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_slender_04.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0004-3dc61d3ec887"),
                    SpeciesType = SpeciesType.Avian,
                    AssetName = "Avian_slender_05.png"
                },

                // Fungoid
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-d7b41cfdaf76"),
                    SpeciesType = SpeciesType.Fungoid,
                    AssetName = "Fungoid_17.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-99013cb95bbd"),
                    SpeciesType = SpeciesType.Fungoid,
                    AssetName = "Fungoid_massive_11.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-321b094f5762"),
                    SpeciesType = SpeciesType.Fungoid,
                    AssetName = "Fungoid_massive_12.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-8788d5f3e35d"),
                    SpeciesType = SpeciesType.Fungoid,
                    AssetName = "Fungoid_massive_13.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-14430c731dc2"),
                    SpeciesType = SpeciesType.Fungoid,
                    AssetName = "Fungoid_massive_14.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-ea718adf8cba"),
                    SpeciesType = SpeciesType.Fungoid,
                    AssetName = "Fungoid_massive_15.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-0fabe7ca981f"),
                    SpeciesType = SpeciesType.Fungoid,
                    AssetName = "Fungoid_massive_16.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-b04304969301"),
                    SpeciesType = SpeciesType.Fungoid,
                    AssetName = "Fungoid_normal_06.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-4458e73a842c"),
                    SpeciesType = SpeciesType.Fungoid,
                    AssetName = "Fungoid_normal_07.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-576f665de7d2"),
                    SpeciesType = SpeciesType.Fungoid,
                    AssetName = "Fungoid_normal_08.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-5127456c421d"),
                    SpeciesType = SpeciesType.Fungoid,
                    AssetName = "Fungoid_normal_09.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-4dba51dc2901"),
                    SpeciesType = SpeciesType.Fungoid,
                    AssetName = "Fungoid_normal_10.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-3255c2b6bb8e"),
                    SpeciesType = SpeciesType.Fungoid,
                    AssetName = "Fungoid_slender_01.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-5c4b5de19471"),
                    SpeciesType = SpeciesType.Fungoid,
                    AssetName = "Fungoid_slender_02.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-674c0cd12909"),
                    SpeciesType = SpeciesType.Fungoid,
                    AssetName = "Fungoid_slender_03.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-7366ab557689"),
                    SpeciesType = SpeciesType.Fungoid,
                    AssetName = "Fungoid_slender_04.png"
                },

                // Humanoid
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-3fd3c71477e3"),
                    SpeciesType = SpeciesType.Humanoid,
                    AssetName = "Human.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-689e44079a1d"),
                    SpeciesType = SpeciesType.Humanoid,
                    AssetName = "Humanoid_02.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-8da311f350e4"),
                    SpeciesType = SpeciesType.Humanoid,
                    AssetName = "Humanoid_03.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-a824f3b7650f"),
                    SpeciesType = SpeciesType.Humanoid,
                    AssetName = "Humanoid_04.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-a9ecea6c70f0"),
                    SpeciesType = SpeciesType.Humanoid,
                    AssetName = "Humanoid_05.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-ab24503fa348"),
                    SpeciesType = SpeciesType.Humanoid,
                    AssetName = "Humanoid_hp_01.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-f75660d2b48c"),
                    SpeciesType = SpeciesType.Humanoid,
                    AssetName = "Humanoid_hp_02.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-7a0a13c31b24"),
                    SpeciesType = SpeciesType.Humanoid,
                    AssetName = "Humanoid_hp_06.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-000ec530cb8b"),
                    SpeciesType = SpeciesType.Humanoid,
                    AssetName = "Humanoid_hp_07.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-eff52ae02db1"),
                    SpeciesType = SpeciesType.Humanoid,
                    AssetName = "Humanoid_hp_08.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-0f7c49113abd"),
                    SpeciesType = SpeciesType.Humanoid,
                    AssetName = "Humanoid_hp_09.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-45a446592796"),
                    SpeciesType = SpeciesType.Humanoid,
                    AssetName = "Humanoid_hp_10.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-16ba70b3283c"),
                    SpeciesType = SpeciesType.Humanoid,
                    AssetName = "Humanoid_hp_11.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-d890407c0aee"),
                    SpeciesType = SpeciesType.Humanoid,
                    AssetName = "Humanoid_hp_12.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-fa500ed000ad"),
                    SpeciesType = SpeciesType.Humanoid,
                    AssetName = "Humanoid_hp_13.png"
                },

                // Lithoids
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0000-3d38f15ceb53"),
                    SpeciesType = SpeciesType.Lithoid,
                    AssetName = "800px-Lithoid_02.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-9b54ce119f41"),
                    SpeciesType = SpeciesType.Lithoid,
                    AssetName = "Lithoid_01.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-900dfed3ffb3"),
                    SpeciesType = SpeciesType.Lithoid,
                    AssetName = "Lithoid_03.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-61ea12c85a2c"),
                    SpeciesType = SpeciesType.Lithoid,
                    AssetName = "Lithoid_04.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-272873c8b411"),
                    SpeciesType = SpeciesType.Lithoid,
                    AssetName = "Lithoid_05.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-6ea926a2b0c6"),
                    SpeciesType = SpeciesType.Lithoid,
                    AssetName = "Lithoid_06.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-1dde173a0d72"),
                    SpeciesType = SpeciesType.Lithoid,
                    AssetName = "Lithoid_07.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-ce568aa409cf"),
                    SpeciesType = SpeciesType.Lithoid,
                    AssetName = "Lithoid_08.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-3201f2777c5c"),
                    SpeciesType = SpeciesType.Lithoid,
                    AssetName = "Lithoid_09.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-cb94dd8d78d0"),
                    SpeciesType = SpeciesType.Lithoid,
                    AssetName = "Lithoid_10.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-5da0041f1c23"),
                    SpeciesType = SpeciesType.Lithoid,
                    AssetName = "Lithoid_11.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-f6b64797af4c"),
                    SpeciesType = SpeciesType.Lithoid,
                    AssetName = "Lithoid_12.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-4b55bc7c7346"),
                    SpeciesType = SpeciesType.Lithoid,
                    AssetName = "Lithoid_13.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-7fbbd7e6992a"),
                    SpeciesType = SpeciesType.Lithoid,
                    AssetName = "Lithoid_14.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-a58f567804b0"),
                    SpeciesType = SpeciesType.Lithoid,
                    AssetName = "Lithoid_15.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-ae4531fe98bc"),
                    SpeciesType = SpeciesType.Lithoid,
                    AssetName = "Lithoid_machine.png"
                },

                // Mammal
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-72178817ffaa"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_massive_11.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-42c24127daa8"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_massive_12.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-1faa52038f22"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_massive_13.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-e16843b2e2d4"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_massive_14.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-ccce22d92c71"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_massive_15.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-a65bbcd295e6"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_massive_16.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-252076fdcc03"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_massive_17.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-59a7222370b2"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_normal_06.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-9b7cd58a7118"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_normal_07.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-6be3708f70d8"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_normal_08.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-e9aa91d69f33"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_normal_09.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-8de4db2a895d"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_normal_10.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-56f1b8279079"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_ratling.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-f3a13f95e0b9"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_slender_01.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-95ca149e3a4c"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_slender_02.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-9f3280cc0fcd"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_slender_03.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-0d1116d2e2fd"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_slender_04.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-7c282c3ab5fd"),
                    SpeciesType = SpeciesType.Mammalian,
                    AssetName = "Mammalian_slender_05.png"
                },

                // Molluscoid
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-9adcf9c7ae35"),
                    SpeciesType = SpeciesType.Molluscoid,
                    AssetName = "Molluscoid_17.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-97c37af24f37"),
                    SpeciesType = SpeciesType.Molluscoid,
                    AssetName = "Molluscoid_18.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-3353eec706e9"),
                    SpeciesType = SpeciesType.Molluscoid,
                    AssetName = "Molluscoid_massive_11.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-c3deb1b54c6b"),
                    SpeciesType = SpeciesType.Molluscoid,
                    AssetName = "Molluscoid_massive_12.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-82af9750923a"),
                    SpeciesType = SpeciesType.Molluscoid,
                    AssetName = "Molluscoid_massive_13.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-19022b56b981"),
                    SpeciesType = SpeciesType.Molluscoid,
                    AssetName = "Molluscoid_massive_14.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-96cd63952f82"),
                    SpeciesType = SpeciesType.Molluscoid,
                    AssetName = "Molluscoid_massive_15.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-c602cfc55bac"),
                    SpeciesType = SpeciesType.Molluscoid,
                    AssetName = "Molluscoid_massive_16.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-caf576baecb8"),
                    SpeciesType = SpeciesType.Molluscoid,
                    AssetName = "Molluscoid_normal_06.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-e2fa58654045"),
                    SpeciesType = SpeciesType.Molluscoid,
                    AssetName = "Molluscoid_normal_07.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-b56b180bd974"),
                    SpeciesType = SpeciesType.Molluscoid,
                    AssetName = "Molluscoid_normal_08.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-70189ead7e9a"),
                    SpeciesType = SpeciesType.Molluscoid,
                    AssetName = "Molluscoid_slender_01.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-91d757ea0e3f"),
                    SpeciesType = SpeciesType.Molluscoid,
                    AssetName = "Molluscoid_slender_02.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-9e9b2ac7b9e4"),
                    SpeciesType = SpeciesType.Molluscoid,
                    AssetName = "Molluscoid_slender_03.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-7f1c48f5ede1"),
                    SpeciesType = SpeciesType.Molluscoid,
                    AssetName = "Molluscoid_slender_04.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-78fce4d1996c"),
                    SpeciesType = SpeciesType.Molluscoid,
                    AssetName = "Molluscoid_slender_05.png"
                },

                // Necroids
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-63f6fd064a0a"),
                    SpeciesType = SpeciesType.Necroid,
                    AssetName = "Necroids_01_portrait_purple.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-23339f3ea8d5"),
                    SpeciesType = SpeciesType.Necroid,
                    AssetName = "Necroids_02_portrait_brass.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-eabafe68ff0f"),
                    SpeciesType = SpeciesType.Necroid,
                    AssetName = "Necroids_03_portrait_green.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-8cce2081284a"),
                    SpeciesType = SpeciesType.Necroid,
                    AssetName = "Necroids_04_portrait_purple.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-981bd9a023d2"),
                    SpeciesType = SpeciesType.Necroid,
                    AssetName = "Necroids_05_portrait_green.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-244d34cb4118"),
                    SpeciesType = SpeciesType.Necroid,
                    AssetName = "Necroids_06_portrait_blue.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-2def3762d45b"),
                    SpeciesType = SpeciesType.Necroid,
                    AssetName = "Necroids_07_portrait_black.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-c848de3cf30f"),
                    SpeciesType = SpeciesType.Necroid,
                    AssetName = "Necroids_08_portrait_orange.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-a97029d805e0"),
                    SpeciesType = SpeciesType.Necroid,
                    AssetName = "Necroids_09_portrait_teal.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-7e353a1cb111"),
                    SpeciesType = SpeciesType.Necroid,
                    AssetName = "Necroids_10_portrait_blue.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-6cc0c4862ff4"),
                    SpeciesType = SpeciesType.Necroid,
                    AssetName = "Necroids_11_portrait_v3.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-331a6a65c25a"),
                    SpeciesType = SpeciesType.Necroid,
                    AssetName = "Necroids_12_portrait_green.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-ea5d9cd4c132"),
                    SpeciesType = SpeciesType.Necroid,
                    AssetName = "Necroids_13_portrait_blue.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-f164258d5e8f"),
                    SpeciesType = SpeciesType.Necroid,
                    AssetName = "Necroids_14_portrait_blue.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-b193d0a19107"),
                    SpeciesType = SpeciesType.Necroid,
                    AssetName = "Necroids_15_portrait_grey.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-3278ace6f46b"),
                    SpeciesType = SpeciesType.Necroid,
                    AssetName = "Necroids_machine_portrait_red.png"
                },

                // Plantoid
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-2f31841ab4c8"),
                    SpeciesType = SpeciesType.Plantoid,
                    AssetName = "Plantoid_01.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-b5380a53a13b"),
                    SpeciesType = SpeciesType.Plantoid,
                    AssetName = "Plantoid_02.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-4725dd08e0a4"),
                    SpeciesType = SpeciesType.Plantoid,
                    AssetName = "Plantoid_03.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-6d781b55eafa"),
                    SpeciesType = SpeciesType.Plantoid,
                    AssetName = "Plantoid_04.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-e7642dc2baef"),
                    SpeciesType = SpeciesType.Plantoid,
                    AssetName = "Plantoid_05.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-8f57c287cbc1"),
                    SpeciesType = SpeciesType.Plantoid,
                    AssetName = "Plantoid_06.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-be709b1b6b50"),
                    SpeciesType = SpeciesType.Plantoid,
                    AssetName = "Plantoid_07.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-7826f5f2f44c"),
                    SpeciesType = SpeciesType.Plantoid,
                    AssetName = "Plantoid_08.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-5a3142b959c0"),
                    SpeciesType = SpeciesType.Plantoid,
                    AssetName = "Plantoid_09.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-01554a52ad30"),
                    SpeciesType = SpeciesType.Plantoid,
                    AssetName = "Plantoid_10.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-0c5c26e55699"),
                    SpeciesType = SpeciesType.Plantoid,
                    AssetName = "Plantoid_11.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-e4be2cfb9669"),
                    SpeciesType = SpeciesType.Plantoid,
                    AssetName = "Plantoid_12.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-12f5a268ea73"),
                    SpeciesType = SpeciesType.Plantoid,
                    AssetName = "Plantoid_13.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-0a053a0bb1ad"),
                    SpeciesType = SpeciesType.Plantoid,
                    AssetName = "Plantoid_14.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-7ca378911564"),
                    SpeciesType = SpeciesType.Plantoid,
                    AssetName = "Plantoid_15.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-e7bdfe9602a4"),
                    SpeciesType = SpeciesType.Plantoid,
                    AssetName = "Plantoid_hivemind.png"
                },

                // Reptilian
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-0dfba808b2e1"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_16.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-1134f66f5ec3"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_17.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-30f42f709914"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_massive_11.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-79db1e8cde80"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_massive_12.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-a39ce2042ab3"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_massive_13.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-a6ad7d9f57d4"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_massive_14.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-17dddf6838c0"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_massive_15.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-3b9f9a7f1159"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_normal_06.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-14abe8b79d4b"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_normal_07.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-ca1fe0e018fa"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_normal_08.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-1ff761c80d42"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_normal_09.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-499bb7f8f6a4"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_normal_10.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-cd69dc75eafe"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_slender_01.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-48118bebafbc"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_slender_02.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-31415b8ca46c"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_slender_03.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-5d88c4d28f82"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_slender_04.png"
                }, new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-0a3a9a135a64"),
                    SpeciesType = SpeciesType.Reptilian,
                    AssetName = "Reptilian_slender_05.png"
                },

                // Synthetic
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-7a08ccd15f45"),
                    SpeciesType = SpeciesType.Synthetic,
                    AssetName = "Synthetic_dawn_portrait_arthopoid.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-e684483c9a10"),
                    SpeciesType = SpeciesType.Synthetic,
                    AssetName = "Synthetic_dawn_portrait_avian.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-3523e73dd73b"),
                    SpeciesType = SpeciesType.Synthetic,
                    AssetName = "Synthetic_dawn_portrait_fungoid.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-c19d3d54e6b3"),
                    SpeciesType = SpeciesType.Synthetic,
                    AssetName = "Synthetic_dawn_portrait_humanoid.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-ef50dcf55ea0"),
                    SpeciesType = SpeciesType.Synthetic,
                    AssetName = "Synthetic_dawn_portrait_mammalian.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-b4c122695332"),
                    SpeciesType = SpeciesType.Synthetic,
                    AssetName = "Synthetic_dawn_portrait_molluscoid.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-9d8396e9ae11"),
                    SpeciesType = SpeciesType.Synthetic,
                    AssetName = "Synthetic_dawn_portrait_plantoid.png"
                },
                new Species()
                {
                    Id = Guid.Parse("22222222-2222-0000-0005-3dab2554c31a"),
                    SpeciesType = SpeciesType.Synthetic,
                    AssetName = "Synthetic_dawn_portrait_reptilian.png"
                }
                
            );
        }
    }
}