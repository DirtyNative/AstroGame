using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class OutputResourceEntityTypeConfiguration : IEntityTypeConfiguration<OutputResource>
    {
        public void Configure(EntityTypeBuilder<OutputResource> builder)
        {
            builder.ToTable("OutputResources");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            
            builder.HasOne(e => e.Resource)
                .WithMany()
                .HasForeignKey(e => e.ResourceId);
        }
    }
}