using AstroGame.Shared.Models.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Players
{
    public class PlayerSpeciesPerkSeed : IEntityTypeConfiguration<PlayerSpeciesPerk>
    {
        public void Configure(EntityTypeBuilder<PlayerSpeciesPerk> builder)
        {
            builder.HasData(new PlayerSpeciesPerk()
            {
                Id = Guid.Parse("11110000-0000-0000-0000-000000000000"),
                PlayerSpeciesId = Guid.Parse("22222222-1111-0000-0000-000000000000"),
                PerkId = Guid.Parse("00000000-0000-1111-0000-000000000000"),
            });
        }
    }
}