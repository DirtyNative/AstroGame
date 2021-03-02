using Zenject;

namespace Assets.Scripts.Configurations
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();

            /*Container.Bind<IService>()
                .To<IImplementation>()
                .AsSingle();*/

        }
    }
}