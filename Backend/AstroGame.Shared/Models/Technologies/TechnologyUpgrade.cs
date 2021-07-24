using System;

namespace AstroGame.Shared.Models.Technologies
{
    public abstract class TechnologyUpgrade
    {
        public Guid Id { get; set; }
        public Guid TechnologyId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string HangfireJobId { get; set; }
        
        public virtual Technology Technology { get; set; }
    }
}
