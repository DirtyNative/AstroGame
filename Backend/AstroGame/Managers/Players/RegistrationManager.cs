using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Core.Exceptions;
using AstroGame.Core.Services;
using AstroGame.Shared.Models.Players;
using AstroGame.Storage.Repositories.Players;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Players
{
    [ScopedService]
    public class RegistrationManager
    {
        private readonly PlayerRepository _playerRepository;
        private readonly PasswordService _passwordService;

        public RegistrationManager(PlayerRepository playerRepository, PasswordService passwordService)
        {
            _playerRepository = playerRepository;
            _passwordService = passwordService;
        }

        public async Task<Guid> RegisterAsync(string email, string username, string password)
        {
            var playerExists = await _playerRepository.ExistsAsync(email);

            if (playerExists)
            {
                throw new ConflictException($"Email {email} is already registered");
            }

            var usernameExists = await _playerRepository.UsernameExistsAsync(username);

            if (usernameExists)
            {
                throw new ConflictException($"Username {username} already taken");
            }

            // TODO: Check if password is valid
            
            var derivedPassword = _passwordService.DeriveBytes(password);

            var credentials = new Credentials()
            {
                Email = email,
                Password = derivedPassword.PasswordBytes,
                Salt = derivedPassword.SaltBytes
            };

            var player = new Player()
            {
                Credentials = credentials,
                Username = username,
            };

            await _playerRepository.AddAsync(player);
            return player.Id;
        }
    }
}