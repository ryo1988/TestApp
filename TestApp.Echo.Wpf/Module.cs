using Autofac;
using Prism.Modularity;
using Prism.Regions;
using TestApp.Echo.Core;

namespace TestApp.Echo.Wpf
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var echoPresenter = new EchoPresenter();
            builder.RegisterInstance(echoPresenter).SingleInstance();
            builder.RegisterInstance<IEchoPresenter>(echoPresenter).SingleInstance();
        }
    }

    public class PrismModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public PrismModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(EchoService));
        }
    }
}