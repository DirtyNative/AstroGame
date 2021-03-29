using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Buildings
{
    public class BuildingSeed : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasData(new Building()
            {
                Id = Guid.Parse("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                Name = "Iron Mine",
                Description = "",
                Order = 1,
                AssetName = "iron_mine.jpg",
                BuildableOn = StellarObjectType.Planet,
            });
        }
    }
}