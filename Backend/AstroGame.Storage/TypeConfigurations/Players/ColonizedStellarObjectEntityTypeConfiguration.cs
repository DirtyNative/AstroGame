using AstroGame.Shared.Models.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Players
{
    public class ColonizedStellarObjectEntityTypeConfiguration : IEntityTypeConfiguration<ColonizedStellarObject>
    {
        public void Configure(EntityTypeBuilder<ColonizedStellarObject> builder)
        {
            builder.ToTable("ColonizedStellarObjects");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasOne(e => e.Player)
                .WithMany(e => e.ColonizedObjects).HasForeignKey(e => e.PlayerId);
            builder.HasOne(e => e.ColonizableStellarObject)
                .WithOne(e => e.ColonizedStellarObject)
                .HasForeignKey<ColonizedStellarObject>(e => e.StellarObjectId);
        }
    }
}