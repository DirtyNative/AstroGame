using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.StellarSystems;

namespace AstroGame.Shared.Models.StellarObjects
{
    public class Planet : StellarObject
    {
        public Planet()
        {
        }

        public Planet(SingleObjectSystem parentSystem) : base(parentSystem)
        {
        }

        public int AverageTemperature { get; set; }
        public double DistanceToCenter { get; set; }
        public bool HasAtmosphere { get; set; }
        public bool HasRings { get; set; }
        public PlanetType PlanetType { get; set; }
    }
}