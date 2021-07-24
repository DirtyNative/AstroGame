using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class BuildingConstructionEntityTypeConfiguration : IEntityTypeConfiguration<BuildingConstruction>
    {
        public void Configure(EntityTypeBuilder<BuildingConstruction> builder)
        {
            builder.ToTable("BuildingConstructions");

            builder.HasOne(e => e.BuildingChain)
                .WithMany(e => e.BuildingUpgrades)
                .HasForeignKey(e => e.BuildingChainId);

            builder.HasOne(e => e.StellarObject)
                .WithMany()
                .HasForeignKey(e => e.StellarObjectId);
        }
    }
}