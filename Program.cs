using System;
using System.IO;
using System.Windows.Forms;

namespace Runner
{
    internal static class Program
    {
        // Full path of the current executable
        public static string ExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

        // Full path of the program settings
        public static string SettingsPath = Path.Combine(
            Path.GetDirectoryName(ExecutablePath),
            Path.GetFileNameWithoutExtension(ExecutablePath)
        ) + ".ini";

        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RunnerForm());
        }
    }
}
