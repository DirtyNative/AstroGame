using AstroGame.Shared.Models.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Players
{
    public class PlayerSeed : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasData(new Player()
            {
                Id = Guid.Parse("22222222-0000-0000-0000-000000000000"),
                Username = "DirtyNative",
                PlayerSpeciesId = Guid.Parse("22222222-1111-0000-0000-000000000000"),
            });
        }
    }
}