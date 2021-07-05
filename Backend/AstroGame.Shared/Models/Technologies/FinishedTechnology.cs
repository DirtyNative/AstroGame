using System;

namespace AstroGame.Shared.Models.Technologies
{
    public abstract class FinishedTechnology
    {
        public Guid Id { get; set; }
        public Guid TechnologyId { get; set; }
        public uint Level { get; set; }

        public virtual Technology Technology { get; set; }
    }
}