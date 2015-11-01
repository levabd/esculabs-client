using System.Windows.Controls;

namespace Fibrosis
{
    using ModuleFramework;
    using System.Windows;
    using Views;

    /// <summary>
    /// Interaction logic for Widget.xaml
    /// </summary>
    public partial class FibrosisWidget : UserControl
    {
        private Window _parent;
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

        public FibrosisWidget(Window parent)
        {
            InitializeComponent();
            _parent = parent;        
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddExamine();
            window.Owner = _parent;

            window.Show();
        }
    }


}
