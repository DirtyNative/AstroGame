using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Players
{
    public class Species
    {
        public Guid Id { get; set; }
        public string AssetName { get; set; }

        [JsonIgnore] public List<PlayerSpecies> PlayerSpecies { get; set; }
    }
}