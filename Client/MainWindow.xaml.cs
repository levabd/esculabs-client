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
using System.Windows.Shapes;

namespace Client
{
    using MahApps.Metro.Controls;
    using MahApps.Metro.Controls.Dialogs;
    using Helpers;
    using Models;
    using Views;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly ViewManager _views;
        private Physician _currentPhysician;

        public MainWindow()
        {
            InitializeComponent();

            _views = new ViewManager { Container = ViewContainer};
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Height = SystemParameters.PrimaryScreenHeight;
            Width = SystemParameters.PrimaryScreenWidth;
            Left = 0;
            Top = 0;

            var loginView = _views.SetView("LoginView", x =>
            {
                ((LoginView) x).LoginEventHandler += HandleAuthorizationAttempt;
            });

            if (loginView == null)
            {
                MessageBox.Show("Can't load LoginView");
            }
        }

  
        private async void HandleAuthorizationAttempt(object sender, AuthArgs e)
        {
            if (e.Succeded)
            {
                _currentPhysician = e.Physician;

                _views.SetView("PatientsListView", x =>
                {
                    var view = (PatientsListView) x;

                    view.TileClickEventHandler += HandlePatientTileClick;
                    view.AddPatientButtonClick += HandleAddPatientButtonClick;
                });

            }
            else
            {
                await this.ShowMessageAsync("Не удалось выполнить вход", "Не удалось войти в систему с указанным логином/паролем");
            }
        }

        private void ShowAddPatientView()
        {
            var view = new AddPatient();

            // transitionContent.Content = view;
        }

        private void HandleAddPatientButtonClick(object sender, RoutedEventArgs e)
        {
            ShowAddPatientView();
        }

        private void HandlePatientTileClick(object sender, PatientTileClickArgs e)
        {
            //  modulesListView.Initialize(this, _currentPhysician, e.Patient);
            // modulesListView.ShowWidgets();

            //  modulesListTabItem.IsSelected = true;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageDialogResult c;

            //switch (stepsTabControl.SelectedIndex)
            //{
            //    case (0):                    
            //        c = await this.ShowMessageAsync("Выключение устройства", "Вы действительно хотите выйти из приложения и выключить устройство?", MessageDialogStyle.AffirmativeAndNegative, new MessageDialogConfiguration().CommonSettings);

            //        if (c == MessageDialogResult.Affirmative)
            //        {
            //            Close();
            //        }

            //        break;
            //    case (1):
            //        c = await this.ShowMessageAsync("Выход из учётной записи", "Вы не сможете работать с устройством, пока заново не введёте свой логин и пароль. Вы действительно хотите выйти из своей учётной записи?", MessageDialogStyle.AffirmativeAndNegative, new MessageDialogConfiguration().CommonSettings);

            //        if (c == MessageDialogResult.Affirmative)
            //        {
            //            ToggleAuthorizedTabs(false);
            //            _currentPhysician = null;
            //            stepsTabControl.SelectedIndex = 0;
            //        }

            //        break;
            //    default:
            //        break;
            //}
        }
    }

    public class TemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //получаем вызывающий контейнер
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is int)
            {
                int currentItem = 0;

                int.TryParse(item.ToString(), out currentItem);

                switch (currentItem)
                {
                    case 0:
                        return element.FindResource("CloseButtonIcon") as DataTemplate;
                    case 1:
                        return element.FindResource("LogoutButtonIcon") as DataTemplate;
                    default:
                        return element.FindResource("BackButtonIcon") as DataTemplate;
                }
            }

            return null;
        }
    }
}
