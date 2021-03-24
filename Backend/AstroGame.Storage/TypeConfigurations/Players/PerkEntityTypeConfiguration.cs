using AstroGame.Shared.Models.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Players
{
    public class PerkEntityTypeConfiguration : IEntityTypeConfiguration<Perk>
    {
        public void Configure(EntityTypeBuilder<Perk> builder)
        {
            builder.ToTable("Perks");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.Property(e => e.BuildingSpeedMultiplier).HasDefaultValue(1);

            // Research
            builder.Property(e => e.EngineersResearchSpeedMultiplier).HasDefaultValue(1);
            builder.Property(e => e.PhysicsResearchSpeedMultiplier).HasDefaultValue(1);
            builder.Property(e => e.BiologicalResearchSpeedMultiplier).HasDefaultValue(1);

            // Resource Speeds
            builder.Property(e => e.BuildingMaterialsProductionSpeed).HasDefaultValue(1);
            builder.Property(e => e.ConsumablesProductionSpeedMultiplier).HasDefaultValue(1);
            builder.Property(e => e.ComponentsProductionSpeedMultiplier).HasDefaultValue(1);
            builder.Property(e => e.AlloysProductionSpeedMultiplier).HasDefaultValue(1);
            builder.Property(e => e.FuelsProductionSpeedMultiplier).HasDefaultValue(1);

            // Resource Counts
            builder.Property(e => e.BuildingMaterialsProductionValueMultiplier).HasDefaultValue(1);
            builder.Property(e => e.ConsumablesProductionValueMultiplier).HasDefaultValue(1);
            builder.Property(e => e.ComponentsProductionValueMultiplier).HasDefaultValue(1);
            builder.Property(e => e.AlloysProductionValueMultiplier).HasDefaultValue(1);
            builder.Property(e => e.FuelsProductionValueMultiplier).HasDefaultValue(1);
        }
    }
}