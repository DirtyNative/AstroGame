using AstroGame.Shared.Models.Technologies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class StellarObjectDependentTechnologyUpgradeEntityTypeConfiguration : IEntityTypeConfiguration<StellarObjectDependentTechnologyUpgrade>
    {
        public void Configure(EntityTypeBuilder<StellarObjectDependentTechnologyUpgrade> builder)
        {
            builder.ToTable("StellarObjectDependentTechnologyUpgrades");

            builder.HasOne(e => e.StellarObject)
                .WithMany()
                .HasForeignKey(e => e.StellarObjectId);
        }
    }
}