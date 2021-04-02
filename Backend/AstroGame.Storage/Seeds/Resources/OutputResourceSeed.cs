using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Resources
{
    public class OutputResourceSeed : IEntityTypeConfiguration<OutputResource>
    {
        public void Configure(EntityTypeBuilder<OutputResource> builder)
        {
            builder.HasData(new OutputResource()
            {
                Id = Guid.Parse("24A0EFE4-27D2-43C6-BB7B-61B36C129B00"),
                BuildingId = Guid.Parse("5B2AA6BC-9754-42EB-B519-39EDD989F9BB"),
                ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                BaseValue = 60,
                Multiplier = 1.5,
            });
        }
    }
}