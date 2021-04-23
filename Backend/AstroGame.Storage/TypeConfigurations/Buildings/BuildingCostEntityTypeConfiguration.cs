using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class BuildingCostEntityTypeConfiguration : IEntityTypeConfiguration<BuildingCost>
    {
        public void Configure(EntityTypeBuilder<BuildingCost> builder)
        {
            builder.ToTable("BuildingCosts");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
        }
    }
}
