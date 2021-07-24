using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Technologies;
using System;

namespace AstroGame.Shared.Models.Buildings
{
    public class BuildingConstruction : TechnologyUpgrade
    {
        public Guid BuildingChainId { get; set; }
        public Guid StellarObjectId { get; set; }

        public virtual BuildingChain BuildingChain { get; set; }
        public virtual StellarObject StellarObject { get; set; }
    }
}