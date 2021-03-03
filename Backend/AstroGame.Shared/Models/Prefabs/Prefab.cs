using System;
using UnityEngine;

namespace AstroGame.Shared.Models.Prefabs
{
    public abstract class Prefab
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Vector3 Offset { get; set; }

        public Vector3 Rotation { get; set; }

        public Vector3 Scale { get; set; }
    }
}