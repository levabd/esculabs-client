using System.Windows.Controls;

namespace Fibrosis
{
    using EsculabsCommon;
    using System.Windows;
    using Views;

    /// <summary>
    /// Interaction logic for Widget.xaml
    /// </summary>
    public partial class FibrosisWidget : UserControl
    {
        private IPatient _patient;

        public IPatient Patient
        {
            get
            {
                return _patient;
            }
            set
            {
                _patient = value;
            }
        }

        public FibrosisWidget()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddExamine();
            window.Show();
        }
    }


}
