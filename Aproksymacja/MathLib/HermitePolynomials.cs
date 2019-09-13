using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aproximation.MathLib
{
    class HermitePolynomials : IEnumerable<Func<double,double>>
    {
        private List<Func<double, double>> Polynomials { get; set; }

        public HermitePolynomials()
        {
            Polynomials = new List<Func<double, double>>();
            Polynomials.Add(delegate (double x)
           {
               return 1;
           });
            Polynomials.Add(delegate (double x)
            {
                return 2 * x;
            });
        }

        public void UpTo(int degree)
        {
            for (int i = Polynomials.Count; i <= degree; i++)
            {
                calculateNext(i);
            }
        }

        public void calculateNext(int degree)
        {
            Func<double, double> polynomial = delegate (double x)
             {
                 var result = 2 * x * Polynomials[degree - 1](x) - 2 * (degree - 1) * Polynomials[degree - 2](x);
                 return result;
             };
            Polynomials.Add(polynomial);
        }

        public Func<double, double> this[int index] {
            get
            {
                if(0 <= index && index < Polynomials.Count)
                {
                    return Polynomials[index];
                }
                else
                {
                    for (int i = Polynomials.Count; i <= index; i++)
                    {
                        calculateNext(i);
                    }
                    return Polynomials[index];
                }
            }
        }
        public IEnumerator<Func<double, double>> GetEnumerator()
        {
            return ((IEnumerable<Func<double, double>>)Polynomials).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Func<double, double>>)Polynomials).GetEnumerator();
        }
    }
}
