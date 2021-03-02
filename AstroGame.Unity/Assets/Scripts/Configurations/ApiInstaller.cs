using Assets.Scripts.Apis;
using Retrofit;
using Zenject;

namespace Assets.Scripts.Configurations
{
    /// <summary>
    /// Used to register the Web Apis
    /// </summary>
    public class ApiInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();

            var adapter = new RetrofitAdapter.Builder()
                .SetEndpoint("https://localhost:7555/api/v1")
                .Build();

            var httpService = adapter.Create<IGalaxyApi>();

            Container.BindInstance(httpService);
        }
    }
}