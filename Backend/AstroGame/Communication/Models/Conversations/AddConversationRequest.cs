using System;
using System.Collections.Generic;

namespace AstroGame.Api.Communication.Models.Conversations
{
    public class AddConversationRequest
    {
        public string Name { get; set; }

        public List<Guid> Participants { get; set; }
    }
}
