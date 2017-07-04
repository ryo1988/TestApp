using Reactive.Bindings;
using TestApp.Echo.Core;

namespace TestApp.Echo.Wpf
{
    public class EchoPresenter : IEchoPresenter
    {
        public ReactiveProperty<string> EchoResult { get; }

        public EchoPresenter()
        {
            EchoResult = new ReactiveProperty<string>();
        }

        public void Present(string value)
        {
            EchoResult.Value = value;
        }
    }
}