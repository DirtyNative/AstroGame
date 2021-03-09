using AstroGame.Shared.Models.Stellar.BaseTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

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

        /// <summary>
        /// The systems number
        /// </summary>
        public uint SystemNumber { get; set; }

        /// <summary>
        /// The position in 3D space
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// <para>Indicates if this system is generated</para>
        /// <para>Because the galaxy is not generated recursively, the solar systems need to be generated on demand</para>
        /// </summary>
        public bool IsGenerated { get; set; }

        public List<StellarSystem> CenterSystems { get; set; }

        public List<StellarSystem> Satellites { get; set; }
    }
}