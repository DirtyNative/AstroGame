using AstroGame.Shared.Models.Technologies.FinishedTechnologies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Technologies
{
    public class LevelablePlayerDependentFinishedTechnologyEntityTypeConfiguration : IEntityTypeConfiguration<LevelablePlayerDependentFinishedTechnology>
    {
        public void Configure(EntityTypeBuilder<LevelablePlayerDependentFinishedTechnology> builder)
        {
            builder.ToTable("LevelablePlayerDependentFinishedTechnologies");
            builder.HasBaseType<PlayerDependentFinishedTechnology>();
        }
    }
}
