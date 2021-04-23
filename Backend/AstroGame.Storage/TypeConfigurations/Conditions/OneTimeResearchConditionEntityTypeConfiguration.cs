using AstroGame.Shared.Models.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Conditions
{
    public class OneTimeResearchConditionEntityTypeConfiguration : IEntityTypeConfiguration<OneTimeResearchCondition>
    {
        public void Configure(EntityTypeBuilder<OneTimeResearchCondition> builder)
        {
            builder.ToTable("OneTimeResearchConditions");
            builder.HasBaseType<ResearchCondition>();
        }
    }
}