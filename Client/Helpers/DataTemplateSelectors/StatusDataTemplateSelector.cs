using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Client.Models;

namespace Client.Helpers.DataTemplateSelectors
{
    public class StatusDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item == null)
            {
                return null;
            }

            if (item is ExpertStatus)
            {
                switch ((ExpertStatus)item)
                {
                    case ExpertStatus.Confirmed:
                        return Application.Current.Resources["CorrectStatusDataTemplate"] as DataTemplate;
                    case ExpertStatus.Unconfirmed:
                        return Application.Current.Resources["IncorrectStatusDataTemplate"] as DataTemplate;
                    case ExpertStatus.Pending:
                        return Application.Current.Resources["PendingStatusDataTemplate"] as DataTemplate;
                }

            }

            if (item is bool)
            {
                return (bool)item
                    ? Application.Current.Resources["CorrectStatusDataTemplate"] as DataTemplate
                    : Application.Current.Resources["IncorrectStatusDataTemplate"] as DataTemplate;
            }

            return null;
        }
    }
}
