namespace Client.Views
{
    using System;
    using System.Windows;
    using EsculabsCommon;
    using EsculabsCommon.Repositories;
    using Helpers;

    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginView : BaseView
    {
        public event EventHandler<AuthArgs> LoginEventHandler;

        public LoginView()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            var p = PhysiciansRepository.Instance.Authorize(loginTextBox.Text, passwordTextBox.Password);

            if (LoginEventHandler == null)
            {
                return;
            }

            var args = new AuthArgs
            {
                Succeded = p != null,
                Physician = p
            };
                
            LoginEventHandler(this, args);
        }
    }
}
