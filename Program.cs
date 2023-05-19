using System;
using System.IO;
using System.Windows.Forms;

namespace Runner
{
    internal static class Program
    {

        // Name of the current executable
        public static string ExecutableName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        // Version of the current executable
        public static Version ExecutableVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

        // Full path of the current executable
        public static string ExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

        // Full path of the program settings
        public static string SettingsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            ExecutableName,
            "Settings.ini"
        );

        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Load settings
            if (!Settings.Load())
            {
                // Warn about error loading settings
                MessageBox.Show("Errore caricamento impostazioni", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Application.Run(new RunnerForm());
        }
    }
}
