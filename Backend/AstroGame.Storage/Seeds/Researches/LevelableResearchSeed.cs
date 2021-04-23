using AstroGame.Shared.Models.Researches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Researches
{
    public class LevelableResearchSeed : IEntityTypeConfiguration<LevelableResearch>
    {
        public void Configure(EntityTypeBuilder<LevelableResearch> builder)
        {
            builder.HasData(
                new LevelableResearch()
                {
                    Id = Guid.Parse("4F692196-4C30-4AF0-9813-03CFE4C35E15"),
                    Name = "Quantum Theory",
                    Description = "TODO",
                    Order = 0,
                    ResearchType = ResearchType.Physics,
                    AssetName = "1.jpg",
                },

                //////////////////////////////
                // Military technologies
                //////////////////////////////
                new LevelableResearch()
                {
                    Id = Guid.Parse("73488326-4F47-418C-A5BD-7D31095FB539"),
                    Name = "Espionage Technology",
                    Description = "TODO",
                    Order = 0,
                    ResearchType = ResearchType.Engineering,
                    AssetName = "1.jpg",
                },
                new LevelableResearch()
                {
                    Id = Guid.Parse("233C1C99-CDA1-4D90-AD8B-834903B455F3"),
                    Name = "Weapon Engineering",
                    Description = "TODO",
                    Order = 0,
                    ResearchType = ResearchType.Military,
                    AssetName = "1.jpg",
                },
                new LevelableResearch()
                {
                    Id = Guid.Parse("12F1450B-5AD5-4799-98C4-8A63C0F79DA2"),
                    Name = "Shield Engineering",
                    Description = "TODO",
                    Order = 0,
                    ResearchType = ResearchType.Military,
                    AssetName = "1.jpg",
                },
                new LevelableResearch()
                {
                    Id = Guid.Parse("E193BA9C-4B8C-4E21-8C5C-E15421DE26F4"),
                    Name = "Armor Engineering",
                    Description = "TODO",
                    Order = 0,
                    ResearchType = ResearchType.Military,
                    AssetName = "1.jpg",
                },

                //////////////////////////////
                // Thruster technologies
                //////////////////////////////
                new LevelableResearch()
                {
                    Id = Guid.Parse("113DC4ED-4272-4577-8B55-92780E0751FF"),
                    Name = "Impulse Thruster",
                    Description = "TODO",
                    Order = 0,
                    ResearchType = ResearchType.Engineering,
                    AssetName = "1.jpg",
                },
                new LevelableResearch()
                {
                    Id = Guid.Parse("F19FC99C-2DB1-4877-9AC3-32974174F970"),
                    Name = "Ion Thruster",
                    Description = "TODO",
                    Order = 0,
                    ResearchType = ResearchType.Engineering,
                    AssetName = "1.jpg",
                },
                new LevelableResearch()
                {
                    Id = Guid.Parse("5966224B-F201-4A6A-8B86-D7CF36856E06"),
                    Name = "Plasma Thruster",
                    Description = "TODO",
                    Order = 0,
                    ResearchType = ResearchType.Engineering,
                    AssetName = "1.jpg",
                },
                new LevelableResearch()
                {
                    Id = Guid.Parse("9B4D8661-7811-4324-A6BF-EE30CD83C3CD"),
                    Name = "Dark Matter Thruster",
                    Description = "TODO",
                    Order = 0,
                    ResearchType = ResearchType.Engineering,
                    AssetName = "1.jpg",
                },

                //////////////////////////////
                // Social technologies
                //////////////////////////////
                new LevelableResearch()
                {
                    Id = Guid.Parse("08B9FEAC-851B-4F76-87CA-B97D1A9F1A78"),
                    Name = "Dark Matter Thruster",
                    Description = "TODO",
                    Order = 0,
                    ResearchType = ResearchType.Social,
                    AssetName = "1.jpg",
                },

                //////////////////////////////
                // Industry technologies
                //////////////////////////////
                new LevelableResearch()
                {
                    Id = Guid.Parse("8EFB2B99-2132-4510-8D24-FF80B86223DB"),
                    Name = "Efficient Workplaces",
                    Description = "TODO",
                    Order = 0,
                    ResearchType = ResearchType.Industry,
                    AssetName = "1.jpg",
                }

                //////////////////////////////
                // New worlds technologies
                //////////////////////////////
            );
        }
    }
}