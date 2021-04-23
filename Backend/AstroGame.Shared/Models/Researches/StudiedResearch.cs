using AstroGame.Shared.Models.Players;
using System;

namespace AstroGame.Shared.Models.Researches
{
    public class StudiedResearch
    {
        public Guid Id { get; set; }
        public Guid ResearchId { get; set; }
        public Guid PlayerId { get; set; }

        public uint Level { get; set; }

        public virtual Research Research { get; set; }
        public virtual Player Player { get; set; }
    }
}