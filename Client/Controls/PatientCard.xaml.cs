

namespace Client.Controls
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Helpers;
    using Pages;
    using Models;
    using ViewModels;


    public sealed partial class PatientCard : UserControl
    {
        public PatientCard()
        {
            this.InitializeComponent();
        }

        private void ShowExaminesListButton_Click(object sender, RoutedEventArgs e)
        {
            var p = DataContext as Patient;

            if (p == null)
            {
                return;
            }

            var frame = Window.Current.Content as Frame;
            frame?.Navigate(typeof(ExaminesListPage), new ExamineViewModel(p));
        }

        private async void AddExamineButton_Click(object sender, RoutedEventArgs e)
        {
            var importer = new FibxImporter(DataContext as Patient);

            await importer.OpenFile();
        }
    }
}
