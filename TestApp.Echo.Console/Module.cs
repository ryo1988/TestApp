using System;
using Autofac;
using TestApp.Echo.Core;

namespace TestApp.Echo.Console
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConsoleEchoPresenter>().As<IEchoPresenter>();
        }
    }
}
