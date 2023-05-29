using System;

namespace Runner.Events
{
    internal class UpdaterCompletedEventArgs : EventArgs
    {
        public Exception Error { get; internal set; } = null;

        public bool Success { get; internal set; } = false;

        public string FilePath { get; internal set; } = null;

        public Version FileVersion { get; internal set; } = null;
    }

    internal delegate void UpdaterCompletedEventHandler(object sender, UpdaterCompletedEventArgs e);
}
