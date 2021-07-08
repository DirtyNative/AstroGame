using System;
using System.Collections.Generic;

namespace AstroGame.Api.Communication.Models.Resources
{
    public abstract class TechnologyValueResponse
    {
        public Guid TechnologyId { get; set; }
        public uint Level { get; set; }
        public List<ResourceAmountResponse> TechnologyCosts { get; set; } = new();
    }
}
