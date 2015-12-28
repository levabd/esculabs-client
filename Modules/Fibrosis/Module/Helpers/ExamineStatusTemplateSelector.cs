namespace Fibrosis.Helpers
{
    using System.Windows;
    using System.Windows.Controls;
    using EsculabsCommon;
    using Fibrosis.Models;

    public class ExamineStatusTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //получаем вызывающий контейнер
            var element = container as ContentPresenter;

            if (element == null || item == null)
            {
                return null;
            }

            if (item is ExpertStatus)
            {
                switch ((ExpertStatus)item)
                {
                    case ExpertStatus.Confirmed:
                        return element.FindResource("ConfirmedStatusIcon") as DataTemplate;
                    case ExpertStatus.Unconfirmed:
                        return element.FindResource("UnconfirmedStatusIcon") as DataTemplate;
                    default:
                        return element.FindResource("PendingStatusIcon") as DataTemplate;
                }
            }

            if (item is bool)
            {
                return (bool)item
                    ? element.FindResource("ConfirmedStatusIcon") as DataTemplate
                    : element.FindResource("UnconfirmedStatusIcon") as DataTemplate;
            }

            return element.FindResource("PendingStatusIcon") as DataTemplate;
        }
    }
}
