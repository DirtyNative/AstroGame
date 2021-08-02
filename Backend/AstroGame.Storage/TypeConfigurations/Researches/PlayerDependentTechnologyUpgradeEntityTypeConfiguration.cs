using AstroGame.Shared.Models.Technologies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Researches
{
    public class PlayerDependentTechnologyUpgradeEntityTypeConfiguration : IEntityTypeConfiguration<PlayerDependentTechnologyUpgrade>
    {
        public void Configure(EntityTypeBuilder<PlayerDependentTechnologyUpgrade> builder)
        {
            builder.ToTable("PlayerDependentTechnologyUpgrades");

            builder.HasOne(e => e.Player)
                .WithOne()
                .HasForeignKey<PlayerDependentTechnologyUpgrade>(e => e.PlayerId);
        }
    }
}