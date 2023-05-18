using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Runner
{
    public partial class RunnerForm : Form
    {
        private ProcessHelper ProcessHelper { get; set; } = new ProcessHelper();

        public RunnerForm()
        {
            InitializeComponent();

            // Set event listner
            ProcessHelper.Started += (s, e) => Process_Execution(s, e, true);
            ProcessHelper.Exited += (s, e) => Process_Execution(s, e, false);

            ProcessHelper.ErrorDataReceived += (s, e) => Process_Output(s, e, true);
            ProcessHelper.OutputDataReceived += (s, e) => Process_Output(s, e, false);
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

        private bool SelectNewFileToExecute()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;
                openFileDialog.DereferenceLinks = false;
                openFileDialog.Title = "Seleziona il file da eseguire";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    Settings.FileToExecute = openFileDialog.FileName;

                    // Save new settings
                    Settings.Save();

                    return true;
                }
            }

            return false;
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

            // Bring to front
            BringToFront();

            // Check if file to execute are set
            if (Settings.FileToExecute.IsEmpty())
            {
                // Select new file to execute
                if (!SelectNewFileToExecute())
                {
                    // If no file to execute exit from app
                    Application.Exit();
                }
            }

            // Update GUI
            UpdateComponents();
            UpdateOutputText(true);
        }

        private void FileToExecuteLabel_Click(object sender, EventArgs e)
        {
            // Select new file to execute
            if (SelectNewFileToExecute())
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
                    ProcessHelper.Create(Settings.FileToExecute);

                    // Start process
                    if (!ProcessHelper.Start())
                    {
                        MessageBox.Show("Impossibile avviare il processo", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Impossibile interrompere il processo", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
