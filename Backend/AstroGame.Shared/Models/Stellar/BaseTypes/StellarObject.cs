using AstroGame.Core.Structs;
using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Stellar.BaseTypes
{
    /// <summary>
    /// Anything that can be rendered
    /// </summary>
    public abstract class StellarObject : StellarThing
    {
        protected StellarObject()
        {
        }

        protected StellarObject(StellarSystem parentSystem)
        {
            ParentSystem = parentSystem;
            ParentSystemId = parentSystem.Id;
        }

        public abstract StellarObjectType StellarObjectType { get; }

        public StellarSystem ParentSystem { get; set; }
        public Guid ParentSystemId { get; set; }

        /// <summary>
        /// The average distance from this object to the center it rotates around
        /// NULL means it is the center object
        /// </summary>
        public double? AverageDistanceToCenter { get; set; }

        /// <summary>
        /// The objects relative rotating speed to earth. 1 means 24 hours for a complete rotation
        /// </summary>
        public double RotationSpeed { get; set; }

        /// <summary>
        /// The average temperature in Celsius
        /// </summary>
        public int AverageTemperature { get; set; }

        public string AssetName { get; set; }

        [JsonProperty(Order = -9)] public virtual string Name { get; set; }

        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// The resources stored on this object
        /// </summary>
        public List<ResourceSnapshot> ResourceSnapshots { get; set; }

        [JsonProperty(Order = 100)] public List<StellarObjectResource> Resources { get; set; } = new();
    }
}