namespace MouseBoxLib.lib
{
    /// <summary>
    /// Прямая y = kx + b
    /// </summary>
    public class Straight
    {
        private float k, b;

        public float K {
            get
            {
                return k;
            }
        }

        public float B {
            get
            {
                return b;
            }
        }

        /// <summary>
        /// Конструктор прямой по двум точкам
        /// </summary>
        /// <param name="x1">Координата x точки A(x, y)</param>
        /// <param name="y1">Координата y точки A(x, y)</param>
        /// <param name="x2">Координата x точки B(x, y)</param>
        /// <param name="y2">Координата y точки B(x, y)</param>
        public Straight(float x1, float y1, float x2, float y2)
        {
            k = -((y1 - y2) / (x2 - x1));
            b = -(((x1 * y2) - (x2 - y1)) / (x2 - x1));
        }

        /// <summary>
        /// Конструктор прямой
        /// </summary>
        /// <param name="k">Угловой коэффициент</param>
        /// <param name="b">Свободный коэффициент</param>
        public Straight(float k, float b)
        {
            this.k = k;
            this.b = b;
        }

        /// <summary>
        /// Получение y координаты прямой в точке x
        /// </summary>
        /// <param name="x">Координата x</param>
        /// <returns>Координата y</returns>
        public float getY(float x)
        {
            return k * x + b;
        }

    }
}
