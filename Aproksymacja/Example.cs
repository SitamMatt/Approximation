using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Aproksymacja
{
    public static class Example
    {
        public static double Polynomial(double x)
        {
            return 4 * Pow(x, 4) - 2 * Pow(x, 3) + 4 * Pow(x, 2) - 4 * x + 1;
        }

        public static double Sinus(double x)
        {
            return 4 * Sin(2 * x);
        }

        public static double Absolute(double x)
        {
            return 2 * Abs(Pow(x, 3));
        }
    }
}