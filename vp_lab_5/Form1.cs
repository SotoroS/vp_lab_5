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

        // Очистка области для отрисовки
        private void buttonClear_Click(object sender, System.EventArgs e)
        {
            mouseBox.ClearDrawPanel();
        }

        /// <summary>
        /// Изменение статуса траектории
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mouseBox_MoveMouseCircularPath(object sender, EventArgs e)
        {
            if (((MouseBoxLib.MouseBox)sender).Status)
            {
                labelStatus.Text = "TRUE";
                labelStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                labelStatus.Text = "FALSE";
                labelStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        /// <summary>
        /// Изменение шага аппроксимации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownStep_Validated(object sender, EventArgs e)
        {
            mouseBox.step = (uint)((NumericUpDown)sender).Value;

        }

        /// <summary>
        /// Изменение значения радиуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownRadius_Validated(object sender, EventArgs e)
        {
            mouseBox.radiusСurvature = (float)((NumericUpDown)sender).Value;
        }

        /// <summary>
        /// Изменение размера точки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownSizePoint_Validated(object sender, EventArgs e)
        {
            mouseBox.sizePoint = (uint)((NumericUpDown)sender).Value;
        }

        /// <summary>
        /// Изменение разрешения на отрисовку траектории
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxTrajectory_CheckedChanged(object sender, EventArgs e)
        {
            mouseBox.isDrawTrajectory = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// Изменение разрешения на отрисовку отрезка AB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxSAB_CheckedChanged(object sender, EventArgs e)
        {
            mouseBox.isDrawAB = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// Изменение разрешения на отрисовку перпендикуляра MK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxPMK_CheckedChanged(object sender, EventArgs e)
        {
            mouseBox.isDrawPMK = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// Изменение разрешения на отрисовку отрезка MK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxSMK_CheckedChanged(object sender, EventArgs e)
        {
            mouseBox.isDrawSMK = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// Изменение разрешения на отрисовку перпендикуляра RO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxPRO_CheckedChanged(object sender, EventArgs e)
        {
            mouseBox.isDrawPRO = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// Изменение разрешения на отрисовку точки A
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxA_CheckedChanged(object sender, EventArgs e)
        {
            mouseBox.isDrawPointA = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// Изменение разрешения на отрисовку точки B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxB_CheckedChanged(object sender, EventArgs e)
        {
            mouseBox.isDrawPointB = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// Изменение разрешения на отрисовку точки M
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxM_CheckedChanged(object sender, EventArgs e)
        {
            mouseBox.isDrawPointM = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// Изменение разрешения на отрисовку точки K
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxK_CheckedChanged(object sender, EventArgs e)
        {
            mouseBox.isDrawPointK = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// Изменение разрешения на отрисовку точки R
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxR_CheckedChanged(object sender, EventArgs e)
        {
            mouseBox.isDrawPointR = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// Изменение разрешения на отрисовку точки O
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxO_CheckedChanged(object sender, EventArgs e)
        {
            mouseBox.isDrawPointO = ((CheckBox)sender).Checked;
        }
    }
}
