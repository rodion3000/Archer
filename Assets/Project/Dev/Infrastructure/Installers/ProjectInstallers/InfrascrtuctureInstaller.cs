using Project.Dev.Infrastructure.AssetManager;
using Project.Dev.Infrastructure.Factories;
using Project.Dev.Infrastructure.SceneManagment;
using Project.Dev.Services.Logging;
using Project.Dev.Services.StaticDataService;
using Zenject;

namespace Project.Dev.Infrastructure.Installers.ProjectInstallers
{
    public class InfrascrtuctureInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AddressableProvider>().AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<LoggingService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle().NonLazy();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<StateFactories>().AsSingle();
        }
    }
}
