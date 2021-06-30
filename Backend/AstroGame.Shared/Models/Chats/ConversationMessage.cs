using System;
using AstroGame.Shared.Models.Players;

namespace AstroGame.Shared.Models.Chats
{
    public class ConversationMessage
    {
        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        public Guid PlayerId { get; set; }

        public string Message { get; set; }

        public virtual Conversation Conversation { get; set; }
        public virtual Player Player { get; set; }
    }
}
