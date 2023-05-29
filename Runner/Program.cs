using Runner.Utils;
using System;
using System.IO;
using System.Reflection;

namespace Runner
{
    internal static class Program
    {
        // Indicates whether the program needs to be restarted
        public static bool NeedRestart { get; set; } = false;

        // Name of the current executable
        public static readonly string ExecutableName = Assembly.GetExecutingAssembly().GetName().Name;

        // Version of the current executable
        public static readonly Version ExecutableVersion = Assembly.GetExecutingAssembly().GetName().Version;

        // Full path of the current executable
        public static readonly string ExecutablePath = Assembly.GetExecutingAssembly().Location;

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
            // Initialize loader
            Loader.Initialize();

            // Load settings
            Settings.Load();

            // Start application
            App app = new App();
            app.InitializeComponent();
            app.Run();

            // Save settings
            Settings.Save();
        }
    }
}
