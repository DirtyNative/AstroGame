using AstroGame.Shared.Models.Stellar.BaseTypes;

namespace AstroGame.Shared.Models.Stellar.StellarSystems
{
    public class SolarSystem : MultiObjectSystem
    {
        public SolarSystem()
        {
        }

        public SolarSystem(StellarSystem parent) : base(parent)
        {
        }

        public new string Name { get; set; }
    }
}