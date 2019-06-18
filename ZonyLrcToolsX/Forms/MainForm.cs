using System.Windows.Forms;
using ZonyLrcToolsX.Forms;

namespace ZonyLrcToolsX
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ToolStripButton_About_Click(object sender, System.EventArgs e) => new AboutForm().ShowDialog();

        private void ToolStripButton_Config_Click(object sender, System.EventArgs e) => new ConfigForm().ShowDialog();
    }
}