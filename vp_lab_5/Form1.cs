using System.Windows.Forms;

namespace vp_lab_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mouseBox_MoveMouseCircularPath(object sender, System.EventArgs e)
        {
            MessageBox.Show("The calculations are complete", "My Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void buttonClear_Click(object sender, System.EventArgs e)
        {
            mouseBox.ClearDrawPanel();
        }
    }
}
