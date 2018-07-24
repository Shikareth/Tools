using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Tools.Controls
{
    /// <summary>
    /// Interaction logic for Chart.xaml
    /// </summary>
    public partial class Chart : UserControl
    {
        internal DependencyProperty DatasetsProperty = DependencyProperty.Register("Datasets", typeof(IEnumerable<Polyline>), typeof(Chart), new PropertyMetadata(new List<Polyline>(), GetBounds));
        DependencyProperty XMinProperty = DependencyProperty.Register("XMin", typeof(double), typeof(Chart), new PropertyMetadata(0.0));
        DependencyProperty YMinProperty = DependencyProperty.Register("YMin", typeof(double), typeof(Chart), new PropertyMetadata(0.0));
        DependencyProperty XMaxProperty = DependencyProperty.Register("XMax", typeof(double), typeof(Chart), new PropertyMetadata(1.0));
        DependencyProperty YMaxProperty = DependencyProperty.Register("YMax", typeof(double), typeof(Chart), new PropertyMetadata(1.0));

        DependencyProperty IsAutoScaleOnProperty = DependencyProperty.Register("IsAutoScaleOn", typeof(bool), typeof(Chart), new PropertyMetadata(true));


        public List<Polyline> DataSets
        {
            get { return (List<Polyline>)GetValue(DatasetsProperty); }
            set { SetValue(DatasetsProperty, value); }
        }
        public double XMin
        {
            get { return (double)GetValue(XMinProperty); }
            set { SetValue(XMinProperty, value); }
        }
        public double YMin
        {
            get { return (double)GetValue(YMinProperty); }
            set { SetValue(YMinProperty, value); }
        }
        public double XMax
        {
            get { return (double)GetValue(XMaxProperty); }
            set { SetValue(XMaxProperty, value); }
        }
        public double YMax
        {
            get { return (double)GetValue(YMaxProperty); }
            set { SetValue(YMaxProperty, value); }
        }

        public bool IsAutoScaleOn
        {
            get { return (bool)GetValue(IsAutoScaleOnProperty); }
            set { SetValue(IsAutoScaleOnProperty, value); }
        }

        public Chart()
        {
            InitializeComponent();
        }

        private static void GetBounds(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Chart chart = (Chart)d;
            if (!chart.IsAutoScaleOn) return;

            double xmin;
            double ymin;
            double xmax;
            double ymax;

            foreach (var data in chart.DataSets)
            {
                IEnumerable<double> XArray = data.Points.Select((x) => x.X);
                IEnumerable<double> YArray = data.Points.Select((x) => x.Y);
                xmin = XArray.Min();
                ymin = YArray.Min();
                xmax = XArray.Max();
                ymax = YArray.Max();

                if (xmin < chart.XMin) chart.XMin = xmin;
                if (ymin < chart.YMin) chart.YMin = ymin;
                if (xmax > chart.XMax) chart.XMax = xmax;
                if (ymax > chart.YMax) chart.YMax = ymax;
            }




        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            Random rnd = new Random();

            for (int n = 0; n < 1; n++)
            {
                Polyline p = new Polyline();

                p.Stroke = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)));
                p.StrokeThickness = 1;
                for (int i = 0; i < 500; i++)
                    p.Points.Add(new Point(i, rnd.Next(-25, 25)));

                DataSets.Add(p);
            }
        }
    }
}
