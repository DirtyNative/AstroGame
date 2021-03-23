using AstroGame.Shared.Models.Authorizations;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Shared.Apis
{
    public interface IAuthorizationApi
    {
        [Post("/connect/token")]
        Task<Dictionary<string, dynamic>> LoginAsync([Body(BodySerializationMethod.UrlEncoded)]
            Dictionary<string, string> data);
    }
}