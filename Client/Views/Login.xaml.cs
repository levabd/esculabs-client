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

namespace Client.Views
{
    using Repositories;
    using Helpers;
    using MahApps.Metro.Controls.Dialogs;
    using MahApps.Metro.Controls;

    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public event EventHandler<AuthorizationArgs> LoginEventHandler;

        public bool Authorized = false;

        public Login()
        {
            InitializeComponent();
        }

        private async void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            var a = PhysiciansRepository.Instance.Authorize(loginTextBox.Text, passwordTextBox.Password);

            if (LoginEventHandler != null)
            {
                AuthorizationArgs args = new AuthorizationArgs()
                {
                    Authorized = a,
                    Physician = a ? PhysiciansRepository.Instance.CurrentPhysician : null
                };
                
                LoginEventHandler(this, args);
            }

            //if (r == false)
            //{
            //    await MetroWindow.ShowMessageAsync("Не удалось выполнить вход", "Не удалось войти в систему с указанным логином/паролем");
            //}
        }
    }
}
