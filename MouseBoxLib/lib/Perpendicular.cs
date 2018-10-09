using System;
using System.Drawing;

namespace MouseBoxLib.lib
{
    public class Perpendicular
    {
        private static int count = 0;

        private float k, x, y;

        /// <summary>
        /// Получение k компоненты перпендикулярной прямой
        /// </summary>
        public float K {
            get
            {
                return (getY(x + 5) - y) / 5;
            }
        }

        /// <summary>
        /// Получение b компоненты перепендикулярной прямой
        /// </summary>
        public float B {
            get
            {
                return (((x + 5) * y) - (x * getY(x + 5))) / 5;
            }
        }

        /// <summary>
        /// Конструктор перпендикуляра
        /// </summary>
        /// <param name="x">Координата x точки M(x, y), через которую будет построен перпендикуляр</param>
        /// <param name="y">Координата y точки M(x, y), через которую будет построен перпендикуляр</param>
        /// <param name="k">Угловой коэффициент k прямой, для которой строиться перпендикуляр</param>
        public Perpendicular(float x, float y, float k)
        {
            this.x = x;
            this.y = y;
            this.k = k;
        }

        /// <summary>
        /// Получение значения координаты y перпендикуляра по x
        /// </summary>
        /// <param name="x">Координата x</param>
        /// <returns>Координата y</returns>
        public float getY(float x)
        {
            //Console.WriteLine("{0}: x - {1}, k - {2}, this.x - {3}, y - {4}, res - {5}", count++, x, k, this.x, y, (-(1 / k) * (x - this.x)) + y);
            return (k == 0) ? this.x : (-(1 / k) * (x - this.x)) + y;
        }

        /// <summary>
        /// Получение значения координаты y перпендикуляра по y
        /// </summary>
        /// <param name="y">Координата y</param>
        /// <returns>Координата y</returns>
        public float getX(float y)
        {
            return x - k * (y - this.y);
        }
    }
}
