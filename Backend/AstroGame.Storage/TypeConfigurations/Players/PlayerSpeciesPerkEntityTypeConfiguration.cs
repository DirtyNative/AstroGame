using AstroGame.Shared.Models.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Players
{
    public class PlayerSpeciesPerkEntityTypeConfiguration : IEntityTypeConfiguration<PlayerSpeciesPerk>
    {
        public void Configure(EntityTypeBuilder<PlayerSpeciesPerk> builder)
        {
            builder.ToTable("PlayerSpeciesPerks");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasOne(e => e.Perk).WithMany().HasForeignKey(e => e.PerkId);
        }
    }
}