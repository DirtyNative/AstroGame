using AstroGame.Shared.Models.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Conditions
{
    public class LevelableConditionSeed : IEntityTypeConfiguration<LevelableCondition>
    {
        public void Configure(EntityTypeBuilder<LevelableCondition> builder)
        {
            builder.HasData(
                new LevelableCondition()
                {
                    Id = Guid.Parse("5CE36DF3-90D7-477A-9278-B2D9100F6B2F"),
                    NeededTechnologyId = Guid.Parse("0233326E-2B2A-4170-993E-835417E293C6"),
                    TechnologyId = Guid.Parse("A3058710-E6FE-4DB1-98D2-F7D93874FF5A"),
                    NeededLevel = 5
                }
            );
        }
    }
}