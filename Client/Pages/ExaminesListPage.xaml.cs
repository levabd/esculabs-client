﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Client.Controls;
using Client.Models;
using Client.ViewModels;
using FibrosisModule.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Client.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class ExaminesListPage : Page, INotifyPropertyChanged
    {
        private ExamineViewModel _viewModel;

        public ExamineViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                if (_viewModel == value)
                {
                    return;
                }

                _viewModel = value;
                OnPropertyChanged();
            }
        }

        public ExaminesListPage()
        {
            InitializeComponent();

            DataContext = this;

            SetUpPageAnimation();

            PageHeader.PageName = "Список обследований пациента";
        }

        protected void SetUpPageAnimation()
        {
            var collection = new TransitionCollection();
            var theme = new NavigationThemeTransition();
            var info = new ContinuumNavigationTransitionInfo();

            theme.DefaultNavigationTransitionInfo = info;
            collection.Add(theme);
            Transitions = collection;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = e.Parameter as ExamineViewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ExaminesList_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var examine = e.ClickedItem as FibrosisExamine;

            if (examine == null)
            {
                return;
            }

            ViewModel.SelectedExamine = examine;

            var frame = Window.Current.Content as Frame;
            frame?.Navigate(typeof(ExaminePage), ViewModel);
        }
    }
}
