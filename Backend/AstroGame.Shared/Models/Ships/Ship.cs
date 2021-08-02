using AstroGame.Shared.Models.Resources;
using System;
using System.Collections.Generic;
using AstroGame.Shared.Models.Technologies;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Ships
{
    public class Ship : Technology, IProducibleTechnology
    {
       
        public ShipType ShipType { get; set; }

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
        [JsonIgnore] public virtual Resource Fuel { get; set; }
    }
}