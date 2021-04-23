using AstroGame.Shared.Models.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Conditions
{
    public class BuildingConditionEntityTypeConfiguration : IEntityTypeConfiguration<BuildingCondition>
    {
        public void Configure(EntityTypeBuilder<BuildingCondition> builder)
        {
            builder.ToTable("BuildingConditions");
            builder.HasBaseType<Condition>();

            builder.HasOne(e => e.Building)
                .WithMany()
                .HasForeignKey(e => e.BuildingId);
        }
    }
}