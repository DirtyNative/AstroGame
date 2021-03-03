using AstroGame.Shared.Enums;

namespace AstroGame.Shared.Models.Prefabs
{
    public class PlanetAtmospherePrefab : Prefab
    {
        /// <summary>
        /// Atmospheres differ by planet types
        /// </summary>
        public PlanetType[] PlanetTypes { get; set; }
    }
}
