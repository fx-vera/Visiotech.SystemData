using System;
using System.Windows;
using System.Windows.Controls;
using Visiotech.SystemData.MVVM.Interfaces;
using Visiotech.SystemData.MVVM.ViewModels;
using Visiotech.SystemData.MVVM.Views;

namespace Visiotech.SystemData.MVVM.Settings
{
    public class AppBase : Application
    {
        protected sealed override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

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
