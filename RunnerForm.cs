using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Runner
{
    public partial class RunnerForm : Form
    {
        private ProcessHelper ProcessHelper { get; set; } = new ProcessHelper();

        public RunnerForm()
        {
            InitializeComponent();
        }

        private void UpdateComponents()
        {
            if (InvokeRequired)
            {
                // Invoke correct thread to update gui
                Invoke((MethodInvoker)delegate { UpdateComponents(); });

                return;
            }

            // Update start and stop button
            StartButton.Enabled = !Settings.FileToExecute.IsEmpty() && !ProcessHelper.IsRunning;
            StopButton.Enabled = !Settings.FileToExecute.IsEmpty() && ProcessHelper.IsRunning;

            // Update file to execute label
            FileToExecuteLabel.Text = Settings.FileToExecute;
            FileToExecuteLabel.Enabled = StartButton.Enabled;
        }

        private void UpdateOutputText(bool clean, string output, bool error)
        {
            if (InvokeRequired)
            {
                // Invoke correct thread to update gui
                Invoke((MethodInvoker)delegate { UpdateOutputText(clean, output, error); });

                return;
            }

            if (clean)
            {
                // Clean previous output
                OutputTextBox.Clear();
            }

            if (!output.IsEmpty())
            {
                // Append new output
                OutputTextBox.Text += output;
            }
        }
    }
}
