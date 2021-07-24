using AstroGame.Shared.Models.Technologies;
using AstroGame.Shared.Models.Technologies.FinishedTechnologies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Technologies
{
    public class
        OneTimePlayerDependentFinishedTechnologyEntityTypeConfiguration : IEntityTypeConfiguration<
            OneTimePlayerDependentFinishedTechnology>
    {
        public void Configure(EntityTypeBuilder<OneTimePlayerDependentFinishedTechnology> builder)
        {
            builder.ToTable("OneTimePlayerDependentFinishedTechnologies");
            builder.HasBaseType<PlayerDependentFinishedTechnology>();
        }
    }
}