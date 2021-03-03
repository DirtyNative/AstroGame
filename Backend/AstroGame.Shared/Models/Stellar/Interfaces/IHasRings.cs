using System;
using AstroGame.Shared.Models.Prefabs;

namespace AstroGame.Shared.Models.Stellar.Interfaces
{
    public interface IHasRings
    {
        Guid? RingPrefabId { get; set; }
        RingsPrefab RingsPrefab { get; set; }
    }
}