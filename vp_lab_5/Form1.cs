using System;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace vp_lab_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //AllocConsole();
        }

        private void mouseBox_MoveMouseCircularPath(object sender, System.EventArgs e)
        {
        }

        // Очистка области для отрисовки
        private void buttonClear_Click(object sender, System.EventArgs e)
        {
            mouseBox.ClearDrawPanel();
        }


        // Изменение шага индетификации круговой траектории
        private void buttonChangeStep_Click(object sender, System.EventArgs e)
        {
            mouseBox.step = Convert.ToUInt32(textBoxStep.Text);
        }



        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FreeConsole();
    }
}
