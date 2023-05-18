using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Runner
{
    internal class ProcessHelper
    {
        public Process Process { get; private set; } = null;

        public bool IsRunning { get => !(Process?.HasExited ?? true); }

        public string LastError { get; private set; } = "";

        // Event on process started
        public event EventHandler Started;

        // Event on process exited
        public event EventHandler Exited;

        // Event on process stderr data received
        public event DataReceivedEventHandler ErrorDataReceived;

        // Event on process stdout data received
        public event DataReceivedEventHandler OutputDataReceived;

        private void OnStarted()
        {
            if (Started != null)
            {
                // Invoke listners
                Started(this, EventArgs.Empty);
            }
        }

        public Process Create(string file)
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
                        FileName = "cmd.exe",
                        Arguments = "/c " + file,
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

                // Set output events listners
                Process.ErrorDataReceived += ErrorDataReceived;
                Process.OutputDataReceived += OutputDataReceived;

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
                    // Listen process output
                    Process.BeginOutputReadLine();
                    Process.BeginErrorReadLine();
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
                    Process.Kill();
                    Process = null;
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
