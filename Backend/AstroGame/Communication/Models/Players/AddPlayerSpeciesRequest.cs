using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.Players;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AstroGame.Api.Communication.Models.Players
{
    [AutoMap(typeof(PlayerSpecies))]
    public class AddPlayerSpeciesRequest
    {
        public Guid SpeciesId { get; set; }

        public string EmpireName { get; set; }

        /// <summary>
        /// The PlanetType this species prefers. 100 % habitability
        /// </summary>
        public PlanetType PreferredPlanetType { get; set; }

        public List<AddPlayerSpeciesPerkRequest> Perks { get; set; }
    }
}