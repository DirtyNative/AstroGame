using UnityEngine;

namespace AstroGame.Shared.Models.Prefabs
{
    public class MoonPrefab : Prefab
    {
        public virtual Vector3 Offset { get; set; }

        public virtual Vector3 Rotation { get; set; }

        public virtual Vector3 Scale { get; set; }
    }
}