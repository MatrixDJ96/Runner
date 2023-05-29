using Runner.Windows;
using System.Windows;

namespace Runner
{
    /// <summary>
    /// Logica di interazione per App.xaml
    /// </summary>
    public partial class App : Application
    {
        public RunnerWindow RunnerWindow => new RunnerWindow();

        public UpdaterWindow UpdaterWindow => new UpdaterWindow();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Start updater form
            UpdaterWindow.ShowDialog();

            if (!Program.NeedRestart)
            {
                // Start runner form
                RunnerWindow.ShowDialog();
            }

            // Close application
            Shutdown();
        }
    }
}
