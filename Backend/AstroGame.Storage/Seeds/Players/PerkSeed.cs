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
                    Id = Guid.Parse("00000000-0000-1111-0000-6712d7115748"),
                    Title = "Fast builder",
                    Description = "Building big constructs is a no-brainer for your species.",
                    BuildingSpeedMultiplier = 0.9,
                },

                // Research
                new Perk()
                {
                    Id = Guid.Parse("00000000-0000-1111-0000-dadcd19d28e3"),
                    Title = "Natural Sociologists",
                    Description = "Your species loves to inspect other creatures, and so does with species from other planets.",
                    BiologicalResearchSpeedMultiplier = 0.85,
                },
                new Perk()
                {
                    Id = Guid.Parse("00000000-0000-1111-0000-cb67c0894e44"),
                    Title = "Natural Physicists",
                    Description = "Ever wanted to fly into a black hole? Well your species does!",
                    PhysicsResearchSpeedMultiplier = 0.85,
                },
                new Perk()
                {
                    Id = Guid.Parse("00000000-0000-1111-0000-551336d46b5d"),
                    Title = "Natural Engineers",
                    Description = "Absolute nerds, which love robots and automatism. Hopefully not too much",
                    EngineersResearchSpeedMultiplier = 0.85,
                },
                new Perk()
                {
                    Id = Guid.Parse("00000000-0000-1111-0000-326db14a91f9"),
                    Title = "Intelligent",
                    Description = "\"We're good at everything, but not with something specific.\" Well..",
                    BiologicalResearchSpeedMultiplier = 0.95,
                    EngineersResearchSpeedMultiplier = 0.95,
                    PhysicsResearchSpeedMultiplier = 0.95,
                }
            );
        }
    }
}