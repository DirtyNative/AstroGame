using System.Collections.Generic;
using AstroGame.Shared.Models.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Conditions
{
    public class
        BuildingConstructionConditionEntityTypeConfiguration : IEntityTypeConfiguration<BuildingConstructionCondition>
    {
        public void Configure(EntityTypeBuilder<BuildingConstructionCondition> builder)
        {
            builder.ToTable("BuildingConstructionConditions");
            builder.HasBaseType<NeededCondition>();
            //builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.Building)
                .WithMany(e => e.BuildingConditions as IEnumerable<BuildingConstructionCondition>)
                .HasForeignKey(e => e.BuildingId);

            builder.HasOne(e => e.Condition)
                .WithMany()
                .HasForeignKey(e => e.ConditionId);
        }
    }
}