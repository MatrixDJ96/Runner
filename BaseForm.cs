using System.Drawing;
using System.Windows.Forms;

namespace Runner
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();

            // Scale font in all controls
            ScaleFontControl(this, null);

            // Set application icon to form
            Icon = Program.ExecutableIcon;
        }

        private void ScaleFontControl(Control control, Control parent)
        {
            if (control.Font != parent?.Font)
            {
                // Update font control scaling size by device dpi
                control.Font = new Font(control.Font.Name, control.Font.Size * control.DeviceDpi / 96);
            }

            foreach (Control item in control.Controls)
            {
                // Recursive call for all children controls
                ScaleFontControl(item, control);
            }
        }
    }
}
