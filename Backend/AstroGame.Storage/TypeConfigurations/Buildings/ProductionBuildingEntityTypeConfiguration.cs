using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class ProductionBuildingEntityTypeConfiguration : IEntityTypeConfiguration<ProductionBuilding>
    {
        public void Configure(EntityTypeBuilder<ProductionBuilding> builder)
        {
            builder.ToTable("ProductionBuildings");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<Building>();

            builder.HasMany(e => e.InputResources)
                .WithOne(e => e.Building as ProductionBuilding)
                .HasForeignKey(e => e.BuildingId);

            builder.HasMany(e => e.OutputResources)
                .WithOne(e => e.Building as ProductionBuilding)
                .HasForeignKey(e => e.BuildingId);
        }
    }
}