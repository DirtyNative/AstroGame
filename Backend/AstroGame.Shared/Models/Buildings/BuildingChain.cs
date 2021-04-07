using AstroGame.Shared.Models.Players;
using System;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Buildings
{
    public class BuildingChain
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }

        /// <summary>
        /// Indicates how many buildings a player can build simultaneously
        /// </summary>
        public int ChainLength { get; set; }

        public virtual List<BuildingConstruction> BuildingUpgrades { get; set; } = new();
        public virtual Player Player { get; set; }
    }
}