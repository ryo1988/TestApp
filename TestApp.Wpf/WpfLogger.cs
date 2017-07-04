using System.Collections.ObjectModel;
using TestApp.Core;

namespace TestApp.Wpf
{
    public class WpfLogger : ILogger
    {
        public readonly ObservableCollection<string> Logs = new ObservableCollection<string>();

        public void Add(string log)
        {
            Logs.Add(log);
        }
    }
}