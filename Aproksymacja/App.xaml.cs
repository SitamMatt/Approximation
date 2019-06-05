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
                    // uzupełnić o potrzebne funkcje
                    //case 1:
                    //    function = Example.Polynomial;
                    //    break;
                    //case 2:
                    //    function = Example.Sinus;
                    //    break;
                    //case 3:
                    //    function = Example.Absolute;
                    //    break;
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



            /// end
            /// 

            // wartości funkcji aproksymowanej - po prostu lista lub tablica wartości (x,y)
            ChartValues<ObservablePoint> fun = new ChartValues<ObservablePoint>();
            // wartości funkcji aproksymującej
            ChartValues<ObservablePoint> approximation = new ChartValues<ObservablePoint>(); 
            for (int i = 0; i <= 255; i++)
            {
                fun.Add(new ObservablePoint(i, Fun(i))); // wypełnianie listy wartościami (x,y)
                approximation.Add(new ObservablePoint(i, Afun(i)));
            }

            MainWindow window = new MainWindow();
            window.Plot.FunctionValues = fun;
            window.Plot.ApproximatedFunctionValues = approximation;
            window.Plot.Update(); // rysowanie wykresu
            window.Show();
        }

        double Fun(double x)
        {
            return Math.Sin(x);
        }

        double Afun(double x)
        {
            return x * x;
        }
    }
}
