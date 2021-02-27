using AstroGame.Shared.Models.Prefabs;
using System;

namespace AstroGame.Shared.Models.Stellar.Interfaces
{
    public interface IHasClouds
    {
        Guid? CloudsPrefabId { get; set; }
        CloudsPrefab CloudsPrefab { get; set; }
    }
}
