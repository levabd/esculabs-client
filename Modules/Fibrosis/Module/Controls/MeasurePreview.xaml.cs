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

<<<<<<< HEAD:Modules/Fibrosis/Module/Controls/MeasurePreview.xaml.cs
<<<<<<< HEAD:Client/MeasurePreview.xaml.cs
namespace Client
{
    using Model;
=======
namespace Fibrosis.Controls
{
    using Models;
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Modules/Fibrosis/Module/Controls/MeasurePreview.xaml.cs
=======
namespace Fibrosis.Controls
{
    using Models;
>>>>>>> 9091c88eeff4630df1b243824f7d74e284b9a9ab:Modules/Fibrosis/Module/Controls/MeasurePreview.xaml.cs

    /// <summary>
    /// Interaction logic for MeasurePreview.xaml
    /// </summary>
    public partial class MeasurePreview : UserControl
    {
        public Measure measure;

        public MeasurePreview()
        {
            InitializeComponent();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            // TODO: to-do-do-doo
            Focusable = true;

            status.Content = "Wat";
            image.Source = LoadImage("images/elasto.jpg");
        }

        private BitmapImage LoadImage(string fileName)
        {
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(fileName, UriKind.Relative);
            src.EndInit();

            return src;
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {          
            BorderBrush = new SolidColorBrush(Colors.Orange);
            Cursor = Cursors.Hand;
            //CaptureMouse();
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            BorderBrush = new SolidColorBrush(Colors.Gray);
            Cursor = Cursors.Arrow;
            //ReleaseMouseCapture();
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            BorderBrush = new SolidColorBrush(Colors.LightGray);
        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            BorderBrush = new SolidColorBrush(Colors.Gray);
        }
    }
}
