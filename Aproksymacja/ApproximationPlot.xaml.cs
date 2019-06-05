using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aproksymacja
{
    /// <summary>
    /// Logika interakcji dla klasy ApproximationPlot.xaml
    /// </summary>
    public partial class ApproximationPlot : UserControl
    {
        public ChartValues<ObservablePoint> FunctionValues { get; set; }
        public ChartValues<ObservablePoint> ApproximatedFunctionValues { get; set; }

        public ApproximationPlot()
        {
            InitializeComponent();
            DataContext = this;
        }
        public void Update()
        {
            Function.Values = FunctionValues;
            ApproximatedFunction.Values = ApproximatedFunctionValues;
        }
        
    }
}
