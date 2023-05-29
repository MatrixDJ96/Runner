using Runner.Properties;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Runner.Utils
{
    internal static class Loader
    {
        private static bool AssemblyHooked { get; set; } = false;

        public static void Initialize()
        {
            if (!AssemblyHooked)
            {
                AssemblyHooked = true;
                // Add event listener to load dll at runtime
                AppDomain.CurrentDomain.AssemblyResolve += LoadAssembly;
            }
        }

        private static Assembly LoadAssembly(object sender, ResolveEventArgs e)
        {
            // Result assembly
            Assembly assembly = null;

            // Get assembly name chunks
            var assemblyChunks = new List<string>(e.Name.Split(','));

            if (assemblyChunks.Count > 0)
            {
                // Load assembly from resources
                switch (assemblyChunks[0])
                {
                    case "Newtonsoft.Json":
                        assembly = Assembly.Load(Resources.Newtonsoft_Json);
                        break;
                }
            }

            return assembly;
        }
    }
}
