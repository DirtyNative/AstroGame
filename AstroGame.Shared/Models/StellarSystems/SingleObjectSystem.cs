using AstroGame.Shared.Models.StellarObjects;

namespace AstroGame.Shared.Models.StellarSystems
{
    public class SingleObjectSystem : StellarSystem
    {
        public SingleObjectSystem()
        {
        }

        public SingleObjectSystem(StellarSystem parent) : base(parent)
        {
        }

        public StellarObject CenterObject { get; set; }
    }
}