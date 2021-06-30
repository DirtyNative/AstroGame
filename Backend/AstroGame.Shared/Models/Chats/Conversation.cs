using System;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Chats
{
    public class Conversation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public virtual List<ConversationParticipant> Participants { get; set; }
        public virtual List<ConversationMessage> Messages { get; set; }
    }
}