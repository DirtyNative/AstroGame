using AstroGame.Shared.Models.Technologies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Technologies
{
    public class
        PlayerDependentFinishedTechnologyEntityTypeConfiguration : IEntityTypeConfiguration<
            PlayerDependentFinishedTechnology>
    {
        public void Configure(EntityTypeBuilder<PlayerDependentFinishedTechnology> builder)
        {
            builder.ToTable("PlayerDependentFinishedTechnologies");
            builder.HasBaseType<FinishedTechnology>();

            builder.HasOne(e => e.Player)
                .WithMany()
                .HasForeignKey(e => e.PlayerId);
        }
    }
}