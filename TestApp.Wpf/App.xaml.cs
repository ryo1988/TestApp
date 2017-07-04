using System;
using System.Windows;
using Autofac;
using Prism.Autofac;
using TestApp.Core;

namespace TestApp.Wpf
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}
