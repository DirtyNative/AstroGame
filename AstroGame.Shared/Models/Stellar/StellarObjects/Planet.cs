using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Prefabs;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.Interfaces;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System;

namespace AstroGame.Shared.Models.Stellar.StellarObjects
{
    public class Planet : StellarObject, IHasAtmosphere, IHasRings, IHasClouds, IProvidesResources,
        IRenderable<PlanetPrefab>,
        ISphereObject
    {
        public Planet()
        {
        }

        public Planet(SingleObjectSystem parentSystem) : base(parentSystem)
        {
        }

        public PlanetType PlanetType { get; set; }
        public Guid PrefabId { get; set; }
        public PlanetPrefab Prefab { get; set; }
        public double Scale { get; set; }
        public double AxialTilt { get; set; }
        public Guid? AtmospherePrefabId { get; set; }
        public PlanetAtmospherePrefab AtmospherePrefab { get; set; }
        public Guid? RingPrefabId { get; set; }
        public RingsPrefab RingsPrefab { get; set; }
        public Guid? CloudsPrefabId { get; set; }
        public CloudsPrefab CloudsPrefab { get; set; }
    }
}