using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Client.Pages
{
    using Repositories;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();

            SetUpPageAnimation();
        }

        protected void SetUpPageAnimation()
        {
            var collection = new TransitionCollection();
            var theme = new NavigationThemeTransition();
            var info = new EntranceNavigationTransitionInfo();

            theme.DefaultNavigationTransitionInfo = info;

            collection.Add(theme);
            Transitions = collection;
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var user = UsersRepository.Instance.TryLogin(LoginTextBox.Text, PasswordBox.Password);

            if (user == null)
            {
                var d = new MessageDialog("Не удалось найти пользователя с указанным логином/паролем!", "Ошибка входа");
                d.Commands.Add(new UICommand("ОК"));

                await d.ShowAsync();

                return;
            }

            Frame.Navigate(typeof(PatientsListPage));
        }

        private void PasswordBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                LoginButton_Click(null, null);
            }
        }

        private async void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var d = new MessageDialog("Вы действительно хотите выйти из приложения и выключить устройство?", "Подтверждение выхода");
            d.Commands.Add(new UICommand { Label = "Отмена", Id = 0 });
            d.Commands.Add(new UICommand { Label = "Да", Id = 1 });

            var r = await d.ShowAsync();

            if ((int)r.Id == 1)
            {
                Application.Current.Exit();
            }
        }
    }
}
