using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using AstroGame.Shared.Models.Resources.Elements;

namespace AstroGame.Api.Seeds
{
    /*
    public class ElementSeed : IEntityTypeConfiguration<Element>
    {
        public void Configure(EntityTypeBuilder<Element> builder)
        {
            builder.HasData(
                new Element()
                {
                    Name = "Hydrogen",
                    Symbol = "H",
                    Type = ElementType.Gases,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Helium",
                    Symbol = "He",
                    Type = ElementType.Gases,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Lithium",
                    Symbol = "Li",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Beryllium",
                    Symbol = "Be",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Boron",
                    Symbol = "B",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Carbon",
                    Symbol = "C",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Nitrogen",
                    Symbol = "N",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Oxygen",
                    Symbol = "O",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Fluorine",
                    Symbol = "F",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Neon",
                    Symbol = "Ne",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Sodium",
                    Symbol = "Na",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Magnesium",
                    Symbol = "Mg",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Aluminium",
                    Symbol = "Al",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Silicon",
                    Symbol = "Si",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Phosphorus",
                    Symbol = "P",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Sulfur",
                    Symbol = "S",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Chlorine",
                    Symbol = "Cl",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Argon",
                    Symbol = "Ar",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Potassium",
                    Symbol = "K",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Calcium",
                    Symbol = "Ca",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Scandium",
                    Symbol = "Sc",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Titanium",
                    Symbol = "Ti",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Vanadium",
                    Symbol = "V",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Chromium",
                    Symbol = "Cr",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Manganese",
                    Symbol = "Mn",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Iron",
                    Symbol = "Fe",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Cobalt",
                    Symbol = "Co",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Nickel",
                    Symbol = "Ni",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Copper",
                    Symbol = "Cu",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Zinc",
                    Symbol = "Zn",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Gallium",
                    Symbol = "Ga",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Germanium",
                    Symbol = "Ge",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Arsenic",
                    Symbol = "As",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Selenium",
                    Symbol = "Se",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Bromine",
                    Symbol = "Br",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Krypton",
                    Symbol = "Kr",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Rubidium",
                    Symbol = "Rb",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Strontium",
                    Symbol = "Sr",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Yttrium",
                    Symbol = "Y",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Zirconium",
                    Symbol = "Zr",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Niobium",
                    Symbol = "Nb",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                },
                new Element()
                {
                    Name = "Molybdenum",
                    Symbol = "Mo",
                    Type = ElementType.Metals,
                    IsRadioactive = false
                }
            );
        }
    } */
}