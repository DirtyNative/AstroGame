using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class CivilBuildingEntityTypeConfiguration : IEntityTypeConfiguration<CivilBuilding>
    {
        public void Configure(EntityTypeBuilder<CivilBuilding> builder)
        {
            builder.ToTable("CivilBuildings");
            builder.HasBaseType<Building>();
        }
    }
}