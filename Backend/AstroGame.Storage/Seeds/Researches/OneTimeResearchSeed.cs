using AstroGame.Shared.Models.Researches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Researches
{
    public class OneTimeResearchSeed : IEntityTypeConfiguration<OneTimeResearch>
    {
        public void Configure(EntityTypeBuilder<OneTimeResearch> builder)
        {
            builder.HasData(
                //////////////////////////////
                // New worlds technologies
                //////////////////////////////
                new OneTimeResearch()
                {
                    Id = Guid.Parse("4139A914-6958-482A-9FAB-6291426E075F"),
                    Name = "Planet colonization",
                    Description = "TODO",
                    Order = 0,
                    ResearchType = ResearchType.NewWorlds,
                    AssetName = "1.jpg",
                },
                new OneTimeResearch()
                {
                    Id = Guid.Parse("FCC5C51A-5705-4517-9890-F5FA8D8BDE25"),
                    Name = "Moon colonization",
                    Description = "TODO",
                    Order = 0,
                    ResearchType = ResearchType.NewWorlds,
                    AssetName = "1.jpg",
                }
            );
        }
    }
}