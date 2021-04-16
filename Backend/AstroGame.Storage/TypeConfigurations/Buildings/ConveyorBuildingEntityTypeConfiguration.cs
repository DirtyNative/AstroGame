using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class ConveyorBuildingEntityTypeConfiguration : IEntityTypeConfiguration<ConveyorBuilding>
    {
        public void Configure(EntityTypeBuilder<ConveyorBuilding> builder)
        {
            builder.ToTable("ConveyorBuildings");
            builder.HasBaseType<Building>();

            builder.HasMany(e => e.OutputResources)
                .WithOne(e => e.Building as ConveyorBuilding)
                .HasForeignKey(e => e.BuildingId);
        }
    }
}