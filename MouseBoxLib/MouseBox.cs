using System;
using System.Windows.Forms;
using System.Drawing;
using MouseBoxLib.lib;
using System.Collections.Generic;

namespace MouseBoxLib
{
    public partial class MouseBox : UserControl
    {
        /// <summary>
        /// Хранит в себе список делегатов выполняемых при движении курсора мыши по круговой траектории
        /// </summary>
        public event EventHandler MoveMouseCircularPath;

        // Шаг определения круговой траектории
        public uint step = 50;

        // Состояния
        public bool isDrawVector = true;
        public bool isDrawRegin = false;

        // Режим рисовки
        private bool isPaintEntry = true;

        // Траектория движения мышки
        private List<PointF> path = new List<PointF>();

        // Графическая зона
        private Graphics g;


        // Создание перьев
        Pen pathPen = new Pen(Color.Blue, 1);
        Pen vectorPen = new Pen(Color.Red, 1);
        Pen perpendicularPen = new Pen(Color.DarkRed, 1);
        Pen circlePen = new Pen(Color.Green, 1);

        // Создание кистей
        SolidBrush gBrush = new SolidBrush(Color.Green);
        SolidBrush bBrush = new SolidBrush(Color.Black);
        SolidBrush grBrush = new SolidBrush(Color.Gray);

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
            // Проверяем можем ли мы рисовать
            if (isPaintEntry && e.Button == MouseButtons.Left)
            {
                // Очищаем предыдущие линиии
                if (path.Count == 0) ClearDrawPanel();

                // Добавляем позицию мыши в список точек
                path.Add(e.Location);

                // Отрисовка линиии 
                if (path.Count > 2) g.DrawLines(pathPen, path.ToArray());

                // Каждые 10 точеку
                if (path.Count % step == 0)
                {
                    // Рисуем вектор из точки начала к последней точке линии
                    if (isDrawVector) g.DrawLine(vectorPen, path[path.Count - (int)step], path[path.Count - 1]);

                    // Рабочая область AB
                    PointF A = path[path.Count - (int)step];
                    PointF B = path[path.Count - 1];

                    // Средняя точка R траектории AB
                    PointF R = path[path.Count - ((int)step / 2)];

                    // Точка M по середине отрезка AB
                    PointF M = new PointF((A.X + B.X) / 2f, (A.Y + B.Y) / 2f);

                    // Прямая AB
                    Straight straightAB = new Straight(A.X, A.Y, B.X, B.Y);

                    // Перпендикуляр к прямой AB в точке M
                    Perpendicular perpendicularMK = new Perpendicular(M.X, M.Y, straightAB.K);

                    // Перпендикуляр к перпендикуляру MK в точке R
                    Perpendicular perpendicularRO = new Perpendicular(R.X, R.Y, perpendicularMK.K);

                    // Отрисовываем перпендикуляр MK
                    g.DrawLine(perpendicularPen,
                        new PointF(0f, perpendicularMK.getY(0f)),
                        new PointF(300f, perpendicularMK.getY(300f))
                    );

                    // Отрисовываем перпендикуляр RO
                    g.DrawLine(circlePen,
                        new PointF(0f, perpendicularRO.getY(0f)),
                        new PointF(300f, perpendicularRO.getY(300f))
                    );

                    PointF intersection = Intersection(perpendicularMK.K, perpendicularMK.B, perpendicularRO.K, perpendicularRO.B);

                    // Отрисовка точек M, R, intersection
                    g.FillEllipse(gBrush, M.X, M.Y, 5, 5);
                    g.FillEllipse(bBrush, R.X, R.Y, 5, 5);
                    g.FillEllipse(grBrush, intersection.X, intersection.Y, 5, 5);
                }
            }
        }

        // Курсор вышел за края рабочей зоны
        private void drawPanel_MouseLeave(object sender, EventArgs e)
        {
            // Выключаем режим рисования
            isPaintEntry = false;
            // Очищаем линию
            path.Clear();
        }

        // Курсор вернулся в рабочую зону
        private void drawPanel_MouseEnter(object sender, EventArgs e)
        {
            // Включаем режим рисования
            isPaintEntry = true;
        }

        /// <summary>
        /// Очистка панели для рисования
        /// </summary>
        public void ClearDrawPanel()
        {
            g.Clear(SystemColors.Control);
        }

        /// <summary>
        /// Точка пересечения двух прямых
        /// </summary>
        /// <param name="k1"></param>
        /// <param name="b1"></param>
        /// <param name="k2"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public PointF Intersection(float k1, float b1, float k2, float b2)
        {
            return new PointF((b1 - b2) / (k2 - k1), (((k2 * b1) - (k2 * b2)) / (k2 - k1)) + b2);
        }

    }
}

