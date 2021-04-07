using AstroGame.Shared.Models.Buildings;
using System;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Players
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string ConfirmationToken { get; set; }

        public Guid? PlayerSpeciesId { get; set; }

        /// <summary>
        /// Every Player has a BuildingChain which stores the amount
        /// how many buildings this player can build simultaneously
        /// </summary>
        public Guid BuildingChainId { get; set; }

        //TODO: public Guid AllianceId { get; set; }

        public Credentials Credentials { get; set; }
        public List<ColonizedStellarObject> ColonizedObjects { get; set; }
        public PlayerSpecies PlayerSpecies { get; set; }
        public virtual BuildingChain BuildingChain { get; set; }
    }
}