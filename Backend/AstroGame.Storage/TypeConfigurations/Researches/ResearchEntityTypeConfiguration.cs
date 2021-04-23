using AstroGame.Shared.Models.Researches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Researches
{
    public class ResearchEntityTypeConfiguration : IEntityTypeConfiguration<Research>
    {
        public void Configure(EntityTypeBuilder<Research> builder)
        {
            builder.ToTable("Researches");
        }
    }
}