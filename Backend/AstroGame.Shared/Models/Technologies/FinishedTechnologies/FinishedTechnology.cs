using System;

namespace AstroGame.Shared.Models.Technologies.FinishedTechnologies
{
    public abstract class FinishedTechnology
    {
        public Guid Id { get; set; }
        public Guid TechnologyId { get; set; }

        public virtual Technology Technology { get; set; }
    }
}