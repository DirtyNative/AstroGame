using AstroGame.Shared.Models.Technologies.FinishedTechnologies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Technologies
{
    public class
        StellarObjectDependentFinishedTechnologyEntityTypeConfiguration : IEntityTypeConfiguration<
            StellarObjectDependentFinishedTechnology>
    {
        public void Configure(EntityTypeBuilder<StellarObjectDependentFinishedTechnology> builder)
        {
            builder.ToTable("StellarObjectDependentFinishedTechnologies");
            builder.HasBaseType<FinishedTechnology>();

            builder.HasOne(e => e.ColonizedStellarObject)
                .WithMany(e => e.FinishedTechnologies)
                .HasForeignKey(e => e.ColonizedStellarObjectId);
        }
    }
}