using AstroGame.Shared.Models.Technologies.FinishedTechnologies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Technologies
{
    public class FinishedTechnologyEntityTypeConfiguration : IEntityTypeConfiguration<FinishedTechnology>
    {
        public void Configure(EntityTypeBuilder<FinishedTechnology> builder)
        {
            builder.ToTable("FinishedTechnologies");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.Technology)
                .WithMany()
                .HasForeignKey(e => e.TechnologyId);
        }
    }
}