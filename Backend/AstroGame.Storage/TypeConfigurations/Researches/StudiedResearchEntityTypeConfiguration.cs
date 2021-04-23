using AstroGame.Shared.Models.Researches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Researches
{
    public class StudiedResearchEntityTypeConfiguration : IEntityTypeConfiguration<StudiedResearch>
    {
        public void Configure(EntityTypeBuilder<StudiedResearch> builder)
        {
            builder.ToTable("StudiedResearches");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.Research)
                .WithMany()
                .HasForeignKey(e => e.ResearchId);

            builder.HasOne(e => e.Player)
                .WithMany()
                .HasForeignKey(e => e.PlayerId);
        }
    }
}