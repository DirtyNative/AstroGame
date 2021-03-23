using AstroGame.Api.Repositories;
using AstroGame.Shared.Models.Authorizations;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Apis;

namespace AstroGame.Api.Managers
{
    [ScopedService]
    public class AuthorizationManager
    {
        private readonly AuthorizationRepository _authorizationRepository;

        public AuthorizationManager(AuthorizationRepository authorizationRepository)
        {
            _authorizationRepository = authorizationRepository;
        }

        public async Task<CustomTokenResponse> LoginAsync(string email, string password)
        {
            // Try to login
            var response = await _authorizationRepository.LoginAsync("password",
                $"{Scopes.ApiScope} offline_access",
                email,
                password,
                "astrogame.app", "1a7e52d9a1494bb66649478381244ffdfc480ad4507c1f854977e6cecccab5a7");

            return response;
        }
    }
}