using AstroGame.Shared.Models.Technologies;
using AstroGame.Shared.Models.Technologies.FinishedTechnologies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Technologies
{
    public class LevelableStellarObjectDependentFinishedTechnologyEntityTypeConfiguration : IEntityTypeConfiguration<LevelableStellarObjectDependentFinishedTechnology>
    {
        public void Configure(EntityTypeBuilder<LevelableStellarObjectDependentFinishedTechnology> builder)
        {
            builder.ToTable("LevelableStellarObjectDependentFinishedTechnologies");
            builder.HasBaseType<StellarObjectDependentFinishedTechnology>();
        }
    }
}
