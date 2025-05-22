using System.ComponentModel;
using Visiotech.SystemData.MVVM.Interfaces;

namespace Visiotech.SystemData.MVVM.ViewModels
{
    /// <summary>
    /// Abstract class to implement the ViewModels
    /// </summary>
    public abstract class BaseViewModel : IBaseViewModel
    {
        /// <summary>
        /// Name of the ViewModel
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// Unique Id
        /// </summary>
        public abstract string Id { get; }
        /// <summary>
        /// Should be implemented to allow the communication between View and Viewmode (updates)
        /// </summary>

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
