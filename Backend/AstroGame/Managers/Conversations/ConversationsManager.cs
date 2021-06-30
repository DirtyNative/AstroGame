using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Communication.Models.Conversations;
using AstroGame.Core.Exceptions;
using AstroGame.Shared.Models.Chats;
using AstroGame.Storage.Repositories.Conversations;
using AstroGame.Storage.Repositories.Players;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Conversations
{
    [ScopedService]
    public class ConversationsManager
    {
        private readonly ConversationRepository _conversationRepository;
        private readonly PlayerRepository _playerRepository;

        public ConversationsManager(ConversationRepository conversationRepository, PlayerRepository playerRepository)
        {
            _conversationRepository = conversationRepository;
            _playerRepository = playerRepository;
        }

        public async Task<Conversation> GetAsync(Guid id)
        {
            return await _conversationRepository.GetAsync(id);
        }

        public async Task<List<Conversation>> GetByPlayerAsync(Guid playerId)
        {
            return await _conversationRepository.GetByPlayerAsync(playerId);
        }

        public async Task AddAsync(Guid playerId, AddConversationRequest request)
        {
            var conversation = new Conversation()
            {
                Name = request.Name,
                Participants = new List<ConversationParticipant>()
                {
                    // Add the player which creates this conversation
                    new()
                    {
                        JoinedDateTime = DateTime.UtcNow,
                        LastSeenDateTime = DateTime.UtcNow,
                        PlayerId = playerId
                    }
                }
            };

            foreach (var participant in request.Participants)
            {
                if (await _playerRepository.ExistsAsync(participant) == false)
                {
                    throw new NotFoundException($"Player {participant} not found");
                }

                conversation.Participants.Add(new ConversationParticipant()
                {
                    JoinedDateTime = DateTime.UtcNow,
                    LastSeenDateTime = DateTime.UtcNow,
                    PlayerId = participant,
                });
            }

            await _conversationRepository.AddAsync(conversation);
        }

        public async Task<bool> ContainsPlayerAsync(Guid id, Guid playerId)
        {
            return await _conversationRepository.ContainsPlayerAsync(id, playerId);
        }

        public async Task AddPlayerAsync(Guid id, Guid playerId)
        {
            if (await _conversationRepository.ContainsPlayerAsync(id, playerId))
            {
                throw new ConflictException($"Conversation already contains Player {playerId}");
            }

            await _conversationRepository.AddPlayerAsync(id, playerId);
        }

        public async Task WriteMessageAsync(Guid playerId, Guid conversationId, string text)
        {
            var message = new ConversationMessage()
            {
                ConversationId = conversationId,
                Message = text,
                PlayerId = playerId
            };

            await _conversationRepository.AddMessageAsync(conversationId, message);
        }

        public async Task RemovePlayerAsync(Guid id, Guid playerId)
        {
            await _conversationRepository.RemovePlayerAsync(id, playerId);
        }
    }
}