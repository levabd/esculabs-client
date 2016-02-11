namespace Client.Controls
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Helpers;
    using Pages;
    using ViewModels;

    public sealed partial class PatientCard : UserControl
    {
        public PatientCard()
        {
            this.InitializeComponent();
        }

        private void ShowExaminesListButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as PatientViewModel;

            if (vm == null)
            {
                return;
            }

            var frame = Window.Current.Content as Frame;
            frame?.Navigate(typeof(ExaminesListPage), vm);
        }

        private async void AddExamineButton_Click(object sender, RoutedEventArgs e)
        {
            var importer = new FibxImporter(DataContext as PatientViewModel);

            await importer.OpenFile();
        }
    }
}
