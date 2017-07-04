using TestApp.Core;

namespace TestApp.Echo.Core
{
    public class EchoService : IEchoService, IService
    {
        private readonly IEchoPresenter _presenter;
        private readonly ILogger _logger;

        public EchoService(IEchoPresenter presenter, ILogger logger)
        {
            _presenter = presenter;
            _logger = logger;
        }

        public virtual bool Run()
        {
            return true;
        }

        public void Echo(string value)
        {
            _logger.Add($"Echo:{value}");
            _presenter.Present(value);
        }
    }
}