using AstroGame.Core.Exceptions;
using AstroGame.Core.Services;
using AstroGame.Storage.Repositories.Players;
using IdentityModel;
using IdentityServer4.Validation;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AstroGame.Identity.Validators
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly PlayerRepository _playerRepository;
        private readonly PasswordService _passwordService;

        public ResourceOwnerPasswordValidator(PlayerRepository playerRepository, PasswordService passwordService)
        {
            _playerRepository = playerRepository;
            _passwordService = passwordService;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var player = await _playerRepository.GetByEmailAsync(context.Request.UserName);

            if (player == null)
            {
                throw new BadRequestException($"Player {context.Request.UserName} does not exists");
            }

            // Generate the password bytes
            var password = _passwordService.DeriveBytes(context.Password, salt: player.Credentials.Salt);

            // validate username/password against in-memory store
            if (player.Credentials.Password.SequenceEqual(password.PasswordBytes) == false)
            {
                throw new BadRequestException("Invalid credentials provided");
            }

            // If the email is not authenticated
            if (player.ConfirmationToken != null)
            {
                throw new LockedException($"Email {context.Request.UserName} not confirmed");
            }

            // ###################################################
            // TODO: GrantValidationResult wants a principal.. Don't know what this is, guess it comes from the DB
            var claims = new[]
            {
                new Claim(JwtClaimTypes.Subject, player.Id.ToString()),
                new Claim(JwtClaimTypes.Name, player.Credentials.Email),
                new Claim(JwtClaimTypes.IdentityProvider, "AuthServer"),
                new Claim(JwtClaimTypes.AuthenticationTime, DateTime.UtcNow.ToEpochTime().ToString()),
                new Claim(JwtClaimTypes.AuthenticationMethod, "what"),
            };
            var ci = new ClaimsIdentity(claims);
            var cp = new ClaimsPrincipal(ci);

            // ###################################################

            // All went good
            context.Result = new GrantValidationResult(principal: cp);
        }
    }
}