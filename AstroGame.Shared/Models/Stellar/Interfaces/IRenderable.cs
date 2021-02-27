using System;
using AstroGame.Shared.Models.Prefabs;

namespace AstroGame.Shared.Models.Stellar.Interfaces
{
    /// <summary>
    /// Defines an object which can be rendered within Unity
    /// </summary>
    public interface IRenderable<T> where T : Prefab
    {
        Guid PrefabId { get; set; }
        T Prefab { get; set; }
    }
}