using Runner.Forms;
using Runner.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Runner
{
    internal static class Program
    {
        // Indicates whether the program has been updated to a new version
        public static bool Updated { get; set; } = false;

        // Indicates whether the program needs to be restarted
        public static bool NeedRestart { get; set; } = false;

        // Name of the current executable
        public static readonly string ExecutableName = Assembly.GetExecutingAssembly().GetName().Name;

        // Version of the current executable
        public static readonly Version ExecutableVersion = Assembly.GetExecutingAssembly().GetName().Version;

        // GUID of the current executable
        public static readonly string ExecutableGuid = Assembly.GetExecutingAssembly().GetCustomAttribute<GuidAttribute>().Value;

        // Full path of the current executable
        public static readonly string ExecutablePath = Assembly.GetExecutingAssembly().Location;

        // Icon of the current executable
        public static readonly Icon ExecutableIcon = Icon.ExtractAssociatedIcon(ExecutablePath);

        // Full path of the program settings
        public static readonly string SettingsPath = Path.Combine(
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

            // Initialize loader
            Loader.Initialize();

            // Load settings
            Settings.Load();

            // Start updater form
            Application.Run(new UpdaterForm());

            if (!NeedRestart)
            {
                // Start runner form
                Application.Run(new RunnerForm());
            }

            // Save settings
            Settings.Save();
        }
    }
}
