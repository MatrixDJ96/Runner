using System;
using System.Collections.Generic;
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
            // Abort previous clean (if any)
            AbortClean();

            // Thread to clean files
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
            // List of files to delete
            var result = new List<string> { };

            try
            {
                // Create new domain to load assembly
                var domain = AppDomain.CreateDomain("cleaner");

                // Get all files with .old extension
                var entries = Directory.GetFileSystemEntries(
                    Path.GetDirectoryName(Program.ExecutablePath), "*.old", SearchOption.TopDirectoryOnly
                );

                foreach (var entry in entries)
                {
                    try
                    {
                        // Load assembly from file using new domain
                        var assembly = domain.Load(new AssemblyName { CodeBase = entry });

                        // Try to load GUID of the loaded assembly 
                        var guid = assembly?.GetCustomAttribute<GuidAttribute>();

                        // Check if GUID is the same of the current executable
                        if (guid?.Value == Program.ExecutableGuid)
                        {
                            // Add file to delete list
                            result.Add(entry);
                        }
                    }
                    catch { }
                }

                // Unload domain to release files
                AppDomain.Unload(domain);

            }
            catch { }

            // Delete old backup files
            foreach (var entry in result)
            {
                try
                {
                    File.Delete(entry);
                }
                catch { }
            }
        }
    }
}