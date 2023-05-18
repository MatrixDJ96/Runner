using System;
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
        }
    }
}
