using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Client.Controls
{
    public partial class PageHeader : UserControl, INotifyPropertyChanged
    {
        private string _pageName;

        public string PageName
        {
            get { return _pageName; }
            set
            {
                if (_pageName == value)
                {
                    return;
                }

                _pageName = value;
                OnPropertyChanged();
            }
        }

        public PageHeader()
        {
            this.InitializeComponent();

            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var frame = Window.Current.Content as Frame;

            if (frame != null && frame.CanGoBack)
            {
                frame.GoBack();
            }
        }
    }
}
