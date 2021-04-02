using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using AstroGame.Shared.Enums;

namespace AstroGame.Storage.Seeds.Buildings
{
    public class StorageBuildingSeed : IEntityTypeConfiguration<StorageBuilding>
    {
        public void Configure(EntityTypeBuilder<StorageBuilding> builder)
        {
            builder.HasData(
                //////////////////////////////
                // Planet
                //////////////////////////////
                new StorageBuilding()
                {
                    Id = Guid.Parse("F09E72D5-28D8-4390-BDF5-3B589B61FC15"),
                    Name = "Iron Store",
                    Description = "TODO",
                    Order = 1,
                    AssetName = "19.jpg",
                    BuildableOn = StellarObjectType.Planet,
                }
            );
        }
    }
}