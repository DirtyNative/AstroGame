using AstroGame.Shared.Models.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Players
{
    public class PerkSeed : IEntityTypeConfiguration<Perk>
    {
        public void Configure(EntityTypeBuilder<Perk> builder)
        {
            builder.HasData(new Perk()
            {
                Id = Guid.Parse("00000000-0000-1111-0000-000000000000"),
                Title = "Fast builder",
                Description = "",
            });
        }
    }
}