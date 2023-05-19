using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace Runner
{
    internal class Runner
    {
        public Process Process { get; private set; } = null;

        public bool IsRunning { get => !(Process?.HasExited ?? true); }

        public string LastError { get; private set; } = "";

        // Event on process started
        public event EventHandler Started;

        // Event on process exited
        public event EventHandler Exited;

        // Event on process stderr data received
        public event OutputReceivedEventHandler ErrorDataReceived;

        // Event on process stdout data received
        public event OutputReceivedEventHandler OutputDataReceived;

        // Thread for reading error data from process
        public Thread ErrorDataThread { get; private set; } = null;

        // Thread for reading output data from process
        public Thread OutputDataThread { get; private set; } = null;

        private void OnStarted()
        {
            if (Started != null)
            {
                // Invoke listners
                Started(this, EventArgs.Empty);
            }
        }

        private void OnErrorDataReceived(object sender, string error)
        {
            // Dispatch event securely
            ErrorDataReceived?.Invoke(sender, new OutputReceivedEventArgs(error));
        }

        private void OnOutputDataReceived(object sender, string output)
        {
            // Dispatch event securely
            OutputDataReceived?.Invoke(sender, new OutputReceivedEventArgs(output));
        }

        private void ReadDataFromStream(StreamReader reader, bool error)
        {
            while (!reader.EndOfStream)
            {
                var content = reader.Read();
                var output = (char)content;

                if (content != -1 && output != '\r')
                {
                    if (error)
                    {
                        // Trigger error data event
                        OnErrorDataReceived(this, output.ToString());
                    }
                    else
                    {
                        // Trigger output data event
                        OnOutputDataReceived(this, output.ToString());
                    }
                }
            }
        }

        public Process Create(string file, string arguments)
        {
            if (Process == null)
            {
                // Get correct encoding for output
                var encoding = Encoding.GetEncoding(850);

                // Generate working from file path
                var workingDir = Path.GetDirectoryName(file);

                // Create process with custom start info
                Process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = file,
                        Arguments = arguments,
                        WorkingDirectory = workingDir,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        StandardOutputEncoding = encoding,
                        StandardErrorEncoding = encoding,
                        CreateNoWindow = true,
                    }
                };

                // Set exited event listner
                Process.Exited += Exited;
                Process.Exited += (s, e) => Process = null;

                // Enable process events
                Process.EnableRaisingEvents = true;
            }

            return Process;
        }

        public bool Start()
        {
            var result = false;

            if (Process != null)
            {
                try
                {
                    LastError = "";
                    Process.Start();
                    result = true;
                }
                catch (Exception e)
                {
                    Process = null;
                    LastError = e.Message;
                }

                if (result)
                {
                    // Trigger event
                    OnStarted();

                    // Create thread for reading error
                    ErrorDataThread = new Thread(
                        new ThreadStart(() => ReadDataFromStream(Process.StandardError, true))
                    );

                    // Create thread for reading output
                    OutputDataThread = new Thread(
                        new ThreadStart(() => ReadDataFromStream(Process.StandardOutput, false))
                    );

                    // Start threads
                    OutputDataThread.Start();
                    ErrorDataThread.Start();
                }
            }

            return result;
        }

        public bool Kill()
        {
            var result = false;

            if (Process != null)
            {
                try
                {
                    // Kill process
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "taskkill.exe",
                        Arguments = "/F /T /PID " + Process.Id,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }).WaitForExit();

                    result = true;
                }
                catch (Exception e)
                {
                    LastError = e.Message;
                }
            }

            return result;
        }
    }
}
