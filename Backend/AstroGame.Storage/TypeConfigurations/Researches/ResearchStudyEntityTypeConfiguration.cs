using AstroGame.Shared.Models.Researches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Researches
{
    public class ResearchStudyEntityTypeConfiguration : IEntityTypeConfiguration<ResearchStudy>
    {
        public void Configure(EntityTypeBuilder<ResearchStudy> builder)
        {
            builder.ToTable("ResearchStudies");

            builder.HasOne(e => e.Player)
                .WithOne()
                .HasForeignKey<ResearchStudy>(e => e.PlayerId);
        }
    }
}