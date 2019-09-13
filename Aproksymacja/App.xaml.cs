using Aproksymacja.MathLib;
using Aproximation.MathLib;
using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Aproksymacja
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Func<double, double> function = null;
            {
                int funSelection = 0;
                bool isParsable = false;
                bool isBetween = false;
                do
                {
                    Console.WriteLine("Wybierz wariant funkcji do całkowania:");
                    Console.WriteLine("(1). f(x) = 4x^4 -2x^3 + 4x^2 -4x +1 ");
                    Console.WriteLine("(2). f(x) = 4sin(2x) ");
                    Console.WriteLine("(3). f(x) = 2|x^3|");
                    isParsable = Int32.TryParse(Console.ReadLine(), out funSelection);
                    isBetween = funSelection.IsBetween(1, 3);
                } while (!(isParsable && isBetween));
                switch (funSelection)
                {
                    case 1:
                        function = Example.Polynomial;
                        break;
                    case 2:
                        function = Example.Sinus;
                        break;
                    case 3:
                        function = Example.Absolute;
                        break;
                }
            }

            double a, b;
            {
                bool isNumber = false;
                bool isCorrect = false;
                do
                {
                    Console.WriteLine("Określ przedziały całkowania:");
                    Console.Write("a:");
                    isNumber = double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out a);
                    Console.Write("b:");
                    isNumber = double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out b);
                    isCorrect = a < b;
                } while (!isNumber || !isCorrect);
            }

            int polynomialDegree;
            {
                bool isDegreeCorrect = false;
                do
                {
                    Console.Write("Określ stopień wielomianu aproksymującego: ");
                    isDegreeCorrect = int.TryParse(Console.ReadLine(), out polynomialDegree);
                } while (!isDegreeCorrect);
            }

            ///
            /// oblicanie funkcji aproksymującej
            ///
            HermitePolynomials hermites = new HermitePolynomials();
            double[] factors = new double[polynomialDegree + 1];
            for (int i = 0; i <= polynomialDegree; i++)
            {
                double fun(double x)
                {
                    return function(x) * hermites[i](x);
                }
                double integral = new Gauss_Hermite(fun, 0.00001).GetResult();
                factors[i] = integral / (Math.Pow(2, i) * MathExtensions.Factorial(i) * Math.Sqrt(Math.PI));
            }
            Approximation approximationResult = new Approximation(factors, hermites, polynomialDegree);
            Func<double, double> approximatedFunction = approximationResult.GetResult();
            /// end
            ///

            ChartValues<ObservablePoint> functionPoints = new ChartValues<ObservablePoint>();
            ChartValues<ObservablePoint> approximatedFunctionPoints = new ChartValues<ObservablePoint>();
            for (double i = a; i <= b; i++)
            {
                functionPoints.Add(new ObservablePoint(i, function(i))); // wypełnianie listy wartościami (x,y)
                approximatedFunctionPoints.Add(new ObservablePoint(i, approximatedFunction(i)));
            }

            MainWindow window = new MainWindow();
            window.Plot.FunctionValues = functionPoints;
            window.Plot.ApproximatedFunctionValues = approximatedFunctionPoints;
            window.Plot.Update(); // rysowanie wykresu
            window.Show();
        }
    }
}