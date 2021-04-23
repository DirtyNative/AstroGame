using AstroGame.Shared.Models.Researches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Researches
{
    public class OneTimeResearchEntityTypeConfiguration : IEntityTypeConfiguration<OneTimeResearch>
    {
        public void Configure(EntityTypeBuilder<OneTimeResearch> builder)
        {
            builder.ToTable("OneTimeResearches");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<Research>();
        }
    }
}