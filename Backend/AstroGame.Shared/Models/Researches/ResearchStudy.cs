using AstroGame.Shared.Models.Players;
using Newtonsoft.Json;
using System;

namespace AstroGame.Shared.Models.Researches
{
    public class ResearchStudy
    {
        public Guid Id { get; set; }
        public Guid ResearchId { get; set; }
        public Guid PlayerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string HangfireJobId { get; set; }

        [JsonIgnore] public virtual Research Research { get; set; }
        [JsonIgnore] public virtual Player Player { get; set; }
    }
}