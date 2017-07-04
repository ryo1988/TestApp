using System;
using System.Reactive.Linq;
using Reactive.Bindings;
using TestApp.Echo.Core;

namespace TestApp.Echo.Wpf
{
    public class EchoServiceViewModel
    {
        public ReactiveProperty<string> EchoText { get; }
        public ReactiveCommand EchoCommand { get; }
        public ReactiveProperty<string> EchoResult { get; }

        private readonly IEchoService _echoService;

        public EchoServiceViewModel(IEchoService echoService, EchoPresenter echoPresenter)
        {
            _echoService = echoService;

            EchoText = new ReactiveProperty<string>();
            EchoCommand = new ReactiveCommand();
            EchoCommand
                .Do(_ => _echoService.Echo(EchoText.Value))
                .Subscribe();
            EchoResult = echoPresenter.EchoResult;
        }
    }
}