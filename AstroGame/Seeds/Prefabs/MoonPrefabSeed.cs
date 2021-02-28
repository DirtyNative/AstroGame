using AstroGame.Shared.Models.Prefabs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using UnityEngine;

namespace AstroGame.Api.Seeds.Prefabs
{
    public class MoonPrefabSeed : IEntityTypeConfiguration<MoonPrefab>
    {
        public void Configure(EntityTypeBuilder<MoonPrefab> builder)
        {
            builder.HasData(new MoonPrefab()
            {
                Id = Guid.Parse("00000000-2222-0000-0000-000000000001"),
                Name = "Moon_1",
                Scale = Vector3.zero,
                Rotation = Vector3.left,
                Offset = Vector3.back
            }, new MoonPrefab()
            {
                Id = Guid.Parse("00000000-2222-0000-0000-000000000002"),
                Name = "Moon_2",
                Scale = Vector3.zero,
                Rotation = Vector3.left,
                Offset = Vector3.back
            }, new MoonPrefab()
            {
                Id = Guid.Parse("00000000-2222-0000-0000-000000000003"),
                Name = "Moon_3",
                Scale = Vector3.zero,
                Rotation = Vector3.left,
                Offset = Vector3.back
            });
        }
    }
}