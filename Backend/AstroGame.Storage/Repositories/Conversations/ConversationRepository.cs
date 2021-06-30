using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Chats;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Conversations
{
    [ScopedService]
    public class ConversationRepository
    {
        private readonly AstroGameDataContext _context;

        public ConversationRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<Conversation> GetAsync(Guid id)
        {
            return await _context.Conversations
                .Include(e => e.Messages)
                .Include(e => e.Participants)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Conversation>> GetByPlayerAsync(Guid playerId)
        {
            return await _context.Conversations
                .Include(e => e.Messages)
                .Include(e => e.Participants)
                .Where(e => e.Participants.Any(p => p.PlayerId == playerId))
                .ToListAsync();
        }

        public async Task AddAsync(Conversation conversation)
        {
            await _context.Conversations.AddAsync(conversation);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ContainsPlayerAsync(Guid id, Guid playerId)
        {
            var conversation = await GetAsync(id);
            return conversation.Participants.Any(e => e.PlayerId == playerId);
        }

        public async Task AddPlayerAsync(Guid id, Guid playerId)
        {
            var conversation = await GetAsync(id);
            conversation.Participants.Add(new ConversationParticipant()
            {
                PlayerId = playerId,
                ConversationId = conversation.Id,
                Conversation = conversation,
                JoinedDateTime = DateTime.UtcNow,
                LastSeenDateTime = DateTime.UtcNow,
            });

            await _context.SaveChangesAsync();
        }

        public async Task AddMessageAsync(Guid id, ConversationMessage message)
        {
            var conversation = await GetAsync(id);

            conversation.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task RemovePlayerAsync(Guid id, Guid playerId)
        {
            var conversation = await GetAsync(id);
            conversation.Participants.RemoveAll(e => e.PlayerId == playerId);

            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}