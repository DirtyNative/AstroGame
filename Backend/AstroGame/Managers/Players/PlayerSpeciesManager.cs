using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Communication.Models.Players;
using AstroGame.Core.Exceptions;
using AstroGame.Shared.Models.Players;
using AstroGame.Storage.Repositories.Players;
using AutoMapper;
using System;
using System.Threading.Tasks;
using AstroGame.Storage.Database;

namespace AstroGame.Api.Managers.Players
{
    [ScopedService]
    public class PlayerSpeciesManager
    {
        private readonly PlayerSpeciesRepository _playerSpeciesRepository;
        private readonly PlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayerSpeciesManager(PlayerSpeciesRepository playerSpeciesRepository, IMapper mapper,
            PlayerRepository playerRepository)
        {
            _playerSpeciesRepository = playerSpeciesRepository;
            _mapper = mapper;
            _playerRepository = playerRepository;
        }

        public async Task<Guid> AddAsync(Guid playerId, AddPlayerSpeciesRequest request)
        {
            // TODO: Make some checks

            var playerExists = await _playerRepository.ExistsAsync(playerId);

            if (playerExists == false)
            {
                throw new NotFoundException($"Player {playerId} not found");
            }

            if (await _playerSpeciesRepository.ExistsAsync(playerId))
            {
                throw new ConflictException("Player {playerId} already has a species");
            }

            var playerSpecies = _mapper.Map<PlayerSpecies>(request);
            playerSpecies.PlayerId = playerId;

            var playerSpeciesId = await _playerSpeciesRepository.AddAsync(playerSpecies);

            await _playerRepository.AddSpeciesAsync(playerId, playerSpeciesId);
            
            return playerSpeciesId;
        }
    }
}