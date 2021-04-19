using AstroGame.Shared.Models.Resources;
using System;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Ships
{
    public class Ship
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public uint StructuralIntegrity { get; set; }
        public uint ShieldPower { get; set; }
        public uint WeaponPower { get; set; }

        public uint CargoCapacity { get; set; }

        /// <summary>
        /// The ships speed within a solar system
        /// </summary>
        public uint StellarSpeed { get; set; }

        /// <summary>
        /// The ships speed in interstellar space
        /// </summary>
        public uint InterstellarSpeed { get; set; }
        public Guid FuelId { get; set; }
        public uint FuelConsumption { get; set; }
        
        public List<ShipConstructionCost> ConstructionCosts { get; set; }
        public virtual Resource Fuel { get; set; }
    }
}
