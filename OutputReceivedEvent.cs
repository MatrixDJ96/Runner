using System;
using System.Diagnostics;

namespace Runner
{
    public class OutputReceivedEventArgs : EventArgs
    {
        internal string _output;

        public string Output => _output;

        internal OutputReceivedEventArgs(string output)
        {
            _output = output;
        }
    }

    public delegate void OutputReceivedEventHandler(object sender, OutputReceivedEventArgs e);
}
