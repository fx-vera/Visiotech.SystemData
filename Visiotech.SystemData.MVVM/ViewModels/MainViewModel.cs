using System.Windows.Controls;
using Visiotech.SystemData.MVVM.Interfaces;

namespace Visiotech.SystemData.MVVM.ViewModels
{
    /// <summary>
    /// ViewModel binded to the MainWindow
    /// </summary>
    public class MainViewModel : IMainViewModel
    {
        public MainViewModel() { }
        public MainViewModel(IDisplayViewModel baseViewModel, UserControl userControl)
        {
            this.DisplayViewModel = baseViewModel;
            this.DisplayView = userControl;
            this.DisplayView.DataContext = this.DisplayViewModel;
        }
        /// <summary>
        /// Title of the app
        /// </summary>
        public string Title { get; } = "Display System Data App";
        /// <summary>
        /// Unique Id
        /// </summary>
        public string Id { get; } = "{CC009F58-CFF5-4D21-962E-BDD2406087A4}"; // from Guid tool (VS2022)
        /// <summary>
        /// ViewModel to manage the data displayed in the view
        /// </summary>
        public IDisplayViewModel DisplayViewModel { get; }
        /// <summary>
        /// View that binds the ViewModel and Model data
        /// </summary>
        public UserControl DisplayView { get; }
    }
}
