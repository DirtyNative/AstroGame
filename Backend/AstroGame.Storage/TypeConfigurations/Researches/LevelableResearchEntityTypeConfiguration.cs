using AstroGame.Shared.Models.Researches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Researches
{
    public class LevelableResearchEntityTypeConfiguration : IEntityTypeConfiguration<LevelableResearch>
    {
        public void Configure(EntityTypeBuilder<LevelableResearch> builder)
        {
            builder.ToTable("LevelableResearches");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<Research>();
        }
    }
}
