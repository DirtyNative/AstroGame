using AstroGame.Shared.Models.Stellar.BaseTypes;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Stellar.StellarSystems
{
    public class Galaxy : StellarSystem
    {
        public List<StellarSystem> Systems { get; set; }
    }
}