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
        private Graphics g;         // Графическая зона
        private Graphics gInfo;     // Информационная графическая зона

        public bool isDrawVector = true;
        public bool isDrawRegin = false;

        private bool isPaintEntry = true; // Режим рисовки

        // Создание кисти
        Pen linePen = new Pen(Color.Blue, 3);
        Pen vectorPen = new Pen(Color.Red, 3);
        Pen perpendicularPen = new Pen(Color.DarkRed, 3);
        Pen circlePen = new Pen(Color.Green, 3);

        SolidBrush gBrush = new SolidBrush(Color.Green);
        SolidBrush bBrush = new SolidBrush(Color.Black);
        SolidBrush grBrush = new SolidBrush(Color.Gray);



        // Линия
        private Line line = new Line();

        /// <summary>
        /// Хранит в себе список делегатов выполняемых при движении курсора мыши по круговой траектории
        /// </summary>
        public event EventHandler MoveMouseCircularPath;

        // Шаг определения круговой траектории
        public uint step = 50;

        public MouseBox()
        {
            InitializeComponent();

            // Инициализация графической области
            g = drawPanel.CreateGraphics();
            //gInfo = InfoPanel.CreateGraphics();
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

                // Добавляем позицию мыши в список точек
                line.points.Add(e.Location);

                // Отрисовка линиии 
                if (line.points.Count > 2)
                    g.DrawLines(linePen, line.points.ToArray());

               // Каждые 10 точеку
                if (line.points.Count % step == 0)
                {
                    // Рисуем вектор из точки начала к последней точке линии
                    if (isDrawVector) g.DrawLine(vectorPen, line.points[line.points.Count - (int)step], line.points[line.points.Count - 1]);

                    PointF A = line.points[line.points.Count - (int)step];
                    PointF B = line.points[line.points.Count - 1];

                    // Точка по середине апроксимации
                    PointF M = new PointF((A.X + B.X) / 2f, (A.Y + B.Y) / 2f);

                    // Средняя точка траектории
                    PointF R = line.points[line.points.Count - (int)step / 2];

                    // Уравнение прямой с угловым коэффициентом y = a * x + b
                    float a = -(A.Y - B.Y) / (B.X - A.X);
                    float b = -((A.X * B.Y) - (B.X * A.Y)) / (B.X - A.X);

                    // Уравнение прмяой парралельной основной прямой y = c * x + d
                    //float d = a;
                    //float c = 

                    //// Строим параллельную прямую
                    //PointF P = new PointF(R.X, (a * (M.X - R.X)) + R.Y);

                    //// Перпендикуляр
                    //Line stright = new Line();

                    //// Формируем ограничения для перпендикуляра
                    //float perpendicularStartX = ((P.X > M.X && P.Y > M.Y) || (P.X > M.X && P.Y < M.Y)) ? 0 : M.X;
                    //float perpendicularEndX = ((P.X < M.X && P.Y < M.Y) || (P.X < M.X && P.Y > M.Y)) ? 300 : M.X;

                    // Создаем перпендикуляр
                    //for (float x = perpendicularStartX; x < perpendicularEndX; x++)
                    //    if (a != 0) stright.points.Add(new PointF(x, (-(1f / a) * (x - M.X)) + M.Y));

                    //// Строим перпендикуляры
                    //if (stright.points.Count > 2) g.DrawLines(perpendicularPen, stright.points.ToArray());

                    //// Отрисовка точек M и R
                    //g.FillEllipse(gBrush, M.X, M.Y, 5, 5);
                    //g.FillEllipse(bBrush, R.X, R.Y, 5, 5);
                    //g.FillEllipse(grBrush, P.X, P.Y, 5, 5);

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
            //gInfo.Clear(SystemColors.Control);
        }
    }
}
