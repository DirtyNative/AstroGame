using AstroGame.Shared.Models.Players;
using System;

namespace AstroGame.Shared.Models.Buildings
{
    public class BuiltBuilding
    {
        public Guid Id { get; set; }
        public Guid BuildingId { get; set; }
        public Guid ColonizedStellarObjectId { get; set; }

        public uint Level { get; set; }

        public virtual Building Building { get; set; }
        public virtual ColonizedStellarObject ColonizedStellarObject { get; set; }
    }
}