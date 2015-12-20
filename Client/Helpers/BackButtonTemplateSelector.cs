namespace Client.Helpers
{
    using System.Windows;
    using System.Windows.Controls;

    public class BackButtonTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;

            if (element == null || !(item is FrameworkElement))
            {
                return null;
            }

            switch (((FrameworkElement)item).GetType().Name)
            {
                case "LoginView":
                    return element.FindResource("CloseButtonIcon") as DataTemplate;
                case "PatientsListView":
                    return element.FindResource("LogoutButtonIcon") as DataTemplate;
                default:
                    return element.FindResource("BackButtonIcon") as DataTemplate;
            }
        }
    }
}
