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
        private ProcessHelper ProcessHelper { get; set; } = new ProcessHelper();

        public RunnerForm()
        {
            InitializeComponent();

            // Set event listner
            ProcessHelper.Started += (s, e) => Process_Execution(s, e, true);
            ProcessHelper.Exited += (s, e) => Process_Execution(s, e, false);

            ProcessHelper.ErrorDataReceived += (s, e) => Process_Output(s, e, true);
            ProcessHelper.OutputDataReceived += (s, e) => Process_Output(s, e, false);

            // Set application icon to form
            Icon = Icon.ExtractAssociatedIcon(Program.ExecutablePath);

            // Set default text of file to execute label
            DefaultFileToExecuteText = FileToExecuteLabel.Text;
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
            FileToExecuteLabel.Text = !Settings.FileToExecute.IsEmpty() ? (Settings.FileToExecute + " " +  Settings.Arguments).Trim() : DefaultFileToExecuteText;
            FileToExecuteLabel.Enabled = Settings.FileToExecute.IsEmpty() || StartButton.Enabled;
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
                OutputTextBox.Clear();
            }

            if (!output.IsEmpty())
            {
                // Set output color
                OutputTextBox.SelectionColor = error ? Color.Red : Color.Black;

                // Append new output
                OutputTextBox.SelectedText = output;
            }
        }

        private void Process_Execution(object sender, EventArgs e, bool clean)
        {
            UpdateComponents();
            UpdateOutputText(clean);
        }

        private void Process_Output(object sender, DataReceivedEventArgs e, bool error)
        {
            UpdateOutputText(false, e.Data + Environment.NewLine, error);
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
            if (!Settings.FileToExecute.IsEmpty())
            {
                // Check if process is running
                if (!ProcessHelper.IsRunning)
                {
                    // Create process
                    ProcessHelper.Create(Settings.FileToExecute, Settings.Arguments);

                    // Start process
                    if (!ProcessHelper.Start())
                    {
                        var error = Environment.NewLine + Environment.NewLine + ProcessHelper.LastError;
                        MessageBox.Show(("Impossibile avviare il processo!" + error).Trim(), "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            // Check if process is running
            if (ProcessHelper.IsRunning)
            {
                // Stop process
                if (!ProcessHelper.Kill())
                {
                    var error = Environment.NewLine + Environment.NewLine + ProcessHelper.LastError;
                    MessageBox.Show(("Impossibile interrompere il processo!" + error).Trim(), "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
