using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Activation;
using Windows.UI.Core;
using Client.Context;
using Client.Helpers;
using Client.Models;
using Microsoft.Data.Entity;

namespace Client.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExtendedSplash : Page
    {
        // Variable to hold the splash screen object.
        private readonly Windows.ApplicationModel.Activation.SplashScreen _splash;             

        internal Frame          RootFrame;
        internal CoreDispatcher UiThreadDispatcher;

        public ExtendedSplash(Windows.ApplicationModel.Activation.SplashScreen splashScreen, bool loadState, Frame rootFrame)
        {
            InitializeComponent();

            // Listen for window resize events to reposition the extended splash screen image accordingly.
            // This ensures that the extended splash screen formats properly in response to window resizing.
            Window.Current.SizeChanged += SplashScreen_OnResize;
          
            _splash = splashScreen;
            if (_splash != null)
            {
                // Register an event handler to be executed when the splash screen has been dismissed.
                _splash.Dismissed += DismissedEventHandler;

                // Retrieve the window coordinates of the splash screen image.
                UpdateImageRect(_splash.ImageLocation);

                // If applicable, include a method for positioning a progress control.
                UpdateProgressBarRect(_splash.ImageLocation);
            }

            RootFrame = rootFrame;

            UiThreadDispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
        }

        void UpdateImageRect(Rect rect)
        {
            SplashImage.SetValue(Canvas.LeftProperty, rect.X);
            SplashImage.SetValue(Canvas.TopProperty, rect.Y);
            SplashImage.Height = rect.Height;
            SplashImage.Width = rect.Width;
        }

        void UpdateProgressBarRect(Rect rect)
        {
            SplashProgressBar.Width = rect.Width;

            SplashProgressBar.SetValue(Canvas.LeftProperty, rect.X + rect.Width * 0.5 - SplashProgressBar.Width * 0.5);
            SplashProgressBar.SetValue(Canvas.TopProperty, rect.Y + rect.Height);
        }

        async void DismissedEventHandler(Windows.ApplicationModel.Activation.SplashScreen sender, object e)
        {
            MigrateDatabase();

            await UiThreadDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                BlurredBackgroundFadeStoryboard.Begin();

                ControlsFadeOutStoryboard.Completed += async (s, a) =>
                {
                    await UiThreadDispatcher.RunAsync(CoreDispatcherPriority.Normal, DismissSplash);
                };

                ControlsFadeOutStoryboard.Begin();
            });
        }

        void DismissSplash()
        {
            // Navigate to mainpage
            RootFrame.Navigate(typeof(LoginPage), _splash.ImageLocation);
        }

        void SplashScreen_OnResize(Object sender, WindowSizeChangedEventArgs e)
        {
            // Safely update the extended splash screen image coordinates. This function will be executed when a user resizes the window.
            if (_splash != null)
            {
                // Update the coordinates of the splash screen image.
                UpdateImageRect(_splash.ImageLocation);

                // If applicable, include a method for positioning a progress control.
                UpdateProgressBarRect(_splash.ImageLocation);
            }
        }

        private void MigrateDatabase()
        {
            using (var db = new EsculabsContext())
            {
                db.Database.Migrate();

                DatabaseSeeder.SeedPatients(db);
                DatabaseSeeder.SeedUsers(db);
            }
        }

        private void SplashBackground_OnImageOpened(object sender, RoutedEventArgs e)
        {
            BackgroundFadeStoryboard.Begin();
        }
    }
}
