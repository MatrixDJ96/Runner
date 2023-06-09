using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace Runner.Utils
{
    internal class Cleaner
    {
        // Thread to clean old backup files
        private static Thread CleanThread { get; set; } = null;
        // Determines if cleaner is doing its job or not
        public static bool IsCleaning { get => CleanThread?.IsAlive ?? false; }

        public static void AbortClean()
        {
            // Check if thread is alive
            if (IsCleaning)
            {
                // Abort previous thread
                CleanThread.Abort();
            }
        }

        public static bool StartClean()
        {
            // Abort previous save (if any)
            AbortClean();

            // Thread to save settings after 1 second
            CleanThread = new Thread(() =>
            {
                // Try to clean files
                try
                {
                    // Clean files
                    CleanInternal();
                }
                catch { }
            });

            // Start thread
            CleanThread.Start();

            return true;
        }

        internal static void CleanInternal()
        {
            var entries = Directory.GetFileSystemEntries(
                Path.GetDirectoryName(Program.ExecutablePath), "*.old", SearchOption.AllDirectories
            );

            foreach (var entry in entries)
            {
                try
                {
                    // Load assembly from file 
                    var assembly = Assembly.LoadFrom(entry);

                    // Get GUID of the assembly (if any)
                    var guid = assembly?.GetCustomAttribute<GuidAttribute>();

                    // Check if GUID is the same of the current executable
                    if (guid?.Value == Program.ExecutableGuid)
                    {
                        // Delete old backup file
                        File.Delete(entry);
                    }
                }
                catch (Exception)
                {
                    // Ignore
                }
            }
        }
    }
}