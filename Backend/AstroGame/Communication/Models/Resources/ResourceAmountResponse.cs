using AstroGame.Shared.Models.Resources;
using System;

namespace AstroGame.Api.Communication.Models.Resources
{
    public class ResourceAmountResponse
    {
        public double Amount { get; set; }

        public Guid ResourceId { get; set; }

        //public Resource Resource { get; set; }
    }
}
