using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class BuildingChainEntityTypeConfiguration : IEntityTypeConfiguration<BuildingChain>
    {
        public void Configure(EntityTypeBuilder<BuildingChain> builder)
        {
            builder.ToTable("BuildingChains");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.Player)
                .WithOne(e => e.BuildingChain)
                .HasForeignKey<BuildingChain>(e => e.PlayerId);

            builder.HasMany(e => e.BuildingUpgrades)
                .WithOne(e => e.BuildingChain)
                .HasForeignKey(e => e.BuildingChainId);
        }
    }
}