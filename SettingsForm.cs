using System;
using System.Drawing;
using System.Windows.Forms;

namespace Runner
{
    public partial class SettingsForm : Form
    {
        // Define whether the settings have been updated
        public bool Updated { get; set; } = false;

        public SettingsForm()
        {
            InitializeComponent();

            // Set application icon to form
            Icon = Icon.ExtractAssociatedIcon(Program.ExecutablePath);
        }

        private void UpdateComponents(bool width = true)
        {
            if (InvokeRequired)
            {
                // Invoke correct thread to update gui
                Invoke((MethodInvoker)delegate { UpdateComponents(width); });

                return;
            }

            // Update file to execute textbox value
            ExecutableTextBox.Text = Settings.Executable;
            ArgumentTextBox.Text = Settings.Arguments;

            if (width)
            {
                // Update components width
                UpdateComponentsWidth();
            }
        }

        private void UpdateComponentsWidth()
        {
            if (InvokeRequired)
            {
                // Invoke correct thread to update gui
                Invoke((MethodInvoker)delegate { UpdateComponentsWidth(); });

                return;
            }

            // Update file to execute textbox width
            ExecutableTextBox.Width = Math.Max(TextRenderer.MeasureText(ExecutableTextBox.Text, ExecutableTextBox.Font).Width, 200);
            ArgumentTextBox.Width = Math.Max(TextRenderer.MeasureText(ArgumentTextBox.Text, ArgumentTextBox.Font).Width, 200);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Set settings as not updated
            Updated = false;

            // Update GUI
            UpdateComponents();
        }

        private void FileToExecuteTextBox_Click(object sender, EventArgs e)
        {
            if (Settings.SelectFileToExecute(false))
            {
                // Update GUI
                UpdateComponents();
            }
        }

        private void FileToExecuteTextBox_TextChanged(object sender, EventArgs e)
        {
            // Update components width
            UpdateComponentsWidth();

            // Update file to execute setting
            Settings.Executable = ExecutableTextBox.Text;
        }

        private void ArgumentTextBox_TextChanged(object sender, EventArgs e)
        {
            // Update components width
            UpdateComponentsWidth();

            // Update argument setting
            Settings.Arguments = ArgumentTextBox.Text;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Set settings as updated
            Updated = true;

            // Set dialog result
            DialogResult = DialogResult.OK;

            // Close form
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (Updated)
            {
                // Save settings
                Settings.Save();
            }
            else
            {
                // Restore settings
                Settings.Load();
            }
        }

    }
}
