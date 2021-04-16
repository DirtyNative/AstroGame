using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class
        ManufacturingFacilityBuildingEntityTypeConfiguration : IEntityTypeConfiguration<ManufacturingFacilityBuilding>
    {
        public void Configure(EntityTypeBuilder<ManufacturingFacilityBuilding> builder)
        {
            builder.ToTable("ManufacturingFacilityBuildings");
            builder.HasBaseType<Building>();

            builder.HasMany(e => e.InputResources)
                .WithOne(e => e.Building as ManufacturingFacilityBuilding)
                .HasForeignKey(e => e.BuildingId);

            builder.HasMany(e => e.OutputResources)
                .WithOne(e => e.Building as ManufacturingFacilityBuilding)
                .HasForeignKey(e => e.BuildingId);
        }
    }
}