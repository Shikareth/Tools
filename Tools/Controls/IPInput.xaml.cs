using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
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
    /// Interaction logic for IPInput.xaml
    /// </summary>
    public partial class IPInput : UserControl, INotifyPropertyChanged
    {
        #region Value

        public static readonly DependencyProperty IP_Property = DependencyProperty.Register("IP", typeof(IPAddress), typeof(IPInput), new PropertyMetadata(IPAddress.Parse("0.0.0.0")));

        public IPAddress IP
        {
            get { return (IPAddress)GetValue(IP_Property); }
            set { SetValue(IP_Property, value); }
        }

        public byte A
        {
            get { return a; }
            set {
                byte[] ip = IP.GetAddressBytes();
                ip[0] = value;
                IP = new IPAddress(ip);
                a = value;
                OnPropertyChanged("A");
            }
        }
        private byte a = 0;

        public byte B
        {
            get { return b; }
            set {
                byte[] ip = IP.GetAddressBytes();
                ip[1] = value;
                IP = new IPAddress(ip);
                b = value;
                OnPropertyChanged("B");
            }
        }
        private byte b = 0;

        public byte C
        {
            get { return c; }
            set {
                byte[] ip = IP.GetAddressBytes();
                ip[2] = value;
                IP = new IPAddress(ip);
                c = value;
                OnPropertyChanged("C");
            }
        }
        private byte c = 0;

        public byte D
        {
            get { return d; }
            set {
                byte[] ip = IP.GetAddressBytes();
                ip[3] = value;
                IP = new IPAddress(ip);
                d = value;
                OnPropertyChanged("D");
            }
        }
        private byte d = 0;

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IPInput()
        {
            InitializeComponent();
        }

        private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender == null)
                return;
            if (sender.GetType() != typeof(TextBox))
                return;

            TextBox ctrl = (TextBox)sender;
            ctrl.SelectAll();
        }

        private void TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Find the TextBox
            DependencyObject parent = e.OriginalSource as UIElement;
            while (parent != null && !(parent is TextBox))
                parent = VisualTreeHelper.GetParent(parent);

            if (parent != null)
            {
                var textBox = (TextBox)parent;
                if (!textBox.IsKeyboardFocusWithin)
                {
                    // If the text box is not yet focussed, give it the focus and
                    // stop further processing of this click event.
                    textBox.Focus();
                    e.Handled = true;
                }
            }
        }

        private void TextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (!(sender is TextBox ctrl))
                return;

            if ((ctrl.IsFocused || ctrl.IsKeyboardFocused) && e.Key == Key.Enter)
                ctrl.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }
    }
}
