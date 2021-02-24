using System.Collections.Generic;

namespace AstroGame.Shared.Models.StellarSystems
{
    public class MultiObjectSystem : StellarSystem
    {
        public MultiObjectSystem()
        {
        }

        public MultiObjectSystem(StellarSystem parent) : base(parent)
        {
        }

        public List<StellarSystem> CenterSystems { get; set; } = new List<StellarSystem>();
    }
}