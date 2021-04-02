using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class StorageBuildingEntityTypeConfiguration : IEntityTypeConfiguration<StorageBuilding>
    {
        public void Configure(EntityTypeBuilder<StorageBuilding> builder)
        {
            builder.ToTable("StorageBuildings");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<Building>();

            builder.HasMany(e => e.BuildingCosts)
                .WithOne(e => e.Building as StorageBuilding)
                .HasForeignKey(e => e.BuildingId);
        }
    }
}