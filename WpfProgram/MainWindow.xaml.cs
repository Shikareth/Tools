using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tools.Extensions;

namespace WpfProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Timer t = new Timer(500);
        Random r = new Random();

        private SolidColorBrush backgroundColor = Brushes.Transparent;
        public SolidColorBrush BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; OnPropertyChanged("BackgroundColor"); }
        }

        private SolidColorBrush fontColor = Brushes.Transparent;
        public SolidColorBrush FontColor
        {
            get { return fontColor; }
            set { fontColor = value; OnPropertyChanged("FontColor"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            t.Elapsed += T_Elapsed;
            t.Start();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher?.Invoke(() =>
            {
                BackgroundColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(0, 255), (byte)r.Next(0, 255), (byte)r.Next(0, 255)));
                FontColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(0, 255), (byte)r.Next(0, 255), (byte)r.Next(0, 255)));
            });
        }
    }
}
