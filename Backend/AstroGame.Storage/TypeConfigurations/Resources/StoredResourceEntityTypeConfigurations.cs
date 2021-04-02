using AstroGame.Shared.Models.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Resources
{
    public class StoredResourceEntityTypeConfigurations : IEntityTypeConfiguration<StoredResource>
    {
        public void Configure(EntityTypeBuilder<StoredResource> builder)
        {
            builder.ToTable("StoredResources");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.ResourceSnapshot)
                .WithMany(e => e.StoredResources)
                .HasForeignKey(e => e.ResourceSnapshotId);

            builder.HasOne(e => e.Resource)
                .WithMany(e => e.StoredResources)
                .HasForeignKey(e => e.ResourceId);
        }
    }
}