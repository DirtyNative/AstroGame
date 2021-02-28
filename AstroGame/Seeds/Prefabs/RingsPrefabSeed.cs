using AstroGame.Shared.Models.Prefabs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using UnityEngine;

namespace AstroGame.Api.Seeds.Prefabs
{
    public class RingsPrefabSeed : IEntityTypeConfiguration<RingsPrefab>
    {
        public void Configure(EntityTypeBuilder<RingsPrefab> builder)
        {
            builder.HasData(new RingsPrefab()
            {
                Id = Guid.Parse("00000000-4444-0000-0000-000000000001"),
                Name = "Rings_1",
                Scale = Vector3.zero,
                Rotation = Vector3.left,
                Offset = Vector3.back
            });
        }
    }
}