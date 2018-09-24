using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using MouseBoxLib.lib;

namespace MouseBoxLib
{
    public partial class MouseBox: UserControl
    {
        Graphics g; // Графическая зона
        bool isDrawing; // Режим рисовки

        // Создание кисти
        Pen linePen = new Pen(Color.Blue, 1);
        Pen vectorPen = new Pen(Color.Red, 1);

        // Линия
        private Line line = new Line();

        /// <summary>
        /// Хранит в себе список делегатов выполняемых при движении курсора мыши по круговой траектории
        /// </summary>
        public event EventHandler MoveMouseCircularPath;

        public uint stepDrawingVector = 10;

        /// <summary>
        /// Метод обрабатывающий выполняющий делегаты, подписанных на событие moveMouseCircularPath
        /// </summary>
        /// <param name="e">Аргументы события</param>
        protected virtual void OnMoveMouseCircularPath(MouseEventArgs e)
        {
            // Проверка на пустату списка делегатов подписанных на это событие
            if (MoveMouseCircularPath != null)
                MoveMouseCircularPath(this, e);
        }

        public MouseBox()
        {
            InitializeComponent();

            // Инициализация графической области
            g = drawPanel.CreateGraphics(); 
        }

        /// <summary>
        /// Очистка панели для рисования
        /// </summary>
        public void ClearDrawPanel()
        {
            g.Clear(SystemColors.Control);
        }

        /// <summary>
        /// Алгорит распознавания круговых движений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                // Отображаем координаты курсора
                labelCoord.Text = "X: " + e.Location.X + " Y: " + e.Location.Y;

                line.points.Add(e.Location);

                // Отрисовка линиии 
                if (line.points.Count > 2)
                    g.DrawLines(linePen, line.points.ToArray());

               // Каждые 10 точеку
                if (line.points.Count % stepDrawingVector == 0)
                {
                    GraphicsPath path = new GraphicsPath();

                    path.AddCurve(line.points.ToArray());

                    Region r = new Region(path);

                    //g.FillRegion(Brushes.Aqua, r);

                    g.DrawLine(vectorPen, line.points[0], line.points[line.points.Count - 1]);
                }
            }
        }

        // Курсор вышел за края рабочей зоны
        private void drawPanel_MouseLeave(object sender, EventArgs e)
        {
            isDrawing = false; // Выключаем режим рисования
            line.points.Clear(); // Очищаем линию
        }

        // Курсор вернулся в рабочую зону
        private void drawPanel_MouseEnter(object sender, EventArgs e)
        {
            isDrawing = true;   // Включаем режим рисования
        }
    }
}
