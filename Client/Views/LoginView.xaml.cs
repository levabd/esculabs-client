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
    public partial class LoginView : UserControl
    {
        public event EventHandler<AuthArgs> LoginEventHandler;

        public LoginView()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            var p = PhysiciansRepository.Instance.Authorize(loginTextBox.Text, passwordTextBox.Password);

            if (LoginEventHandler != null)
            {
                AuthArgs args = new AuthArgs()
                {
                    Succeded = p != null,
                    Physician = p
                };
                
                LoginEventHandler(this, args);
            }
        }
    }
}
