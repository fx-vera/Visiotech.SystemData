using System.Windows.Controls;
using Visiotech.SystemData.MVVM.Interfaces;

namespace Visiotech.SystemData.MVVM.ViewModels
{
    public class MainViewModel : IMainViewModel
    {
        public MainViewModel() { }
        public MainViewModel(IBaseViewModel baseViewModel, UserControl userControl)
        {
            this.DisplayerViewModel = baseViewModel;
            this.DisplayerView = userControl;
            this.DisplayerView.DataContext = baseViewModel;
        }

        public string Title { get; } = "Display System Data App";
        public string Id { get; } = "{CC009F58-CFF5-4D21-962E-BDD2406087A4}"; // from Guid tool (VS2022)
        public IBaseViewModel DisplayerViewModel { get; }
        public UserControl DisplayerView { get; }
    }
}
