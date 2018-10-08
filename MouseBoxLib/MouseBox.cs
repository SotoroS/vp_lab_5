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

        /// <summary>
        /// Шаг аппроксимации траектории движения мыши
        /// </summary>
        public uint step = 50;

        /// <summary>
        /// Размер точек
        /// </summary>
        public uint sizePoint = 5;

        /// <summary>
        /// Радиус допускаемой кривизны круговой трактории
        /// </summary>
        public float radiusСurvature = 50f;

        // Разрешение на отрисовку траектории движения курсора мыши
        public bool isDrawTrajectory = true;
        // Разрешение на отрисовку отрезка AB
        public bool isDrawAB = true;
        // Разрешение на отрисовку перпендикуляра MK
        public bool isDrawPMK = false;
        // Разрешение на отрисовку отрезка MK
        public bool isDrawSMK = false;
        // Разрешение на отрисовку перпендикуляра MK
        public bool isDrawPRO = false;

        // Разрешение на отрисовку точки A
        public bool isDrawPointA = false;
        // Разрешение на отрисовку точки B
        public bool isDrawPointB = false;
        // Разрешение на отрисовку точки M
        public bool isDrawPointM = false;
        // Разрешение на отрисовку точки K
        public bool isDrawPointK = false;
        // Разрешение на отрисовку точки R
        public bool isDrawPointR = false;
        // Разрешение на отрисовку точки O
        public bool isDrawPointO = false;

        // Размеры области отрисовки
        private const float height = 300f;
        private const float width = 300f;

        // Режим рисовки
        private bool isPaintEntry = true;

        // Список точек траектории движения мышки
        private List<PointF> path = new List<PointF>();

        // Графическая зона
        private Graphics g;

        // Точки начала и конца перпендикуляра
        // предыдущего сегмента траетории
        private PointF oldStartpointMK;
        private PointF oldEndPointMK;

        // Создание перьев
        private Pen bPen = new Pen(Color.Blue, 1);
        private Pen blPen = new Pen(Color.Black, 1);
        private Pen rPen = new Pen(Color.Red, 1);
        private Pen drPen = new Pen(Color.DarkRed, 1);
        private Pen dsgPen = new Pen(Color.DarkSeaGreen, 1);
        private Pen gPen = new Pen(Color.Green, 1);

        // Создание кистей
        private SolidBrush rBrush = new SolidBrush(Color.Red);
        private SolidBrush gBrush = new SolidBrush(Color.Green);
        private SolidBrush bBrush = new SolidBrush(Color.Black);
        private SolidBrush grBrush = new SolidBrush(Color.Gray);
        private SolidBrush blBrush = new SolidBrush(Color.Blue);

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
            // Отображаем координаты позиции курсора мыши
            labelCoord.Text = e.Location.ToString();

            // Проверяем можем ли мы рисовать
            if (isPaintEntry && e.Button == MouseButtons.Left)
            {
                // Добавляем позицию мыши в список точек
                path.Add(e.Location);

                // Отрисовка траектории движения курсора мыши 
                if (isDrawTrajectory && path.Count > 2) g.DrawLines(blPen, path.ToArray());

                // Проводим вычисления с заданной точночтью аппроксимации
                if (path.Count % step == 0)
                {
                    ///
                    /// Инициализация
                    ///

                    // Аппроксимация сегмента AB траекториии движения курсора мыши 
                    PointF A = path[path.Count - (int)step];
                    PointF B = path[path.Count - 1];

                    // Средняя точка R сегмента AB траектории движения курсора мыши
                    PointF R = path[path.Count - ((int)step / 2)];

                    // Точка M - середина отрезка AB
                    PointF M = new PointF((A.X + B.X) / 2f, (A.Y + B.Y) / 2f);

                    // Прямая AB
                    Straight straightAB = new Straight(A.X, A.Y, B.X, B.Y);

                    // Перпендикуляр к прямой AB в точке M
                    Perpendicular perpendicularMK = new Perpendicular(M.X, M.Y, straightAB.K);

                    // Перпендикуляр к прмяой MK в точке R
                    Perpendicular perpendicularRO = new Perpendicular(R.X, R.Y, perpendicularMK.K);

                    // Точка пересечения MK и RO
                    PointF O = GetIntersectionPoint(perpendicularMK.K, perpendicularMK.B, perpendicularRO.K, perpendicularRO.B);

                    // Если точки совпадают пропускаем итерацию
                    if (O.X == M.X) return;

                    // Точка для определения коэффициента для нахождения точки радиуса
                    PointF K1 = new PointF(M.X + ((O.X < M.X) ? (-5f) : (+5f)), perpendicularMK.getY(M.X + ((O.X < M.X) ? (-5f) : (+5f))));

                    // Вычисляем длину отрезка MK1
                    float lengthMK1 = (float)Math.Sqrt(((K1.X - M.X) * (K1.X - M.X)) + ((K1.Y - M.Y) * (K1.Y - M.Y)));

                    // Вычисляем отношение длин MK к MK1
                    float k = radiusСurvature / lengthMK1;

                    // Вычисляем координаты точки K
                    PointF K = new PointF(
                        M.X - ((K1.X - M.X) * k),
                        perpendicularMK.getY(M.X - ((K1.X - M.X) * k))
                    );

                    // Определяем допустимые координаты x для перпендикуляра
                    PointF startPointMK = new PointF();
                    startPointMK.X = Math.Min(K.X, M.X);
                    startPointMK.Y = perpendicularMK.getY(startPointMK.X);

                    PointF endPointMK = new PointF();
                    endPointMK.X = Math.Max(K.X, M.X);
                    endPointMK.Y = perpendicularMK.getY(endPointMK.X);

                    if (!oldStartpointMK.IsEmpty && !oldStartpointMK.IsEmpty &&
                        IntersectionSegments(startPointMK, endPointMK, oldStartpointMK, oldEndPointMK))
                    {
                        Console.WriteLine("TRUE");
                    }
                    else
                    {
                        Console.WriteLine("FALSE");
                    }

                    oldStartpointMK = startPointMK;
                    oldEndPointMK = endPointMK;

                    ///
                    /// Отрисовка
                    /// 

                    // Отрисовываем отрезок AB
                    if (isDrawAB) g.DrawLine(rPen, A, B);

                    // Отрисовка прямой MK
                    if (isDrawPMK) g.DrawLine(dsgPen,
                        new PointF(0f, perpendicularMK.getY(0f)),
                        new PointF(300f, perpendicularMK.getY(300f))
                    );

                    // Отрисовываем отрезок MK
                    if (isDrawSMK) g.DrawLine(gPen, startPointMK, endPointMK);

                    // Отрисовываем перпендикуляр RO
                    if (isDrawPRO) g.DrawLine(bPen,
                        new PointF(0f, perpendicularRO.getY(0f)),
                        new PointF(300f, perpendicularRO.getY(300f))
                    );

                    // Отсрисовка точек M & R
                    if (isDrawPointA) g.FillEllipse(rBrush, A.X - ((float)sizePoint / 2f), A.Y - ((float)sizePoint / 2f), sizePoint, sizePoint);
                    if (isDrawPointB) g.FillEllipse(rBrush, B.X - ((float)sizePoint / 2f), B.Y - ((float)sizePoint / 2f), sizePoint, sizePoint);
                    if (isDrawPointM) g.FillEllipse(rBrush, M.X - ((float)sizePoint / 2f), M.Y - ((float)sizePoint / 2f), sizePoint, sizePoint);
                    if (isDrawPointR) g.FillEllipse(bBrush, R.X - ((float)sizePoint / 2f), R.Y - ((float)sizePoint / 2f), sizePoint, sizePoint);
                    if (isDrawPointO) g.FillEllipse(gBrush, O.X - ((float)sizePoint / 2f), O.Y - ((float)sizePoint / 2f), sizePoint, sizePoint);
                    if (isDrawPointK) g.FillEllipse(gBrush, K.X - ((float)sizePoint / 2f), K.Y - ((float)sizePoint / 2f), sizePoint, sizePoint);
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

