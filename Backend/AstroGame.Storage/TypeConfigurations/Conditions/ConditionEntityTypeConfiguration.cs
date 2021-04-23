using AstroGame.Shared.Models.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.TypeConfigurations.Conditions
{
    public class ConditionEntityTypeConfiguration : IEntityTypeConfiguration<Condition>
    {
        public void Configure(EntityTypeBuilder<Condition> builder)
        {
            builder.ToTable("Conditions");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
        }
    }
}