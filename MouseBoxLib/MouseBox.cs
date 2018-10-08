using System;
using System.Windows.Forms;
using System.Drawing;
using MouseBoxLib.lib;
using System.Collections.Generic;

namespace MouseBoxLib
{
    public partial class MouseBox : UserControl
    {
        // Размеры области отрисовки
        private const float height = 300f;
        private const float width = 300f;
        
        /// <summary>
        /// Хранит в себе список делегатов выполняемых при движении курсора мыши по круговой траектории
        /// </summary>
        public event EventHandler MoveMouseCircularPath;

        /// <summary>
        /// Шаг аппроксимации траектории движения мыши
        /// </summary>
        public uint step = 50;

        /// <summary>
        /// Радиус допускаемой кривизны круговой трактории
        /// </summary>
        public float radiusСurvature = 50f;
        

        // Состояния
        public bool isDrawVector = true;
        public bool isDrawRegin = false;

        // Режим рисовки
        private bool isPaintEntry = true;

        // Список точек траектории движения мышки
        private List<PointF> path = new List<PointF>();

        // Графическая зона
        private Graphics g;

        // Точки начала и конца перпендикуляра
        // предыдущего сегмента траетории
        private PointF oldStartX;
        private PointF oldEndX;


        // Создание перьев
        Pen pathPen = new Pen(Color.Blue, 1);
        Pen vectorPen = new Pen(Color.Red, 1);
        Pen perpendicularPen = new Pen(Color.DarkRed, 1);
        Pen circlePen = new Pen(Color.Green, 1);

        // Создание кистей
        SolidBrush gBrush = new SolidBrush(Color.Green);
        SolidBrush bBrush = new SolidBrush(Color.Black);
        SolidBrush grBrush = new SolidBrush(Color.Gray);
        SolidBrush blBrush = new SolidBrush(Color.Blue);

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
            labelCoord.Text = e.Location.ToString();

            // Проверяем можем ли мы рисовать
            if (isPaintEntry && e.Button == MouseButtons.Left)
            {
                // Добавляем позицию мыши в список точек
                path.Add(e.Location);

                // Отрисовка линиии 
                if (path.Count > 2) g.DrawLines(pathPen, path.ToArray());

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

                    // Точка пересечения MK и RO
                    PointF I = GetIntersectionPoint(perpendicularMK.K, perpendicularMK.B, perpendicularRO.K, perpendicularRO.B);

                    // Выводи полученные точки
                    //Console.WriteLine("R({0}; {1}) M({2}; {3}) I({4}; {5})", R.X, R.Y, M.X, M.Y, I.X, I.Y);

                    // Отсрисовка точек M & R
                    g.FillEllipse(gBrush, M.X - 2f, M.Y - 2f, 4, 4);
                    g.FillEllipse(bBrush, R.X - 2f, R.Y - 2f, 4, 4);

                    // Отрисовка точек M, R, intersection
                    g.FillEllipse(grBrush, I.X - 2f, I.Y - 2f, 4, 4);

                    // TODO: Реализовать обрабтку в случае нахождение точек на вертикальной прямой
                    // Если точки совпадают пропускаем этап
                    if (I.X == M.X) return;

                    // Алгоритм определение границ для перпендикуляра
                    // Точка для определения коэффициента для нахождения точки радиуса
                    PointF K1 = new PointF(M.X + ((I.X < M.X) ? (-5f) : (+5f)), perpendicularMK.getY(M.X + ((I.X < M.X) ? (-5f) : (+5f))));

                    float lengthMK1 = (float)Math.Sqrt(((K1.X - M.X) * (K1.X - M.X)) + ((K1.Y - M.Y) * (K1.Y - M.Y)));
                    float k = radiusСurvature / lengthMK1;

                    PointF K = new PointF(
                        M.X - ((K1.X - M.X) * k),
                        perpendicularMK.getY(M.X - ((K1.X - M.X) * k))
                    );

                    // Отрисовываем точку K
                    g.FillEllipse(blBrush, K.X - 2f, K.Y - 2f, 4, 4);

                    //// Отрисовываем перпендикуляр RO
                    //g.DrawLine(circlePen,
                    //    new PointF(0f, perpendicularRO.getY(0f)),
                    //    new PointF(300f, perpendicularRO.getY(300f))
                    //);

                    // Определяем допустимые координаты x для перпендикуляра
                    float startX = (I.X > M.X) ? K.X : M.X;
                    float endX = (I.X > M.X) ? M.X : K.X;

                    // Отрисовываем перпендикуляр MK
                    g.DrawLine(perpendicularPen,
                        new PointF(startX, perpendicularMK.getY(startX)),
                        new PointF(endX, perpendicularMK.getY(endX))
                    );

                    if (!oldStartX.IsEmpty && !oldStartX.IsEmpty &&
                        IntersectionSegments(
                            new PointF(startX, perpendicularMK.getY(startX)), 
                            new PointF(endX, perpendicularMK.getY(endX)),
                            oldStartX,
                            oldEndX))
                    {
                        Console.WriteLine("TRUE");
                    }
                    else
                    {
                        Console.WriteLine("FALSE");
                    }

                    oldStartX = new PointF(startX, perpendicularMK.getY(startX));
                    oldEndX = new PointF(endX, perpendicularMK.getY(endX));

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
        public PointF GetIntersectionPoint(float k1, float b1, float k2, float b2)
        {
            return new PointF((b1 - b2) / (k2 - k1), (((k2 * b1) - (k2 * b2)) / (k2 - k1)) + b2);
        }

        /// <summary>
        /// Проверка на пересечение отрезков AB и CD
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns></returns>
        public bool IntersectionSegments(PointF A, PointF B, PointF C, PointF D)
        {
            float v1 = VectorMultiply(new PointF(D.X - C.X, D.Y - C.Y), new PointF(A.X - C.X, A.Y - C.Y));
            float v2 = VectorMultiply(new PointF(D.X - C.X, D.Y - C.Y), new PointF(B.X - C.X, B.Y - C.Y));
            float v3 = VectorMultiply(new PointF(B.X - A.X, B.Y - A.Y), new PointF(C.X - A.X, C.Y - A.Y));
            float v4 = VectorMultiply(new PointF(B.X - A.X, B.Y - A.Y), new PointF(D.X - A.X, D.Y - A.Y));

            return (v1 * v2) < 0 && (v3 * v4) < 0;
        }

        /// <summary>
        /// Векторное произведение
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public float VectorMultiply(PointF A, PointF B)
        {
            return A.X * B.Y - B.X * A.Y;
        }

    }
}

