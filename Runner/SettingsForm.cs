using System;
using System.Windows.Forms;

namespace Runner
{
    public partial class SettingsForm : BaseForm
    {
        // Define whether the settings have been updated
        public bool Updated { get; set; } = false;

        private void UpdateComponents(bool width = true)
        {
            if (InvokeRequired)
            {
                // Invoke correct thread to update gui
                Invoke((MethodInvoker)delegate { this?.UpdateComponents(width); });

                return;
            }

            // Update file to execute textbox value
            ExecutableTextBox.Text = Settings.Executable;
            ArgumentsTextBox.Text = Settings.Arguments;

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
                Invoke((MethodInvoker)delegate { this?.UpdateComponentsWidth(); });

                return;
            }

            // Update file to execute textbox width
            ExecutableTextBox.Width = Math.Max(TextRenderer.MeasureText(ExecutableTextBox.Text, ExecutableTextBox.Font).Width + (int)ExecutableTextBox.Font.Size, ExecutableTextBox.MinimumSize.Width);
            ArgumentsTextBox.Width = Math.Max(TextRenderer.MeasureText(ArgumentsTextBox.Text, ArgumentsTextBox.Font).Width + (int)ExecutableTextBox.Font.Size, ExecutableTextBox.MinimumSize.Width);
        }

        public static bool SelectFile(out string filename)
        {
            filename = null;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;
                openFileDialog.DereferenceLinks = true;
                openFileDialog.Title = "Seleziona un file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    filename = openFileDialog.FileName;

                    return true;
                }
            }

            return false;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Set settings as not updated
            Updated = false;

            // Update GUI
            UpdateComponents();
        }

        private void ExecutableButton_Click(object sender, EventArgs e)
        {
            if (SelectFile(out var filename))
            {
                // Set new executable
                Settings.Executable = filename;

                // Update GUI
                UpdateComponents();
            }
        }

        private void ArgumentsButton_Click(object sender, EventArgs e)
        {
            if (SelectFile(out var filename))
            {
                // Set new arguments
                Settings.Arguments = filename;

                // Update GUI
                UpdateComponents();
            }
        }

        private void ExecutableTextBox_TextChanged(object sender, EventArgs e)
        {
            // Update components width
            UpdateComponentsWidth();

            // Update file to execute setting
            Settings.Executable = ExecutableTextBox.Text;
        }

        private void ArgumentsTextBox_TextChanged(object sender, EventArgs e)
        {
            // Update components width
            UpdateComponentsWidth();

            // Update argument setting
            Settings.Arguments = ArgumentsTextBox.Text;
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
