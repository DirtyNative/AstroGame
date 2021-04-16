using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class RefineryBuildingEntityTypeConfiguration : IEntityTypeConfiguration<RefineryBuilding>
    {
        public void Configure(EntityTypeBuilder<RefineryBuilding> builder)
        {
            builder.ToTable("RefineryBuildings");
            builder.HasBaseType<Building>();

            builder.HasMany(e => e.InputResources)
                .WithOne(e => e.Building as RefineryBuilding)
                .HasForeignKey(e => e.BuildingId);

            builder.HasMany(e => e.OutputResources)
                .WithOne(e => e.Building as RefineryBuilding)
                .HasForeignKey(e => e.BuildingId);
        }
    }
}