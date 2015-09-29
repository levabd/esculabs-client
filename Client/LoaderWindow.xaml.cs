using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for LoaderWindow.xaml
    /// </summary>
    public partial class LoaderWindow : Window
    {
        private int dotCount = 0;

        public LoaderWindow()
        {
            InitializeComponent();
        }

        private void timerCallback(object state)
        {
            dotCount++;

            if (dotCount > 3)
            {
                dotCount = 0;
            }

            var text = "Пожалуйста, подождите";
            for (int i = 0; i < dotCount; i++)
            {
                text += ".";
            }

            Dispatcher.Invoke(() => label.Content = text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var tmrShow = new Timer(timerCallback, null, 0, 1000);
        }
    }
}
