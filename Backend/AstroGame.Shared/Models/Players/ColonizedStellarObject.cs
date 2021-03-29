using System;
using System.Collections.Generic;
using AstroGame.Shared.Models.Buildings;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Players
{
    public class ColonizedStellarObject
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public DateTime ColonizedOn { get; set; }
        public Guid StellarObjectId { get; set; }

        // Actual Resources

        // Built Buildings

        [JsonIgnore] public Player Player { get; set; }
        public ColonizableStellarObject ColonizableStellarObject { get; set; }

        public List<BuiltBuilding> BuiltBuildings { get; set; }
    }
}