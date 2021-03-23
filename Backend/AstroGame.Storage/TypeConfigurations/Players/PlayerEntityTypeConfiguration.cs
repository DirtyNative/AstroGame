using AstroGame.Shared.Models.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Players
{
    public class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Players");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.PlayerSpecies)
                .WithOne(e => e.Player)
                .HasForeignKey<PlayerSpecies>(e => e.PlayerId);

            builder.HasOne(e => e.Credentials)
                .WithOne()
                .HasForeignKey<Credentials>(e => e.PlayerId);
        }
    }
}