using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class
        ResearchLaboratoryBuildingEntityTypeConfiguration : IEntityTypeConfiguration<ResearchLaboratoryBuilding>
    {
        public void Configure(EntityTypeBuilder<ResearchLaboratoryBuilding> builder)
        {
            builder.ToTable("ResearchLaboratoryBuildings");
            builder.HasBaseType<Building>();

            builder.HasMany(e => e.InputResources)
                .WithOne(e => e.Building as ResearchLaboratoryBuilding)
                .HasForeignKey(e => e.BuildingId);

            builder.HasMany(e => e.OutputResources)
                .WithOne(e => e.Building as ResearchLaboratoryBuilding)
                .HasForeignKey(e => e.BuildingId);
        }
    }
}