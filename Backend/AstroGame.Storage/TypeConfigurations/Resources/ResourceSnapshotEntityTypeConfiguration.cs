using AstroGame.Shared.Models.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Resources
{
    public class ResourceSnapshotEntityTypeConfiguration : IEntityTypeConfiguration<ResourceSnapshot>
    {
        public void Configure(EntityTypeBuilder<ResourceSnapshot> builder)
        {
            builder.ToTable("ResourceSnapshots");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasMany(e => e.StoredResources)
                .WithOne(e => e.ResourceSnapshot)
                .HasForeignKey(e => e.ResourceSnapshotId);

            builder.HasOne(e => e.StellarObject)
                .WithMany(e => e.ResourceSnapshots)
                .HasForeignKey(e => e.StellarObjectId);
        }
    }
}