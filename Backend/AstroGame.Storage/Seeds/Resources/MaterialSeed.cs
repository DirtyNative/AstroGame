using System;
using AstroGame.Shared.Models.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.Seeds.Resources
{
    public class MaterialSeed : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasData(
                // Consumables
                new Material()
                {
                    Id = Guid.Parse("00000000-0000-1111-0000-000000000001"),
                    Name = "Water",
                    Type = MaterialType.Consumables,
                    NaturalOccurrenceWeight = 1,
                },
                new Material()
                {
                    Id = Guid.Parse("00000000-0000-1111-0000-000000000002"),
                    Name = "Food",
                    Type = MaterialType.Consumables,
                    NaturalOccurrenceWeight = 1
                },
                new Material()
                {
                    Id = Guid.Parse("00000000-0000-1111-0000-000000000003"),
                    Name = "Luxury Goods",
                    Type = MaterialType.Consumables,
                    NaturalOccurrenceWeight = 1
                },

                // Components
                new Material()
                {
                    Id = Guid.Parse("00000000-1111-1111-0000-000000000001"),
                    Name = "Conductive Components",
                    Type = MaterialType.Components,
                    NaturalOccurrenceWeight = 1
                },
                new Material()
                {
                    Id = Guid.Parse("00000000-1111-1111-0000-000000000002"),
                    Name = "Conductive Components",
                    Type = MaterialType.Components,
                    NaturalOccurrenceWeight = 1
                },
                new Material()
                {
                    Id = Guid.Parse("00000000-1111-1111-0000-000000000003"),
                    Name = "Supra conductors",
                    Type = MaterialType.Components,
                    NaturalOccurrenceWeight = 1
                },

                // Fuels
                new Material()
                {
                    Id = Guid.Parse("00000000-2222-1111-0000-000000000001"),
                    Name = "Deuterium",
                    Type = MaterialType.Fuels,
                    NaturalOccurrenceWeight = 1,
                },
                new Material()
                {
                    Id = Guid.Parse("00000000-2222-1111-0000-000000000002"),
                    Name = "Tritium",
                    Type = MaterialType.Fuels,
                    NaturalOccurrenceWeight = 1,
                },

                // Building
                new Material()
                {
                    Id = Guid.Parse("00000000-3333-1111-0000-000000000002"),
                    Name = "Steel",
                    Type = MaterialType.Building,
                    NaturalOccurrenceWeight = 0,
                },
                new Material()
                {
                    Id = Guid.Parse("00000000-3333-1111-0000-000000000003"),
                    Name = "Nanites",
                    Type = MaterialType.Building,
                    NaturalOccurrenceWeight = 0,
                },

                // Alloys
                new Material()
                {
                    Id = Guid.Parse("00000000-4444-1111-0000-000000000001"),
                    Name = "Reactive alloys",
                    Type = MaterialType.Alloys,
                    NaturalOccurrenceWeight = 0,
                },
                new Material()
                {
                    Id = Guid.Parse("00000000-4444-1111-0000-000000000002"),
                    Name = "Nano alloys",
                    Type = MaterialType.Alloys,
                    NaturalOccurrenceWeight = 0,
                },

                // Don't know what or
                new Material()
                {
                    Id = Guid.Parse("00000000-5555-1111-0000-000000000001"),
                    Name = "Dark matter",
                    Type = MaterialType.Building,
                    NaturalOccurrenceWeight = 0,
                }
            );
        }
    }
}