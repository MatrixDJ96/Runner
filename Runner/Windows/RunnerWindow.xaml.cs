using Runner.Events;
using Runner.Extensions;
using System;
using System.Windows;
using System.Windows.Interop;

namespace Runner.Windows
{
    /// <summary>
    /// Logica di interazione per RunnerWindow.xaml
    /// </summary>
    public partial class RunnerWindow : Window
    {
        private string DefaultExecutableText { get; set; } = "";

        private SettingsWindow SettingsWindow => new SettingsWindow();

        private Utils.Runner Runner { get; set; } = new Utils.Runner();

        public RunnerWindow()
        {
            InitializeComponent();

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
            DefaultExecutableText = SettingsButton.Content.ToString();

            // Add version on form title
            Title += " v" + Program.ExecutableVersion;
        }

        private void UpdateComponents()
        {
            if (!(Dispatcher.CheckAccess()))
            {
                // Invoke correct thread to update gui
                Dispatcher.Invoke(() => UpdateComponents());

                return;
            }

            // Update start and stop button
            StartButton.IsEnabled = !Settings.Executable.IsEmpty() && !Runner.IsRunning;
            StopButton.IsEnabled = !Settings.Executable.IsEmpty() && Runner.IsRunning;

            // Update file to execute label
            SettingsButton.Content = !Settings.Executable.IsEmpty() ? Settings.FullExecutable : DefaultExecutableText;
            SettingsButton.IsEnabled = Settings.Executable.IsEmpty() || StartButton.IsEnabled;

#if DEBUG
            // Update counter text with counter value
            CounterText.Text = Settings.Counter != 0 ? "Salvataggi: " + Settings.Counter.ToString() : "";
#else
            // Hide counter text
            CounterText.Visibility = Visibility.Collapsed;
#endif
        }

        private void UpdateOutputText(bool clean, string output = null, bool error = false)
        {
            if (!(Dispatcher.CheckAccess()))
            {
                // Invoke correct thread to update gui
                Dispatcher.Invoke(() => UpdateOutputText(clean, output, error));

                return;
            }

            if (clean)
            {
                if (error)
                {
                    // Clean previous error
                    ErrorTextBox.Inlines.Clear();
                }
                else
                {
                    // Clean previous output
                    OutputTextBox.Inlines.Clear();
                }
            }

            if (output != null)
            {
                if (error)
                {
                    // Append new error
                    ErrorTextBox.Inlines.Add(output);
                    // Scroll to end
                    ErrorRichTextBox.ScrollToEnd();
                    // Enable error button
                    ErrorButton.IsEnabled = true;
                }
                else
                {
                    // Append new output
                    OutputTextBox.Inlines.Add(output);
                    // Scroll to end
                    OutputRichTextBox.ScrollToEnd();
                }
            }
        }

        private void ShowOutputText(bool show, bool button = false)
        {
            if (!(Dispatcher.CheckAccess()))
            {
                // Invoke correct thread to update gui
                Dispatcher.Invoke(() => ShowOutputText(show, button));

                return;
            }

            if (show)
            {
                // Change button label
                ErrorButton.Content = ErrorButton.Content.ToString().Replace("Nascondi", "Mostra");
                // Show output text box
                OutputRichTextBox.Visibility = Visibility.Visible;
                ErrorRichTextBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                // Change button label
                ErrorButton.Content = ErrorButton.Content.ToString().Replace("Mostra", "Nascondi");
                // Show error text box
                ErrorRichTextBox.Visibility = Visibility.Visible;
                OutputRichTextBox.Visibility = Visibility.Collapsed;
            }

            if (button)
            {
                // Disable error button
                ErrorButton.IsEnabled = false;
            }
        }

        private void Process_Execution(object sender, EventArgs e, bool clean)
        {
            UpdateComponents();
            // Clean error text box
            UpdateOutputText(clean, error: true);
            // Clean output text box
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

        private void RunnerWindow_Loaded(object sender, EventArgs e)
        {
            if (!Settings.FirstRun)
            {
                // Apply saved location
                Left = Settings.LocationX;
                Top = Settings.LocationY;

                // Apply saved size
                Width = Settings.SizeWidth;
                Height = Settings.SizeHeight;
            }
            else
            {
                // Set first run to false
                Settings.FirstRun = false;
                // Save current size and position
                SaveCurrentSizeAndPosition();
            }

            // Set app in foreground
            Activate();

            // Update GUI
            UpdateComponents();
            UpdateOutputText(true);
            ShowOutputText(true, true);

            // Set windows events
            HwndSource.FromHwnd(new WindowInteropHelper(this).Handle).AddHook(WindowProc);
        }

        private IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0231: // WM_ENTERSIZEMOVE
                    if (Settings.IsSaving)
                    {
                        // Abort save settings
                        Settings.AbortSave();
                    }
                    handled = true;
                    break;
                case 0x0232: // WM_EXITSIZEMOVE
                    // Save current size and position
                    SaveCurrentSizeAndPosition();
                    handled = true;
                    break;
            }

            return IntPtr.Zero;
        }

        private void SaveCurrentSizeAndPosition()
        {
            // Get form size
            Settings.SizeWidth = (int)Width;
            Settings.SizeHeight = (int)Height;

            // Get form location
            Settings.LocationX = (int)Left;
            Settings.LocationY = (int)Top;

            // Start save settings
            Settings.StartSave();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            // Select new file to execute
            if (SettingsWindow.ShowDialog() == true)
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
                        MessageBox.Show(("Impossibile avviare il processo!" + error).Trim(), "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    MessageBox.Show(("Impossibile interrompere il processo!" + error).Trim(), "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ErrorButton_Click(object sender, EventArgs e)
        {
            ShowOutputText(!OutputRichTextBox.IsVisible);
        }
    }
}
