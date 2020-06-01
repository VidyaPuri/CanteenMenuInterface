using Caliburn.Micro;
using CanteenMenuInterface.ViewModels;
using System.Windows;

namespace CanteenMenuInterface
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
