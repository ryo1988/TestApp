using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Autofac;
using Autofac.Configuration;
using TestApp.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyModel;

namespace TestApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadLocalAssembly();
            var configurationBuilder = new ConfigurationBuilder();
            var currentDirectory = Directory.GetCurrentDirectory();
            configurationBuilder.SetBasePath(currentDirectory);
            configurationBuilder.AddJsonFile("App.config");
            var module = new ConfigurationModule(configurationBuilder.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
            builder.RegisterType<ConsoleLogger>().As<ILogger>();
            var container = builder.Build();
            var services = container.Resolve<IEnumerable<IService>>();
            foreach (var service in services)
            {
                service.Run();
            }
        }

        static void LoadAssembly(string filePath)
        {
            var assemblyName = AssemblyLoadContext.GetAssemblyName(filePath);
            var dependencyContext = DependencyContext.Default;
            var ressource = dependencyContext.CompileLibraries.FirstOrDefault(r => r.Name.ToLower().Contains(assemblyName.Name.ToLower()));

            if(ressource != null)
            {
                Assembly.Load(new AssemblyName(ressource.Name));
                return;
            }

            if(File.Exists(filePath))
            {
                AssemblyLoadContext.Default.LoadFromAssemblyPath(filePath);
            }
        }

        static void LoadLocalAssembly()
        {
            var location = Assembly.GetEntryAssembly().Location;
            var directory = Path.GetDirectoryName(location);

            var files = Directory.GetFiles(directory, "*.dll");
            foreach (var file in files)
            {
                LoadAssembly(file);
            }
        }
    }
}