using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aproximation.MathLib
{
    class Approximation
    {
        private readonly Func<double, double> _Result;
        private readonly double[] _Factors;
        private readonly HermitePolynomials _Polynomials;
        private readonly double m;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="factors"></param>
        /// <param name="polynomials"></param>
        /// <param name="m">degree of the resultant polynomial</param>
        public Approximation(double[] factors, HermitePolynomials polynomials, double degree)
        {
            _Factors = factors;
            _Polynomials = polynomials;
            m = degree;
        }

        public Func<double, double> GetResult()
        {
            double resultantFun(double x)
            {
                double result = 0;
                for (int k = 0; k < m; k++)
                {
                    double factor = _Factors[k];
                    double poly = _Polynomials[k](x);
                    result += factor * poly;
                }
                return result;
            }
            return resultantFun;
        }
    }
}
