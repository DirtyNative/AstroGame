using System;
using AstroGame.Shared.Models.Prefabs;

namespace AstroGame.Shared.Models.Stellar.Interfaces
{
    public interface IHasAtmosphere
    {
        Guid? AtmospherePrefabId { get; set; }

        PlanetAtmospherePrefab AtmospherePrefab { get; set; }
    }
}