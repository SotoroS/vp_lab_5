using System;
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

        // Очистка области для отрисовки
        private void buttonClear_Click(object sender, System.EventArgs e)
        {
            mouseBox.ClearDrawPanel();
        }

        // Переключатель режима отрисовки вектора
        private void buttonDrawVectorTrigger_Click(object sender, System.EventArgs e)
        {
            if (mouseBox.isDrawVector)
            {
                mouseBox.isDrawVector = false;
                buttonDrawVectorTrigger.Text = "Включить отрисовку векторов";
            }
            else
            {
                mouseBox.isDrawVector = true;
                buttonDrawVectorTrigger.Text = "Выключить отрисовку векторов";
            }
        }

        // Переключатель режима отрисовки региона
        private void buttonDrawRegionTrigger_Click(object sender, System.EventArgs e)
        {
            if (mouseBox.isDrawRegin)
            {
                mouseBox.isDrawRegin = false;
                buttonDrawRegionTrigger.Text = "Включить отрисовку регионов";
            }
            else
            {
                mouseBox.isDrawRegin = true;
                buttonDrawRegionTrigger.Text = "Выключить отрисовку регионов";
            }
        }

        // Изменение шага индетификации круговой траектории
        private void buttonChangeStep_Click(object sender, System.EventArgs e)
        {
            mouseBox.step = Convert.ToUInt32(textBoxStep.Text);
        }
    }
}
