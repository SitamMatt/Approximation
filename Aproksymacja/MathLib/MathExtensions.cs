using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aproksymacja.MathLib
{
    public static class MathExtensions
    {
        public static double Factorial(int number)
        {
            if (number == 0) return 1;
            double result = 1;
            while (number != 1)
            {
                result = result * number;
                number = number - 1;
            }
            return result;
        }
    }
}