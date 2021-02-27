using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Prefabs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using UnityEngine;

namespace AstroGame.Api.Seeds.Prefabs
{
    public class PlanetAtmospherePrefabSeed : IEntityTypeConfiguration<PlanetAtmospherePrefab>
    {
        public void Configure(EntityTypeBuilder<PlanetAtmospherePrefab> builder)
        {
            builder.HasData(new PlanetAtmospherePrefab()
                {
                    Id = Guid.NewGuid(),
                    Name = "PlanetAtmosphere_1",
                    PlanetTypes = new[] {PlanetType.Volcano, PlanetType.Desert},
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                },
                new PlanetAtmospherePrefab()
                {
                    Id = Guid.NewGuid(),
                    Name = "PlanetAtmosphere_2",
                    PlanetTypes = new[] {PlanetType.Volcano, PlanetType.Desert},
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetAtmospherePrefab()
                {
                    Id = Guid.NewGuid(),
                    Name = "PlanetAtmosphere_3",
                    PlanetTypes = new[] {PlanetType.Continental, PlanetType.Rock},
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetAtmospherePrefab()
                {
                    Id = Guid.NewGuid(),
                    Name = "PlanetAtmosphere_4",
                    PlanetTypes = new[] {PlanetType.Gaia, PlanetType.Gas},
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                }, new PlanetAtmospherePrefab()
                {
                    Id = Guid.NewGuid(),
                    Name = "PlanetAtmosphere_5",
                    PlanetTypes = new[] {PlanetType.Ocean, PlanetType.Ice},
                    Scale = Vector3.zero,
                    Rotation = Vector3.zero,
                    Offset = Vector3.zero
                });
        }
    }
}