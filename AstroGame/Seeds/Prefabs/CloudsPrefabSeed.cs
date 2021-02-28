﻿using AstroGame.Shared.Models.Prefabs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using UnityEngine;

namespace AstroGame.Api.Seeds.Prefabs
{
    public class CloudsPrefabSeed : IEntityTypeConfiguration<CloudsPrefab>
    {
        public void Configure(EntityTypeBuilder<CloudsPrefab> builder)
        {
            builder.HasData(new CloudsPrefab()
            {
                Id = Guid.Parse("00000000-1111-0000-0000-000000000001"),
                Name = "Clouds_1",
                Scale = Vector3.zero,
                Rotation = Vector3.left,
                Offset = Vector3.back
            });
        }
    }
}
