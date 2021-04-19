using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class LevelableBuildingEntityTypeConfiguration : IEntityTypeConfiguration<LevelableBuilding>
    {
        public void Configure(EntityTypeBuilder<LevelableBuilding> builder)
        {
            builder.ToTable("LevelableBuildings");
            builder.HasBaseType<Building>();
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            /* builder.HasMany(e => e.BuildingCosts)
                .WithOne(e => e.Building)
                .HasForeignKey(e => e.BuildingId); */

            builder.HasMany(e => e.InputResources)
                .WithOne(e => e.Building as LevelableBuilding)
                .HasForeignKey(e => e.BuildingId);

            builder.HasMany(e => e.OutputResources)
                .WithOne(e => e.Building as LevelableBuilding)
                .HasForeignKey(e => e.BuildingId);
        }
    }
}
