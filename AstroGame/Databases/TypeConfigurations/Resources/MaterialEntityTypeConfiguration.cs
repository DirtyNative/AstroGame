using AstroGame.Shared.Models.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Api.Databases.TypeConfigurations.Resources
{
    public class MaterialEntityTypeConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("Materials");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<Resource>();

            builder.HasOne(e => e.Manufaction)
                .WithOne(e => e.OutputMaterial).HasForeignKey<Material>(e => e.ManufactionId);
        }
    }
}