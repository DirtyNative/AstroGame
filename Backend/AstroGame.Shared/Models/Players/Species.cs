using AstroGame.Shared.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Players
{
    public class Species
    {
        public Guid Id { get; set; }
        public SpeciesType SpeciesType { get; set; }
        public string AssetName { get; set; }

        [JsonIgnore] public List<PlayerSpecies> PlayerSpecies { get; set; }
    }
}