﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Client.Models;
using Client.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Client.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class WhiskerPlotPage : INotifyPropertyChanged
    {
        private string _whiskerPlotImage;

        public string WhiskerPlotImage
        {
            get { return _whiskerPlotImage; }
            set
            {
                if (_whiskerPlotImage == value)
                {
                    return;
                }

                _whiskerPlotImage = value;
                OnPropertyChanged();
            }
        }


        public WhiskerPlotPage()
        {
            this.InitializeComponent();

            DataContext = this;

            SetUpPageAnimation();

            PageHeader.PageName = "Просмотр дисперсии";
        }

        protected void SetUpPageAnimation()
        {
            var collection = new TransitionCollection();
            var theme = new NavigationThemeTransition();
            var info = new DrillInNavigationTransitionInfo();

            theme.DefaultNavigationTransitionInfo = info;
            collection.Add(theme);
            Transitions = collection;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            WhiskerPlotImage = e.Parameter as string;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
