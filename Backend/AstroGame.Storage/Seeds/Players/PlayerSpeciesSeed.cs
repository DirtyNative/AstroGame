using AstroGame.Shared.Models.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using AstroGame.Shared.Enums;

namespace AstroGame.Storage.Seeds.Players
{
    public class PlayerSpeciesSeed : IEntityTypeConfiguration<PlayerSpecies>
    {
        public void Configure(EntityTypeBuilder<PlayerSpecies> builder)
        {
            /*builder.HasData(new PlayerSpecies()
            {
                Id = Guid.Parse("22222222-1111-0000-0000-000000000000"),
                PlayerId = Guid.Parse("22222222-0000-0000-0000-000000000000"),
                SpeciesId = Guid.Parse("22222222-2222-0000-0000-000000000000"),
                EmpireName = "Dirty's Empire",
                PreferredPlanetType = PlanetType.Gaia,
            }); */
        }
    }
}