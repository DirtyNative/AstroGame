using AstroGame.Shared.Models.Resources;
using System;

namespace AstroGame.Shared.Models.Technologies
{
    public abstract class TechnologyCost
    {
        public Guid Id { get; set; }
        public Guid TechnologyId { get; set; }
        public Guid ResourceId { get; set; }

        public Technology Technology { get; set; }
        public Resource Resource { get; set; }
    }
}