using System;
using AstroGame.Shared.Enums;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Players
{
    public class PlayerSpecies
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public Guid SpeciesId { get; set; }

        public string EmpireName { get; set; }

        /// <summary>
        /// The PlanetType this species prefers. 100 % habitability
        /// </summary>
        public PlanetType PreferredPlanetType { get; set; }

        // TODO: Set the properties for the species
        // E.g: Intelligent, Hard working, militaristic

        [JsonIgnore] public Player Player { get; set; }
        public Species Species { get; set; }
    }
}