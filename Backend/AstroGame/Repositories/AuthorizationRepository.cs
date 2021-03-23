using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Apis;
using AstroGame.Shared.Models.Authorizations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Repositories
{
    [ScopedService]
    public class AuthorizationRepository
    {
        private readonly IAuthorizationApi _api;

        public AuthorizationRepository(IAuthorizationApi api)
        {
            _api = api;
        }

        public async Task<CustomTokenResponse> LoginAsync(string grantType, string scope, string username,
            string password, string clientId, string clientSecret)
        {
            var request = new Dictionary<string, string>
            {
                {"grant_type", grantType},
                {"username", username},
                {"password", password},
                {"client_id", clientId},
                {"client_secret", clientSecret},
                {"scope", scope},
            };

            var response = await _api.LoginAsync(request);

            return CustomTokenResponse.Parse(response);
        }
    }
}