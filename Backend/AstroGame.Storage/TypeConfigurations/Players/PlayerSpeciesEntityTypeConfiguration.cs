using AstroGame.Shared.Models.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Players
{
    public class PlayerSpeciesEntityTypeConfiguration : IEntityTypeConfiguration<PlayerSpecies>
    {
        public void Configure(EntityTypeBuilder<PlayerSpecies> builder)
        {
            builder.ToTable("PlayerSpecies");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.Player)
                .WithOne(e => e.PlayerSpecies).HasForeignKey<Player>(e => e.PlayerSpeciesId);

            builder.HasOne(e => e.Species)
                .WithMany(e => e.PlayerSpecies).HasForeignKey(e => e.SpeciesId);

            builder.HasMany(e => e.Perks)
                .WithOne(e => e.PlayerSpecies).HasForeignKey(e => e.PlayerSpeciesId);
        }
    }
}