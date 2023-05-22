using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace Runner
{
    public partial class UpdaterForm : Form
    {
        private Updater Updater { get; set; } = new Updater();
        private Runner Runner { get; set; } = new Runner();

        public UpdaterForm()
        {
            InitializeComponent();

            // Set event listner
            Updater.DownloadCompleted += (s, e) => Hide();
            Updater.DownloadCompleted += Updater_DownloadCompleted;

            Updater.DownloadProgressChanged += (s, e) => Activate();
            Updater.DownloadProgressChanged += Updater_DownloadProgressChanged;

            // Set application icon to form
            Icon = Program.ExecutableIcon;
        }

        private void UpdaterForm_Load(object sender, EventArgs e)
        {
            if (!Updater.Update())
            {
                MessageBox.Show("Impossibile verificare aggiornamenti", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                    var update = "Scaricata nuova versione \"" + e.FileVersion + "\"" + Environment.NewLine + Environment.NewLine + "Vuoi applicare ora l'aggiornamento?";

                    if (MessageBox.Show(update, "Aggiornamento scaricato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Create process
                        Runner.Create(e.FilePath, "");

                        // Start process
                        if (Runner.Start())
                        {
                            // Set restart needed
                            Program.NeedRestart = true;
                        }
                        else
                        {
                            var error = Environment.NewLine + Environment.NewLine + Runner.LastError;
                            MessageBox.Show(("Impossibile avviare il processo!" + error).Trim(), "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
                MessageBox.Show(("Errore scaricamento nuova versione!" + error).Trim(), "Errore aggiornamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
