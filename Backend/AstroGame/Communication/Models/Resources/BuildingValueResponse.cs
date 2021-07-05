using System;
using System.Collections.Generic;

namespace AstroGame.Api.Communication.Models.Resources
{
    public class BuildingValueResponse
    {
        public Guid BuildingId { get; set; }
        public uint Level { get; set; }
        public List<ResourceAmountResponse> BuildingConsumptions { get; set; } = new();
        public List<ResourceAmountResponse> BuildingProductions { get; set; } = new();
        public List<ResourceAmountResponse> TechnologyCosts { get; set; } = new();
    }
}
