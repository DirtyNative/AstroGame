using System.Collections.Generic;

namespace AstroGame.Api.Communication.Models.Resources
{
    public class BuildingValueResponse : TechnologyValueResponse
    {
        public List<ResourceAmountResponse> Consumptions { get; set; } = new();
        public List<ResourceAmountResponse> Productions { get; set; } = new();
    }
}
