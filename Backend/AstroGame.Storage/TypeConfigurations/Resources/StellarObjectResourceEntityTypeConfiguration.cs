using AstroGame.Shared.Models.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Resources
{
    public class StellarObjectResourceEntityTypeConfiguration : IEntityTypeConfiguration<StellarObjectResource>
    {
        public void Configure(EntityTypeBuilder<StellarObjectResource> builder)
        {
            builder.ToTable("StellarObjectResources");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            /*builder.HasOne(e => e.StellarObject).WithMany(e => (e as IProvidesResources).StoredResources)
                .HasForeignKey(e => e.StellarObjectId);*/

            builder.HasOne(e => e.Resource)
                .WithMany(e => e.StellarObjectResources)
                .HasForeignKey(e => e.ResourceId);
        }
    }
}