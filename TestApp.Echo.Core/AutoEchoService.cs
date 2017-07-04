using System.Collections.Generic;
using TestApp.Core;

namespace TestApp.Echo.Core
{
    public class AutoEchoService : EchoService
    {
        public AutoEchoService(IEchoPresenter presenter, ILogger logger) : base(presenter, logger)
        {
        }

        public override bool Run()
        {
            Echo("Test1");
            Echo("Test2");
            Echo("Test3");

            return true;
        }
    }
}