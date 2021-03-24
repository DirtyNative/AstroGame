using System;
using AstroGame.Api.Communication.Models.Players;
using AstroGame.Storage.Repositories.Players;
using System.Threading.Tasks;
using AstroGame.Core.Exceptions;
using AstroGame.Shared.Models.Players;
using AutoMapper;

namespace AstroGame.Api.Managers.Players
{
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

        public async Task AddAsync(Guid playerId, AddPlayerSpeciesRequest request)
        {
            // TODO: Make some checks

            var exists = await _playerRepository.ExistsAsync(playerId);

            if (exists == false)
            {
                throw new NotFoundException($"Player {playerId} not found");
            }

            var converted = _mapper.Map<PlayerSpecies>(request);

            converted.PlayerId = playerId;
        }
    }
}