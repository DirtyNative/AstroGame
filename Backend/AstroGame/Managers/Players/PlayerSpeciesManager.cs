﻿using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Communication.Models.Players;
using AstroGame.Core.Exceptions;
using AstroGame.Shared.Models.Players;
using AstroGame.Storage.Repositories.Players;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AstroGame.Api.Services;
using AstroGame.Shared.Models.Resources;
using AstroGame.Storage.Repositories.Stellar;

namespace AstroGame.Api.Managers.Players
{
    [ScopedService]
    public class PlayerSpeciesManager
    {
        private readonly ResourceService _resourceService;

        private readonly PlayerSpeciesRepository _playerSpeciesRepository;
        private readonly PlayerRepository _playerRepository;
        private readonly PlanetRepository _planetRepository;

        private readonly IMapper _mapper;

        public PlayerSpeciesManager(PlayerSpeciesRepository playerSpeciesRepository, IMapper mapper,
            PlayerRepository playerRepository, PlanetRepository planetRepository, ResourceService resourceService)
        {
            _playerSpeciesRepository = playerSpeciesRepository;
            _mapper = mapper;
            _playerRepository = playerRepository;
            _planetRepository = planetRepository;
            _resourceService = resourceService;
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
                throw new ConflictException($"Player {playerId} already has a species");
            }

            var playerSpecies = _mapper.Map<PlayerSpecies>(request);
            playerSpecies.PlayerId = playerId;

            // Generate the starter planet
            var planet = await _planetRepository.GetFirstUncolonizedAsync(request.PreferredPlanetType);

            if (planet == null)
            {
                throw new NotFoundException($"No planet found for type {request.PreferredPlanetType}");
            }

            var colonizedStellarObject = new ColonizedStellarObject()
            {
                ColonizableStellarObject = planet,
                ColonizedOn = DateTime.UtcNow,
                PlayerId = playerId,
                StellarObjectId = planet.Id
            };

            var playerSpeciesId = await _playerSpeciesRepository.AddAsync(playerSpecies);
            await _playerRepository.AddSpeciesAsync(playerId, playerSpeciesId);

            // Terraform the planet to make it habitable to the player
            await _planetRepository.UpdateAsync(planet.Id, true, request.PreferredPlanetType, colonizedStellarObject);

            // To build something, the player needs some base resources
            await _resourceService.AddResourcesAsync(planet.Id, new List<StoredResource>()
            {
                new()
                {
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000016"),
                    Amount = 500,
                }
            });

            return playerSpeciesId;
        }
    }
}