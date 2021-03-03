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

        public Vector3 Position { get; set; }

        public List<StellarSystem> CenterSystems { get; set; }

        public List<StellarSystem> Satellites { get; set; }
    }
}