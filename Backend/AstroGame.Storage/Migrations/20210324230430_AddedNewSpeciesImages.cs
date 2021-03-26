using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AddedNewSpeciesImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerSpecies_Perks_PerkId",
                table: "PlayerSpecies");

            migrationBuilder.DropIndex(
                name: "IX_PlayerSpecies_PerkId",
                table: "PlayerSpecies");

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0000-000000000000"));

            migrationBuilder.DropColumn(
                name: "PerkId",
                table: "PlayerSpecies");

            migrationBuilder.AddColumn<int>(
                name: "SpeciesType",
                table: "Species",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName", "SpeciesType" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-0000-0001-f767e933b649"), "Alien_AI.png", 3 },
                    { new Guid("22222222-2222-0000-0005-c602cfc55bac"), "Molluscoid_massive_16.png", 6 },
                    { new Guid("22222222-2222-0000-0005-caf576baecb8"), "Molluscoid_normal_06.png", 6 },
                    { new Guid("22222222-2222-0000-0005-e2fa58654045"), "Molluscoid_normal_07.png", 6 },
                    { new Guid("22222222-2222-0000-0005-b56b180bd974"), "Molluscoid_normal_08.png", 6 },
                    { new Guid("22222222-2222-0000-0005-70189ead7e9a"), "Molluscoid_slender_01.png", 6 },
                    { new Guid("22222222-2222-0000-0005-91d757ea0e3f"), "Molluscoid_slender_02.png", 6 },
                    { new Guid("22222222-2222-0000-0005-9e9b2ac7b9e4"), "Molluscoid_slender_03.png", 6 },
                    { new Guid("22222222-2222-0000-0005-7f1c48f5ede1"), "Molluscoid_slender_04.png", 6 },
                    { new Guid("22222222-2222-0000-0005-96cd63952f82"), "Molluscoid_massive_15.png", 6 },
                    { new Guid("22222222-2222-0000-0005-78fce4d1996c"), "Molluscoid_slender_05.png", 6 },
                    { new Guid("22222222-2222-0000-0005-23339f3ea8d5"), "Necroids_02_portrait_brass.png", 7 },
                    { new Guid("22222222-2222-0000-0005-eabafe68ff0f"), "Necroids_03_portrait_green.png", 7 },
                    { new Guid("22222222-2222-0000-0005-8cce2081284a"), "Necroids_04_portrait_purple.png", 7 },
                    { new Guid("22222222-2222-0000-0005-981bd9a023d2"), "Necroids_05_portrait_green.png", 7 },
                    { new Guid("22222222-2222-0000-0005-244d34cb4118"), "Necroids_06_portrait_blue.png", 7 },
                    { new Guid("22222222-2222-0000-0005-2def3762d45b"), "Necroids_07_portrait_black.png", 7 },
                    { new Guid("22222222-2222-0000-0005-c848de3cf30f"), "Necroids_08_portrait_orange.png", 7 },
                    { new Guid("22222222-2222-0000-0005-a97029d805e0"), "Necroids_09_portrait_teal.png", 7 },
                    { new Guid("22222222-2222-0000-0005-63f6fd064a0a"), "Necroids_01_portrait_purple.png", 7 },
                    { new Guid("22222222-2222-0000-0005-19022b56b981"), "Molluscoid_massive_14.png", 6 },
                    { new Guid("22222222-2222-0000-0005-82af9750923a"), "Molluscoid_massive_13.png", 6 },
                    { new Guid("22222222-2222-0000-0005-c3deb1b54c6b"), "Molluscoid_massive_12.png", 6 },
                    { new Guid("22222222-2222-0000-0005-1faa52038f22"), "Mammalian_massive_13.png", 5 },
                    { new Guid("22222222-2222-0000-0005-e16843b2e2d4"), "Mammalian_massive_14.png", 5 },
                    { new Guid("22222222-2222-0000-0005-ccce22d92c71"), "Mammalian_massive_15.png", 5 },
                    { new Guid("22222222-2222-0000-0005-a65bbcd295e6"), "Mammalian_massive_16.png", 5 },
                    { new Guid("22222222-2222-0000-0005-252076fdcc03"), "Mammalian_massive_17.png", 5 },
                    { new Guid("22222222-2222-0000-0005-59a7222370b2"), "Mammalian_normal_06.png", 5 },
                    { new Guid("22222222-2222-0000-0005-9b7cd58a7118"), "Mammalian_normal_07.png", 5 },
                    { new Guid("22222222-2222-0000-0005-6be3708f70d8"), "Mammalian_normal_08.png", 5 },
                    { new Guid("22222222-2222-0000-0005-e9aa91d69f33"), "Mammalian_normal_09.png", 5 },
                    { new Guid("22222222-2222-0000-0005-8de4db2a895d"), "Mammalian_normal_10.png", 5 },
                    { new Guid("22222222-2222-0000-0005-56f1b8279079"), "Mammalian_ratling.png", 5 },
                    { new Guid("22222222-2222-0000-0005-f3a13f95e0b9"), "Mammalian_slender_01.png", 5 },
                    { new Guid("22222222-2222-0000-0005-95ca149e3a4c"), "Mammalian_slender_02.png", 5 },
                    { new Guid("22222222-2222-0000-0005-9f3280cc0fcd"), "Mammalian_slender_03.png", 5 },
                    { new Guid("22222222-2222-0000-0005-0d1116d2e2fd"), "Mammalian_slender_04.png", 5 },
                    { new Guid("22222222-2222-0000-0005-7c282c3ab5fd"), "Mammalian_slender_05.png", 5 },
                    { new Guid("22222222-2222-0000-0005-9adcf9c7ae35"), "Molluscoid_17.png", 6 },
                    { new Guid("22222222-2222-0000-0005-97c37af24f37"), "Molluscoid_18.png", 6 },
                    { new Guid("22222222-2222-0000-0005-3353eec706e9"), "Molluscoid_massive_11.png", 6 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName", "SpeciesType" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-0000-0005-7e353a1cb111"), "Necroids_10_portrait_blue.png", 7 },
                    { new Guid("22222222-2222-0000-0005-6cc0c4862ff4"), "Necroids_11_portrait_v3.png", 7 },
                    { new Guid("22222222-2222-0000-0005-331a6a65c25a"), "Necroids_12_portrait_green.png", 7 },
                    { new Guid("22222222-2222-0000-0005-ea5d9cd4c132"), "Necroids_13_portrait_blue.png", 7 },
                    { new Guid("22222222-2222-0000-0005-a39ce2042ab3"), "Reptilian_massive_13.png", 9 },
                    { new Guid("22222222-2222-0000-0005-a6ad7d9f57d4"), "Reptilian_massive_14.png", 9 },
                    { new Guid("22222222-2222-0000-0005-17dddf6838c0"), "Reptilian_massive_15.png", 9 },
                    { new Guid("22222222-2222-0000-0005-3b9f9a7f1159"), "Reptilian_normal_06.png", 9 },
                    { new Guid("22222222-2222-0000-0005-14abe8b79d4b"), "Reptilian_normal_07.png", 9 },
                    { new Guid("22222222-2222-0000-0005-ca1fe0e018fa"), "Reptilian_normal_08.png", 9 },
                    { new Guid("22222222-2222-0000-0005-1ff761c80d42"), "Reptilian_normal_09.png", 9 },
                    { new Guid("22222222-2222-0000-0005-499bb7f8f6a4"), "Reptilian_normal_10.png", 9 },
                    { new Guid("22222222-2222-0000-0005-cd69dc75eafe"), "Reptilian_slender_01.png", 9 },
                    { new Guid("22222222-2222-0000-0005-48118bebafbc"), "Reptilian_slender_02.png", 9 },
                    { new Guid("22222222-2222-0000-0005-31415b8ca46c"), "Reptilian_slender_03.png", 9 },
                    { new Guid("22222222-2222-0000-0005-5d88c4d28f82"), "Reptilian_slender_04.png", 9 },
                    { new Guid("22222222-2222-0000-0005-0a3a9a135a64"), "Reptilian_slender_05.png", 9 },
                    { new Guid("22222222-2222-0000-0005-7a08ccd15f45"), "Synthetic_dawn_portrait_arthopoid.png", 10 },
                    { new Guid("22222222-2222-0000-0005-e684483c9a10"), "Synthetic_dawn_portrait_avian.png", 10 },
                    { new Guid("22222222-2222-0000-0005-3523e73dd73b"), "Synthetic_dawn_portrait_fungoid.png", 10 },
                    { new Guid("22222222-2222-0000-0005-c19d3d54e6b3"), "Synthetic_dawn_portrait_humanoid.png", 10 },
                    { new Guid("22222222-2222-0000-0005-ef50dcf55ea0"), "Synthetic_dawn_portrait_mammalian.png", 10 },
                    { new Guid("22222222-2222-0000-0005-b4c122695332"), "Synthetic_dawn_portrait_molluscoid.png", 10 },
                    { new Guid("22222222-2222-0000-0005-79db1e8cde80"), "Reptilian_massive_12.png", 9 },
                    { new Guid("22222222-2222-0000-0005-42c24127daa8"), "Mammalian_massive_12.png", 5 },
                    { new Guid("22222222-2222-0000-0005-30f42f709914"), "Reptilian_massive_11.png", 9 },
                    { new Guid("22222222-2222-0000-0005-0dfba808b2e1"), "Reptilian_16.png", 9 },
                    { new Guid("22222222-2222-0000-0005-f164258d5e8f"), "Necroids_14_portrait_blue.png", 7 },
                    { new Guid("22222222-2222-0000-0005-b193d0a19107"), "Necroids_15_portrait_grey.png", 7 },
                    { new Guid("22222222-2222-0000-0005-3278ace6f46b"), "Necroids_machine_portrait_red.png", 7 },
                    { new Guid("22222222-2222-0000-0005-2f31841ab4c8"), "Plantoid_01.png", 8 },
                    { new Guid("22222222-2222-0000-0005-b5380a53a13b"), "Plantoid_02.png", 8 },
                    { new Guid("22222222-2222-0000-0005-4725dd08e0a4"), "Plantoid_03.png", 8 },
                    { new Guid("22222222-2222-0000-0005-6d781b55eafa"), "Plantoid_04.png", 8 },
                    { new Guid("22222222-2222-0000-0005-e7642dc2baef"), "Plantoid_05.png", 8 },
                    { new Guid("22222222-2222-0000-0005-8f57c287cbc1"), "Plantoid_06.png", 8 },
                    { new Guid("22222222-2222-0000-0005-be709b1b6b50"), "Plantoid_07.png", 8 },
                    { new Guid("22222222-2222-0000-0005-7826f5f2f44c"), "Plantoid_08.png", 8 },
                    { new Guid("22222222-2222-0000-0005-5a3142b959c0"), "Plantoid_09.png", 8 },
                    { new Guid("22222222-2222-0000-0005-01554a52ad30"), "Plantoid_10.png", 8 },
                    { new Guid("22222222-2222-0000-0005-0c5c26e55699"), "Plantoid_11.png", 8 },
                    { new Guid("22222222-2222-0000-0005-e4be2cfb9669"), "Plantoid_12.png", 8 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName", "SpeciesType" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-0000-0005-12f5a268ea73"), "Plantoid_13.png", 8 },
                    { new Guid("22222222-2222-0000-0005-0a053a0bb1ad"), "Plantoid_14.png", 8 },
                    { new Guid("22222222-2222-0000-0005-7ca378911564"), "Plantoid_15.png", 8 },
                    { new Guid("22222222-2222-0000-0005-e7bdfe9602a4"), "Plantoid_hivemind.png", 8 },
                    { new Guid("22222222-2222-0000-0005-1134f66f5ec3"), "Reptilian_17.png", 9 },
                    { new Guid("22222222-2222-0000-0005-9d8396e9ae11"), "Synthetic_dawn_portrait_plantoid.png", 10 },
                    { new Guid("22222222-2222-0000-0005-72178817ffaa"), "Mammalian_massive_11.png", 5 },
                    { new Guid("22222222-2222-0000-0005-a58f567804b0"), "Lithoid_15.png", 0 },
                    { new Guid("22222222-2222-0000-0003-25c639b710ed"), "Arthropoid_slender_05.png", 2 },
                    { new Guid("22222222-2222-0000-0004-579805ddbf3e"), "Avian_18.png", 4 },
                    { new Guid("22222222-2222-0000-0004-461e17de2b81"), "Avian_massive_11.png", 4 },
                    { new Guid("22222222-2222-0000-0004-beb2f37aabca"), "Avian_massive_12.png", 4 },
                    { new Guid("22222222-2222-0000-0004-d9b3206f5bde"), "Avian_massive_13.png", 4 },
                    { new Guid("22222222-2222-0000-0004-df4f7fa13342"), "Avian_massive_14.png", 4 },
                    { new Guid("22222222-2222-0000-0004-26e3d161cc91"), "Avian_massive_15.png", 4 },
                    { new Guid("22222222-2222-0000-0004-009e992f1667"), "Avian_massive_16.png", 4 },
                    { new Guid("22222222-2222-0000-0003-f8e74a276650"), "Arthropoid_slender_03.png", 2 },
                    { new Guid("22222222-2222-0000-0004-e4561c11b129"), "Avian_massive_17.png", 4 },
                    { new Guid("22222222-2222-0000-0004-ba43849d85ac"), "Avian_normal_07.png", 4 },
                    { new Guid("22222222-2222-0000-0004-a41cbfc3a2d0"), "Avian_normal_08.png", 4 },
                    { new Guid("22222222-2222-0000-0004-c94ddb578e15"), "Avian_normal_09.png", 4 },
                    { new Guid("22222222-2222-0000-0004-f2d51ca358e1"), "Avian_normal_10.png", 4 },
                    { new Guid("22222222-2222-0000-0004-79f7dc57a6ef"), "Avian_slender_01.png", 4 },
                    { new Guid("22222222-2222-0000-0004-d1abb18ac955"), "Avian_slender_02.png", 4 },
                    { new Guid("22222222-2222-0000-0004-e9b1c9f53b00"), "Avian_slender_03.png", 4 },
                    { new Guid("22222222-2222-0000-0004-eca3989cff8c"), "Avian_slender_04.png", 4 },
                    { new Guid("22222222-2222-0000-0004-59b4a036598a"), "Avian_normal_06.png", 4 },
                    { new Guid("22222222-2222-0000-0003-0bd8bc8b5c04"), "Arthropoid_slender_01.png", 2 },
                    { new Guid("22222222-2222-0000-0003-62f458ececf0"), "Arthropoid_normal_10.png", 2 },
                    { new Guid("22222222-2222-0000-0003-8a190f13b5dd"), "Arthropoid_normal_09.png", 2 },
                    { new Guid("22222222-2222-0000-0001-ee1bd82b1062"), "Alien_AI_red.png", 3 },
                    { new Guid("22222222-2222-0000-0001-e78d009741ad"), "Alien_extradimensional_01.png", 3 },
                    { new Guid("22222222-2222-0000-0001-be5807e86491"), "Alien_extradimensional_02.png", 3 },
                    { new Guid("22222222-2222-0000-0001-305c25f034d7"), "Alien_extradimensional_03.png", 3 },
                    { new Guid("22222222-2222-0000-0001-a4bea66e94c2"), "Alien_Swarm.png", 3 },
                    { new Guid("22222222-2222-0000-0003-5cedabc2eb68"), "Arthropoid_18.png", 2 },
                    { new Guid("22222222-2222-0000-0003-292ed1175ce1"), "Arthropoid_19.png", 2 },
                    { new Guid("22222222-2222-0000-0003-5aaeb4e06b38"), "Arthropoid_20.png", 2 },
                    { new Guid("22222222-2222-0000-0003-5b960184b0db"), "Arthropoid_massive_11.png", 2 },
                    { new Guid("22222222-2222-0000-0003-a783cc04fafa"), "Arthropoid_massive_12.png", 2 },
                    { new Guid("22222222-2222-0000-0003-0ea9d5234afb"), "Arthropoid_massive_13.png", 2 },
                    { new Guid("22222222-2222-0000-0003-6d2c7313dcf6"), "Arthropoid_massive_14.png", 2 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName", "SpeciesType" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-0000-0003-7268b02c24eb"), "Arthropoid_massive_15.png", 2 },
                    { new Guid("22222222-2222-0000-0003-ed8d781ff41b"), "Arthropoid_massive_16.png", 2 },
                    { new Guid("22222222-2222-0000-0003-2a9b2afc1a1e"), "Arthropoid_massive_17.png", 2 },
                    { new Guid("22222222-2222-0000-0003-e1a194845eda"), "Arthropoid_normal_06.png", 2 },
                    { new Guid("22222222-2222-0000-0003-5edf18e174ef"), "Arthropoid_normal_07.png", 2 },
                    { new Guid("22222222-2222-0000-0003-f801ce1701fc"), "Arthropoid_normal_08.png", 2 },
                    { new Guid("22222222-2222-0000-0003-111c578bbf31"), "Arthropoid_normal_08.png", 2 },
                    { new Guid("22222222-2222-0000-0004-3dc61d3ec887"), "Avian_slender_05.png", 4 },
                    { new Guid("22222222-2222-0000-0005-d7b41cfdaf76"), "Fungoid_17.png", 11 },
                    { new Guid("22222222-2222-0000-0005-99013cb95bbd"), "Fungoid_massive_11.png", 11 },
                    { new Guid("22222222-2222-0000-0005-321b094f5762"), "Fungoid_massive_12.png", 11 },
                    { new Guid("22222222-2222-0000-0005-0f7c49113abd"), "Humanoid_hp_09.png", 1 },
                    { new Guid("22222222-2222-0000-0005-45a446592796"), "Humanoid_hp_10.png", 1 },
                    { new Guid("22222222-2222-0000-0005-16ba70b3283c"), "Humanoid_hp_11.png", 1 },
                    { new Guid("22222222-2222-0000-0005-d890407c0aee"), "Humanoid_hp_12.png", 1 },
                    { new Guid("22222222-2222-0000-0005-fa500ed000ad"), "Humanoid_hp_13.png", 1 },
                    { new Guid("22222222-2222-0000-0000-3d38f15ceb53"), "800px-Lithoid_02.png", 0 },
                    { new Guid("22222222-2222-0000-0005-9b54ce119f41"), "Lithoid_01.png", 0 },
                    { new Guid("22222222-2222-0000-0005-900dfed3ffb3"), "Lithoid_03.png", 0 },
                    { new Guid("22222222-2222-0000-0005-61ea12c85a2c"), "Lithoid_04.png", 0 },
                    { new Guid("22222222-2222-0000-0005-272873c8b411"), "Lithoid_05.png", 0 },
                    { new Guid("22222222-2222-0000-0005-6ea926a2b0c6"), "Lithoid_06.png", 0 },
                    { new Guid("22222222-2222-0000-0005-1dde173a0d72"), "Lithoid_07.png", 0 },
                    { new Guid("22222222-2222-0000-0005-ce568aa409cf"), "Lithoid_08.png", 0 },
                    { new Guid("22222222-2222-0000-0005-3201f2777c5c"), "Lithoid_09.png", 0 },
                    { new Guid("22222222-2222-0000-0005-cb94dd8d78d0"), "Lithoid_10.png", 0 },
                    { new Guid("22222222-2222-0000-0005-5da0041f1c23"), "Lithoid_11.png", 0 },
                    { new Guid("22222222-2222-0000-0005-f6b64797af4c"), "Lithoid_12.png", 0 },
                    { new Guid("22222222-2222-0000-0005-4b55bc7c7346"), "Lithoid_13.png", 0 },
                    { new Guid("22222222-2222-0000-0005-7fbbd7e6992a"), "Lithoid_14.png", 0 },
                    { new Guid("22222222-2222-0000-0005-eff52ae02db1"), "Humanoid_hp_08.png", 1 },
                    { new Guid("22222222-2222-0000-0005-ae4531fe98bc"), "Lithoid_machine.png", 0 },
                    { new Guid("22222222-2222-0000-0005-000ec530cb8b"), "Humanoid_hp_07.png", 1 },
                    { new Guid("22222222-2222-0000-0005-f75660d2b48c"), "Humanoid_hp_02.png", 1 },
                    { new Guid("22222222-2222-0000-0005-8788d5f3e35d"), "Fungoid_massive_13.png", 11 },
                    { new Guid("22222222-2222-0000-0005-14430c731dc2"), "Fungoid_massive_14.png", 11 },
                    { new Guid("22222222-2222-0000-0005-ea718adf8cba"), "Fungoid_massive_15.png", 11 },
                    { new Guid("22222222-2222-0000-0005-0fabe7ca981f"), "Fungoid_massive_16.png", 11 },
                    { new Guid("22222222-2222-0000-0005-b04304969301"), "Fungoid_normal_06.png", 11 },
                    { new Guid("22222222-2222-0000-0005-4458e73a842c"), "Fungoid_normal_07.png", 11 },
                    { new Guid("22222222-2222-0000-0005-576f665de7d2"), "Fungoid_normal_08.png", 11 },
                    { new Guid("22222222-2222-0000-0005-5127456c421d"), "Fungoid_normal_09.png", 11 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName", "SpeciesType" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-0000-0005-4dba51dc2901"), "Fungoid_normal_10.png", 11 },
                    { new Guid("22222222-2222-0000-0005-3255c2b6bb8e"), "Fungoid_slender_01.png", 11 },
                    { new Guid("22222222-2222-0000-0005-5c4b5de19471"), "Fungoid_slender_02.png", 11 },
                    { new Guid("22222222-2222-0000-0005-674c0cd12909"), "Fungoid_slender_03.png", 11 },
                    { new Guid("22222222-2222-0000-0005-7366ab557689"), "Fungoid_slender_04.png", 11 },
                    { new Guid("22222222-2222-0000-0005-3fd3c71477e3"), "Human.png", 1 },
                    { new Guid("22222222-2222-0000-0005-689e44079a1d"), "Humanoid_02.png", 1 },
                    { new Guid("22222222-2222-0000-0005-8da311f350e4"), "Humanoid_03.png", 1 },
                    { new Guid("22222222-2222-0000-0005-a824f3b7650f"), "Humanoid_04.png", 1 },
                    { new Guid("22222222-2222-0000-0005-a9ecea6c70f0"), "Humanoid_05.png", 1 },
                    { new Guid("22222222-2222-0000-0005-ab24503fa348"), "Humanoid_hp_01.png", 1 },
                    { new Guid("22222222-2222-0000-0005-7a0a13c31b24"), "Humanoid_hp_06.png", 1 },
                    { new Guid("22222222-2222-0000-0005-3dab2554c31a"), "Synthetic_dawn_portrait_reptilian.png", 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0000-3d38f15ceb53"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0001-305c25f034d7"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0001-a4bea66e94c2"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0001-be5807e86491"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0001-e78d009741ad"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0001-ee1bd82b1062"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0001-f767e933b649"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-0bd8bc8b5c04"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-0ea9d5234afb"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-111c578bbf31"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-25c639b710ed"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-292ed1175ce1"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-2a9b2afc1a1e"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-5aaeb4e06b38"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-5b960184b0db"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-5cedabc2eb68"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-5edf18e174ef"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-62f458ececf0"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-6d2c7313dcf6"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-7268b02c24eb"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-8a190f13b5dd"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-a783cc04fafa"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-e1a194845eda"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-ed8d781ff41b"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-f801ce1701fc"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0003-f8e74a276650"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-009e992f1667"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-26e3d161cc91"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-3dc61d3ec887"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-461e17de2b81"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-579805ddbf3e"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-59b4a036598a"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-79f7dc57a6ef"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-a41cbfc3a2d0"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-ba43849d85ac"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-beb2f37aabca"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-c94ddb578e15"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-d1abb18ac955"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-d9b3206f5bde"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-df4f7fa13342"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-e4561c11b129"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-e9b1c9f53b00"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-eca3989cff8c"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0004-f2d51ca358e1"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-000ec530cb8b"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-01554a52ad30"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-0a053a0bb1ad"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-0a3a9a135a64"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-0c5c26e55699"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-0d1116d2e2fd"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-0dfba808b2e1"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-0f7c49113abd"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-0fabe7ca981f"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-1134f66f5ec3"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-12f5a268ea73"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-14430c731dc2"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-14abe8b79d4b"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-16ba70b3283c"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-17dddf6838c0"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-19022b56b981"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-1dde173a0d72"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-1faa52038f22"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-1ff761c80d42"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-23339f3ea8d5"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-244d34cb4118"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-252076fdcc03"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-272873c8b411"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-2def3762d45b"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-2f31841ab4c8"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-30f42f709914"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-31415b8ca46c"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-3201f2777c5c"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-321b094f5762"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-3255c2b6bb8e"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-3278ace6f46b"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-331a6a65c25a"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-3353eec706e9"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-3523e73dd73b"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-3b9f9a7f1159"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-3dab2554c31a"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-3fd3c71477e3"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-42c24127daa8"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-4458e73a842c"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-45a446592796"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-4725dd08e0a4"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-48118bebafbc"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-499bb7f8f6a4"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-4b55bc7c7346"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-4dba51dc2901"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-5127456c421d"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-56f1b8279079"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-576f665de7d2"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-59a7222370b2"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-5a3142b959c0"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-5c4b5de19471"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-5d88c4d28f82"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-5da0041f1c23"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-61ea12c85a2c"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-63f6fd064a0a"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-674c0cd12909"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-689e44079a1d"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-6be3708f70d8"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-6cc0c4862ff4"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-6d781b55eafa"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-6ea926a2b0c6"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-70189ead7e9a"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-72178817ffaa"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-7366ab557689"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-7826f5f2f44c"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-78fce4d1996c"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-79db1e8cde80"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-7a08ccd15f45"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-7a0a13c31b24"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-7c282c3ab5fd"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-7ca378911564"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-7e353a1cb111"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-7f1c48f5ede1"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-7fbbd7e6992a"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-82af9750923a"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-8788d5f3e35d"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-8cce2081284a"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-8da311f350e4"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-8de4db2a895d"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-8f57c287cbc1"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-900dfed3ffb3"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-91d757ea0e3f"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-95ca149e3a4c"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-96cd63952f82"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-97c37af24f37"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-981bd9a023d2"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-99013cb95bbd"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-9adcf9c7ae35"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-9b54ce119f41"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-9b7cd58a7118"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-9d8396e9ae11"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-9e9b2ac7b9e4"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-9f3280cc0fcd"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-a39ce2042ab3"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-a58f567804b0"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-a65bbcd295e6"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-a6ad7d9f57d4"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-a824f3b7650f"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-a97029d805e0"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-a9ecea6c70f0"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-ab24503fa348"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-ae4531fe98bc"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-b04304969301"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-b193d0a19107"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-b4c122695332"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-b5380a53a13b"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-b56b180bd974"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-be709b1b6b50"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-c19d3d54e6b3"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-c3deb1b54c6b"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-c602cfc55bac"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-c848de3cf30f"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-ca1fe0e018fa"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-caf576baecb8"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-cb94dd8d78d0"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-ccce22d92c71"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-cd69dc75eafe"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-ce568aa409cf"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-d7b41cfdaf76"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-d890407c0aee"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-e16843b2e2d4"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-e2fa58654045"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-e4be2cfb9669"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-e684483c9a10"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-e7642dc2baef"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-e7bdfe9602a4"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-e9aa91d69f33"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-ea5d9cd4c132"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-ea718adf8cba"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-eabafe68ff0f"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-ef50dcf55ea0"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-eff52ae02db1"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-f164258d5e8f"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-f3a13f95e0b9"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-f6b64797af4c"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-f75660d2b48c"));

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-0000-0005-fa500ed000ad"));

            migrationBuilder.DropColumn(
                name: "SpeciesType",
                table: "Species");

            migrationBuilder.AddColumn<Guid>(
                name: "PerkId",
                table: "PlayerSpecies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName" },
                values: new object[] { new Guid("22222222-2222-0000-0000-000000000000"), "image_1" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSpecies_PerkId",
                table: "PlayerSpecies",
                column: "PerkId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerSpecies_Perks_PerkId",
                table: "PlayerSpecies",
                column: "PerkId",
                principalTable: "Perks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
