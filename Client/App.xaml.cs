using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Client
{
    using System.Data.Entity;
    using System.Runtime.InteropServices;
    using Context;
    using Repositories;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region winapi
        protected const int SW_HIDE = 0;
        protected const int SW_SHOW = 1;
        protected const int WH_KEYBOARD = 2;

        private int _hTrayWnd = 0;
        private IntPtr _hInstance;
        private int _hKeyboardHook = 0;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        protected static extern int FindWindow(string lpszClassName, string lpszWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        protected static extern int ShowWindow(int hWnd, int nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        protected static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        protected static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        protected delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        #endregion

        protected override void OnStartup(StartupEventArgs e)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PgSqlContext, Migrations.Configuration>("PgSqlConnectionString"));

            _hTrayWnd = FindWindow("Shell_TrayWnd", "");

            //_hInstance = LoadLibrary("User32"); <<< 
            //_hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD, KeyboardHook, _hInstance, 0);

            ToggleWindowsShit(false);

            CultureInfo CultureInfo = new CultureInfo("ru-RU");

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo;

            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(
                    CultureInfo.IetfLanguageTag)));
            base.OnStartup(e);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            ToggleWindowsShit();
        }

        private int KeyboardHook(int nCode, IntPtr wParam, IntPtr lParam)
        {
            //if ((lParam & 0x40000000) && (HC_ACTION == nCode))
            //{
            //    if ((wParam == VK_SPACE) || (wParam == VK_RETURN) || (wParam >= 0x2f) && (wParam <= 0x100))
            //    {

            //    }
            //}

            return CallNextHookEx(_hKeyboardHook, nCode, wParam, lParam);
        }

        private void ToggleWindowsShit(bool enabled = true)
        {
            if (!enabled)
            {
                ShowWindow(_hTrayWnd, SW_HIDE);
            }
            else
            {
                ShowWindow(_hTrayWnd, SW_SHOW);
            }
        }
    }
}
