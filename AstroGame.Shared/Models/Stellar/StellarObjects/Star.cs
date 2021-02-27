using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Prefabs;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.Interfaces;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System;

namespace AstroGame.Shared.Models.Stellar.StellarObjects
{
    public class Star : StellarObject, IProvidesResources, IRenderable<StarPrefab>, ISphereObject
    {
        public Star()
        {
        }

        public Star(SingleObjectSystem parentSystem) : base(parentSystem)
        {
        }

        public StarType StarType { get; set; }
        public Guid PrefabId { get; set; }
        public StarPrefab Prefab { get; set; }
        public double Scale { get; set; }
        public double AxialTilt { get; set; }
    }
}