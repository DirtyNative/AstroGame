using AstroGame.Shared.Models.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Players
{
    public class SpeciesSeed : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.HasData(new Species()
            {
                Id = Guid.Parse("22222222-2222-0000-0000-000000000000"),
                AssetName = "image_1"
            });
        }
    }
}
