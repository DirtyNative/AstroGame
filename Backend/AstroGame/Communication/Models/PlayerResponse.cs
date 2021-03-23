using AstroGame.Shared.Models.Players;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace AstroGame.Api.Communication.Models
{
    [AutoMap(typeof(Player))]
    public class PlayerResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public Guid? PlayerSpeciesId { get; set; }

        public List<ColonizedStellarObject> ColonizedObjects { get; set; }
        public PlayerSpecies PlayerSpecies { get; set; }
    }
}
