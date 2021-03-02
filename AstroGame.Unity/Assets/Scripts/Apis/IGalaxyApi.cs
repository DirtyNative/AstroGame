using AstroGame.Shared.Models.Stellar.StellarSystems;
using Retrofit.Methods;

namespace Assets.Scripts.Apis
{
    public interface IGalaxyApi
    {
        [Get("/")]
        Galaxy GetGalaxy();
    }
}
