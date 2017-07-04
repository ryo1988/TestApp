using TestApp.Echo.Core;

namespace TestApp.Echo.Console
{
    public class ConsoleEchoPresenter : IEchoPresenter
    {
        public void Present(string value)
        {
            System.Console.WriteLine(value);
        }
    }
}