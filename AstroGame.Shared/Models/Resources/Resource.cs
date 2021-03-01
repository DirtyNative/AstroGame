using System;

namespace AstroGame.Shared.Models.Resources
{
    public abstract class Resource
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double NaturalOccurrenceWeight { get; set; }
    }
}