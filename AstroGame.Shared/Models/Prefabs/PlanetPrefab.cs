using AstroGame.Shared.Enums;
using UnityEngine;

namespace AstroGame.Shared.Models.Prefabs
{
    public class PlanetPrefab : Prefab
    {
        /// <summary>
        /// Filters the prefab with the planet type
        /// </summary>
        public PlanetType PlanetType { get; set; }
    }
}