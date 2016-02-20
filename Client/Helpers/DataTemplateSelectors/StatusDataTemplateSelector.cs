namespace Client.Helpers.DataTemplateSelectors
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Models;

    /// <summary>
    /// DataTemplateSelector для статуса проверки системой и экспертом.
    /// Шаблоны находятся в App.xaml
    /// </summary>
    public class StatusDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item == null)
            {
                return null;
            }

            // Статус "корректно"
            if ((item is ExpertStatus && (ExpertStatus) item == ExpertStatus.Confirmed) || (item is bool && (bool) item))
            {
                return Application.Current.Resources["CorrectStatusDataTemplate"] as DataTemplate;
            }

            // Статус "некорректно"
            if ((item is ExpertStatus && (ExpertStatus) item == ExpertStatus.Unconfirmed) || (item is bool && !(bool) item))
            {
                return Application.Current.Resources["IncorrectStatusDataTemplate"] as DataTemplate;
            }

            // Статус "на рассмотрении" для статуса проверки экспертом
            if (item is ExpertStatus && (ExpertStatus) item == ExpertStatus.Pending)
            {
                return Application.Current.Resources["PendingStatusDataTemplate"] as DataTemplate;
            }

            return null;
        }
    }
}
