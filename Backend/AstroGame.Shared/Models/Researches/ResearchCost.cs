using AstroGame.Shared.Models.Resources;
using System;

namespace AstroGame.Shared.Models.Researches
{
    public abstract class ResearchCost
    {
        public Guid Id { get; set; }
        public Guid ResearchId { get; set; }
        public Guid ResourceId { get; set; }

        public Research Research { get; set; }
        public Resource Resource { get; set; }
    }
}