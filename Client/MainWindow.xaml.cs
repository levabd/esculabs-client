using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Client.Repositories;

namespace Client
{
    using EsculabsCommon;
    using MahApps.Metro.Controls;
    using MahApps.Metro.Controls.Dialogs;
    using Helpers;
    using Models;
    using Views;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ViewManager _views;
        private Physician _physician;
        private Role _physicianRole;
        
        public Physician Physician
        {
            get { return _physician; }
            set
            {
                _physician = value;
                OnPropertyChanged();
            }
        }

        public Role PhysicianRole
        {
            get { return _physicianRole; }
            set
            {
                _physicianRole = value;
                OnPropertyChanged();
            }
        }


        public MainWindow()
        {
            InitializeComponent();

            _views = new ViewManager();

            if (_views == null)
            {
                MessageBox.Show("Can't create ViewManager. Really?");
                return;
            }

            _views.Container = ViewContainer;
            _views.ViewChangeEventHandler += HandleViewChange;

            ModulesRepository.Instance.SubscribeViewManager(_views);

            DataContext = this;
        }
        
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Height = SystemParameters.PrimaryScreenHeight;
            Width = SystemParameters.PrimaryScreenWidth;
            Left = 0;
            Top = 0;

            var loginView = _views.SetView(typeof (LoginView).FullName, x =>
            {
                // Быдлокод. Обработчик события может быть подписан только один раз

                ((LoginView)x).LoginEventHandler -= HandleAuthorizationAttempt;
                ((LoginView) x).LoginEventHandler += HandleAuthorizationAttempt;
            });

            if (loginView == null)
            {
                MessageBox.Show("Can't load LoginView");
            }
        }
        
        /// <summary>
        /// Обработчик события попытки авторизации
        /// </summary>
        /// <param name="sender">LoginView</param>
        /// <param name="e">Результат авторизации и авторизированный целитель</param>
        private async void HandleAuthorizationAttempt(object sender, AuthArgs e)
        {
            if (e.Succeded)
            {
                Physician = e.Physician;

                // Получаем самую высокую роль целителя
                PhysicianRole = Physician.Roles.OrderBy(x => x.Id).FirstOrDefault();

                _views.SetView(typeof(PatientsListView).FullName, x =>
                {
                    // Быдлокод. Обработчик события может быть подписан только один раз

                    ((PatientsListView)x).TileClickEventHandler -= HandlePatientTileClick;
                    ((PatientsListView)x).AddPatientButtonClickHandler -= HandleAddPatientButtonClick;

                    ((PatientsListView) x).TileClickEventHandler += HandlePatientTileClick;
                    ((PatientsListView) x).AddPatientButtonClickHandler += HandleAddPatientButtonClick;
                });

            }
            else
            {
                await this.ShowMessageAsync("Не удалось выполнить вход", "Не удалось войти в систему с указанным логином/паролем");
            }
        }

        /// <summary>
        /// Обработчик события смены вьюх. Стреляется из ViewManager
        /// </summary>
        /// <param name="sender">ViewManager</param>
        /// <param name="e">Вьюха, на которую нас переключил ViewManager</param>
        private void HandleViewChange(object sender, ViewChangeArgs e)
        {
            if (e?.View == null)
            {
                return;
            }

            if (e.View is LoginView)
            {
                BackButtonPresenter.Content = 0;
            }
            else if (e.View is PatientsListView)
            {
                BackButtonPresenter.Content = 1;
            }
            else
            {
                BackButtonPresenter.Content = 2;
            }
        }

        /// <summary>
        /// Обработчик события щелчка на кнопку добавления пациента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleAddPatientButtonClick(object sender, RoutedEventArgs e)
        {
            _views.SetView(typeof(AddPatientView).FullName, x => ((AddPatientView) x).BackButtonFunc = () => _views.SetPrevious());
        }

        /// <summary>
        /// Обработчик события щелчка на плитку списка пациентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandlePatientTileClick(object sender, PatientTileClickArgs e)
        {
            var view = (ModulesListView)_views.SetView(typeof (ModulesListView).FullName);

            if (view == null)
            {
                return;
            }

            view.Patient = e.Patient;
            view.ReloadWidgets();
        }

        /// <summary>
        /// Обработчик щелчка навигационной кнопки "Назад"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((int)BackButtonPresenter.Content == 0)
            {
                var c =
                    await
                        this.ShowMessageAsync("Выключение устройства",
                            "Вы действительно хотите выйти из приложения и выключить устройство?",
                            MessageDialogStyle.AffirmativeAndNegative, new MessageDialogConfiguration().CommonSettings);

                if (c == MessageDialogResult.Affirmative)
                {
                    Close();
                }
            }
            else if ((int)BackButtonPresenter.Content == 1)
            {
                var c =
                    await
                        this.ShowMessageAsync("Выход из учётной записи",
                            "Вы не сможете работать с устройством, пока заново не введёте свой логин и пароль. Вы действительно хотите выйти из своей учётной записи?",
                            MessageDialogStyle.AffirmativeAndNegative, new MessageDialogConfiguration().CommonSettings);

                if (c == MessageDialogResult.Affirmative)
                {
                    Physician = null;
                    PhysicianRole = null;
                }
            }

            _views.SetPrevious();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// Класс, позволяющий выбирать по индексу иконку кнопки "Назад"
    /// </summary>
    public class BackButtonTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //получаем вызывающий контейнер
            var element = container as FrameworkElement;

            if (element == null || item == null || !(item is int))
            {
                return null;
            }

            switch ((int)item)
            {
                case 0:
                    return element.FindResource("CloseButtonIcon") as DataTemplate;
                case 1:
                    return element.FindResource("LogoutButtonIcon") as DataTemplate;
                default:
                    return element.FindResource("BackButtonIcon") as DataTemplate;
            }
        }
    }
}