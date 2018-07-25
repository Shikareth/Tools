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
    /// Interaction logic for FilteredTextBox.xaml
    /// </summary>
    public partial class FilteredTextBox : UserControl
    {
        public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(FilteredTextBox), new PropertyMetadata("", ValidateInput));
        public static DependencyProperty RegxProperty = DependencyProperty.Register("Regx", typeof(string), typeof(FilteredTextBox), new PropertyMetadata(@".*"));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public string Regx
        {
            get { return (string)GetValue(RegxProperty); }
            set { SetValue(RegxProperty, value); }
        }


        public FilteredTextBox()
        {
            InitializeComponent();
        }

        private static void ValidateInput(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {


            if (!(sender is TextBox ctrl)) return;



        }
    }

}
