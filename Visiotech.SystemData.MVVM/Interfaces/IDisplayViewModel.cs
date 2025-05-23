namespace Visiotech.SystemData.MVVM.Interfaces
{
    /// <summary>
    /// Interface for the Display viewmodel
    /// </summary>
    public interface IDisplayViewModel : IBaseViewModel
    {
        /// <summary>
        /// Save the data from UI to a Json file.
        /// </summary>
        void SaveData();
    }
}
