using System;
using System.Windows;
using System.Windows.Controls;
using Visiotech.SystemData.MVVM.Interfaces;
using Visiotech.SystemData.MVVM.ViewModels;
using Visiotech.SystemData.MVVM.Views;

namespace Visiotech.SystemData.MVVM.Settings
{
    /// <summary>
    /// Custom AppBase to allow include custom data for the MainWindow. 
    /// </summary>
    public class AppBase : Application
    {
        //
        // Summary:
        //     Generates the event System.Windows.Application.Startup.
        //
        // Parameters:
        //   e:
        //     Objet System.Windows.StartupEventArgs that contains the event data.
        protected sealed override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ShutdownMode = ShutdownMode.OnMainWindowClose;

            MainWindow = CreateMainWindow();
            if (MainWindow == null)
            {
                MessageBox.Show("Error", "Error loading the app!");
            }
            else
            {
                MainWindow.Show();
            }
        }

        /// <summary>
        /// Create the mainWindow and attach the DisplayView and ViewModel
        /// </summary>
        /// <returns></returns>
        private Window CreateMainWindow()
        {
            MainView mainView = new MainView();

            try
            {
                IBaseViewModel displayViewModel = new DisplayViewModel();
                UserControl displayView = new DisplayView();
                IMainViewModel mainViewModel = new MainViewModel(displayViewModel, displayView);

                mainView = new MainView(mainViewModel);
                mainView.Dispatcher.BeginInvoke(new Action(() =>
                mainView.SetCurrentValue(Window.TopmostProperty, false)), System.Windows.Threading.DispatcherPriority.ApplicationIdle, null);
            }
            catch (Exception ex)
            {
                // should log the exception
                mainView = null;
            }
            return mainView;
        }
    }
}
