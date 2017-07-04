using TestApp.Core;

namespace TestApp.Echo.Core
{
    public interface IEchoService : IService
    {
        void Echo(string value);
    }
}