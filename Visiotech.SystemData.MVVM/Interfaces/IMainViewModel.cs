namespace Visiotech.SystemData.MVVM.Interfaces
{
    /// <summary>
    /// Interface for the main view model (the main Window)
    /// </summary>
    public interface IMainViewModel
    {
        /// <summary>
        /// Title of the app.
        /// </summary>
        string Title { get; }
        /// <summary>
        /// Unique Id
        /// </summary>
        string Id { get; }
        /// <summary>
        /// Attached view model with the display info
        /// </summary>
        IBaseViewModel DisplayerViewModel { get; }
        /// <summary>
        /// Attached view to display the info.
        /// </summary>
        System.Windows.Controls.UserControl DisplayerView { get; }
    }
}
