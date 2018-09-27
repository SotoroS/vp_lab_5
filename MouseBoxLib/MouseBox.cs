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
        private Graphics g; // Графическая зона

        public bool isDrawVector = false;
        public bool isDrawRegin = false;

        private bool isPaintEntry = true; // Режим рисовки

        // Создание кисти
        Pen linePen = new Pen(Color.Blue, 1);
        Pen vectorPen = new Pen(Color.Red, 1);
        Pen perpendicularPen = new Pen(Color.DarkRed, 1);
        Pen circlePen = new Pen(Color.Green, 1);


        // Линия
        private Line line = new Line();

        /// <summary>
        /// Хранит в себе список делегатов выполняемых при движении курсора мыши по круговой траектории
        /// </summary>
        public event EventHandler MoveMouseCircularPath;

        // Шаг определения круговой траектории
        public uint step = 10;

        public MouseBox()
        {
            InitializeComponent();

            // Инициализация графической области
            g = drawPanel.CreateGraphics(); 
        }

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

        /// <summary>
        /// Алгорит распознавания круговых движений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPaintEntry)
            {
                // Отображаем координаты курсора
                labelCoord.Text = "X: " + e.Location.X + " Y: " + e.Location.Y;

                line.points.Add(e.Location);

                // Отрисовка линиии 
                if (line.points.Count > 2)
                    g.DrawLines(linePen, line.points.ToArray());

               // Каждые 10 точеку
                if (line.points.Count % step == 0)
                {
                    GraphicsPath path = new GraphicsPath();

                    path.AddCurve(line.points.ToArray());

                    Region r = new Region(path);

                    // Закрашиваем регион 
                    if (isDrawRegin) g.FillRegion(Brushes.Aqua, r);

                    // Рисуем вектор из точки начала круга к последней точке линии
                    if (isDrawVector) g.DrawLine(vectorPen, line.points[line.points.Count - (int)step], line.points[line.points.Count - 1]);

                    PointF A = line.points[line.points.Count - (int)step];
                    PointF B = line.points[line.points.Count - 1];

                    // Точка по середине апроксимации
                    PointF M = new PointF((A.X + B.X) / 2f, (A.Y + B.Y) / 2f);

                    // Точка по середине траектории
                    PointF R = line.points[line.points.Count - (int)step / 2];

                    SolidBrush brush = new SolidBrush(Color.Green);

                    // Отрисовываем точку
                    g.FillEllipse(brush, M.X, M.Y, 5, 5);

                    // Общее уравнение прямой  a * x + b * y + c = 0
                    float a = A.Y - B.Y;
                    float b = B.X - A.X;
                    float c = (A.X * B.Y) - (B.X * A.Y);

                    // Уравнение прямой с угловым коэффициентом y = k * x + d
                    float k = -a / b;
                    float d = -c / b;

                    Line stright = new Line();

                    float perpendicularStartX = (M.X > R.X) ? M.X : 0;
                    float perpendicularEndX = (R.X > M.X) ? M.X : 300;

                    for (float x = perpendicularStartX; x < perpendicularEndX; x++)
                    {
                        if (k != 0)
                            stright.points.Add(new PointF(x, (- (1f / k) * (x - M.X)) + M.Y));
                    }

                    if (stright.points.Count > 2)
                        g.DrawLines(perpendicularPen, stright.points.ToArray());


                }
            }
        }

        // Курсор вышел за края рабочей зоны
        private void drawPanel_MouseLeave(object sender, EventArgs e)
        {
            isPaintEntry = false; // Выключаем режим рисования
            line.points.Clear(); // Очищаем линию
        }

        // Курсор вернулся в рабочую зону
        private void drawPanel_MouseEnter(object sender, EventArgs e)
        {
            isPaintEntry = true;   // Включаем режим рисования
        }

        /// <summary>
        /// Очистка панели для рисования
        /// </summary>
        public void ClearDrawPanel()
        {
            g.Clear(SystemColors.Control);
        }
    }
}
