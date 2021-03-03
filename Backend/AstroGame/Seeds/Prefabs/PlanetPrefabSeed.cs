using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Prefabs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using UnityEngine;

namespace AstroGame.Api.Seeds.Prefabs
{
    public class PlanetPrefabSeed : IEntityTypeConfiguration<PlanetPrefab>
    {
        public void Configure(EntityTypeBuilder<PlanetPrefab> builder)
        {
            builder.HasData(
                // Volcano 
                new PlanetPrefab()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "Planet_Volcano_1",
                    PlanetType = PlanetType.Volcano,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                },
                new PlanetPrefab()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Name = "Planet_Volcano_2",
                    PlanetType = PlanetType.Volcano,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetPrefab()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Name = "Planet_Volcano_3",
                    PlanetType = PlanetType.Volcano,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }

                // Desert
                , new PlanetPrefab()
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    Name = "Planet_Desert_1",
                    PlanetType = PlanetType.Desert,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetPrefab()
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    Name = "Planet_Desert_2",
                    PlanetType = PlanetType.Desert,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetPrefab()
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    Name = "Planet_Desert_3",
                    PlanetType = PlanetType.Desert,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }

                // Continental
                , new PlanetPrefab()
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                    Name = "Planet_Continental_1",
                    PlanetType = PlanetType.Continental,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetPrefab()
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                    Name = "Planet_Continental_2",
                    PlanetType = PlanetType.Continental,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetPrefab()
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                    Name = "Planet_Continental_3",
                    PlanetType = PlanetType.Continental,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }

                // Rock
                , new PlanetPrefab()
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    Name = "Planet_Rock_1",
                    PlanetType = PlanetType.Rock,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetPrefab()
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    Name = "Planet_Rock_2",
                    PlanetType = PlanetType.Rock,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetPrefab()
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    Name = "Planet_Rock_3",
                    PlanetType = PlanetType.Rock,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }

                // Gaia
                , new PlanetPrefab()
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000001"),
                    Name = "Planet_Gaia_1",
                    PlanetType = PlanetType.Gaia,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetPrefab()
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000002"),
                    Name = "Planet_Gaia_2",
                    PlanetType = PlanetType.Gaia,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetPrefab()
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000003"),
                    Name = "Planet_Gaia_3",
                    PlanetType = PlanetType.Gaia,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }

                // Gas
                , new PlanetPrefab()
                {
                    Id = Guid.Parse("50000000-0000-0000-0000-000000000001"),
                    Name = "Planet_Gas_1",
                    PlanetType = PlanetType.Gas,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetPrefab()
                {
                    Id = Guid.Parse("50000000-0000-0000-0000-000000000002"),
                    Name = "Planet_Gas_2",
                    PlanetType = PlanetType.Gas,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetPrefab()
                {
                    Id = Guid.Parse("50000000-0000-0000-0000-000000000003"),
                    Name = "Planet_Gas_3",
                    PlanetType = PlanetType.Gas,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }

                // Ocean
                , new PlanetPrefab()
                {
                    Id = Guid.Parse("60000000-0000-0000-0000-000000000001"),
                    Name = "Planet_Ocean_1",
                    PlanetType = PlanetType.Ocean,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetPrefab()
                {
                    Id = Guid.Parse("60000000-0000-0000-0000-000000000002"),
                    Name = "Planet_Ocean_2",
                    PlanetType = PlanetType.Ocean,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetPrefab()
                {
                    Id = Guid.Parse("60000000-0000-0000-0000-000000000003"),
                    Name = "Planet_Ocean_3",
                    PlanetType = PlanetType.Ocean,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }

                // Ice
                , new PlanetPrefab()
                {
                    Id = Guid.Parse("70000000-0000-0000-0000-000000000001"),
                    Name = "Planet_Ice_1",
                    PlanetType = PlanetType.Ice,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetPrefab()
                {
                    Id = Guid.Parse("70000000-0000-0000-0000-000000000002"),
                    Name = "Planet_Ice_2",
                    PlanetType = PlanetType.Ice,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetPrefab()
                {
                    Id = Guid.Parse("70000000-0000-0000-0000-000000000003"),
                    Name = "Planet_Ice_3",
                    PlanetType = PlanetType.Ice,
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }
            );
        }
    }
}