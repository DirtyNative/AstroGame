using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class InputResourceEntityTypeConfiguration : IEntityTypeConfiguration<InputResource>
    {
        public void Configure(EntityTypeBuilder<InputResource> builder)
        {
            builder.ToTable("InputResources");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.Resource)
                .WithMany()
                .HasForeignKey(e => e.ResourceId);
        }
    }
}