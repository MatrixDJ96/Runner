using Runner.Events;
using Runner.Extensions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Runner.Forms
{
    public partial class RunnerForm : BaseForm
    {
        private string DefaultExecutableText { get; set; } = "";

        private SettingsForm SettingsForm { get; set; } = new SettingsForm();

        private Utils.Runner Runner { get; set; } = new Utils.Runner();

        public RunnerForm()
        {
#if DEBUG
            // Update counter text on counter increased
            Settings.CounterIncreased += (s, e) => UpdateComponents();
#endif

            // Set output text box visible on start
            Runner.Started += (s, e) => ShowOutputText(true, true);

            // Set execution listener to update gui
            Runner.Started += (s, e) => Process_Execution(s, e, true);
            Runner.Exited += (s, e) => Process_Execution(s, e, false);

            // Process error and output data
            Runner.ErrorDataReceived += (s, e) => Process_Output(s, e, true);
            Runner.OutputDataReceived += (s, e) => Process_Output(s, e, false);

            // Set default text of file to execute label
            DefaultExecutableText = SettingsButton.Text;

            // Add version on form title
            Text += " v" + Program.ExecutableVersion;
        }

        private void UpdateComponents()
        {
            if (InvokeRequired)
            {
                // Invoke correct thread to update gui
                Invoke((MethodInvoker)delegate { this?.UpdateComponents(); });

                return;
            }

            // Update start and stop button
            StartButton.Enabled = !Settings.Executable.IsEmpty() && !Runner.IsRunning;
            StopButton.Enabled = !Settings.Executable.IsEmpty() && Runner.IsRunning;

            // Update file to execute label
            SettingsButton.Text = !Settings.Executable.IsEmpty() ? Settings.FullExecutable : DefaultExecutableText;
            SettingsButton.Enabled = Settings.Executable.IsEmpty() || StartButton.Enabled;

#if DEBUG
            // Update counter text with counter value
            CounterText.Text = Settings.Counter != 0 ? "Salvataggi: " + Settings.Counter.ToString() : "";
#else
            // Hide counter text
            CounterText.Visible = false;
#endif
        }

        private void UpdateOutputText(bool clean, string output = null, bool error = false)
        {
            if (InvokeRequired)
            {
                // Invoke correct thread to update gui
                Invoke((MethodInvoker)delegate { this?.UpdateOutputText(clean, output, error); });

                return;
            }

            if (clean)
            {
                if (error)
                {
                    // Clean previous error
                    ErrorTextBox.Clear();
                }
                else
                {
                    // Clean previous output
                    OutputTextBox.Clear();
                }
            }

            if (output != null)
            {
                if (error)
                {
                    // Set focus
                    ErrorTextBox.Focus();
                    // Append new error
                    ErrorTextBox.AppendText(output);
                    // Enable error button
                    ErrorButton.Enabled = true;
                }
                else
                {
                    // Set focus
                    OutputTextBox.Focus();
                    // Append new output
                    OutputTextBox.AppendText(output);
                }
            }
        }

        private void ShowOutputText(bool show, bool button = false)
        {
            if (InvokeRequired)
            {
                // Invoke correct thread to update gui
                Invoke((MethodInvoker)delegate { this?.UpdateComponents(); });

                return;
            }

            if (show)
            {
                // Change button label
                ErrorButton.Text = ErrorButton.Text.Replace("Nascondi", "Mostra");
                // Show output text box
                OutputTextBox.BringToFront();
            }
            else
            {
                // Change button label
                ErrorButton.Text = ErrorButton.Text.Replace("Mostra", "Nascondi");
                // Show error text box
                ErrorTextBox.BringToFront();
            }

            if (button)
            {
                // Disable error button
                ErrorButton.Enabled = false;
            }
        }

        private void Process_Execution(object sender, EventArgs e, bool clean)
        {
            UpdateComponents();
            // Clean error text box
            UpdateOutputText(clean, error: true);
            // Clean output textr box
            UpdateOutputText(clean, error: false);
        }

        private void Process_Output(object sender, RunnerReceivedEventArgs e, bool error)
        {
            if (e.Output == null)
            {
                // Skip null
                return;
            }

            UpdateOutputText(false, e.Output, error);
        }

        private void RunnerForm_Load(object sender, EventArgs e)
        {
            if (!Settings.FirstRun)
            {
                // Apply saved location
                Location = new Point(
                    Settings.LocationX * DeviceDpi / 96,
                    Settings.LocationY * DeviceDpi / 96
                );

                // Apply saved size
                Size = new Size(
                    Settings.SizeWidth * DeviceDpi / 96,
                    Settings.SizeHeight * DeviceDpi / 96
                );
            }
            else
            {
                // Set first run to false
                Settings.FirstRun = false;
                // Save current size and position
                RunnerForm_ResizeEnd(sender, e);
            }

            // Set app in foreground 
            Activate();

            // Update GUI
            UpdateComponents();
            UpdateOutputText(true);
            ShowOutputText(true, true);
        }

        private void RunnerForm_ResizeBegin(object sender, EventArgs e)
        {
            // Stop settings save
            Settings.AbortSave();
        }

        private void RunnerForm_ResizeEnd(object sender, EventArgs e)
        {
            // Get form size
            Settings.SizeWidth = Size.Width * 96 / DeviceDpi;
            Settings.SizeHeight = Size.Height * 96 / DeviceDpi;

            // Get form location
            Settings.LocationX = Location.X * 96 / DeviceDpi;
            Settings.LocationY = Location.Y * 96 / DeviceDpi;

            // Start save settings
            Settings.StartSave();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            // Select new file to execute
            if (SettingsForm.ShowDialog(this) == DialogResult.OK)
            {
                UpdateComponents();
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            // Check if file to execute are set
            if (!Settings.Executable.IsEmpty())
            {
                // Check if process is running
                if (!Runner.IsRunning)
                {
                    // Create process
                    Runner.Create(Settings.Executable, Settings.Arguments);

                    // Start process
                    if (!Runner.Start())
                    {
                        var error = Environment.NewLine + Environment.NewLine + Runner.LastError;
                        MessageBox.Show(("Impossibile avviare il processo!" + error).Trim(), "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            // Check if process is running
            if (Runner.IsRunning)
            {
                // Stop process
                if (!Runner.Kill())
                {
                    var error = Environment.NewLine + Environment.NewLine + Runner.LastError;
                    MessageBox.Show(("Impossibile interrompere il processo!" + error).Trim(), "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ErrorButton_Click(object sender, EventArgs e)
        {
            var outputIndex = FillPanel.Controls.GetChildIndex(OutputTextBox);
            var errorIndex = FillPanel.Controls.GetChildIndex(ErrorTextBox);

            ShowOutputText(outputIndex > errorIndex);
        }
    }
}
