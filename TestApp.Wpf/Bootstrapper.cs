using System.Collections.Generic;
using System.IO;
using System.Windows;
using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using Prism.Autofac;
using Prism.Modularity;
using TestApp.Core;

namespace TestApp.Wpf
{
    public class Bootstrapper : AutofacBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();

            var services = Container.Resolve<IEnumerable<IService>>();
            foreach (var service in services)
            {
                service.Run();
            }
        }

        protected override void ConfigureContainerBuilder(ContainerBuilder builder)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var currentDirectory = Directory.GetCurrentDirectory();
            configurationBuilder.SetBasePath(currentDirectory);
            configurationBuilder.AddXmlFile("Module.config");
            var module = new ConfigurationModule(configurationBuilder.Build());
            builder.RegisterModule(module);
            builder.RegisterType<WpfLogger>().As<ILogger>();

            base.ConfigureContainerBuilder(builder);
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
    }
}