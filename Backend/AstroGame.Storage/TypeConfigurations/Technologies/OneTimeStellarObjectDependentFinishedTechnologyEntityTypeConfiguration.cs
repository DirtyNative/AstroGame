using AstroGame.Shared.Models.Technologies.FinishedTechnologies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Technologies
{
    public class
        OneTimeStellarObjectDependentFinishedTechnologyEntityTypeConfiguration : IEntityTypeConfiguration<
            OneTimeStellarObjectDependentFinishedTechnology>
    {
        public void Configure(EntityTypeBuilder<OneTimeStellarObjectDependentFinishedTechnology> builder)
        {
            builder.ToTable("OneTimeStellarObjectDependentFinishedTechnologies");
            builder.HasBaseType<StellarObjectDependentFinishedTechnology>();
        }
    }
}