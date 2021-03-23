using AstroGame.Shared.Models.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Players
{
    public class SpeciesEntityTypeConfiguration : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.ToTable("Species");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            /*builder.HasMany(e => e.PlayerSpecies)
                .WithOne(e => e.Species).HasForeignKey(e => e.SpeciesId);
            */
        }
    }
}
