using Microsoft.Win32;
using System;
using System.Windows;

namespace Runner.Windows
{
    /// <summary>
    /// Logica di interazione per SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        // Define whether the settings have been updated
        public bool Updated { get; set; } = false;

        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void UpdateComponents()
        {
            if (!(Dispatcher.CheckAccess()))
            {
                // Invoke correct thread to update gui
                Dispatcher.Invoke(() => UpdateComponents());

                return;
            }

            // Update file to execute textbox value
            ExecutableTextBox.Text = Settings.Executable;
            ArgumentsTextBox.Text = Settings.Arguments;
        }

        public static bool SelectFile(out string filename)
        {
            filename = null;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                DereferenceLinks = true,
                Title = "Seleziona un file"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Get the path of specified file
                filename = openFileDialog.FileName;

                return true;
            }

            return false;
        }

        private void SettingsWindow_Loaded(object sender, EventArgs e)
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
            // Update file to execute setting
            Settings.Executable = ExecutableTextBox.Text;
        }

        private void ArgumentsTextBox_TextChanged(object sender, EventArgs e)
        {
            // Update argument setting
            Settings.Arguments = ArgumentsTextBox.Text;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Set settings as updated
            Updated = true;

            // Set dialog result
            DialogResult = true;

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
