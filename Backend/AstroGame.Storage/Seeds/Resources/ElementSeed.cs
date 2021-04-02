using System;
using AstroGame.Shared.Models.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.Seeds.Resources
{
    public class ElementSeed : IEntityTypeConfiguration<Element>
    {
        public void Configure(EntityTypeBuilder<Element> builder)
        {
            builder.HasData(
                // Basic Elements
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000001"),
                    Name = "Hydrogen",
                    Symbol = "H",
                    Type = ElementType.Gases,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000002"),
                    Name = "Helium",
                    Symbol = "He",
                    Type = ElementType.Gases,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000003"),
                    Name = "Lithium",
                    Symbol = "Li",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000004"),
                    Name = "Beryllium",
                    Symbol = "Be",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000005"),
                    Name = "Boron",
                    Symbol = "B",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000006"),
                    Name = "Carbon",
                    Symbol = "C",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000007"),
                    Name = "Nitrogen",
                    Symbol = "N",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000008"),
                    Name = "Oxygen",
                    Symbol = "O",
                    Type = ElementType.Gases,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000009"),
                    Name = "Magnesium",
                    Symbol = "Mg",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000010"),
                    Name = "Aluminum",
                    Symbol = "Al",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000011"),
                    Name = "Silicon",
                    Symbol = "Si",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000012"),
                    Name = "Phosphorus",
                    Symbol = "P",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000013"),
                    Name = "Sulfur",
                    Symbol = "S",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000014"),
                    Name = "Chlorine",
                    Symbol = "Cl",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000015"),
                    Name = "Titanium",
                    Symbol = "Ti",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    Name = "Iron",
                    Symbol = "Fe",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000017"),
                    Name = "Cobalt",
                    Symbol = "Co",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000018"),
                    Name = "Nickel",
                    Symbol = "Ni",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000019"),
                    Name = "Copper",
                    Symbol = "Cu",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000020"),
                    Name = "Zinc",
                    Symbol = "Zn",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000021"),
                    Name = "Gallium",
                    Symbol = "Ga",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000022"),
                    Name = "Germanium",
                    Symbol = "Ge",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000023"),
                    Name = "Palladium",
                    Symbol = "Pd",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000024"),
                    Name = "Silver",
                    Symbol = "Ag",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000025"),
                    Name = "Tin",
                    Symbol = "Sn",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000026"),
                    Name = "Iridium",
                    Symbol = "Ir",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000027"),
                    Name = "Platinum",
                    Symbol = "Pt",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000028"),
                    Name = "Gold",
                    Symbol = "Au",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                },
                new Element()
                {
                    Id = Guid.Parse("00000000-1111-0000-0000-000000000029"),
                    Name = "Plutonium",
                    Symbol = "Pu",
                    Type = ElementType.Metals,
                    NaturalOccurrenceWeight = 1
                }

                
            );
        }
    }
}