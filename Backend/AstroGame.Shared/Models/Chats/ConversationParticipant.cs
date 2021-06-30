using AstroGame.Shared.Models.Players;
using System;

namespace AstroGame.Shared.Models.Chats
{
    public class ConversationParticipant
    {
        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        public Guid PlayerId { get; set; }

        public DateTime JoinedDateTime { get; set; }
        public DateTime LastSeenDateTime { get; set; }

        public virtual Conversation Conversation { get; set; }
        public virtual Player Player { get; set; }
    }
}
