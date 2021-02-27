using System;
using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Prefabs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnityEngine;

namespace AstroGame.Api.Seeds.Prefabs
{
    public class StarPrefabSeed : IEntityTypeConfiguration<StarPrefab>
    {
        public void Configure(EntityTypeBuilder<StarPrefab> builder)
        {
            builder.HasData(new StarPrefab()
            {
                Id = Guid.NewGuid(),
                Name = "Test_Prefab",
                StarType = StarType.BrownDwarf,
                Scale = Vector3.zero,
                Rotation = Vector3.left,
                Offset = Vector3.back
            });
        }
    }
}