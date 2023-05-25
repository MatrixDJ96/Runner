using System;
using System.IO;
using System.Threading;

namespace Runner
{
    internal class Settings
    {
        // Number of times the program has saved settings
        public static int Counter { get; set; } = 0;
        // Event to invoke when counter is increased
        public static event EventHandler CounterIncreased;

        // Thread to save settings when asked with delay
        private static Thread SaveThread { get; set; } = null;

        public static bool FirstRun { get; set; } = true;

        public static int SizeWidth { get; set; } = 0;
        public static int SizeHeight { get; set; } = 0;
        public static int LocationX { get; set; } = 0;
        public static int LocationY { get; set; } = 0;

        public static Version Version { get; set; } = Program.ExecutableVersion;

        public static string Executable { get; set; } = "";
        public static string Arguments { get; set; } = "";

        public static string FullExecutable { get => (Executable + " " + Arguments).Trim(); }

        public static void OnCounterIncreased()
        {
            // Increase counter
            Counter++;
            // Invoke event listeners
            CounterIncreased?.Invoke(null, EventArgs.Empty);
        }

        private static bool SaveInternal(bool clean)
        {
            var result = false;

            try
            {
                // Check if settings file exists
                var exists = File.Exists(Program.SettingsPath);

                if (!exists || clean)
                {
                    if (exists && clean)
                    {
                        // Remove old configuration file
                        File.Delete(Program.SettingsPath);
                    }

                    var dir = Path.GetDirectoryName(Program.SettingsPath);

                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    // Create a new configuration file with default settings
                    using (var stream = File.CreateText(Program.SettingsPath))
                    {
                        stream.WriteLine(nameof(FirstRun) + "=" + FirstRun);
                        stream.WriteLine(nameof(SizeWidth) + "=" + SizeWidth);
                        stream.WriteLine(nameof(SizeHeight) + "=" + SizeHeight);
                        stream.WriteLine(nameof(LocationX) + "=" + LocationX);
                        stream.WriteLine(nameof(LocationY) + "=" + LocationY);
                        stream.WriteLine(nameof(Version) + "=" + Version);
                        stream.WriteLine(nameof(Executable) + "=" + Executable);
                        stream.WriteLine(nameof(Arguments) + "=" + Arguments);
                    }

                    // Increase counter
                    OnCounterIncreased();
                }

                result = true;
            }
            catch { }

            return result;
        }

        public static bool Save(bool clean = true, bool delay = false)
        {
            // Check if thread is alive
            if (SaveThread?.IsAlive ?? false)
            {
                // Abort previous thread
                SaveThread.Abort();
            }

            if (delay)
            {
                // Thread to save settings after 1 second
                SaveThread = new Thread(() =>
                {
                    // Try to save settings
                    try
                    {
                        // Wait 1 second
                        Thread.Sleep(1000);
                        // Save settings
                        SaveInternal(clean);
                    }
                    catch { }
                });

                // Start thread
                SaveThread.Start();

                return true;
            }

            return SaveInternal(clean);
        }

        public static bool Load()
        {
            var result = false;

            try
            {
                Save(false);

                // Load settings reading line by line
                foreach (var line in File.ReadAllLines(Program.SettingsPath))
                {
                    // Split line in 2 piece
                    var chunks = line.Split('=');

                    // Check if lenght is correct
                    if (chunks.Length == 2)
                    {
                        // Set setting key
                        var key = chunks[0];
                        // Set setting value
                        var value = chunks[1];

                        // Apply loaded setting
                        switch (key)
                        {
                            case nameof(FirstRun):
                                // Set form height
                                FirstRun = bool.Parse(value.Trim());
                                break;
                            case nameof(SizeHeight):
                                // Set form height
                                SizeHeight = int.Parse(value.Trim());
                                break;
                            case nameof(SizeWidth):
                                // Set form width
                                SizeWidth = int.Parse(value.Trim());
                                break;
                            case nameof(LocationX):
                                // Set form x position
                                LocationX = int.Parse(value.Trim());
                                break;
                            case nameof(LocationY):
                                // Set form y position
                                LocationY = int.Parse(value.Trim());
                                break;
                            case nameof(Version):
                                // Set current version
                                Version = new Version(value.Trim());
                                break;
                            case nameof(Executable):
                                // Set file to execute
                                Executable = value.Trim();
                                break;
                            case nameof(Arguments):
                                // Set file to execute
                                Arguments = value.Trim();
                                break;
                        }
                    }
                }

                // Check if executable exists 
                if (!Executable.IsEmpty() && !File.Exists(Executable))
                {
                    // Remove invalid setting
                    Executable = "";
                }

                result = true;
            }
            catch { }

            return result;
        }
    }
}
