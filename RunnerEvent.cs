using System;

namespace Runner
{
    internal class RunnerReceivedEventArgs : EventArgs
    {
        public string Output { get; internal set; } = null;

        public RunnerReceivedEventArgs(string output)
        {
            Output = output;
        }
    }

    internal delegate void RunnerReceivedEventHandler(object sender, RunnerReceivedEventArgs e);
}
