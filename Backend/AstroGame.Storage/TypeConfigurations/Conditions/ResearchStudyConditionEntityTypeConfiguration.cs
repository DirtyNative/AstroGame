using AstroGame.Shared.Models.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Conditions
{
    public class ResearchStudyConditionEntityTypeConfiguration : IEntityTypeConfiguration<ResearchStudyCondition>
    {
        public void Configure(EntityTypeBuilder<ResearchStudyCondition> builder)
        {
            builder.ToTable("ResearchStudyConditions");
            builder.HasBaseType<NeededCondition>();
            //builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.Research)
                .WithMany(e => e.ResearchStudyConditions)
                .HasForeignKey(e => e.ResearchId);

            builder.HasOne(e => e.Condition)
                .WithMany()
                .HasForeignKey(e => e.ConditionId);
        }
    }
}