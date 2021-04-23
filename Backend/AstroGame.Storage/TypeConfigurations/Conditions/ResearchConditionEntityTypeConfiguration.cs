using AstroGame.Shared.Models.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Conditions
{
    public class ResearchConditionEntityTypeConfiguration : IEntityTypeConfiguration<ResearchCondition>
    {
        public void Configure(EntityTypeBuilder<ResearchCondition> builder)
        {
            builder.ToTable("ResearchConditions");
            builder.HasBaseType<Condition>();

            builder.HasOne(e => e.Research)
                .WithMany()
                .HasForeignKey(e => e.ResearchId);
        }
    }
}