using System.Windows;
using Bogdan_Monitor.Views;

namespace Bogdan_Monitor
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainView()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }        
    }
}
