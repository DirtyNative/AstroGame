namespace AstroGame.Shared.Models.StellarSystems
{
    public class SolarSystem : MultiObjectSystem
    {
        public SolarSystem()
        {
        }

        public SolarSystem(StellarSystem parent) : base(parent)
        {
        }

        public override string Name { get; set; }
    }
}