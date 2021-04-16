﻿using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class StorageBuildingEntityTypeConfiguration : IEntityTypeConfiguration<StorageBuilding>
    {
        public void Configure(EntityTypeBuilder<StorageBuilding> builder)
        {
            builder.ToTable("StorageBuildings");
            builder.HasBaseType<Building>();
        }
    }
}