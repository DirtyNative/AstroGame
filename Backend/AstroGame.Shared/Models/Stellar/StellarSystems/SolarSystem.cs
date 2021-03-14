using AstroGame.Core.Structs;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using Newtonsoft.Json;
using System;

namespace AstroGame.Shared.Models.Stellar.StellarSystems
{
    public class SolarSystem : StellarSystem
    {
        public SolarSystem()
        {
        }

        public SolarSystem(StellarSystem parent)
        {
            Parent = parent;
        }

        [JsonProperty(Order = -6)] public Guid ParentId { get; set; }

        [JsonIgnore] public StellarSystem Parent { get; set; }

        [JsonProperty(Order = -9)] public string Name { get; set; }

        /// <summary>
        /// The position in 3D space
        /// </summary>
        public Vector3 Position { get; set; }

        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// <para>Indicates if this system is generated</para>
        /// <para>Because the galaxy is not generated recursively, the solar systems need to be generated on demand</para>
        /// </summary>
        public bool IsGenerated { get; set; }
    }
}