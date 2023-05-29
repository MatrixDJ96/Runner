using Runner.Events;
using Runner.Utils;
using System;
using System.Diagnostics;
using System.Net;
using System.Windows;

namespace Runner.Windows
{
    /// <summary>
    /// Logica di interazione per UpdaterWindow.xaml
    /// </summary>
    public partial class UpdaterWindow : Window
    {
        private Updater Updater { get; set; } = new Updater();

        private Utils.Runner Runner { get; set; } = new Utils.Runner();

        public UpdaterWindow()
        {
            InitializeComponent();

            // Set event listener
            Updater.DownloadCompleted += (s, e) => Hide();
            Updater.DownloadCompleted += Updater_DownloadCompleted;

            Updater.DownloadProgressChanged += (s, e) => Activate();
            Updater.DownloadProgressChanged += Updater_DownloadProgressChanged;
        }

        private void UpdaterWindow_Loaded(object sender, EventArgs e)
        {
            if (Settings.Version < Program.ExecutableVersion)
            {
                MessageBox.Show("Software aggiornato alla versione \"" + Program.ExecutableVersion + "\"!", "Aggiornamento", MessageBoxButton.OK, MessageBoxImage.Information);

                // Update current version
                Settings.Version = Program.ExecutableVersion;
                // Save settings
                Settings.Save();
            }

            if (!Updater.Update())
            {
                MessageBox.Show("Impossibile verificare aggiornamenti...", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Warning);

                // Close form
                Close();
            }
        }

        private void Updater_DownloadCompleted(object sender, UpdaterCompletedEventArgs e)
        {
            if (e.Success)
            {
                try
                {
                    // Create process
                    Runner.Create(e.FilePath, "");

                    // Start process
                    if (Runner.Start())
                    {
                        // Set restart needed
                        Program.NeedRestart = true;
                        // Kill current process
                        Process.GetCurrentProcess().Kill();
                    }
                    else
                    {
                        var error = Environment.NewLine + Environment.NewLine + Runner.LastError;
                        MessageBox.Show(("Impossibile avviare nuova versione!" + error).Trim(), "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    e.Error = ex;
                }
            }

            if (e.Error != null)
            {
                var error = Environment.NewLine + Environment.NewLine + e.Error.Message;
                MessageBox.Show(("Errore scaricamento nuova versione!" + error).Trim(), "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Close form
            Close();
        }

        private void Updater_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadProgressBar.Value = e.ProgressPercentage;
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            // Cancel update
            Updater.Cancel();

            // Close form
            Close();
        }
    }
}
