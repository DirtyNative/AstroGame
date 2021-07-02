using System;
using System.Collections.Generic;

namespace AstroGame.Api.Communication.Models.Resources
{
    public class ResearchValueResponse
    {
        public Guid ResearchId { get; set; }
        public uint Level { get; set; }
        public List<ResourceAmountResponse> ResearchCosts { get; set; } = new();
    }
}
