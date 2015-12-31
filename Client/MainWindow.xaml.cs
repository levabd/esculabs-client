namespace Client
{
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using Repositories;
    using MahApps.Metro.Controls;
    using MahApps.Metro.Controls.Dialogs;
    using Helpers;
    using EsculabsCommon.Models;
    using Views;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ViewManager _views;
        private Physician _physician;
        
        public Physician Physician
        {
            get { return _physician; }
            set
            {
                _physician = value;
                OnPropertyChanged();
            }
        }

        public ViewManager ViewManager => _views;

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
            //_views.ViewChangeEventHandler += HandleViewChange;

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

                _views.SetView(typeof(PatientsListView).FullName, x =>
                {
                    // Быдлокод. Обработчик события может быть подписан только один раз

                    ((PatientsListView)x).TileClickEventHandler -= HandlePatientTileClick;
                    ((PatientsListView)x).AddPatientButtonClickHandler -= HandleAddPatientButtonClick;

                    ((PatientsListView)x).TileClickEventHandler += HandlePatientTileClick;
                    ((PatientsListView)x).AddPatientButtonClickHandler += HandleAddPatientButtonClick;
                });

            }
            else
            {
                await this.ShowMessageAsync("Не удалось выполнить вход", "Не удалось войти в систему с указанным логином/паролем");
            }
        }

        /// <summary>
        /// Обработчик события щелчка на кнопку добавления пациента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleAddPatientButtonClick(object sender, RoutedEventArgs e)
        {
            _views.SetView(typeof(AddPatientView).FullName, x => ((AddPatientView) x).BackButtonFunc = () =>
            {
                // TODO: SetView: добавить вьюху-инициатор смены
                var btn = sender as Button;
                var grid = btn?.Parent as Grid;
                var view = grid?.Parent as PatientsListView;

                view?.ReloadPatientsGrid();

                _views.SetPrevious();
            });
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
            view.Physician = Physician;

            view.ReloadWidgets();
        }

        /// <summary>
        /// Обработчик щелчка навигационной кнопки "Назад"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentView = ViewManager.CurrentView;

            if (currentView is LoginView)
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
                else
                {
                    return;
                }
            }
            else if (currentView is PatientsListView)
            {
                var c =
                    await
                        this.ShowMessageAsync("Выход из учётной записи",
                            "Вы не сможете работать с устройством, пока заново не введёте свой логин и пароль. Вы действительно хотите выйти из своей учётной записи?",
                            MessageDialogStyle.AffirmativeAndNegative, new MessageDialogConfiguration().CommonSettings);

                if (c == MessageDialogResult.Affirmative)
                {
                    Physician = null;
                }
                else
                {
                    return;
                }
            }

            _views.SetPrevious();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}