using AstroGame.Shared.Models.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Conditions
{
    public class ConditionEntityTypeConfiguration : IEntityTypeConfiguration<Condition>
    {
        public void Configure(EntityTypeBuilder<Condition> builder)
        {
            builder.ToTable("Conditions");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.NeededTechnology)
                .WithMany(e => e.ConditionFor)
                .HasForeignKey(e => e.NeededTechnologyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Technology)
                .WithMany(e => e.NeededConditions)
                .HasForeignKey(e => e.TechnologyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}