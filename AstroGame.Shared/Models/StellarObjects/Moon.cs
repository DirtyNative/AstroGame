using AstroGame.Shared.Models.StellarSystems;

namespace AstroGame.Shared.Models.StellarObjects
{
    public class Moon : StellarObject
    {
        public Moon()
        {
        }

        public Moon(StellarSystem parent) : base(parent)
        {
        }

        public int AverageTemperate { get; set; }
        public double DistanceToCenter { get; set; }
        public bool HasRings { get; set; }
    }
}