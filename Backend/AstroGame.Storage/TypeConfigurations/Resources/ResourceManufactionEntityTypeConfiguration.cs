using AstroGame.Shared.Models.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Resources
{
    public class ResourceManufactionEntityTypeConfiguration : IEntityTypeConfiguration<ResourceManufaction>
    {
        public void Configure(EntityTypeBuilder<ResourceManufaction> builder)
        {
            builder.ToTable("ResourceManufactions");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.OutputMaterial)
                .WithOne(e => e.Manufaction).HasForeignKey<ResourceManufaction>(e => e.OutputMaterialId);

            builder.HasMany(e => e.InputResources).WithOne(e => e.Output);
        }
    }
}