using Reactive.Bindings;

namespace TestApp.Wpf
{
    public class EchoServiceViewModel
    {
        public ReactiveCommand EchoCommand { get; }
        public ReactiveProperty<string> EchoResult { get; }

        public EchoServiceViewModel()
        {
            EchoCommand = new ReactiveCommand();
        }
    }
}