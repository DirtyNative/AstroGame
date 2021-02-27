using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.Interfaces;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System;
using AstroGame.Shared.Models.Prefabs;

namespace AstroGame.Shared.Models.Stellar.StellarObjects
{
    public class Moon : StellarObject, IHasRings, IProvidesResources, IRenderable<MoonPrefab>, ISphereObject
    {
        public Moon()
        {
        }

        public Moon(SingleObjectSystem parentSystem) : base(parentSystem)
        {
        }

        public double Scale { get; set; }
        public double AxialTilt { get; set; }
        public Guid PrefabId { get; set; }
        public MoonPrefab Prefab { get; set; }
        public Guid? RingPrefabId { get; set; }
        public RingsPrefab RingsPrefab { get; set; }
    }
}