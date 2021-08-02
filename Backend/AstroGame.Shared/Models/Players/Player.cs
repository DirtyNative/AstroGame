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
        
        //TODO: public Guid AllianceId { get; set; }

        public Credentials Credentials { get; set; }
        public List<ColonizedStellarObject> ColonizedObjects { get; set; }
        public PlayerSpecies PlayerSpecies { get; set; }
    }
}