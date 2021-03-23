using AstroGame.Shared.Models.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Resources
{
    public class InputResourceEntityTypeConfiguration : IEntityTypeConfiguration<InputResource>
    {
        public void Configure(EntityTypeBuilder<InputResource> builder)
        {
            builder.ToTable("InputResources");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.Input)
                .WithMany()
                .HasForeignKey(e => e.ResourceId);

            builder.HasOne(e => e.Output)
                .WithMany(e => e.InputResources)
                .HasForeignKey(e => e.OutputMaterialId);
        }
    }
}