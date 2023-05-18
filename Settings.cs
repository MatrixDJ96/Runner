using System.IO;

namespace Runner
{
    internal class Settings
    {
        public static bool FirstRun { get; set; } = true;

        public static int SizeWidth { get; set; } = 0;
        public static int SizeHeight { get; set; } = 0;
        public static int LocationX { get; set; } = 0;
        public static int LocationY { get; set; } = 0;

        public static string FileToExecute { get; set; } = "";

        public static bool Save(bool clean = true)
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
                    stream.WriteLine(nameof(FileToExecute) + "=" + FileToExecute);
                }
            }

            return true;
        }

        public static bool Load()
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
                        case nameof(FileToExecute):
                            // Set file to execute
                            FileToExecute = value.Trim();
                            break;
                    }
                }
            }

            return true;
        }
    }
}
