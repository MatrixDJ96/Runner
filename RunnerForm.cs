using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Runner
{
    public partial class RunnerForm : Form
    {
        private string DefaultFileToExecuteText { get; set; } = "";

        private SettingsForm SettingsForm { get; set; } = new SettingsForm();
        private Runner Runner { get; set; } = new Runner();

        public RunnerForm()
        {
            InitializeComponent();

            // Set event listner
            Runner.Started += (s, e) => ShowOutputText(true,  true);
            Runner.Started += (s, e) => Process_Execution(s, e, true);
            Runner.Exited += (s, e) => Process_Execution(s, e, false);

            Runner.ErrorDataReceived += (s, e) => Process_Output(s, e, true);
            Runner.OutputDataReceived += (s, e) => Process_Output(s, e, false);

            // Set application icon to form
            Icon = Icon.ExtractAssociatedIcon(Program.ExecutablePath);

            // Set default text of file to execute label
            DefaultFileToExecuteText = ExecutableLabel.Text;
        }

        ~RunnerForm()
        {
            try
            {
                // Check if process is running
                if (Runner.IsRunning)
                {
                    // Stop process
                    Runner.Kill();
                }
            }
            catch { }
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
            StartButton.Enabled = !Settings.Executable.IsEmpty() && !Runner.IsRunning;
            StopButton.Enabled = !Settings.Executable.IsEmpty() && Runner.IsRunning;

            // Update file to execute label
            ExecutableLabel.Text = !Settings.Executable.IsEmpty() ? (Settings.Executable + " " +  Settings.Arguments).Trim() : DefaultFileToExecuteText;
            ExecutableLabel.Enabled = Settings.Executable.IsEmpty() || StartButton.Enabled;
        }

        private void UpdateOutputText(bool clean, string output = null, bool error = false)
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
                ErrorTextBox.Clear();
                OutputTextBox.Clear();
            }

            if (output != null)
            {
                var textBox = error ? ErrorTextBox : OutputTextBox;

                // Set output color
                textBox.SelectionColor = error ? Color.Red : Color.Black;

                // Append new output
                textBox.SelectedText = output;

                if (error)
                {
                    ErrorButton.Enabled = true;
                }
            }
        }

        private void ShowOutputText(bool show, bool button = false)
        {
            if (InvokeRequired)
            {
                // Invoke correct thread to update gui
                Invoke((MethodInvoker)delegate { UpdateComponents(); });

                return;
            }

            if (show)
            {
                ErrorButton.Text = ErrorButton.Text.Replace("Nascondi", "Mostra");
                OutputTextBox.BringToFront();
            }
            else
            {
                ErrorButton.Text = ErrorButton.Text.Replace("Mostra", "Nascondi");
                ErrorTextBox.BringToFront();
            }

            if (button)
            {
                ErrorButton.Enabled = false;
            }
        }

        private void Process_Execution(object sender, EventArgs e, bool clean)
        {
            UpdateComponents();
            UpdateOutputText(clean);
        }

        private void Process_Output(object sender, OutputReceivedEventArgs e, bool error)
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
            // Load settings
            Settings.Load();

            if (!Settings.FirstRun)
            {
                // Apply saved location
                Location = new Point(
                    Settings.LocationX,
                    Settings.LocationY
                );

                // Apply saved size
                Size = new Size(
                    Settings.SizeWidth,
                    Settings.SizeHeight
                );
            }
            else
            {
                // Save default size and location
                Settings.FirstRun = false;
                RunnerForm_ResizeEnd(sender, e);
            }

            // Bring to front
            BringToFront();

            // Update GUI
            UpdateComponents();
            UpdateOutputText(true);
        }

        private void RunnerForm_ResizeEnd(object sender, EventArgs e)
        {
            // Get form size
            Settings.SizeWidth = Size.Width;
            Settings.SizeHeight = Size.Height;

            // Get form location
            Settings.LocationX = Location.X;
            Settings.LocationY = Location.Y;

            Settings.Save();
        }

        private void FileToExecuteLabel_Click(object sender, EventArgs e)
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
