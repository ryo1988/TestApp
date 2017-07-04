using Autofac;
using Autofac.Core;
using TestApp.Core;

namespace TestApp.Echo.Core
{
    public class Module : Autofac.Module
    {
        public bool IsAuto { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            if (IsAuto)
            {
                builder.RegisterType<AutoEchoService>().As<IEchoService>().As<IService>();
            }
            else
            {
                builder.RegisterType<EchoService>().As<IEchoService>().As<IService>();
            }
        }

        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            registration.Activated += (s, e) =>
            {
            };
        }
    }
}